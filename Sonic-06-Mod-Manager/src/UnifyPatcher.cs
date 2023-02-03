using System;
using System.IO;
using System.Text;
using System.Linq;
using Unify.Messenger;
using Unify.Serialisers;
using Unify.Environment3;
using System.Diagnostics;
using Unify.Globalisation;
using System.Windows.Forms;
using System.IO.Compression;
using System.Collections.Generic;
using Marathon.IO.Formats.Miscellaneous;
using Marathon.IO.Formats.Text;
using Marathon.IO.Formats.Archives;
using ArcPackerLib;
using System.Drawing.Text;

// Sonic '06 Mod Manager is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2020 Knuxfan24
 * Copyright (c) 2020 HyperBE32

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

namespace Unify.Patcher
{
    class ModEngine
    {
        public static List<string> skipped = new List<string>(),  // Define the skipped list for error tracking
                                   corepkg = new List<string>(),  // Define the PKG list for xenon/ps3 for custom filesystems
                                   win32pkg = new List<string>(); // Define the PKG list for win32 for custom filesystems

        /// <summary>
        /// Installs the specified mods (requires for statement iteration for more than one mod).
        /// </summary>
        /// <param name="mod">File path to the mod's INI file.</param>
        /// <param name="name">Name of the mod by Title key.</param>
        public static void InstallMods(string mod, string name) {
            string platform          = INI.DeserialiseKey("Platform", mod),                   // Deserialise 'Platform' key
                   merge             = INI.DeserialiseKey("Merge", mod),                      // Deserialise 'Merge' key
                   customFilesystem  = INI.DeserialiseKey("CustomFilesystem", mod);           // Deserialise 'CustomFilesystem' key
            string[] custom          = INI.DeserialiseKey("Custom", mod).Split(','),          // Deserialise 'Custom' key
                     read_only       = INI.DeserialiseKey("Read-only", mod).Split(','),       // Deserialise 'Read-only' key
                     requiredPatches = INI.DeserialiseKey("RequiredPatches", mod).Split(','); // Deserialise 'RequiredPatches' key
            bool _merge, _customFilesystem;

            // Parse strings as Boolean values
            if (!bool.TryParse(merge, out _merge)) _merge = false;
            if (!bool.TryParse(customFilesystem, out _customFilesystem)) _customFilesystem = true;

            //Skip the mod if the platform is invalid
            string system = Literal.System(Properties.Settings.Default.Path_GameExecutable);
            if (system != platform && platform != "All Systems") {
                skipped.Add($"► {name} (failed because the mod was not targeted for the {system})");
                return;
            }

            foreach (string file in Paths.CollectModData(Path.GetDirectoryName(mod))) {
                // Absolute file path (core/xenon/win32 and beyond)
                string filePath = Literal.CoreReplace(file.Remove(0, Path.GetDirectoryName(mod).Length).Substring(1));

                // Absolute file path (from the mod) combined with the game directory
                string vanillaFilePath = Path.Combine(Path.GetDirectoryName(Properties.Settings.Default.Path_GameExecutable), filePath);

                // Backup file path derived from the file about to be overwritten
                string targetFilePath = $"{vanillaFilePath}_back";

                // Checks if the processed file exists in the custom filesystem - if so, add to PKG preparation list
                if (_customFilesystem && custom.Contains(Path.GetFileName(file)) && Path.GetExtension(file) == ".arc") {
                    // If the absolute file path contains 'win32' - add to win32 PKG preparation list
                    if (filePath.Contains("win32")) win32pkg.Add(Path.GetFileName(file));

                    // If the absolute file path contains 'xenon' or 'ps3' - add to xenon/win32 PKG preparation list
                    else corepkg.Add(Path.GetFileName(file));
                }

                // Backup the original file
                if (File.Exists(vanillaFilePath) && !File.Exists(targetFilePath)) File.Copy(vanillaFilePath, targetFilePath);

                //Check if file should be merged
                if (Path.GetExtension(file) == ".arc" && _merge && !read_only.Contains(Path.GetFileName(file)) && File.Exists(vanillaFilePath)) {
                    Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Merge] {file}");
                    Merge(vanillaFilePath, file);

                //If the file is not an archive or it shouldn't be merged, just copy it
                } else {
                    // Skip if file doesn't exist in the base game and it's not custom.
                    if (!File.Exists(vanillaFilePath) && !custom.Contains(Path.GetFileName(file))) continue;

                    Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Copy] {file}");
                    File.Copy(file, vanillaFilePath, true);
                }

                // Generate custom filesystem in PKG if the lists are populated
                if (_customFilesystem && (corepkg.Count != 0 || win32pkg.Count != 0)) {
                    if (platform == "Xbox 360") CustomFilesystemPackage("xenon");
                    else if (platform == "PlayStation 3") CustomFilesystemPackage("ps3");
                    else if (platform == "All Systems") CustomFilesystemPackage(Literal.Core(Properties.Settings.Default.Path_GameExecutable));
                    else {
                        skipped.Add($"► {name} (failed because the targeted platform was invalid)");
                        return;
                    }
                }
            }

            // Install the required patches for the mod
            if (requiredPatches[0] != string.Empty)
                foreach (string patch in requiredPatches) {
                    string fullPath = Path.Combine(Program.Patches, patch);
                    if (Paths.CheckFileLegitimacy(fullPath))
                        PatchEngine.InstallPatches(fullPath, Lua.DeserialiseParameter("Title", fullPath, true));
                    else
                        skipped.Add($"► {name} (could not locate {patch})");
                }

            // If the mod uses a custom patch, install it.
            string modPatch = Paths.ReplaceFilename(mod, "patch.mlua");
            if (Paths.CheckFileLegitimacy(modPatch)) {
                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Patch] <hybrid> Patching {name}...");
                PatchEngine.InstallPatches(modPatch, name);
            }
        }

        /// <summary>
        /// Uninstalls all mods.
        /// </summary>
        public static void UninstallMods() {
            // If the game directory is empty/doesn't exist, ignore request
            if (Paths.CheckFileLegitimacy(Properties.Settings.Default.Path_GameExecutable)) {
                    // Search for all files
                    List<string> files = Directory.GetFiles(
                                         Path.GetDirectoryName(Properties.Settings.Default.Path_GameExecutable),
                                         "*.*_back",
                                         SearchOption.AllDirectories).ToList();

                    foreach (string file in files) {
                        if (File.Exists(file.Remove(file.Length - 5))) {
                            Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Remove] {file}");
                            File.Delete(file.Remove(file.Length - 5)); // Delete file with last five characters set to '_back'
                        }
                        File.Move(file, file.Remove(file.Length - 5)); // Remove last five characters ('_back')
                }
            }
        }

        /// <summary>
        /// Uninstalls user-made filesystems.
        /// </summary>
        public static void UninstallCustomFilesystem(ListView.ListViewItemCollection listViewItems) {
            if (Paths.CheckFileLegitimacy(Properties.Settings.Default.Path_GameExecutable)) { // If the game directory is empty/doesn't exist, ignore request
                string[] gameFiles = Directory.GetFiles(Path.GetDirectoryName(Properties.Settings.Default.Path_GameExecutable), "*.*", SearchOption.AllDirectories); // Get the game files.
                foreach (ListViewItem mod in listViewItems) {
                    string[] custom = INI.DeserialiseKey("Custom", mod.SubItems[6].Text).Split(','); // Deserialise 'Custom' key

                    if (custom[0] != string.Empty) { // Speeds things up a bit - ensures it's not checking a default null parameter
                        foreach (string file in custom) {
                            foreach (string gameFile in gameFiles) {
                                // Check if this file has the name of one of our custom files, if so, delete it.
                                if (Path.GetFileName(gameFile) == file) {
                                    Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Remove] {gameFile}");
                                    File.Delete(gameFile);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Removes redirected save data.
        /// </summary>
        public static void UninstallSaves(ListView.ListViewItemCollection listViewItems) {
            if (Properties.Settings.Default.Path_SaveData != string.Empty || File.Exists(Properties.Settings.Default.Path_SaveData)) {
                foreach (ListViewItem mod in listViewItems) {
                    // Basically just to check 'SonicNextSaveData.bin' as a directory
                    string saveLocation = Path.GetDirectoryName(Path.GetDirectoryName(Properties.Settings.Default.Path_SaveData));

                    // Deserialise 'Save' key
                    string savedata = INI.DeserialiseKey("Save", mod.SubItems[6].Text);

                    if (savedata != string.Empty) { // Speeds things up a bit - ensures it's not checking a default null parameter
                        if (Literal.Emulator(Properties.Settings.Default.Path_GameExecutable) == "Xenia") {
                            string[] saves = Array.Empty<string>();

                            // Get all backup directories
                            if (Directory.Exists(saveLocation)) saves = Directory.GetDirectories(saveLocation, "SonicNextSaveData.bin_back", SearchOption.AllDirectories);

                            foreach (var dir in saves) {
                                // Original save data path
                                string saveFile = Path.Combine(dir.ToString().Remove(dir.Length - 5), Path.GetFileName(dir.ToString().Remove(dir.Length - 5)));

                                // Copy redirected save data back to the mod's directory (keeps user progress)
                                if (File.Exists(saveFile)) {
                                    Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Remove] {dir}");
                                    if (savedata != string.Empty) File.Copy(saveFile, Path.Combine(Path.GetDirectoryName(mod.SubItems[6].Text), "savedata.360"), true);
                                }

                                // Recursively erase redirected save data
                                if (Directory.Exists(dir.ToString().Remove(dir.Length - 5))) {
                                    Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Remove] {dir}");
                                    Directory.Delete(dir.ToString().Remove(dir.Length - 5), true);
                                }

                                // Restore original save data
                                Directory.Move(dir.ToString(), dir.ToString().Remove(dir.Length - 5));
                            }
                        } else if (Literal.Emulator(Properties.Settings.Default.Path_GameExecutable) == "RPCS3") {
                            string[] saves = Array.Empty<string>();

                            // Original save data path
                            if (Directory.Exists(saveLocation)) saves = Directory.GetFiles(saveLocation, "SYS-DATA_back", SearchOption.AllDirectories);

                            foreach (var file in saves) {
                                string saveFile = Path.Combine(file.ToString().Remove(file.Length - 5), Path.GetFileName(file.ToString().Remove(file.Length - 5)));

                                // Copy redirected save data back to the mod's directory (keeps user progress)
                                if (File.Exists(saveFile)) {
                                    Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Remove] {file}");
                                    if (savedata != string.Empty) File.Copy(saveFile, Path.Combine(Path.GetDirectoryName(mod.SubItems[6].Text), "savedata.ps3"), true);
                                }

                                // Erase redirected save data
                                if (File.Exists(file.ToString().Remove(file.Length - 5))) {
                                    Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Remove] {file}");
                                    File.Delete(file.ToString().Remove(file.Length - 5));
                                }

                                // Restore original save data
                                File.Move(file.ToString(), file.ToString().Remove(file.Length - 5));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new 'archive.pkg' container for new filesystems.
        /// </summary>
        public static void CustomFilesystemPackage(string platform)
        {
            //Create a custom PKG based on all the custom arcs specified in mods
            string system = Path.Combine(Path.GetDirectoryName(Properties.Settings.Default.Path_GameExecutable), platform, "archives", "system.arc");

            if (!File.Exists($"{system}_back"))
                File.Copy(system, $"{system}_back", true);

            string unpack = UnpackARC(system, Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()));

            // Decode the PKG
            string directoryRoot = Path.Combine(unpack, $"{platform}\\archive");
            AssetPackage pkg = new AssetPackage($"{directoryRoot}.pkg");

            foreach (var type in pkg.Types)
            {
                if (type.Name == "archive")
                {
                    foreach (string arc in corepkg)
                    {
                        var file = new AssetPackage.AssetFile
                        {
                            File = $"archives/{arc}",
                            Name = Path.GetFileNameWithoutExtension(arc)
                        };

                        type.Files.Add(file);
                    }
                }
                else if (type.Name == "archive_win32")
                {
                    foreach (string arc in win32pkg)
                    {
                        var file = new AssetPackage.AssetFile
                        {
                            File = $"archives/{arc}",
                            Name = Path.GetFileNameWithoutExtension(arc)
                        };

                        type.Files.Add(file);
                    }
                }
            }

            //Save the edited PKG
            pkg.Save($"{directoryRoot}.pkg", true);

            //Repack changes
            RepackARC(unpack, system);

            //Clear lists
            corepkg.Clear();
            win32pkg.Clear();
        }

        /// <summary>
        /// Extracts an archive to a temporary location.
        /// </summary>
        public static string UnpackARC(string arc, string extractDir)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == Path.GetPathRoot(Environment.SystemDirectory))
                {
                    if (drive.AvailableFreeSpace > new FileInfo(arc).Length)
                    {
                        U8Archive unpack = new U8Archive(arc);
                        unpack.Extract(extractDir);

                        return extractDir;
                    }
                    else
                    {
                        throw new InsufficientMemoryException($"Unable to extract '{Path.GetFileName(arc)}' due to insufficient drive space...");
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Repacks an archive from a temporary location.
        /// </summary>
        public static void RepackARC(string extractDir, string arc)
        {
            if (extractDir != string.Empty)
            {
                ArcPacker repack = new ArcPacker();
                repack.WriteArc(arc, extractDir);

                // Erases temporary repack data
                try
                {
                    DirectoryInfo tempData = new DirectoryInfo(extractDir);
                    if (Directory.Exists(extractDir))
                    {
                        foreach (FileInfo file in tempData.GetFiles()) file.Delete();
                        foreach (DirectoryInfo directory in tempData.GetDirectories()) directory.Delete(true);
                        Directory.Delete(extractDir);
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// Merges two archives into a single archive.
        /// </summary>
        public static void Merge(string arc1, string arc2)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()); // Defines the temporary path.

            UnpackARC(arc1, tempPath);
            UnpackARC(arc2, tempPath);

            RepackARC(tempPath, arc1);
        }
    }

    class PatchEngine
    {
        static string _archive = string.Empty, _archiveLocation = string.Empty;
        static List<string> _ignoreList = new List<string>(), _searchList = new List<string>();
        public static bool decrypted = false;

        /// <summary>
        /// Installs the specified patches (requires for statement iteration for more than one mod).
        /// </summary>
        /// <param name="patch">File path to the patch's MLUA file.</param>
        /// <param name="name">Name of the patch by Title key.</param>
        public static void InstallPatches(string patch, string name)
        {
            // Deserialise 'Platform' parameter
            string platform = Lua.DeserialiseParameter("Platform", patch, true),
                   gameExecutable = Properties.Settings.Default.Path_GameExecutable;

            bool allSystemsMode = platform == "All Systems",
                 systemReached  = false;

            _ignoreList = new List<string>();
            _searchList = new List<string>();

            // Skip the patch if the platform is invalid...
            string system = Literal.System(gameExecutable);
            if (system != platform && !allSystemsMode) {
                ModEngine.skipped.Add($"► {name} (failed because the patch was not targeted for the {system})");
                return;
            }

#if !DEBUG
            try {
#endif
                // Begin reading patch script...
                using (StreamReader patchScript = new StreamReader(patch, Encoding.Default)) {
                    string line;
                    while ((line = patchScript.ReadLine()) != null)
                    {
                        // If the platform is 'All Systems' then check if it shall proceed if labels are involved...
                        if (allSystemsMode) {
                            if (line.StartsWith("All Systems") || line.StartsWith(system)) systemReached = true;
                            else if (line.StartsWith(Literal.OppositeSystem(gameExecutable))) systemReached = false;
                        } else
                            // System is specific, so proceed as normal...
                            systemReached = true;

                        if (systemReached)
                        {
                            switch (line)
                            {
                                // Unpacks an archive to a temporary location.
                                case string x when x.StartsWith("BeginBlock("):
                                {
                                    // Deserialise 'BeginBlock' parameter
                                    string _BeginBlock = Lua.DeserialiseParameter("BeginBlock", line, false);

                                    // Populate location cache
                                    string location = _archiveLocation = Path.Combine(
                                                                         Path.GetDirectoryName(Properties.Settings.Default.Path_GameExecutable),
                                                                         Literal.CoreReplace(_BeginBlock));

                                    _archive = ModEngine.UnpackARC(location, Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()));

                                    break;
                                }

                                // Decrypts the game's XEX/EBOOT.
                                case "DecryptExecutable()":
                                {
                                    BackupFile(gameExecutable);
                                    if (system == "Xbox 360") XEX.Decrypt(gameExecutable);
                                    else if (system == "PlayStation 3") EBOOT.Decrypt(gameExecutable);
                                    else continue;
                                    decrypted = true;

                                    break;
                                }

                                // Encrypts the game's XEX/EBOOT.
                                case "EncryptExecutable()":
                                {
                                    EncryptExecutable();

                                    break;
                                }

                                // Writes a byte to the specified offset in the file.
                                case string x when x.StartsWith("WriteByte("):
                                {
                                    // Deserialise 'WriteByte' parameter
                                    string[] _WriteByte = Lua.DeserialiseParameterList("WriteByte", line, false);
                                    WriteByte(Literal.CoreReplace(_WriteByte[0]), Convert.ToInt32(_WriteByte[1], 16), Convert.ToByte(_WriteByte[2], 16));

                                    break;
                                }

                                // Writes a byte array to the specified offset in the file.
                                case string x when x.StartsWith("WriteBytes("):
                                {
                                    // Deserialise 'WriteBytes' parameter
                                    string[] _WriteBytes = Lua.DeserialiseParameterList("WriteBytes", line, false);

                                    // Convert the string to a byte array
                                    byte[] _WriteBytesArray = Bytes.StringToByteArray(_WriteBytes[2].Replace(" ", ""));

                                    // Iterate through byte array to write from the offset
                                    for (int i = 0; i < _WriteBytesArray.Length; i++)
                                        WriteByte(Literal.CoreReplace(_WriteBytes[0]), Convert.ToInt32(_WriteBytes[1], 16) + i, _WriteBytesArray[i]);

                                    break;
                                }


                                // Writes a byte array to the relative virtual address in the executable.
                                case string x when x.StartsWith("WriteVirtualBytes("):
                                {
                                    // Deserialise 'WriteVirtualBytes' parameter
                                    string[] _WriteVirtualBytes = Lua.DeserialiseParameterList("WriteVirtualBytes", line, false);

                                    // Convert the string to a byte array
                                    byte[] _WriteVirtualBytesArray = Bytes.StringToByteArray(_WriteVirtualBytes[1].Replace(" ", ""));

                                    // Iterate through byte array to write from the offset
                                    for (int i = 0; i < _WriteVirtualBytesArray.Length; i++)
                                        WriteByte("Executable", Bytes.GetPhysicalFromVirtual(Convert.ToInt32(_WriteVirtualBytes[0], 16)) + i, _WriteVirtualBytesArray[i]);

                                    break;
                                }

                                // Writes null bytes to the specified offset in the file.
                                case string x when x.StartsWith("WriteNullBytes("):
                                {
                                    // Deserialise 'WriteNullBytes' parameter
                                    string[] _WriteNullBytes = Lua.DeserialiseParameterList("WriteNullBytes", line, false);

                                    // Iterate through byte count to null from the offset
                                    for (int i = 0; i < Convert.ToInt32(_WriteNullBytes[2]); i++)
                                        WriteByte(Literal.CoreReplace(_WriteNullBytes[0]), Convert.ToInt32(_WriteNullBytes[1], 16) + i, 0);

                                    break;
                                }

                                // Writes Base64 data to a binary file.
                                case string x when x.StartsWith("WriteBase64("):
                                {
                                    // Deserialise 'WriteBase64' parameter
                                    string[] _WriteBase64 = Lua.DeserialiseParameterList("WriteBase64", line, false);

                                    // Append the location to the active path
                                    string _Base64Location = GetDataLocation(Literal.CoreReplace(_WriteBase64[0]));

                                    BackupFile(_Base64Location); // Backup the pre-written file no matter what

                                    // Convert and write Base64 to a binary file
                                    byte[] bytes = Convert.FromBase64String(_WriteBase64[1]);

                                    // Create directory in case it doesn't exist
                                    Directory.CreateDirectory(Path.GetDirectoryName(_Base64Location));

                                    // Write Base64 data
                                    File.WriteAllBytes(_Base64Location, bytes);

                                    break;
                                }

                                // Writes a NOP value to the specified offset at the file path.
                                case string x when x.StartsWith("WriteNopPPC("):
                                {
                                    // Deserialise 'WriteNopPPC' parameter
                                    string[] _WriteNopPPC = Lua.DeserialiseParameterList("WriteNopPPC", line, false);

                                    // Write the NOPs with the information from the parameter
                                    WriteNop(_WriteNopPPC, false);

                                    break;
                                }

                                // Writes a NOP value to the relative virtual address in the executable.
                                case string x when x.StartsWith("WriteVirtualNop("):
                                {
                                    /* Deserialise 'WriteVirtualNop' parameter as a list because our bad code
                                       causes the first character to be omitted from a single string. */
                                    string[] _WriteVirtualNop = Lua.DeserialiseParameterList("WriteVirtualNop", line, false);

                                    // Write the NOPs virtually with the information from the parameter
                                    WriteNop(_WriteVirtualNop, true);

                                    break;
                                }

                                // Writes ASCII text in bytes to the specified offset in the file.
                                case string x when x.StartsWith("WriteTextBytes("):
                                {
                                    // Deserialise 'WriteTextBytes' parameter
                                    string[] _WriteTextBytes = Lua.DeserialiseParameterList("WriteTextBytes", line, false);
                                    byte[] textBytes = Encoding.ASCII.GetBytes(_WriteTextBytes[2]);

                                    // Iterate through the encoded bytes
                                    for (int i = 0; i < textBytes.Length; i++)
                                        WriteByte(Literal.CoreReplace(_WriteTextBytes[0]), Convert.ToInt32(_WriteTextBytes[1], 16) + i, textBytes[i]);

                                    break;
                                }

                                // Renames a file.
                                case string x when x.StartsWith("Rename("):
                                {
                                    // Deserialise 'Rename' parameter
                                    string[] _Rename = Lua.DeserialiseParameterList("Rename", line, false);

                                    // Append the location to the active path
                                    string _RenameLocation = GetDataLocation(Literal.CoreReplace(_Rename[0])),

                                           // Define the final path names
                                           newName = Paths.ReplaceFilename(_RenameLocation, Path.GetFileName(_Rename[1])),
                                           rBackup = $"{_RenameLocation}_back";

                                    BackupFile(_RenameLocation); // Backup the pre-renamed file no matter what

                                    if (!File.Exists(newName)) File.Move(_RenameLocation, newName);
                                    else if (newName == rBackup && File.Exists(rBackup)) File.Delete(_RenameLocation);

                                    break;
                                }

                                // Renames all files with the specified extension to the new extension.
                                case string x when x.StartsWith("RenameByExtension("):
                                {
                                    // Deserialise 'RenameByExtension' parameter
                                    string[] _RenameByExtension = Lua.DeserialiseParameterList("RenameByExtension", line, false);

                                    // Append the location to the active path
                                    string _RenameExtensionLocation = GetDataLocation(Literal.CoreReplace(_RenameByExtension[0]));

                                    // Iterate through all files by extension
                                    foreach (string file in Directory.GetFiles(_RenameExtensionLocation, _RenameByExtension[1], SearchOption.TopDirectoryOnly))
                                    {
                                        // Get new file name
                                        string newExtension = Path.ChangeExtension(file, _RenameByExtension[2]),
                                               rbeBackup = $"{file}_back";

                                        if (!File.Exists(newExtension)) File.Move(file, newExtension);
                                        else if (newExtension == rbeBackup && File.Exists(rbeBackup)) File.Delete(file);
                                    }

                                    break;
                                }

                                // Deletes a file or folder.
                                case string x when x.StartsWith("Delete("):
                                {
                                    // Deserialise 'Delete' parameter
                                    string _Delete = Lua.DeserialiseParameter("Delete", line, false),

                                    // Append the location to the active path
                                    _DeleteLocation = GetDataLocation(Literal.CoreReplace(_Delete));

                                    BackupFile(_DeleteLocation); // Backup the pre-deleted file no matter what

                                    // Delete file or directory
                                    if (File.Exists(_DeleteLocation)) File.Delete(_DeleteLocation);
                                    else if (Directory.Exists(_DeleteLocation) && _archive != string.Empty)
                                    {
                                        try
                                        {
                                            // Erases the directory contents
                                            DirectoryInfo data = new DirectoryInfo(_DeleteLocation);
                                            if (Directory.Exists(_DeleteLocation))
                                            {
                                                foreach (FileInfo file in data.GetFiles()) file.Delete();
                                                foreach (DirectoryInfo directory in data.GetDirectories()) directory.Delete(true);
                                                Directory.Delete(_DeleteLocation);
                                            }
                                        }
                                        catch { }
                                    }

                                    break;
                                }

                                // Copies a file to a new location, with an overwrite function.
                                case string x when x.StartsWith("Copy("):
                                {
                                    // Deserialise 'Copy' parameter
                                    string[] _Copy = Lua.DeserialiseParameterList("Copy", line, false);

                                    // Append the location to the active path
                                    string _CopyLocation = GetDataLocation(Literal.CoreReplace(_Copy[0]));

                                    BackupFile(_CopyLocation); // Backup the pre-copied file no matter what

                                    if (File.Exists(_CopyLocation))
                                        File.Copy(_CopyLocation, GetDataLocation(Literal.CoreReplace(_Copy[1])), bool.Parse(_Copy[2]));

                                    break;
                                }

                                // Creates a list of phrases to ignore when iterating.
                                case string x when x.StartsWith("Ignore("):
                                {
                                    // Deserialise 'Ignore' parameter
                                    _ignoreList = Lua.DeserialiseParameterList("Ignore", line, false).ToList();

                                    break;
                                }

                                // Creates a list of phrases to search for when iterating.
                                case string x when x.StartsWith("Search("):
                                {
                                    // Deserialise 'Search' parameter
                                    _searchList = Lua.DeserialiseParameterList("Search", line, false).ToList();

                                    break;
                                }

                                // Adds a Lua parameter.
                                case string x when x.StartsWith("ParameterAdd("):
                                {
                                    // Deserialise 'ParameterAdd' parameter
                                    string[] _ParameterAdd = Lua.DeserialiseParameterList("ParameterAdd", line, false);

                                    // Append the location to the active path
                                    string _ParameterAddLocation = GetDataLocation(Literal.CoreReplace(_ParameterAdd[0]));

                                    // Add parameters in a single file.
                                    if (File.Exists(_ParameterAddLocation))
                                        ParameterAdd(_ParameterAddLocation, _ParameterAdd[1], _ParameterAdd[2]);

                                    // Add parameters recursively.
                                    else if (Directory.Exists(_ParameterAddLocation))
                                        foreach (string luaData in Directory.GetFiles(_ParameterAddLocation, "*.lub", SearchOption.TopDirectoryOnly))
                                            if (!_ignoreList.Any(Path.GetFileName(luaData).Contains))
                                            {
                                                if (_searchList.Count != 0 && !_searchList.Any(Path.GetFileName(luaData).Contains)) continue;
                                                ParameterAdd(luaData, _ParameterAdd[1], _ParameterAdd[2]);
                                            }

                                    break;
                                }

                                // Edits a Lua parameter.
                                case string x when x.StartsWith("ParameterEdit("):
                                {
                                    // Deserialise 'ParameterEdit' parameter
                                    string[] _ParameterEdit = Lua.DeserialiseParameterList("ParameterEdit", line, false);

                                    // Append the location to the active path
                                    string _ParameterEditLocation = GetDataLocation(Literal.CoreReplace(_ParameterEdit[0]));

                                    // Edit parameters in a single file.
                                    if (File.Exists(_ParameterEditLocation))
                                        ParameterEdit(_ParameterEditLocation, _ParameterEdit[1], _ParameterEdit[2]);

                                    // Edit parameters recursively.
                                    else if (Directory.Exists(_ParameterEditLocation))
                                        foreach (string luaData in Directory.GetFiles(_ParameterEditLocation, "*.lub", SearchOption.TopDirectoryOnly))
                                            if (!_ignoreList.Any(Path.GetFileName(luaData).Contains))
                                            {
                                                if (_searchList.Count != 0 && !_searchList.Any(Path.GetFileName(luaData).Contains)) continue;
                                                ParameterEdit(luaData, _ParameterEdit[1], _ParameterEdit[2]);
                                            }

                                    break;
                                }

                                
                                // Removes all instances of a parameter from a Lua file.
                                case string x when x.StartsWith("ParameterErase("):
                                {
                                    // Deserialise 'ParameterErase' parameter
                                    string[] _ParameterErase = Lua.DeserialiseParameterList("ParameterErase", line, false);

                                    // Append the location to the active path
                                    string _ParameterEraseLocation = GetDataLocation(Literal.CoreReplace(_ParameterErase[0]));

                                    // Edit parameters in a single file.
                                    if (File.Exists(_ParameterEraseLocation))
                                        ParameterErase(_ParameterEraseLocation, _ParameterErase[1]);

                                    // Edit parameters recursively.
                                    else if (Directory.Exists(_ParameterEraseLocation))
                                        foreach (string luaData in Directory.GetFiles(_ParameterEraseLocation, "*.lub", SearchOption.TopDirectoryOnly))
                                            if (!_ignoreList.Any(Path.GetFileName(luaData).Contains))
                                            {
                                                if (_searchList.Count != 0 && !_searchList.Any(Path.GetFileName(luaData).Contains)) continue;
                                                ParameterErase(luaData, _ParameterErase[1]);
                                            }

                                    break;
                                }

                                // Renames a Lua parameter.
                                case string x when x.StartsWith("ParameterRename("):
                                {
                                    // Deserialise 'ParameterRename' parameter
                                    string[] _ParameterRename = Lua.DeserialiseParameterList("ParameterRename", line, false);

                                    // Append the location to the active path
                                    string _ParameterRenameLocation = GetDataLocation(Literal.CoreReplace(_ParameterRename[0]));

                                    // Edit parameters in a single file.
                                    if (File.Exists(_ParameterRenameLocation))
                                        ParameterRename(_ParameterRenameLocation, _ParameterRename[1], _ParameterRename[2]);

                                    // Edit parameters recursively.
                                    else if (Directory.Exists(_ParameterRenameLocation))
                                        foreach (string luaData in Directory.GetFiles(_ParameterRenameLocation, "*.lub", SearchOption.TopDirectoryOnly))
                                            if (!_ignoreList.Any(Path.GetFileName(luaData).Contains))
                                            {
                                                if (_searchList.Count != 0 && !_searchList.Any(Path.GetFileName(luaData).Contains)) continue;
                                                ParameterRename(luaData, _ParameterRename[1], _ParameterRename[2]);
                                            }

                                    break;
                                }

                                // Adds an MST entry.
                                case string x when x.StartsWith("TextAdd("):
                                {
                                    // Deserialise 'TextAdd' parameter
                                    string[] _TextAdd = Lua.DeserialiseParameterList("TextAdd", line, false);

                                    // Append the location to the active path
                                    string _TextAddLocation = GetDataLocation(Literal.CoreReplace(_TextAdd[0]));

                                    // Edit text in a single file.
                                    if (File.Exists(_TextAddLocation))
                                        TextAdd(_TextAddLocation, _TextAdd[1], _TextAdd[2], _TextAdd[3]);

                                    // Edit text recursively.
                                    else if (Directory.Exists(_TextAddLocation))
                                        foreach (string mstData in Directory.GetFiles(_TextAddLocation, "*.mst", SearchOption.TopDirectoryOnly))
                                            if (!_ignoreList.Any(Path.GetFileName(mstData).Contains))
                                            {
                                                if (_searchList.Count != 0 && !_searchList.Any(Path.GetFileName(mstData).Contains)) continue;
                                                TextAdd(mstData, _TextAdd[1], _TextAdd[2], _TextAdd[3]);
                                            }

                                    break;
                                }

                                // Edits an MST entry.
                                case string x when x.StartsWith("TextEdit("):
                                {
                                    // Deserialise 'TextEdit' parameter
                                    string[] _TextEdit = Lua.DeserialiseParameterList("TextEdit", line, false);

                                    // Append the location to the active path
                                    string _TextEditLocation = GetDataLocation(Literal.CoreReplace(_TextEdit[0]));

                                    // Edit text in a single file.
                                    if (File.Exists(_TextEditLocation))
                                        TextEdit(_TextEditLocation, _TextEdit[1], _TextEdit[2], _TextEdit[3]);

                                    // Edit text recursively.
                                    else if (Directory.Exists(_TextEditLocation))
                                        foreach (string mstData in Directory.GetFiles(_TextEditLocation, "*.mst", SearchOption.TopDirectoryOnly))
                                            if (!_ignoreList.Any(Path.GetFileName(mstData).Contains))
                                            {
                                                if (_searchList.Count != 0 && !_searchList.Any(Path.GetFileName(mstData).Contains)) continue;
                                                TextEdit(mstData, _TextEdit[1], _TextEdit[2], _TextEdit[3]);
                                            }

                                    break;
                                }

                                // Replaces a string.
                                case string x when x.StartsWith("StringReplace("):
                                {
                                    // Deserialise 'StringReplace' parameter
                                    string[] _StringReplace = Lua.DeserialiseParameterList("StringReplace", line, false);

                                    // Append the location to the active path
                                    string _StringReplaceLocation = GetDataLocation(Literal.CoreReplace(_StringReplace[0]));

                                    // Edit text in a single file.
                                    if (File.Exists(_StringReplaceLocation))
                                        StringReplace(_StringReplaceLocation, _StringReplace[1], _StringReplace[2]);

                                    // Edit text recursively.
                                    else if (Directory.Exists(_StringReplaceLocation))
                                        foreach (string lubData in Directory.GetFiles(_StringReplaceLocation, "*.lub", SearchOption.TopDirectoryOnly))
                                            if (!_ignoreList.Any(Path.GetFileName(lubData).Contains))
                                            {
                                                if (_searchList.Count != 0 && !_searchList.Any(Path.GetFileName(lubData).Contains)) continue;
                                                StringReplace(lubData, _StringReplace[1], _StringReplace[2]);
                                            }

                                    break;
                                }

                                // Adds a PKG entry.
                                case string x when x.StartsWith("PackageAdd("):
                                {
                                    // Deserialise 'PackageAdd' parameter
                                    string[] _PackageAdd = Lua.DeserialiseParameterList("PackageAdd", line, false);

                                    // Append the location to the active path
                                    string _PackageAddLocation = GetDataLocation(Literal.CoreReplace(_PackageAdd[0]));

                                    // Edit text in a single file.
                                    if (File.Exists(_PackageAddLocation))
                                        PackageAdd(_PackageAddLocation, _PackageAdd[1], _PackageAdd[2], _PackageAdd[3]);

                                    // Edit text recursively.
                                    else if (Directory.Exists(_PackageAddLocation))
                                        foreach (string pkgData in Directory.GetFiles(_PackageAddLocation, "*.pkg", SearchOption.TopDirectoryOnly))
                                            if (!_ignoreList.Any(Path.GetFileName(pkgData).Contains))
                                            {
                                                if (_searchList.Count != 0 && !_searchList.Any(Path.GetFileName(pkgData).Contains)) continue;
                                                PackageAdd(pkgData, _PackageAdd[1], _PackageAdd[2], _PackageAdd[3]);
                                            }

                                    break;
                                }

                                // Edits a PKG entry.
                                case string x when x.StartsWith("PackageEdit("):
                                {
                                    // Deserialise 'PackageEdit' parameter
                                    string[] _PackageEdit = Lua.DeserialiseParameterList("PackageEdit", line, false);

                                    // Append the location to the active path
                                    string _PackageEditLocation = GetDataLocation(Literal.CoreReplace(_PackageEdit[0]));

                                    // Edit text in a single file.
                                    if (File.Exists(_PackageEditLocation))
                                        PackageEdit(_PackageEditLocation, _PackageEdit[1], _PackageEdit[2], _PackageEdit[3]);

                                    // Edit text recursively.
                                    else if (Directory.Exists(_PackageEditLocation))
                                        foreach (string pkgData in Directory.GetFiles(_PackageEditLocation, "*.pkg", SearchOption.TopDirectoryOnly))
                                            if (!_ignoreList.Any(Path.GetFileName(pkgData).Contains))
                                            {
                                                if (_searchList.Count != 0 && !_searchList.Any(Path.GetFileName(pkgData).Contains)) continue;
                                                PackageEdit(pkgData, _PackageEdit[1], _PackageEdit[2], _PackageEdit[3]);
                                            }

                                    break;
                                }

                                // Removes all instances of an entry from a PKG.
                                case string x when x.StartsWith("PackageErase("):
                                {
                                    // Deserialise 'PackageErase' parameter
                                    string[] _PackageErase = Lua.DeserialiseParameterList("PackageErase", line, false);

                                    // Append the location to the active path
                                    string _PackageEraseLocation = GetDataLocation(Literal.CoreReplace(_PackageErase[0]));

                                    // Edit text in a single file.
                                    if (File.Exists(_PackageEraseLocation))
                                        PackageErase(_PackageEraseLocation, _PackageErase[1], _PackageErase[2]);

                                    // Edit text recursively.
                                    else if (Directory.Exists(_PackageEraseLocation))
                                        foreach (string pkgData in Directory.GetFiles(_PackageEraseLocation, "*.pkg", SearchOption.TopDirectoryOnly))
                                            if (!_ignoreList.Any(Path.GetFileName(pkgData).Contains))
                                            {
                                                if (_searchList.Count != 0 && !_searchList.Any(Path.GetFileName(pkgData).Contains)) continue;
                                                PackageErase(pkgData, _PackageErase[1], _PackageErase[2]);
                                            }

                                    break;
                                }

                                // Repacks an archive from the temporary location created by BeginBlock().
                                case string x when x.StartsWith("EndBlock("):
                                {
                                    BackupFile(_archiveLocation); // Backup the pre-packed archive no matter what
                                    ModEngine.RepackARC(_archive, _archiveLocation);
                                    _archive = _archiveLocation = string.Empty; // Clear location cache

                                    break;
                                }
                            }
                        }
                    }
                }
#if !DEBUG
            } catch (Exception ex) {
                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Error] {name}\n{ex}");
                ModEngine.skipped.Add($"► {name} (check the debug log for more information)");
            }
#endif
        }

        private static void WriteNop(string[] paramArray, bool @virtual)
        {
            byte[] nopBytes = new byte[4] { 0x60, 0x00, 0x00, 0x00 }; // PowerPC NOP opcode

            int nopCount = @virtual ?
                           paramArray.Length == 2 ? Convert.ToInt32(paramArray[1]) : 1 : // NOP count is the second parameter for virtual
                           paramArray.Length == 3 ? Convert.ToInt32(paramArray[2]) : 1 ; // NOP count is the third parameter for physical

            int offset = @virtual ?
                         Bytes.GetPhysicalFromVirtual(Convert.ToInt32(paramArray[0], 16)) : // Virtual address calculation on first parameter
                         Convert.ToInt32(paramArray[1], 16);

            // Iterate through the opcode bytes
            for (int nop = 0; nop < nopCount; nop++)
            {
                for (int i = 0; i < nopBytes.Length; i++)
                {
                    // write bytes
                    WriteByte(@virtual ? "Executable" : Literal.CoreReplace(paramArray[0]), offset, nopBytes[i]);

                    // increment offset
                    offset++;
                }
            }
        }

        /// <summary>
        /// Backs up the specified file to the Mod Manager's specification.
        /// </summary>
        /// <param name="filePath">File to back up.</param>
        private static void BackupFile(string filePath)
        {
            if (!File.Exists($"{filePath}_back") && File.Exists(filePath))
                File.Copy(filePath, $"{filePath}_back");
        }

        /// <summary>
        /// Gets the game directory or current archive and appends the specified location to the end.
        /// </summary>
        /// <param name="location">Path to append.</param>
        /// <returns>Assembled path.</returns>
        private static string GetDataLocation(string location)
        {
            if (_archive != string.Empty)
                return Path.Combine(_archive, location);
            else
                return Path.Combine(Path.GetDirectoryName(Properties.Settings.Default.Path_GameExecutable), location);
        }

        /// <summary>
        /// Encrypts the game executable.
        /// </summary>
        public static void EncryptExecutable()
        {
            string gameExecutable = Properties.Settings.Default.Path_GameExecutable,
                   system         = Literal.System(gameExecutable);

            BackupFile(gameExecutable);
            if (system == "Xbox 360") XEX.Encrypt(gameExecutable);
            else if (system == "PlayStation 3") EBOOT.Encrypt(gameExecutable);
            decrypted = false;
        }

        /// <summary>
        /// Writes a byte to the specified offset in a file.
        /// </summary>
        /// <param name="location">File</param>
        /// <param name="offset">Hexadecimal offset</param>
        /// <param name="_byte">Final byte</param>
        private static void WriteByte(string location, long offset, byte _byte)
        {
            if (location == "Executable") location = Properties.Settings.Default.Path_GameExecutable;
            else location = GetDataLocation(location); // Append the location to the active path
            BackupFile(location); // Backup the pre-modified archive no matter what

            if (File.Exists(location))
            {
                using (FileStream stream = File.Open(location, FileMode.Open, FileAccess.Write))
                {
                    stream.Position = offset;
                    stream.WriteByte(_byte);
                }
            }
        }

        /// <summary>
        /// Adds a Lua parameter.
        /// </summary>
        /// <param name="location">File</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="value">Final value</param>
        private static void ParameterAdd(string location, string parameter, string value)
        {
            DecompileLua(location);
            value = value.Replace("\\\"", "\"");
            List<string> scriptList = File.ReadAllLines(location).ToList();
            scriptList.Add($"{parameter} = {value}");
            File.WriteAllLines(location, scriptList);
        }

        /// <summary>
        /// Edits a Lua parameter.
        /// </summary>
        /// <param name="location">File</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="value">Final value</param>
        private static void ParameterEdit(string location, string parameter, string value)
        {
            DecompileLua(location);
            string[] script = File.ReadAllLines(location);
            int lineCount = 0;

            value = value.Replace("\\\"", "\"");
            foreach (string line in script)
            {
                if (line.StartsWith(parameter))
                {
                    string[] split = line.Split(' ');
                    split[2] = value;
                    for (int i = 3; i < split.Count(); i++) split[i] = string.Empty;
                    script[lineCount] = string.Join(" ", split);
                    break;
                }

                lineCount++;
            }

            File.WriteAllLines(location, script);
        }

        /// <summary>
        /// Removes all instances of a parameter from a Lua file.
        /// </summary>
        /// <param name="location">File</param>
        /// <param name="parameter">Parameter</param>
        private static void ParameterErase(string location, string parameter)
        {
            DecompileLua(location);
            List<string> script = File.ReadAllLines(location).ToList();
            List<string> editedScript = File.ReadAllLines(location).ToList();
            int lineCount = 0;

            foreach (string line in script) {
                if (line.Contains(parameter)) editedScript.RemoveAt(lineCount);
                lineCount++;
            }

            File.WriteAllLines(location, editedScript);
        }

        /// <summary>
        /// Renames a Lua parameter.
        /// </summary>
        /// <param name="location">File</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="_new">Final value</param>
        private static void ParameterRename(string location, string parameter, string _new)
        {
            DecompileLua(location);
            string[] script = File.ReadAllLines(location);
            int lineCount = 0;

            foreach (string line in script)
            {
                if (line.StartsWith(parameter))
                {
                    string[] split = line.Split(' ');
                    split[0] = _new;
                    script[lineCount] = string.Join(" ", split);
                    break;
                }

                lineCount++;
            }

            File.WriteAllLines(location, script);
        }

        /// <summary>
        /// Adds an MST entry.
        /// </summary>
        /// <param name="location">File</param>
        /// <param name="name">Entry name</param>
        /// <param name="placeholder">Entry placeholder</param>
        /// <param name="text">Entry text</param>
        private static void TextAdd(string location, string name, string placeholder, string text)
        {
            MessageTable mst = new MessageTable(location);

            var entry = new MessageTable.Message
            {
                Name = name,
                Text = text,
                Placeholder = placeholder
            };

            mst.Entries.Add(entry);

            mst.Save();
        }

        /// <summary>
        /// Edits an MST entry.
        /// </summary>
        /// <param name="location">File</param>
        /// <param name="name">Entry name</param>
        /// <param name="placeholder">Entry placeholder</param>
        /// <param name="text">Entry text</param>
        private static void TextEdit(string location, string name, string placeholder, string text)
        {
            MessageTable mst = new MessageTable(location);

            bool entryFound = false;
            for (int i = 0; i < mst.Entries.Count; i++)
            {
                if (mst.Entries[i].Name == name)
                {
                    entryFound = true;
                    mst.Entries[i].Text = text;
                    mst.Entries[i].Placeholder = placeholder;
                }
            }

            // If the entry doesn't exist, create a new one
            if (!entryFound)
            {
                var newEntry = new MessageTable.Message
                {
                    Name = name,
                    Text = text,
                    Placeholder = placeholder
                };

                mst.Entries.Add(newEntry);
            }

            mst.Save();
        }

        /// <summary>
        /// Replaces a string.
        /// </summary>
        /// <param name="location">File</param>
        /// <param name="_string">String to replace</param>
        /// <param name="_new">Final value</param>
        private static void StringReplace(string location, string _string, string _new)
        {
            DecompileLua(location);

            _string = _string.Replace("\\n", Environment.NewLine);
            _new = _new.Replace("\\n", Environment.NewLine);

            File.WriteAllText(location, File.ReadAllText(location).Replace(_string, _new));
        }

        /// <summary>
        /// Adds a PKG entry.
        /// </summary>
        /// <param name="location">File</param>
        /// <param name="_type">Entry type</param>
        /// <param name="friendlyName">Entry name</param>
        /// <param name="filePath">Entry reference</param>
        private static void PackageAdd(string location, string _type, string friendlyName, string filePath)
        {
            AssetPackage pkg = new AssetPackage(location);

            foreach (var type in pkg.Types)
            {
                if (type.Name == _type)
                {
                    var file = new AssetPackage.AssetFile
                    {
                        File = filePath,
                        Name = friendlyName
                    };

                    type.Files.Add(file);
                }
            }

            pkg.Save();
        }

        /// <summary>
        /// Edits a PKG entry.
        /// </summary>
        /// <param name="location">File</param>
        /// <param name="_type">Entry type</param>
        /// <param name="friendlyName">Entry name</param>
        /// <param name="filePath">Entry reference</param>
        private static void PackageEdit(string location, string _type, string friendlyName, string filePath)
        {
            AssetPackage pkg = new AssetPackage(location);

            foreach (var type in pkg.Types)
            {
                if (type.Name == _type)
                {
                    bool friendlyNameFound = false;

                    for (int i = 0; i < type.Files.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            // Replace file path if the friendly name exists
                            if (type.Files[i].Name == friendlyName)
                            {
                                friendlyNameFound = true;
                                type.Files[i].File = filePath;
                            }
                        }
                        else
                        {
                            // Replace file path if the friendly name exists
                            if (type.Files[i].Name == friendlyName)
                            {
                                friendlyNameFound = true;
                                type.Files.RemoveAt(i);
                            }
                        }
                    }

                    // If the friendly name doesn't exist, create a new reference
                    if (!friendlyNameFound)
                    {
                        var newFile = new AssetPackage.AssetFile
                        {
                            File = filePath,
                            Name = friendlyName
                        };

                        type.Files.Add(newFile);
                    }
                }
            }

            pkg.Save();
        }

        /// <summary>
        /// Removes all instances of an entry from a PKG.
        /// </summary>
        /// <param name="location">File</param>
        /// <param name="_type">Entry type</param>
        /// <param name="friendlyName">Entry name</param>
        private static void PackageErase(string location, string _type, string friendlyName)
        {
            AssetPackage pkg = new AssetPackage(location);

            foreach (var type in pkg.Types)
            {
                if (type.Name == _type)
                {
                    for (int i = 0; i < type.Files.Count; i++)
                    {
                        if (type.Files[i].Name == friendlyName)
                        {
                            type.Files.RemoveAt(i);
                        }
                    }
                }
            }

            pkg.Save();
        }

        /// <summary>
        /// Decompiles a Lua script.
        /// </summary>
        /// <param name="_file">File</param>
        public static void DecompileLua(string _file)
        {
            string[] readText = File.ReadAllLines(_file); //Read the Lub into an array

            if (readText[0].Contains("LuaP"))
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "java.exe";
                    process.StartInfo.Arguments = $"-jar \"{Program.unlub}\" \"{_file}\"";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.CreateNoWindow = true;

                    StringBuilder outputBuilder = new StringBuilder();
                    process.OutputDataReceived += (s, e) => { if (e.Data != null) outputBuilder.AppendLine(e.Data); };

                    process.Start();
                    process.BeginOutputReadLine();
                    process.WaitForExit();

                    File.WriteAllText(_file, outputBuilder.ToString());
                }
            }
        }
    }

    class TweakEngine
    {
        /// <summary>
        /// Apply the specified tweaks.
        /// </summary>
        /// <param name="rush">Required for status change</param>
        public static void ApplyTweaks(RushInterface rush) {
            string gameDirectory = Path.GetDirectoryName(Properties.Settings.Default.Path_GameExecutable);
            string[] files = Directory.GetFiles(gameDirectory, "*.arc", SearchOption.AllDirectories);
            string system = Literal.Core(Properties.Settings.Default.Path_GameExecutable);
            string tweak = string.Empty;

            // Define short variables to properties
            int renderer       = Properties.Settings.Default.Tweak_Renderer,
                reflections    = Properties.Settings.Default.Tweak_Reflections,
                antiAliasing   = Properties.Settings.Default.Tweak_AntiAliasing,
                cameraType     = Properties.Settings.Default.Tweak_CameraType;

            decimal cameraHeight   = Properties.Settings.Default.Tweak_CameraHeight,
                    cameraDistance = Properties.Settings.Default.Tweak_CameraDistance,
                    hammerRange    = Properties.Settings.Default.Tweak_AmyHammerRange,
                    beginWithRings = Properties.Settings.Default.Tweak_BeginWithRings,
                    fieldOfView    = Properties.Settings.Default.Tweak_FieldOfView;

            bool forceMSAA        = Properties.Settings.Default.Tweak_ForceMSAA;

            // Field of View
            if (fieldOfView != 90 && system == "xenon") {
                string xex = Path.Combine(gameDirectory, "default.xex"); // Location of the XEX

                if (!File.Exists($"{xex}_back"))
                    File.Copy(xex, $"{xex}_back", true);

                rush.Status = $"Tweaking Field of View...";
                XEX.Decrypt(xex); // Decrypt the XEX to be able to modify it properly
                XEX.FieldOfView(xex, fieldOfView); // Set FOV
            }

            foreach (string archive in files) {
                if (Path.GetFileName(archive) == "cache.arc") {
                    int proceed = 0;

                    if (renderer != 0)         proceed++;
                    if (reflections != 1)      proceed++;
                    if (antiAliasing != 0)     proceed++;
                    if (forceMSAA)             proceed++;
                    if (cameraType != 0)       proceed++;
                    if (cameraDistance != 650) proceed++;

                    if (proceed != 0) {
                        if (!File.Exists($"{archive}_back"))
                            File.Copy(archive, $"{archive}_back", true);

                        // Unpack archive to temporary location
                        tweak = ModEngine.UnpackARC(archive, Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()));

                        // Default
                        if (renderer == 0) {
                            // Force MSAA
                            if (forceMSAA) {
                                rush.Status = $"Tweaking Anti-Aliasing...";
                                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Tweak] <cache.arc> Set Anti-Aliasing to {antiAliasing}...");
                                MSAA(Path.Combine(tweak, $"{system}\\scripts\\render\\"), antiAliasing, SearchOption.TopDirectoryOnly, 0);
                            }
                        }

                        // Optimised
                        else if (renderer == 1) {
                            rush.Status = $"Tweaking Renderer...";
                            Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Tweak] <cache.arc> Set renderer to Optimised...");
                            File.WriteAllBytes(Path.Combine(tweak, $"{system}\\scripts\\render\\core\\render_main.lub"), Properties.Resources.optimised_render_main);
                        }

                        // Destructive
                        else if (renderer == 2) {
                            rush.Status = $"Tweaking Renderer...";
                            Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Tweak] <cache.arc> Set renderer to Destructive...");
                            File.WriteAllBytes(Path.Combine(tweak, $"{system}\\scripts\\render\\render_gamemode.lub"),   Properties.Resources.vulkan_render_gamemode);
                            File.WriteAllBytes(Path.Combine(tweak, $"{system}\\scripts\\render\\render_title.lub"),      Properties.Resources.vulkan_render_title);
                            File.WriteAllBytes(Path.Combine(tweak, $"{system}\\scripts\\render\\core\\render_main.lub"), Properties.Resources.vulkan_render_main);
                        }

                        // Cheap
                        else if (renderer == 3) {
                            rush.Status = $"Tweaking Renderer...";
                            Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Tweak] <cache.arc> Set renderer to Cheap...");
                            File.WriteAllBytes(Path.Combine(tweak, $"{system}\\scripts\\render\\render_gamemode.lub"), Properties.Resources.render_cheap);
                        }

                        // Reflections
                        if (reflections != 1) {
                            rush.Status = $"Tweaking Reflections...";
                            Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Tweak] <cache.arc> Set reflection resolution to {reflections}...");
                            Reflections(Path.Combine(tweak, $"{system}\\scripts\\render\\core\\render_reflection.lub"), reflections);
                        }

                        if (system == "ps3") {
                            // Camera Type
                            if (cameraType != 0) {
                                rush.Status = $"Tweaking Camera...";
                                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Tweak] <cache.arc> Set camera type to {cameraType}...");
                                CameraType(Path.Combine(tweak, $"{system}\\cameraparam.lub"), cameraType, fieldOfView);
                            }

                            // Camera Distance
                            if (cameraDistance != 650) {
                                rush.Status = $"Tweaking Camera...";
                                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Tweak] <cache.arc> Set camera distance to {cameraDistance}...");
                                CameraDistance(Path.Combine(tweak, $"{system}\\cameraparam.lub"), (int)cameraDistance);
                            }
                        }

                        // Repack archive as tweak
                        ModEngine.RepackARC(tweak, archive);
                    }
                } else if (Path.GetFileName(archive) == "scripts.arc") {
                    int proceed = 0;

                    if (antiAliasing != 0)  proceed++;
                    if (forceMSAA)          proceed++;

                    if (proceed != 0) {
                        if (!File.Exists($"{archive}_back"))
                            File.Copy(archive, $"{archive}_back", true);

                        // Unpack archive to temporary location
                        tweak = ModEngine.UnpackARC(archive, Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()));

                        // Default
                        if (Properties.Settings.Default.Tweak_Renderer == 0)
                            // Force MSAA
                            if (forceMSAA) {
                                rush.Status = $"Tweaking Anti-Aliasing...";
                                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Tweak] <scripts.arc> Set Anti-Aliasing to {antiAliasing}...");
                                MSAA(Path.Combine(tweak, $"{system}\\scripts\\render\\"), antiAliasing, SearchOption.AllDirectories, 1);
                            }

                        // Repack archive as tweak
                        ModEngine.RepackARC(tweak, archive);
                    }
                } else if (Path.GetFileName(archive) == "game.arc") {
                    int proceed = 0;

                    if (cameraType != 0)       proceed++;
                    if (cameraDistance != 650) proceed++;

                    if (proceed != 0) {
                        if (!File.Exists($"{archive}_back"))
                            File.Copy(archive, $"{archive}_back", true);

                        // Unpack archive to temporary location
                        tweak = ModEngine.UnpackARC(archive, Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()));

                        if (system == "xenon") {
                            // Camera Type
                            if (cameraType != 0) {
                                rush.Status = $"Tweaking Camera...";
                                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Tweak] <game.arc> Set camera type to {cameraType}...");
                                CameraType(Path.Combine(tweak, $"{system}\\cameraparam.lub"), cameraType, fieldOfView);
                            }

                            // Camera Distance
                            if (cameraDistance != 650) {
                                rush.Status = $"Tweaking Camera...";
                                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Tweak] <game.arc> Set camera distance to {cameraDistance}...");
                                CameraDistance(Path.Combine(tweak, $"{system}\\cameraparam.lub"), (int)cameraDistance);
                            }
                        }

                        // Repack archive as tweak
                        ModEngine.RepackARC(tweak, archive);
                    }
                } else if (Path.GetFileName(archive) == "player.arc") {
                    int proceed = 0;

                    if (cameraHeight != 70)  proceed++;
                    if (hammerRange != 50)   proceed++;
                    if (beginWithRings != 0) proceed++;

                    if (proceed != 0) {
                        if (!File.Exists($"{archive}_back"))
                            File.Copy(archive, $"{archive}_back", true);

                        // Unpack archive to temporary location
                        tweak = ModEngine.UnpackARC(archive, Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()));

                        // Tokyo Game Show
                        if (cameraType == 1) {
                            rush.Status = $"Tweaking Camera...";
                            Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Tweak] <player.arc> Set camera type to {cameraType}...");
                            CameraType(Path.Combine(tweak, $"{system}\\player\\common.lub"), cameraType, fieldOfView);
                        }

                        // Camera Height
                        if (cameraHeight != 70) {
                            rush.Status = $"Tweaking Camera...";
                            Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Tweak] <player.arc> Set camera height to {cameraHeight}...");
                            CameraHeight(Path.Combine(tweak, $"{system}\\player\\common.lub"), cameraHeight);
                        }

                        // Amy's Hammer Range
                        if (hammerRange != 50) {
                            rush.Status = $"Tweaking Characters...";
                            Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Tweak] <player.arc> Set Amy's hammer range to {hammerRange}...");
                            HammerRange(Path.Combine(tweak, $"{system}\\player\\amy.lub"), hammerRange);
                        }

                        if (beginWithRings != 0) {
                            rush.Status = $"Tweaking Characters...";
                            Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Tweak] <player.arc> Set default Ring count to {beginWithRings}...");
                            BeginWithRings(Path.Combine(tweak, $"{system}\\player\\"), beginWithRings);
                        }

                        // Repack archive as tweak
                        ModEngine.RepackARC(tweak, archive);
                    }
                }
            }
        }

        private static void MSAA(string directoryRoot, int MSAA, SearchOption searchOption, int arcSource) {
#if !DEBUG
            try {
#endif
                string[] files = Directory.GetFiles(directoryRoot, "*.lub", searchOption);

                foreach (var lub in files) {

                    if (Path.GetFileName(lub) == "render_utility.lub") {
                        PatchEngine.DecompileLua(lub);

                        List<string> editedLua = File.ReadAllLines(lub).ToList();

                        if (MSAA == 0)      editedLua.Add("MSAAType = \"2x\"");
                        else if (MSAA == 1) editedLua.Add("MSAAType = \"4x\"");
                        File.WriteAllLines(lub, editedLua);
                    } else if (arcSource == 0 && Path.GetFileName(lub) != "render_event.lub")
                        {
                            continue;
                        }
                    else
                        {
                        PatchEngine.DecompileLua(lub);

                        string[] editedLua = File.ReadAllLines(lub);
                        int lineNum = 0;
                        int modified = 0;

                        foreach (string line in editedLua) {
                            if (line.Contains("MSAAType")) {
                                string[] tempLine = line.Split(' ');
                                if (MSAA == 0)      tempLine[2] = "\"2x\"";
                                else if (MSAA == 1) tempLine[2] = "\"4x\"";
                                editedLua[lineNum] = string.Join(" ", tempLine);
                                modified++;
                            }
                            lineNum++;
                        }
                        if (modified != 0) File.WriteAllLines(lub, editedLua);
                    }
                }
#if !DEBUG
            } catch (Exception ex) {
                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Error] MSAA\n{ex}");
                ModEngine.skipped.Add("► MSAA (check the debug log for more information)");
            }
#endif
        }

        private static void Reflections(string directoryRoot, int scale) {
#if !DEBUG
            try {
#endif
                PatchEngine.DecompileLua(directoryRoot);
                string[] editedLua = File.ReadAllLines(directoryRoot);
                int lineNum = 0;

                foreach (string line in editedLua) {
                    if (line.StartsWith("EnableReflection")) {
                        string[] tempLine = line.Split(' ');
                        if (scale == 0)
                            tempLine[2] = "false";
                        else
                            tempLine[2] = "true";
                        editedLua[lineNum] = string.Join(" ", tempLine);
                    }

                    if (line.StartsWith("  texture_width") || line.StartsWith("  texture_height")) {
                        string[] tempLine = line.Split(' ');
                        if (scale == 1)
                            tempLine[7] = "4";
                        else if (scale == 2)
                            tempLine[7] = "2";
                        else if (scale == 3)
                            tempLine[6] = tempLine[7] = string.Empty;
                        editedLua[lineNum] = string.Join(" ", tempLine);
                    }
                    lineNum++;
                }
                File.WriteAllLines(directoryRoot, editedLua);
#if !DEBUG
            } catch (Exception ex) {
                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Error] Reflections\n{ex}");
                ModEngine.skipped.Add("► Reflections (check the debug log for more information)");
            }
#endif
        }

        private static void CameraType(string directoryRoot, int type, decimal fov) {
#if !DEBUG
            try {
#endif
                PatchEngine.DecompileLua(directoryRoot);
                string[] editedLua = File.ReadAllLines(directoryRoot);
                int lineNum = 0;

                foreach (string line in editedLua) {
                    if (line.StartsWith("distance")) {
                        string[] tempLine = line.Split(' ');
                        if (type == 0)
                            tempLine[2] = "6.5"; //Retail
                        else if (type == 1)
                            if (fov > 90)
                                tempLine[2] = "3.5";
                            else
                                tempLine[2] = "4.5";
                        else if (type == 2)
                            tempLine[2] = "5.5"; //E3
                        editedLua[lineNum] = string.Join(" ", tempLine);
                    }
                    if (line.StartsWith("springK")) {
                        string[] tempLine = line.Split(' ');
                        if (type == 1)
                            if (fov > 90)
                                tempLine[2] = "0.325";
                            else
                                tempLine[2] = "0.225";
                        else
                            tempLine[2] = "0.98";
                        editedLua[lineNum] = string.Join(" ", tempLine);
                    }
                    if (line.StartsWith("altitude")) {
                        string[] tempLine = line.Split(' ');
                        if (type == 1)
                            tempLine[2] = "-15";
                        else
                            tempLine[2] = "15";
                        editedLua[lineNum] = string.Join(" ", tempLine);
                    }
                    if (line.StartsWith("az_driveK")) {
                        string[] tempLine = line.Split(' ');
                        if (type == 1)
                            tempLine[2] = "50000"; //TGS (32500 old)
                        else if(type == 2)
                            tempLine[2] = "690";
                        else
                            tempLine[2] = "3250";
                        editedLua[lineNum] = string.Join(" ", tempLine);
                    }
                    if (line.StartsWith("az_dampingK")) {
                        string[] tempLine = line.Split(' ');
                        if (type == 1)
                            tempLine[2] = "2500";
                        else if(type == 2)
                            tempLine[2] = "100";
                        else
                            tempLine[2] = "250";
                        editedLua[lineNum] = string.Join(" ", tempLine);
                    }
                    lineNum++;
                }
                File.WriteAllLines(directoryRoot, editedLua);
#if !DEBUG
            } catch (Exception ex) {
                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Error] Camera Type\n{ex}");
                ModEngine.skipped.Add("► Camera Type (check the debug log for more information)");
            }
#endif
        }

        private static void CameraDistance(string directoryRoot, int distance) {
#if !DEBUG
            try {
#endif
                PatchEngine.DecompileLua(directoryRoot);
                string[] editedLua = File.ReadAllLines(directoryRoot);
                int lineNum = 0;

                foreach (string line in editedLua) {
                    if (line.StartsWith("distance")) {
                        string[] tempLine = line.Split(' ');
                        tempLine[2] = decimal.Divide(distance, 100).ToString();
                        editedLua[lineNum] = string.Join(" ", tempLine);
                    }
                    lineNum++;
                }
                File.WriteAllLines(directoryRoot, editedLua); //Resave the Lua
#if !DEBUG
            } catch (Exception ex) {
                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Error] Camera Distance\n{ex}");
                ModEngine.skipped.Add("► Camera Distance (check the debug log for more information)");
            }
#endif
        }

        private static void CameraHeight(string directoryRoot, decimal height) {
#if !DEBUG
            try {
#endif
                PatchEngine.DecompileLua(directoryRoot);
                string[] editedLua = File.ReadAllLines(directoryRoot);
                int lineNum = 0;

                foreach (string line in editedLua) {
                    if (line.StartsWith("c_camera")) {
                        if (editedLua[lineNum].Contains("c_camera = { x ="))
                            editedLua[lineNum] = "c_camera = { x = 0 * meter, y = " + (height / 100) + " * meter, z = 0 * meter }";
                        else
                            editedLua[lineNum += 2] = $"  y = {height / 100} * meter,";
                    }
                    lineNum++;
                }
                File.WriteAllLines(directoryRoot, editedLua);
#if !DEBUG
            } catch (Exception ex) {
                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Error] Camera Height\n{ex}");
                ModEngine.skipped.Add("► Camera Height (check the debug log for more information)");
            }
#endif
        }

        private static void HammerRange(string directoryRoot, decimal range) {
#if !DEBUG
            try {
#endif
                PatchEngine.DecompileLua(directoryRoot);
                string[] editedLua = File.ReadAllLines(directoryRoot);
                int lineNum = 0;

                foreach (string line in editedLua) {
                    string[] tempLine = line.Split(' ');
                    if (line.StartsWith("c_hammer_head")) {
                        if (editedLua[lineNum].Contains("c_hammer_head"))
                            editedLua[lineNum] = $"c_hammer_head = {range / 100} * meter";
                    }
                    lineNum++;
                }
                File.WriteAllLines(directoryRoot, editedLua);
#if !DEBUG
            } catch (Exception ex) {
                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Error] Amy's Hammer Range\n{ex}");
                ModEngine.skipped.Add("► Amy's Hammer Range (check the debug log for more information)");
            }
#endif
        }

        private static void BeginWithRings(string directoryRoot, decimal rings) {
#if !DEBUG
            try {
#endif
                foreach (string lub in Directory.GetFiles(directoryRoot, "*.lub", SearchOption.AllDirectories)) {
                    PatchEngine.DecompileLua(lub);
                    List<string> editedLua = File.ReadAllLines(lub).ToList();

                    for (int i = 0; i < editedLua.Count; i++)
                        if (editedLua[i].Contains("c_default_ring")) editedLua.RemoveAt(i);

                    editedLua.Add($"c_default_ring = {rings}");
                    File.WriteAllLines(lub, editedLua);
                }
#if !DEBUG
            } catch (Exception ex) {
                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Error] Begin with Rings\n{ex}");
                ModEngine.skipped.Add("► Begin with Rings (check the debug log for more information)");
            }
#endif
        }
    }

    class EBOOT
    {
        public static void Encrypt(string filepath) {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = Program.scetool,
                Arguments = $"-0 SELF -1 FALSE -s FALSE -2 0A -3 1010000001000003 -4 01000002 -5 APP -A 0001000000000000 -6 0003005500000000 -9 00000000000000000000000000000000000000000000003B0000000100040000 -e \"{filepath}\" \"{filepath}\"", //3.55 keys
                WorkingDirectory = Path.GetDirectoryName(Program.scetool)
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        public static void Decrypt(string filepath) {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = Program.scetool,
                Arguments = $"-d \"{filepath}\" \"{filepath}\"",
                WorkingDirectory = Path.GetDirectoryName(Program.scetool)
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
    }

    class XEX
    {
        public static void Encrypt(string filepath) {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = Program.XexTool,
                Arguments = $"-e e \"{filepath}\""
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        public static void Decrypt(string filepath) {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = Program.XexTool,
                Arguments = $"-e u -c b \"{filepath}\""
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        public static void FieldOfView(string filepath, decimal fov) {
#if !DEBUG
            try {
#endif
                using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Write)) {
                    stream.Position = 0x4F4C;
                    byte[] fov32 = BitConverter.GetBytes(decimal.ToSingle(fov));
                    for (int i = fov32.Length - 1; i >= 0; i--) stream.WriteByte(fov32[i]);
                }
#if !DEBUG
            } catch (Exception ex) {
                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Error] Field of View\n{ex}");
                ModEngine.skipped.Add("► Field of View (check the debug log for more information)");
            }
#endif
        }
    }

    public static class ZIP
    {
        /// <summary>
        /// Extracts a ZIP file.
        /// </summary>
        public static void InstallFromZip(string ZipPath, string location) {
            try {
                if (File.Exists(ZipPath)) {
                    // Extracts all contents inside of the zip file
                    ZipFile.ExtractToDirectory(ZipPath, location);
                } else {
                    UnifyMessenger.UnifyMessage.ShowDialog($"Failed to extract '{Path.GetFileName(ZipPath)}'...",
                                                           "Extract failed...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { InstallFromCustomArchive(ZipPath, location); }
        }

        /// <summary>
        /// Extracts a ZIP file with extra parameters.
        /// </summary>
        public static void ExtractToDirectory(this ZipArchive archive, string destinationDirectoryName, bool overwrite) {
            if (!overwrite) {
                archive.ExtractToDirectory(destinationDirectoryName);
                return;
            }

            foreach (ZipArchiveEntry file in archive.Entries) {
                string completeFileName = Path.Combine(destinationDirectoryName, file.FullName);
                string directory = Path.GetDirectoryName(completeFileName);

                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                if (file.Name != "")
                    if (Path.GetFileName(completeFileName) != Path.GetFileName(Application.ExecutablePath))
                        file.ExtractToFile(completeFileName, true);
                    else
                        file.ExtractToFile(Path.Combine(destinationDirectoryName, $"{Application.ExecutablePath}.new"), true);
            }
        }

        /// <summary>
        /// Extracts a ZIP file containing patches.
        /// </summary>
        public static void ExtractPatches(this ZipArchive archive)
        {
            foreach (ZipArchiveEntry file in archive.Entries)
            {
                if (!string.IsNullOrEmpty(file.Name) && Path.GetExtension(file.Name) == ".mlua")
                {
                    file.ExtractToFile(Path.Combine(Program.Patches, file.FullName).Replace("Sonic-06-Mod-Manager-Patches-master", ""), true);
                }
            }
        }

        /// <summary>
        /// Extracts 7Z/RAR files with 7-Zip.
        /// </summary>
        public static void InstallFromCustomArchive(string ArchivePath, string location) {
            if (File.Exists(ArchivePath)) {
                // Extracts the archive to the temp folder.
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = Program._7Zip,
                    Arguments = $"x -y -o\"{location}\" \"{ArchivePath}\""
                };
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
            } else {
                UnifyMessenger.UnifyMessage.ShowDialog($"Failed to extract '{Path.GetFileName(ArchivePath)}'...",
                                                       "Extract failed...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
