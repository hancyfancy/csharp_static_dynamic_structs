# C Sharp implementation of list, set and bidirectional map
Simple one dimensional and two dimensional data structures.

# How to build for Linux?
## Prerequisites
1. Install Mono:
    - `sudo apt install gnupg ca-certificates`
    - `sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF`
    - `sudo apt update`
    - `sudo apt install mono-complete`
## Compile & Run locally:
1. Change file permissions:
    - `chmod +x *.sh`
2. Compile:
    - `./clean.sh`
    - `./build.sh`
3. Run locally(e.g, Ubuntu):
    - `./run.sh`

# Sample output
```
--------------------Items
10
20
-1
1
894.236
-7.5
c
False
Hello

--------------------Static store
[{Index 0: 0}, {Index 1: 255}, {Index 2: 1}, {Index 3: 8}]

[{Index 0: -32768}, {Index 1: 32767}, {Index 2: 2}, {Index 3: 16}]

[{Index 0: -2147483648}, {Index 1: 2147483647}, {Index 2: 4}, {Index 3: 32}]

[{Index 0: -9223372036854775808}, {Index 1: 9223372036854775807}, {Index 2: 8}, {Index 3: 64}]

[{Index 0: -3.402823E+38}, {Index 1: 3.402823E+38}, {Index 2: -Infinity}, {Index 3: Infinity}, {Index 4: 1.401298E-45}, {Index 5: NaN}]

[{Index 0: -1.79769313486232E+308}, {Index 1: 1.79769313486232E+308}, {Index 2: -Infinity}, {Index 3: Infinity}, {Index 4: 4.94065645841247E-324}, {Index 5: NaN}]

[{Index 0: }, {Index 1: ￿}]

[{Index 0: False}, {Index 1: True}]

[{Index 0: Fellow}, {Index 1: Mellow}, {Index 2: Yellow}, {Index 3: Bellow}]

[{Index 0: }, {Index 1: System.Object}]

--------------------Static store replace item
[{Index 0: }, {Index 1: }, {Index 2: }, {Index 3: }]

[{Index 0: 1}, {Index 1: 3}, {Index 2: 9}, {Index 3: 5}]

[{Index 0: 0}, {Index 1: 0}, {Index 2: 0}, {Index 3: 0}]

[{Index 0: 0}, {Index 1: 7}, {Index 2: 0}, {Index 3: 0}]

Index of 9 = -1
Item at index 3 = 0
--------------------Dynamic store
[{Index 0: 0}, {Index 1: 255}, {Index 2: 1}, {Index 3: 8}]

[{Index 0: -32768}, {Index 1: 32767}, {Index 2: 2}, {Index 3: 16}]

[{Index 0: -2147483648}, {Index 1: 2147483647}, {Index 2: 4}, {Index 3: 32}]

[{Index 0: -9223372036854775808}, {Index 1: 9223372036854775807}, {Index 2: 8}, {Index 3: 64}]

[{Index 0: -3.402823E+38}, {Index 1: 3.402823E+38}, {Index 2: -Infinity}, {Index 3: Infinity}, {Index 4: 1.401298E-45}, {Index 5: NaN}]

[{Index 0: -1.79769313486232E+308}, {Index 1: 1.79769313486232E+308}, {Index 2: -Infinity}, {Index 3: Infinity}, {Index 4: 4.94065645841247E-324}, {Index 5: NaN}]

[{Index 0: }, {Index 1: ￿}]

[{Index 0: False}, {Index 1: True}]

[{Index 0: Fellow}, {Index 1: Mellow}, {Index 2: Yellow}, {Index 3: Bellow}]

[{Index 0: }, {Index 1: System.Object}]

--------------------Dynamic sorted store
[{Index 0: 203}, {Index 1: 606}, {Index 2: 922}, {Index 3: 1662}]

[{Index 0: Bellow}, {Index 1: Fellow}, {Index 2: Mellow}, {Index 3: Yellow}]

--------------------Dynamic store replace item
[{Index 0: 1}, {Index 1: 3}, {Index 2: 9}, {Index 3: 5}]

[{Index 0: 1}, {Index 1: 3}, {Index 2: 7}, {Index 3: 5}]

--------------------Dynamic store insert item
[{Index 0: 1}, {Index 1: 3}, {Index 2: 9}, {Index 3: 5}]

[{Index 0: 1}, {Index 1: 3}, {Index 2: 7}, {Index 3: 9}, {Index 4: 5}]

[{Index 0: 8}, {Index 1: 1}, {Index 2: 3}, {Index 3: 7}, {Index 4: 9}, {Index 5: 5}]

[{Index 0: 8}, {Index 1: 1}, {Index 2: 3}, {Index 3: 7}, {Index 4: 9}, {Index 5: 5}, {Index 6: 4}]

Index of 9 = 4
Item at index 3 = 7

--------------------Dynamic unique item store
[{Index 0: 1}, {Index 1: 2}, {Index 2: 3}]

--------------------Dynamic key value store
Index 0: Key -> Yukon, Value -> 8
Index 1: Key -> Bicker, Value -> 9
Index 2: Key -> Shulz, Value -> 7
Index 3: Key -> Jems, Value -> 3

Index 0: Key -> 1, Value -> [{Index 0: }, {Index 1: }, {Index 2: }, {Index 3: }]

Index 1: Key -> 2, Value -> []

Index 2: Key -> 3, Value -> []


--------------------Dynamic sorted key value store
Index 0: Key -> 3, Value -> Jems
Index 1: Key -> 7, Value -> Shulz
Index 2: Key -> 88, Value -> Yukon
Index 3: Key -> 832, Value -> Bicker

7 -> Shulz
Bicker <- 832

Index 0: Key -> Bicker, Value -> 9
Index 1: Key -> Jems, Value -> 3
Index 2: Key -> Shulz, Value -> 7
Index 3: Key -> Yukon, Value -> 8

Yukon -> 8
3 <- Jems

```
