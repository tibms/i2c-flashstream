#include "bqfs_cmd_type.h"
#include "string.h"
#include "bq27621G1_sample.gm.fs.h"


//for support multiple battery type
struct fg_batt_profile {
	const bqfs_cmd_t *bqfs_image;
	uint16_t array_size;
	uint8_t version;
};

struct fg_batt_profile bqfs_image_array[] = {
	{ bqfs_image, ARRAY_SIZE(bqfs_image), 1 },
};


//below functions should be implemented on customer platform

/*
 * read block data from device, return >=0 on success, <0 on fail
 */
int fg_write_block(uint8_t addr, uint8_t reg, uint8_t *buf, uint8_t len);

/*
 * write block data to device, return >=0 on success, <0 on fail
 */
int fg_read_block(uint8_t addr, uint8_t reg, uint8_t *buf, uint8_t len);

/*
 * delay in milli-seconds
 */
void mdelay(int ms);



#define PRINT(str, args...)  {}

/*split block write into several block operation with small size in case too many data in one command*/
static bool fg_update_bqfs_write_block(uint8_t addr, uint8_t reg, uint8_t* buf, uint8_t len)
{
#define I2C_BLK_SIZE	32
	int ret;
	uint8_t wr_len = 0;

	while (len > I2C_BLK_SIZE) {
		ret = fg_write_block(addr, reg + wr_len, buf + wr_len, I2C_BLK_SIZE);
		if (ret < 0)
			return false;
		wr_len += I2C_BLK_SIZE;
		len -= I2C_BLK_SIZE;
	};

	if (len) {
		ret = fg_write_block(addr, reg + wr_len, buf + wr_len, len);
		if (ret < 0)
			return false;
	}

	return true;
}

/*
 * Execute one i2c command in cmd list
 */ 
static bool fg_update_bqfs_execute_cmd(const bqfs_cmd_t *cmd)
{
	int ret;
	int i;
	uint8_t tmp_buf[10];

	switch (cmd->cmd_type) {
	case CMD_R:
		ret = fg_read_block(cmd->addr, cmd->reg, (uint8_t *)&cmd->data.bytes, cmd->data_len);
		if (ret < 0)
			return false;
		else
			return true;
		break;
	case CMD_W:
		return fg_update_bqfs_write_block(cmd->addr, cmd->reg,
					(uint8_t *)&cmd->data.bytes,
					cmd->data_len);
	case CMD_C:
		if (fg_read_block(cmd->addr, cmd->reg, tmp_buf, cmd->data_len) < 0)
			return false;
		if (memcmp(tmp_buf, cmd->data.bytes, cmd->data_len)) {
			PRINT("CMD_C failed at line %d\n", cmd->line_num);
			for (i = 0; i < cmd->data_len; i++)
				PRINT("Read: %02X, Cmp:%02X", tmp_buf[i], cmd->data.bytes[i]);

			return false;
		}

		return true;
	case CMD_X:
		mdelay(cmd->data.delay);
		return true;
	default:
		PRINT("Unsupported command at line %d\n", cmd->line_num);
		return false;
	}

}

void fg_update_bqfs()
{
	const bqfs_cmd_t *image;
	int i;

	//TODO: check ITPOR to decide if need to do update
	
	image = bqfs_image_array[0].bqfs_image;

	for (i = 0; i < bqfs_image_array[0].array_size; i++) {
		if (!fg_update_bqfs_execute_cmd(&image[i])) {
			PRINT("Failed at command: %d\n", i);
			return;
		}
		mdelay(5);
	}
	
}
