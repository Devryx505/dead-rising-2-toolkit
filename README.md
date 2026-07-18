<div align="center">

# DRTB (Dead Rising Tool Box)

### Blender addon for importing and injecting character/prop meshes across Dead Rising 2, Off the Record, Case Zero, Case West, Dead Rising 3, and Dead Rising 4

![Version](https://img.shields.io/badge/version-4.0.0-blue?style=flat-square)
![Blender](https://img.shields.io/badge/blender-4.0%2B-orange?style=flat-square&logo=blender&logoColor=white)
![Status](https://img.shields.io/badge/status-WIP-yellow?style=flat-square)
![Platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux-informational?style=flat-square)

</div>

---

A single Blender addon that covers the whole Dead Rising series, from Dead Rising 2 and Off the Record through Case Zero, Case West, Dead Rising 3, and Dead Rising 4. It lets you pull character and prop meshes out of the game's files, edit them, and inject them back in, without having to touch any of the underlying formats by hand.

It started as a personal modding tool and is shared here in case it helps anyone else working on these games. It's not a finished, bulletproof tool, so please read the warning section before spending hours on a mesh.

Once installed, everything lives under one panel: `View3D > N-Panel > Dead Rising`, with a separate section for each game.

---

## Read This First

This addon is still a work in progress, and support isn't equally solid across every game it covers. A few things worth knowing before you dive in:

* Not every mesh will import or inject cleanly. Each game handles meshes a little differently under the hood, and some object types are more thoroughly tested than others.
* There are hard limits on mesh size depending on the game and object type. Going over them can block the export or cause problems in game, so pay attention to any warnings the addon gives you.
* Staying under those limits doesn't always guarantee success. Some individual item slots have much less room reserved for them than others, so a mesh that's technically within range can still cause issues if it's pushed far beyond the size of what it's replacing.
* Always keep backup options enabled when injecting. They're on by default for a reason.
* Bone weights, UVs, and tangents are recalculated from your Blender mesh on export. If something looks off in game, check Blender's console output after injecting, the addon prints warnings there.

If you're not comfortable risking a save file or reinstalling assets, don't test on your only save.

---

## Features

* Import character and prop meshes from Dead Rising 2, Off the Record, Case Zero, Case West, Dead Rising 3, and Dead Rising 4
* Inject edited or replacement meshes back into each game's files
* A dedicated tools panel per game, each tuned to how that title's files are structured
* Automatic backups before writing changes
* A mesh cleanup operator ("Fix Mesh") to sort out common issues before exporting
* Material and texture handling per game, including reloading and reapplying material slots
* Optional collision shape injection where supported (best effort, clearly flagged when used)

---

## Installation

1. Download the addon `.zip` (don't unzip it)
2. In Blender, go to `Edit > Preferences > Add-ons > Install...`
3. Select the `.zip` and enable it in the addon list
4. A new panel will appear in the `View3D` sidebar under the Dead Rising tab, with sections for each supported game

Requires Blender 4.0.

---

## Basic Usage

1. **Import** a model from the game you're working on, using that game's section in the panel
2. **Edit** it in Blender however your workflow needs
3. Optionally run **Fix Mesh** before exporting to clean up common issues
4. Select your edited object and use the game's injection tool, pointing it at the target file, with backups enabled
5. Check Blender's console after injecting. Warnings are printed there even when the operator reports success

---

## Known Issues

* Some games and object types are more reliably supported than others. If injection warns you about something unfamiliar, treat the result as unverified until you've checked it in game.
* The addon can't always know the exact space reserved for a specific item slot, only general format limits. Large increases in vertex count compared to the original are flagged where possible, but that's a heuristic, not a guarantee.
* Collision injection is best effort where it's supported. Reshaped or new collision shapes use an approximate fallback and are flagged when used, existing untouched collision is left alone.
* Locators injection got added as well.
* DR2 haas limit to 65,535 vertex per mesh

If you run into something not covered here, please open an issue with details on the game, the object involved, before and after vertex/triangle counts, and the console output from injection.

---

## Contributing

This is an ongoing, community driven project and still very much a work in progress across all the games it supports. Contributions are welcome, especially around the less tested titles and object types.

If you run into a mesh that won't inject properly, a bug report with the game, the object type, and the console output is usually enough to track down the issue.

## Disclaimer

This tool is for modding your own local game files. It is not affiliated with or endorsed by Capcom. Back up your files and use at your own risk.

<br>

---

<br>

# DRTB (Dead Rising Toolbox)

![Platform](https://img.shields.io/badge/platform-Windows-0a0c10?style=for-the-badge&logo=windows&logoColor=white)
![Status](https://img.shields.io/badge/status-active-2a8a4a?style=for-the-badge)
![License](https://img.shields.io/badge/license-Personal%20Use-c47a1e?style=for-the-badge)

[![Dead Rising Toolbox](dead.png)](dead.png)

A desktop app for working with Dead Rising game files, covering Dead Rising 2, Dead Rising 3, and Dead Rising 4 in one window. Browse archives, preview textures, edit data files, and get your files out in a format you can actually work with. Packaged as a standalone Windows executable, no Python or extra setup required.

This started as a personal project to make modding these games less painful, and it's grown into something a lot more complete. Still actively developed.

---

## What it does

* **Two toolsets in one app**, switch between Dead Rising 2 & otr, Dead Rising 2 :Case Zero , Dead Rising 2 Case West tools and Dead Rising 3/4 tools right from the toolbar
* **Browse archives**, open them up and see everything inside in a clean tree view instead of raw hex
* **Unpack files** to a real folder on disk, ready to edit
* **Repack folders** back into a proper archive the game will load
* **Handle nested containers** automatically, so you're not manually chasing down every layer yourself
* **Preview textures** right in the app, no need to alt tab into another program to check your work
* **Edit data files** for Dead Rising 3 and 4 (spawn tables, mission scripts, cinematics, and more) through a searchable editor, with quick tools for common tweaks
* **Convert bin files** for DR3/DR4 to editable text and back
* **Batch operations**, unpack or repack multiple archives at once instead of doing them one by one
* **Drag and drop** a file straight onto the window to open it
* **Dark UI** that's easy on the eyes for long modding sessions

## Getting started

1. Grab the latest `.exe` from the Releases page
2. Run it, no install and nothing else to set up
3. Pick the toolset for the game you're working on (DR2/CW/CZ, or DR3/DR4)
4. Drag in a file, or use the file picker
5. Unpack, edit, repack. That's the whole loop

## Notes

* Archives repacked with this tool match the structure the game expects, so anything unpacked here can be repacked here without extra prep
* Works with Dead Rising 2 & otr, Dead Rising 2 :Case Zero , Dead Rising 2 Case West , Dead Rising 3, and Dead Rising 4
* This is a hobby project built in spare time, so expect the occasional rough edge. Bug reports and feedback are always welcome

## Credits

Big thanks to the people who supported and inspired this project along the way:

* **Dodylectable**
* **UndeadFrankie**
* **𝗦𝗧𝗶𝗣𝟬**
* **Melina**
* **Gibbed**

This tool wouldn't be what it is without their support, feedback, and inspiration. Appreciate you all.

---

*Made for the Dead Rising modding community, by someone who's still zombie bashing years later.*


*Any Update in the future can be.
