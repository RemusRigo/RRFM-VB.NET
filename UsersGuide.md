# RRFM: User's Guide

> RRFM is **in progress**: you can browse folders and open files; file operations are not implemented yet.



## Downloads & Runtimes

Download the latest release from the [Releases page](https://github.com/RemusRigo/RRFM-VB.NET/releases).

|Build|Architecture|Required Runtime|
|-|-|-|
|`win-x64`|64-bit|none (self-contained single file)|
|`win-x86`|32-bit|none (self-contained single file)|

> On 64-bit Windows 10/11, use **x64**. Each build is a single `RRFM.exe` that already contains .NET 10,
> so there is nothing else to install.



## Install

RRFM is portable: there is no installer.

1. Copy `RRFM.exe` to a folder where you have write access, for example `D:\My Apps\RRFM\`.
2. Double-click `RRFM.exe`.

> If Windows blocks the file ("Windows protected your PC"), right-click `RRFM.exe` →
> **Properties** → check **Unblock** → **OK**, then try again.



## Usage

The window has two panels. On the first start, the left panel shows your user profile folder and the right panel your `%TEMP%` folder.

|Action|Description|
|-|-|
|Double-click a folder|Open it|
|Double-click `..`|Go to the parent folder|
|Double-click `.`|Refresh the current folder|
|Double-click a file|Open it with its default application|

When you close RRFM, it saves the window position and size, the splitter position and the folder of each panel
to `RRFM.json` next to `RRFM.exe`.



## Uninstall

Delete the folder you copied `RRFM.exe` to (this also deletes `RRFM.json`).
