<p align="center">
    <a href="https://github.com/Knuxfan24/Sonic-06-Mod-Manager/blob/master/">
        <img src="https://github.com/Knuxfan24/Sonic-06-Mod-Manager/blob/master/logo_small.png" />
    </a>
</p>

<h1 align="center">Sonic '06 Mod Manager</h1>

<p align="center">A tool designed to make it easier to use and manage mods for SONIC THE HEDGEHOG (2006) on the Xbox 360 and PlayStation 3.</p>

# Building
To manually build the Mod Manager, simply clone this repository to a location on your computer and open the Sonic '06 Mod Manager.sln file in Visual Studio (only VS2019 has being tested for this, but any recent version should be able to compile). Right click on the project in the Solution Explorer and choose Rebuild Solution to build an executable in `..\Sonic '06 Mod Manager\bin\Debug`.

If you just wish to use the Manager without touching the code, simply grab the most recent stable release from https://github.com/Knuxfan24/Sonic-06-Mod-Manager/releases

# Usage
When you first run the Mod Manager it will ask you to select a Mods Directory, this can be changed at any time and is where any mods will be stored. Any mods in the folder will appear in your Mods List at the top of the Manager. Select which mods you wish to use with the checkboxes on the left (they will be loaded in order from highest to lowest on the list).

## Xenia Emulator
Configure your Game Directory and Xenia Exectuable locations using the text boxes (or browse buttons). The Game Directory requires the folder containing the win32 and xenon directories, alongside default.xex and the Xenia Executable simply requires you to select your EXE of the Xenia Emulator (https://github.com/xenia-project/xenia). Then click Save and Play to automatically copy the mods to your Game Directory and launch the game in Xenia. Once Xenia is closed, the mods will automatically be uninstalled, restoring the game to base form.

## Xbox 360 Hardware
[Allan Please Add Details]

## PlayStation 3 Hardware
Tick the FTP Server? box to switch into Hardware Mode, this will replace the Game Directory box with an FTP Location one, enter the FTP link to your Modded PlayStation 3 with a copy of SONIC THE HEDGEHOG (2006) on the Hard Drive, (likely to be similar to ftp://192.168.0.27/dev_hdd0/GAMES/BLES00028-[SONIC THE HEDGEHOG]/PS3_GAME/USRDIR/). Ensure that the System dropdown box is set to PlayStation 3 then click Copy Mods, this will copy the mods your console. Once the copy is complete you can launch the game from your backup loader of choice. Once you're done, you can click Remove Mods to uninstall the mods and restore the game to base form.

# Creating Mods
To-Do

# ISO Extraction
Something Something 06 Toolkit and MultiMan or whatever we want to tutorialise for the PS3 version.
