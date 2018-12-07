#include "bqfs_cmd_type.h"
#include "bq27621G1_sample.gm.fs.h"


//for support multiple battery type
struct fg_batt_profile {
	const unsigned char *bqfs_image;
	uint16_t array_size;
	uint8_t version;
};

struct fg_batt_profile bqfs_image_array[] = {
	{ bqfs_image, sizeof(bqfs_image), 1 },
		
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
	const unsigned char *p;
	bqfs_cmd_t cmd;
	int rec_cnt = 0;
	int len;
	int i;

	//TODO: check ITPOR to decide if need to do update
	p = bqfs_image_array[0].bqfs_image;
	
	while (p < bqfs_image_array[0].bqfs_image + bqfs_image_array[0].array_size) {
		cmd.cmd_type = *p++;
		if (cmd.cmd_type == CMD_X) {
			len = *p++;
			if (len != 2){
				return ;//illegal image data
			}
			cmd.data.delay = *p << 8 | *(p + 1); //delay field occupy 2 bytes
			p += 2;
		} else {
			cmd.addr = *p++;
			cmd.reg  = *p++;
			cmd.data_len = *p++;
			for (i = 0; i < cmd.data_len; i++)
				cmd.data.bytes[i] = *p++;
		}

		rec_cnt++;
		if (!fg_update_bqfs_execute_cmd(&cmd)) {
			PRINT("Failed at command: %d\n", i);
			return;
		}

		mdelay(5);
	}
	PRINT("Parameter update Successfully\n");
}

