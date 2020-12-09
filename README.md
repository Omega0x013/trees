# Trees

![Small Conifer Image](https://www.transparentpng.com/thumb/christmas-tree/file-christmas-tree-clipart-png-12.png)

Our project for the Trees simulation

## Tree Class

So when I started writing the tree storage code I realised that it would be kinda hard to manually convert the raw `uint` into a tree every time you wanted to use it, so I made the `Tree` class to do it. You can do `uint` -> `Tree` and `Tree` -> `uint` very easily, and when you're processing each tree, pass a `ref Tree` object around, rather than a `ref uint` to speed up the program. Like this:

```c#
void example(ref uint[] trees) {
  Tree tree = trees[5]; // Get a tree
  tree.age++;
  tree.damage = true;
  trees[5] = tree; // Set the tree again
}
```

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
