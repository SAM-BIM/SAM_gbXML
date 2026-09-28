# SAM Grasshopper icon redesign — SAM_gbXML PR record

Branch `feature/sam-gh-icon-redesign`, based on `sow/2026-Q3` @ `26111c9`. PR: (to be opened).
Propagates the SAM icon design system from SAM-BIM/SAM#166 (head `cf4d924a`, open, not merged) to this repository.

## Current status
All **2** Grasshopper objects in this repo (2 components + 0 params) use redesigned icons: **2 / 2**.
Built and validated; ready for review. **Not merged.**

## Work completed
- `design/grasshopper-icons/`: the shared SAM-BIM icon kit. `icons.py`, `render.py`, `sam_classify.py` and `ICON_DESIGN_SYSTEM.md` are vendored **verbatim** from SAM#166 (hash-checked). `icons_ext.py` and `ICON_DESIGN_SYSTEM_EXT.md` are the frozen SAM-BIM extension v1 (identical in every SAM-BIM repo). `tools/repo_rules.py` holds this repo's explicit decisions.
- **Inventory**: `tools/inventory.py` parses C# source (every non-abstract class declaring `ComponentGuid`).
- **Manifest** (source of truth): `manifest.json` / `manifest.csv` — per object: GUID, class, source, project, object glyph, operation, modifiers, icon id, resource, glyph/badge origin.
- **Generation**: 2 canonical SVGs → 24×24 PNGs; review sheet `review/contact_sheet.png` (native 24 px on GH normal / orange-warning / dark bodies + 3×) and `review/REVIEW.md`.
- **Integration**: each project's existing mechanism; only the icon token inside each `Icon` getter changes.

| Project | Objects | Icon resources | Mechanism |
|---|---|---|---|
| `SAM.Analytical.Grasshopper.gbXML` | 2 | 2 | resx / Bitmap |

## Design reuse
- **Reused SAM object families (1)**: `model`
- **New SAM-BIM ext v1 families used (0)**: — (none)
- **Verbs**: `export`, `import` (all SAM)
- Distinct icons: **2** (2 on SAM glyphs, 0 on ext glyphs). Icon ids shared with SAM render pixel-identically to SAM's.

## Decisions and assumptions
- Grammar, palette, badge families and construction rules are unchanged (SAM#166). No text, no new colours.
- Qualifier variants (`…By<X>`) share an icon intentionally (see `review/REVIEW.md`).
- Interop direction: external → SAM = import ↓, SAM → external = export ↑.
- gbXML → SAM = model import, SAM → gbXML = model export. No new glyphs needed.
- Legacy icon resources are kept (still referenced by context menus / AssemblyInfo); no GUID, name, nickname, category, subcategory, parameter or behaviour change.

## Files changed
- New: `design/grasshopper-icons/**`, `<project>/Resources/Icons/SAM_GH_*.png`, `docs/GH-IconRedesign.md`.
- Modified: 2 component/param `.cs` files (one icon token each), 1× `Resources.resx`, 1× `Resources.Designer.cs`. No csproj change.

## Validation
| Check | Result |
|---|---|
| `tools/classify.py` | 2 classified, 0 unclassified |
| `tools/build.py` identical-pixel collision check | 0 groups (2 distinct icons; 0 intentionally shared icon(s) for qualifier variants, listed in `review/REVIEW.md`) |
| Icon ids shared with SAM#166 vs SAM's `png/24` | 1 shared, 1 byte-identical |
| `tools/integrate.py` re-parse | 2/2 objects reference their `SAM_GH_*` resource; every PNG exists |
| `tools/check_source.py` vs `origin/sow/2026-Q3` | vendored files OK; icon-token swaps: 2, non-icon changes: 0; base 2, now 2 -> UNCHANGED |
| `dotnet build SAM_gbXML.sln -c Debug` | Build succeeded, 0 errors |
| `tools/check_assemblies.py` | every assembly embeds every required 24×24 icon → OK |
| `tests/GhIconTest` (real Rhino 8 / Grasshopper, Rhino.Testing) | 2/2 objects verified: 2 load in real Rhino 8 / Grasshopper by GUID (name/category match); icon = manifest PNG (max diff 1 level, premultiplied-alpha rounding) |
| Repository test projects | none in this repository |
| Visual review (`review/contact_sheet.png`, 24 px on normal / warning / dark bodies) | all icons legible; no collisions |

## Unresolved issues / risks
- Built against sibling repos as checked out locally (SAM on `feature/sam-gh-icon-redesign` = SAM#166); icon changes are API-neutral.

## Recommended next step
Review this PR (compare `review/contact_sheet.png`), then merge by the maintainer. After merge, add the `PROJECT_PROGRESS.md` closeout entry on `sow/2026-Q3` with the merge SHA. SAM#166 (the reference design system) remains open.
