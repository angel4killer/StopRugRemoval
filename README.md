# StopRugRemoval

A collection of little tweaks: don't pick up rugs if there's something on them! Place grass under things! Confirmation on bomb placement! Right click the butterfly hutch to spawn more butterflies! Gates no longer randomly pop off!

#### Installation

1. Install the latest version of [SMAPI](https://smapi.io).
2. Download this mod and unzip it into `Stardew Valley/Mods`.
3. Run the game using SMAPI.

#### Uninstallation

Simply delete from Mods folder.

#### Configuration

Either run this SMAPI with this mod installed once or use [Generic Mod Config Menu](https://www.nexusmods.com/stardewvalley/mods/5098). *You will need to load into a save to edit some options with GMCM.*

Configuration option `Enable` disables the whole mod if needed.

`PreventRugRemoval` prevents accidental removal of rugs if there's something on the rug.

Allows placement of rugs outside, if `CanPlaceRugsOutside` is set to true. By default, you will not be able to plant on rugs, nor will grass spread on rugs. But there's a setting for that: `PreventPlantingOnRugs`.

Prevents you from removing items from tables unless the `FurniturePlacementKey` is held down. (Default is `LeftShift + Z`). You can disable this behavior by deselecting `PreventRemovalFromTable`.

`PlaceGrassUnder` lets you place grass starters under most objects, like fences. Note that this is a low-priority right click interaction, so basically anything else will take precedence. (In particular, trying to place a grass starter in the Deconstructor will deconstruct it unless the Deconstructor was processing something else). This is disabled if [Smart Building's Building Mode](https://www.nexusmods.com/stardewvalley/mods/11158) is on - that mod does a better job placing grass under things anyways.

Prevents gates from popping off if you hold right click near them (again, unless `FurniturePlacementKey` is held down.)

`JukeboxesEverywhere` allow jukeboxes to be played most places. (Some maps have dedicated music that will override the jukebox).

`GoldenCoconutsOffIsland` allows golden coconuts to spawn from any palm tree as long as you've found one. (off by default).

Right click any butterfly hutch to spawn another butterfly! (Not tested yet with Norman's Better Butterfly Hutch, but I read through their code and I cannot see where they'd possibly conflict. We don't touch the same methods at all...)

Bomb confirmation: By default safe areas require confirmation, and dangerous areas do not. (You can confirm for a single bomb or the map, in which case you will not be asked again until you go to a different map.) Safe areas include the farmhouses, the farm, the town, and the Ginger Island farm. Dangerous areas include the mines and volcano, Everywhere else is considered dangerous if there's a single monster on the map and safe otherwise; this is meant to cover mod-added areas. This is fully configurable (including whether or not to confirm in multiplayer separate from singleplayer). (You will need to load into a save first to configure these options though, since the locations list is not populated otherwise.) 

#### Additionally

Translations would be very welcome! DM me or submit a pull request.

* Much thanks to Vigor for the Portuguese translation! 
