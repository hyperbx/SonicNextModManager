<p align="center">
    <a href="https://github.com/Knuxfan24/Sonic-06-Mod-Manager/blob/master/">
        <img src="https://github.com/Knuxfan24/Sonic-06-Mod-Manager/blob/master/logo_small.png" />
    </a>
</p>

<h1 align="center">Sonic '06 Mod Manager</h1>

<p align="center">A tool designed to make it easier to use and manage mods for SONIC THE HEDGEHOG (2006) on the Xbox 360 and PlayStation 3.</p>

# Building
To manually build the Mod Manager, simply clone this repository to a location on your computer and open `Sonic '06 Mod Manager.sln` in Visual Studio (only [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) has been tested for this, but any recent version should be able to compile it). Right-click on the project in the Solution Explorer and choose Rebuild Solution to build an executable in `..\Sonic '06 Mod Manager\bin\Debug`.

If you just wish to use the Manager without touching the code, [simply grab the most recent stable release](https://github.com/Knuxfan24/Sonic-06-Mod-Manager/releases).

# Usage
When you first run the Mod Manager it will ask you to select a mods directory, this can be changed at any time and is where any mods will be stored. Any mods in the folder will appear in your mods list at the top of the Mod Manager. Select which mods you wish to use with the checkboxes on the left (they will be loaded in the selected order - Bottom to Top is default).

## Emulators
Configure your Game Directory and Emulator Exectuable locations using the text fields (or browse buttons). The Game Directory requires the folder containing the `xenon`/`ps3` and `win32` directories, alongside `default.xex`/`EBOOT.BIN` and the Emulator Executable simply requires you to select your EXE of [Xenia emulator](https://github.com/xenia-project/xenia) or [RPCS3](https://github.com/RPCS3/rpcs3). Then click Save and Play to automatically copy the mods to your game directory and launch the game in the selected emulator. Unless you have Manual uninstall checked; once the emulator is closed, the mods will automatically be uninstalled, restoring the game to base form; the same applies for patches.

## Real Hardware
Tick the Manual mods installation box to switch into Hardware Mode and set the Game Directory to a copy of SONIC THE HEDGEHOG (2006) on an external USB drive. Click Install Mods - this will copy the selected mods your external USB drive. Once the copy is complete, you can eject the drive and transfer the files to your console and launch the game from your backup loader of choice. Once you're done, you can click Uninstall Mods to remove the mods from the USB drive and restore the game to base form.

# Creating Mods
To create a mod, click on the Create New Mod button to bring up the Mod Creation window. Fill in the information presented, selecting the target system and whether the mod should merge with the base game files or overwrite them (merge mods can be combined with each other, where as non-merge mods cannot and will be skipped if they conflict). After entering your mod details, click the Create Mod button. This will create a folder with a `mod.ini` file in your mods directory, which you can then place your mod files into. Making sure to mirror the base game's directory setup.

# ISO Extraction
In order to use the Mod Manager, your copy of SONIC THE HEDGEHOG (2006) needs to be extracted, how you will do this depends on your system, follow the appropriate instructions in the links below.

- Xbox 360: https://www.reddit.com/r/xenia/wiki/how_to_rip_games
- PlayStation 3: https://www.reddit.com/r/ps3homebrew/wiki/multiman#wiki_making_backups_of_games

(Xbox 360 users) - If you end up with an ISO Disc Image, then you can use [Sonic '06 Toolkit](https://github.com/HyperPolygon64/Sonic-06-Toolkit) to extract the Xbox 360 ISO.
