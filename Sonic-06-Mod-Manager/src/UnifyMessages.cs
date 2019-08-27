using System;

// Project Unify is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2019 Knuxfan24 & HyperPolygon64

 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:

 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.

 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

namespace Unify.Messages
{
    class SystemMessages {
        public static string tl_DefaultTitle = "Sonic '06 Mod Manager";

        public static string msg_DefaultStatus = "Ready.";
        public static string msg_LaunchXenia = "Launching Xenia...";
        public static string msg_LaunchRPCS3 = "Launching RPCS3...";
        public static string msg_XeniaExitCall = "Waiting for Xenia exit call...";
        public static string msg_RPCS3ExitCall = "Waiting for RPCS3 exit call...";
        public static string msg_CreateNewMod = "Creating new mod...";
        public static string msg_EditMod = "Editing mod...";
        public static string msg_ModInfo = "Previewing mod info...";
        public static string msg_Cleanup = "Cleaning up mods...";
        public static string msg_Prereq_Newtonsoft = "Newtonsoft.Json.dll was written to the application path.";
        public static string tl_FatalError = "Fatal Error";
        public static string msg_Prereq_Ookii = "Ookii.Dialogs.dll was written to the application path.";

        public static string ex_Prereq_Newtonsoft_WriteFailure(Exception exception) { return $"Failed to write Newtonsoft.Json.dll. Please reinstall Sonic '06 Mod Manager.\n\n{exception}"; }
        public static string ex_Prereq_Ookii_WriteFailure(Exception exception) { return $"Failed to write Ookii.Dialogs.dll. Please reinstall Sonic '06 Mod Manager.\n\n{exception}"; }
        public static string msg_InstallingMod(string mod) { return $"Installing {mod}..."; }
        public static string msg_CopyingMod(string mod) { return $"Copying {mod}..."; }
        public static string msg_MergingMod(string mod) { return $"Merging {mod}..."; }
    }

    class ModsMessages {
        public static string msg_NoModDirectory = "No mods directory specified, or the specified directory is invalid - please select your Sonic '06 mods directory...";
        public static string tl_ListError = "List Error";
        public static string ex_ModListError = "An error occurred whilst retrieving the mods list.";
        public static string msg_LocateARCs = "Please select ARC files to make read-only...";
        public static string tl_FileError = "File Error";
        public static string msg_ThumbnailDeleteError = "An error occurred whilst removing the thumbnail.";
        public static string tl_SuccessWarn = "Success, but errors occurred...";
        public static string ex_ModInstallFailure = "General mod installation failure, please ensure your game directory is set correctly.";

        public static string ex_SkippedMod(string mod, string file) { return $"\n► {mod} (failed because a mod was already installed on file: {file} - try merging instead)"; }
        public static string ex_SkippedModsTally(string failedMods) { return $"Mod installation completed, but the following mods were skipped:\n{failedMods}"; }
        public static string ex_IncorrectTarget(string mod, string platform) { return $"\n► {mod} (failed because the mod was not targeted for the {platform})"; }
    }

    class EmulatorMessages {
        public static string msg_LocateGame = "Please specify your game directory...";
        public static string msg_LocateXenia = "Please specify your executable file for Xenia...";
        public static string msg_LocateRPCS3 = "Please specify your executable file for RPCS3...";
    }

    class PatchesMessages {

    }

    class SettingsMessages {
        public static string msg_LocateMods = "Please specify your mods directory...";
        public static string msg_Reset = "This will clear all of the settings for Sonic '06 Mod Manager. Are you sure you want to continue?";
    }
}
