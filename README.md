# i2c-flashstream
i2c flashstream program sample code, MCU version

When you receive gmfs/bqfs/dffs file, you need use convbqfs.pl script to
convert it into a C header file. the usage of this perl script is:

perl convbqfs-mcu.pl --input input_gmfs_or_bqfs_or_dffs_file [--name array_name] [--output output_header_file_name]

if --name not specified, array name is bqfs_image, if --output not specified,
the output file name is same as input file name with .h appended

