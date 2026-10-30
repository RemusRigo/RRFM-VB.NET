# RRFM

RRFM: Remus Rigo File Manager, a two-panel file manager for Windows



## Author

* [@remusrigo](https://github.com/RemusRigo)
* [@remusrigo](https://sourceforge.net/u/remusrigo/profile)



## Features

* Two panels (left and right), each showing a folder: name, extension, size
* Double-click a folder to open it, `..` to go to the parent folder, `.` to refresh
* Double-click a file to open it with its default application
* Remembers the window position and size, the splitter position and both folders (JSON file)
* Planned: copy, move, delete, rename



## User's Guide

See the [User's Guide](UsersGuide.md) for downloads, installation and usage.



## Statistics

![VB.NET](https://img.shields.io/badge/Language-VB.NET-blue)
![.NET8.0](https://img.shields.io/badge/Runtime-.NET%208.0-lightblue)
![.NET10.0](https://img.shields.io/badge/Runtime-.NET%2010.0-lightblue)
![VS](https://img.shields.io/badge/IDE-Visual%20Studio-purple)
![JSON](https://img.shields.io/badge/File-JSON-yellow)
<br>
![status](https://img.shields.io/badge/status-on%20hold-yellow)
![GitHub Downloads (all assets, all releases)](https://img.shields.io/github/downloads/RemusRigo/RRFM-VB.NET/total)



## Roadmap

* 2026-10-29: Fix: Logic in LoadPath: leftPath and rightPath didn't save the current path correctly
* 2026-10-29: Upd: Moved all data/procedures/functions to the FileManager class
* 2026-10-29: Add: Display total number of selected files & folders
* 2026-10-29: Add: [F7] key: Create folder
* 2026-10-29: Fix: At startup when loading left and right paths, they must be activated first
* 2026-10-29: Upd: Change from ActiveListView to ActivePanel
* 2026-10-29: Fix: when a panel is clicked mark it as active
* 2026-10-29: Upd: Moved some UI functions to a new module, so main form's code looks much readable/cleaner
* 2026-10-28: Add: UI: Selected panel has a border, the other has no border
* 2026-10-28: Add: [INS] key: Select files/folders
* 2026-10-28: Fix: Drive not showing: always use UpperCase
* 2026-10-28: Add: Populate drive ComboBox for Left/Right panels
* 2026-10-28: Add: Display current path for Left/Right panels
* 2026-05-06: Add: Settings load/save default window size/position
* 2026-05-06: Add: Save/Load settings in JSON file, so app can be portable
* 2026-05-05: Add: Double click on a file/fonder inside the ListView
* 2026-05-05: Add: Looad path for Left/Right panels
* 2026-05-05: Add: Design UI
* 2026-05-05: Project started

