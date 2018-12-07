
#ifndef __BQFS_CMD_TYPE__
#define __BQFS_CMD_TYPE__


#define CMD_MAX_DATA_SIZE	32
#define RETRY_LIMIT		3
#define CMD_RETRY_DELAY		100 /* in ms */


typedef unsigned char uint8_t;
typedef signed char int8_t;
typedef unsigned short uint16_t;
typedef signed short int16_t;


typedef enum {
	CMD_INVALID = 0,
	CMD_R,	/* Read */
	CMD_W,	/* Write */
	CMD_C,	/* Compare */
	CMD_X,	/* Delay */
} cmd_type_t;

/*
 * DO NOT change the order of fields - particularly reg
 * should be immediately followed by data
 */
typedef struct {
	cmd_type_t cmd_type;
	uint8_t addr;
	uint8_t reg;
	union {
		uint8_t bytes[CMD_MAX_DATA_SIZE + 1];
		uint16_t delay;
	} data;
	uint8_t  data_len;
	uint16_t line_num;
} bqfs_cmd_t;


#endif
