<div align="center">

# DR2:OTR Toolkit

### Blender addon for importing and injecting character/prop meshes into Dead Rising 2 and Off the Record

![Version](https://img.shields.io/badge/version-4.0.0-blue?style=flat-square)
![Blender](https://img.shields.io/badge/blender-3.2%2B-orange?style=flat-square&logo=blender&logoColor=white)
![Status](https://img.shields.io/badge/status-WIP-yellow?style=flat-square)
![License](https://img.shields.io/badge/license-unlicensed-lightgrey?style=flat-square)
![Platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux-informational?style=flat-square)

</div>

---

A Blender addon for pulling `.big` character and prop meshes out of Dead Rising 2 / Off the Record and injecting your own edited or replacement meshes back in, without needing to touch the raw container format by hand.

Started as a personal modding tool, shared here in case it's useful to anyone else digging into these files. It is **not** a finished, bulletproof tool, see the Warning section below before you sink hours into a mesh.

---

## Warning, Read This First

<table>
<tr>
<td>

This addon is **still a work in progress**. Some things to know before you use it:

- **Not every mesh will load correctly.** The `.big` / `persistent.big` format used by this game has several different internal mesh layouts (standard skinned meshes, combined multi-mesh buffers, weapon/prop types, vehicle split-streams, ragdoll/corpse meshes, and a few oddball variants). This addon tries to detect and handle all of them, but detection isn't always right, and some geo types are still handled on a best-effort basis.
- **There is a hard 65,535-vertex-per-mesh limit.** This is not a limitation of the addon, it's baked into the game's compiled renderer, which uses 16-bit index buffers. Exceeding this makes indices wrap around and corrupt the mesh, which reliably crashes the game on load. The addon refuses to export a mesh over this limit as of v4.0.
- **Staying under 65,535 verts does not guarantee it'll work.** Some individual asset slots (a hat, a piece of facewear, etc.) have their own much smaller preallocated buffer in the engine, sized around what the original asset needed. Pushing a mesh several times larger than the original, even if it's nowhere near the 16-bit ceiling, can still crash the game on load.
- **Always back up your `.big` files before injecting.** The exporter has a "Make Backup" option on by default, leave it on.
- **Bone weights, UVs, and tangents are re-derived from your Blender mesh on export.** The exporter flags zero-length normals/tangents, NaNs, and bad weight sums in the console (`[DR2OTR][VALIDATE]`), read that output if something looks wrong in-game.

If you're not comfortable losing a save file or reinstalling assets, don't test injected meshes on your only save.

</td>
</tr>
</table>

---

##  Features

- Import character/prop meshes from a `.big` file into Blender for editing
- Inject edited or replacement meshes back into a `.big` file
- Handles multiple internal geometry layouts (standard, combined/multi-mesh, weapon, corpse/ragdoll, vehicle split-stream, and more, see `constants.py` for the full list)
- Automatic backup of the target `.big` file before writing
- Mesh validation pass before injection (NaN/Inf checks, degenerate faces, out-of-range indices, bone range sanity, vertex count limits)
- Optional collision shape injection (non-Havok-compiled fallback, flagged separately when used)
- Optional material ID override on injection

---

##  Installation

1. Download the addon `.zip` (do not unzip it)
2. In Blender: `Edit > Preferences > Add-ons > Install...`
3. Select the `.zip` and enable **"Dead Rising 2 & Off the Record"** in the addon list
4. A new panel appears in the `View3D` sidebar under the **DR2:OTR** tab

Requires Blender 3.2 or newer.

---

##  Basic Usage

1. **Import**: use the DR2:OTR panel to import meshes from a `.big` file into your scene
2. **Edit**: modify the mesh in Blender as normal, sculpt, remesh, retopo, whatever your workflow needs
3. **Fix Mesh** (recommended before export/sometimes not well i dont know i add it to test): run the "Fix Mesh" operator to clean up common issues (normals, degenerate geometry) before injecting
4. **Export/Inject**: select your edited mesh object(s) and use "Inject into BIG", pointing it at the target `.big` file, keep "Make Backup" enabled
5. Check the Blender **console** after injecting, validation warnings and vertex-growth warnings are printed there even if the operator reports success

---

##  Known Issues

- **Not all geo types are equally well-tested.** Standard skinned meshes (heads, hats, facewear, most clothing) are the most reliable path. Combined/multi-mesh buffers (weapons, some props, vehicles, ragdolls) are supported but have more edge cases in how their `CommandBuffer` slice data gets patched, if injection prints a warning about an unrecognized `CommandBuffer` size for one of these types, treat the result as unverified.
- **No hard guarantee against per-slot buffer overflows.** The addon can't know the real preallocated buffer size for every individual asset slot in the game, only the universal 16-bit format ceiling. Large vertex-count increases over the original asset (roughly 5x or more) are flagged as a warning, but this is a heuristic, not a guarantee of safety.
- **Collision injection is best-effort.** Reshaped or newly added collision shapes don't get properly Havok-compiled data, they get an approximate fallback and are explicitly flagged in the report when used. Existing, unmodified collision shapes are left untouched and are safe.
- **Bounding box is not currently recalculated on injection.** If your mesh's dimensions differ significantly from the original, the stored bounding box will be stale. Likely affects culling more than anything else, hasn't been fully characterized.
- **LOD groups**: if a mesh has multiple LOD groups in its `VBHeader`, only the highest-vertex-count group is currently written to; other LOD levels are left as-is.

If you hit something not listed here, please open an issue with the object's geo type (if known), original vs. new vertex/triangle counts, and the console output from injection.

---

##  Changelog

### v1.15.0
- **Hard-blocked the 65,535 vertex limit.** Previously this was only a console print; exceeding it now aborts injection for that specific mesh before anything is written, and the failure is surfaced in Blender's report popup, not just the console.
- **Added a large-growth warning.** If an injected mesh grows 5x or more over the vertex count of the asset it's replacing, a warning is now logged with before/after counts and a suggested range to try instead. This does not block export, some slots can take more headroom than others, but it flags the most common real-world cause of crashes that occur well under the 65,535 ceiling.
- Minor internal cleanup around mesh validation reporting.

### v1.14.0
- Last stable release before the export-safety pass above.
- Multi-geo-type detection and injection (standard, combined, weapon, corpse/ragdoll, vehicle split-stream, prop-multi, novelty variants)
- Mesh validation pass (NaN/Inf, degenerate faces, out-of-range indices, bone range checks), console-only, non-blocking
- Optional best-effort collision injection
- Automatic `.bak` backups on injection

If you're working with an existing pipeline built around v3.2 behavior (e.g. scripts relying on injection never being blocked), note that v4.0 actively refuses to write a mesh over the hard limit rather than silently producing a broken file.

---

##  Contributing

This is a hobbyist reverse-engineering project, not a finished product. Pull requests, especially around the less-tested geo types (weapon/prop/vehicle combined buffers) or Havok collision compilation, are welcome. If you find a mesh type that doesn't inject correctly, please include the object's `DR2_GeoType` value and the raw console output, that's usually enough to trace the layout.

##  Disclaimer

This tool is for modding your own local game files. It is not affiliated with or endorsed by Capcom. Back up your files. Use at your own risk.
