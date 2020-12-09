# Trees

![Small Conifer Image](https://www.transparentpng.com/thumb/christmas-tree/file-christmas-tree-clipart-png-12.png)

Our project for the Trees simulation

## `uint` tree usage

```text
╔══════════╦═══════╦═══════╦══════╦═════╗
║ Byte     ║   3   ║ 2     ║ 1    ║ 0   ║
╠══════════╬═══════╬═══════╬══════╬═════╣
║ Bits     ║ 24-31 ║ 16-23 ║ 8-15 ║ 0-7 ║
╠══════════╬═══════╩═══════╬══════╩═════╣
║ Function ║ Age           ║ Flags      ║
╚══════════╩═══════════════╩════════════╝
```

## `ushort` flags

```text
╔══════════╦════╦════╦════╦════╦════╦════╦═══╦═══╦═══╦═══╦═══╦═══════════╦══════╦════════╦═══╦═══╗
║ Bits     ║ 15 ║ 14 ║ 13 ║ 12 ║ 11 ║ 10 ║ 9 ║ 8 ║ 7 ║ 6 ║ 5 ║ 4         ║ 3    ║ 2      ║ 1 ║ 0 ║
╠══════════╬════╩════╩════╩════╩════╩════╩═══╩═══╩═══╩═══╩═══╬═══════════╬══════╬════════╬═══╩═══╣
║ Function ║                                                 ║ Protected ║ Dove ║ Damage ║ Type  ║
╚══════════╩═════════════════════════════════════════════════╩═══════════╩══════╩════════╩═══════╝
```
