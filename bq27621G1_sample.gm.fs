;--------------------------------------------------------
;Verify Existing Firmware Version
;--------------------------------------------------------
W: AA 00 01 00
C: AA 00 21 06
W: AA 00 02 00
C: AA 00 05 01
;--------------------------------------------------------
;SET_CFGUPDATE
;--------------------------------------------------------
W: AA 00 13 00
X: 1100
;--------------------------------------------------------
;Data Block
;--------------------------------------------------------
W: AA 3E 02 00
W: AA 40 02 26 00 00 32 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 A5
X: 10
W: AA 3E 02 00
C: AA 60 A5
W: AA 3E 24 00
W: AA 40 00 19 28 63 5F FF 62 00 32 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 69
X: 10
W: AA 3E 24 00
C: AA 60 69
W: AA 3E 30 00
W: AA 40 0E 74 FD FF 38 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 49
X: 10
W: AA 3E 30 00
C: AA 60 49
W: AA 3E 31 00
W: AA 40 0A 0F 02 05 32 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 AD
X: 10
W: AA 3E 31 00
C: AA 60 AD
W: AA 3E 40 00
W: AA 40 B4 D8 0C 01 00 C8 04 00 09 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 91
X: 10
W: AA 3E 40 00
C: AA 60 91
W: AA 3E 44 00
W: AA 40 14 00 03 08 98 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 48
X: 10
W: AA 3E 44 00
C: AA 60 48
W: AA 3E 50 00
W: AA 40 02 BC 01 2C 00 1E 00 C8 C8 14 08 00 3C 0E 10 00 0A 46 14 05 0F 03 20 00 64 46 50 0A 19 28 01 F4
W: AA 60 1B
X: 10
W: AA 3E 50 00
C: AA 60 1B
W: AA 3E 50 01
W: AA 40 00 00 00 00 00 00 00 00 43 80 04 01 14 00 0B 0B B8 01 2C 0A 01 0A 00 00 00 C8 00 64 02 5A 20 64
W: AA 60 07
X: 10
W: AA 3E 50 01
C: AA 60 07
W: AA 3E 50 02
W: AA 40 0F 02 00 05 04 B0 0F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 26
X: 10
W: AA 3E 50 02
C: AA 60 26
W: AA 3E 51 00
W: AA 40 00 A7 00 64 00 FA 00 3C 3C 01 B3 B3 01 90 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 8A
X: 10
W: AA 3E 51 00
C: AA 60 8A
W: AA 3E 52 00
W: AA 40 43 33 00 10 68 3C B4 09 79 0C E4 00 C8 00 32 00 14 03 E8 01 02 60 10 04 00 0A 10 5E FF CE FF CE
W: AA 60 2D
X: 10
W: AA 3E 52 00
C: AA 60 2D
W: AA 3E 52 01
W: AA 40 00 01 02 BC 12 02 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 2C
X: 10
W: AA 3E 52 01
C: AA 60 2C
W: AA 3E 53 00
W: AA 40 10 69 DD E0 E9 E9 EA E4 DC EA F3 F4 F3 F2 F1 EF EF EB EE F3 F6 F7 F8 F9 FC FD FE FE FD FD FA FA
W: AA 60 3B
X: 10
W: AA 3E 53 00
C: AA 60 3B
W: AA 3E 53 01
W: AA 40 F5 F5 F1 F0 F5 F8 F5 DC 90 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 E6
X: 10
W: AA 3E 53 01
C: AA 60 E6
W: AA 3E 54 00
W: AA 40 FE 78 04 01 00 F3 F7 02 1B 3D 0D E8 EB EC FD 00 0C 0B 06 00 EC F5 FE 00 00 F9 F5 FA F9 E1 E2 EC
W: AA 60 EB
X: 10
W: AA 3E 54 00
C: AA 60 EB
W: AA 3E 54 01
W: AA 40 F3 06 01 07 04 0F FD A0 B6 81 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 17
X: 10
W: AA 3E 54 01
C: AA 60 17
W: AA 3E 55 00
W: AA 40 00 08 00 08 00 08 00 08 00 08 00 09 00 09 00 09 00 0A 00 0A 00 0A 00 0A 00 0B 00 0B 00 14 00 00
W: AA 60 6A
X: 10
W: AA 3E 55 00
C: AA 60 6A
W: AA 3E 56 00
W: AA 40 FF C4 02 FA 04 FD 00 04 F8 04 FE 00 FE FC F9 25 B0 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 79
X: 10
W: AA 3E 56 00
C: AA 60 79
W: AA 3E 6C 00
W: AA 40 FE C3 00 FC F8 07 FA FB 01 F5 01 02 10 F6 F5 F5 56 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 0F
X: 10
W: AA 3E 6C 00
C: AA 60 0F
W: AA 3E 5C 00
W: AA 40 02 10 0C 0C 0E 0C 0D 0E 0E 0E 0E 0E 0F 10 16 87 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 AC
X: 10
W: AA 3E 5C 00
C: AA 60 AC
W: AA 3E 5D 00
W: AA 40 01 08 08 0E 21 3E 09 0A 0E 0D 11 19 1E 20 88 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 20
X: 10
W: AA 3E 5D 00
C: AA 60 20
W: AA 3E 5E 00
W: AA 40 01 8A 91 4E 3A 29 2B 31 21 22 21 1F 20 24 AC F9 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 6A
X: 10
W: AA 3E 5E 00
C: AA 60 6A
W: AA 3E 5F 00
W: AA 40 01 01 01 02 06 02 01 01 01 01 01 01 01 02 0C 18 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 C5
X: 10
W: AA 3E 5F 00
C: AA 60 C5
W: AA 3E 68 00
W: AA 40 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 FF
X: 10
W: AA 3E 68 00
C: AA 60 FF
W: AA 3E 6A 00
W: AA 40 CB D4 1A 05 49 E9 FF F5 1C 98 02 D3 FF B9 30 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 AA
X: 10
W: AA 3E 6A 00
C: AA 60 AA
W: AA 3E 6B 00
W: AA 40 EF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 10
X: 10
W: AA 3E 6B 00
C: AA 60 10
W: AA 3E 70 00
W: AA 40 80 00 80 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
W: AA 60 FF
X: 10
W: AA 3E 70 00
C: AA 60 FF
;--------------------------------------------------------
;Exit CFGUPDATE
;--------------------------------------------------------
W: AA 00 00 00
W: AA 00 42 00
X: 2000
