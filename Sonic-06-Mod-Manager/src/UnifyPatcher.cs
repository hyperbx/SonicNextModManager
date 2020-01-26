using System;
using System.IO;
using System.Linq;
using Unify.Messenger;
using Microsoft.Win32;
using Unify.Serialisers;
using Unify.Environment3;
using System.Diagnostics;
using Unify.Globalisation;
using System.Windows.Forms;
using System.IO.Compression;
using System.Collections.Generic;

// Sonic '06 Mod Manager is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2020 Knuxfan24 & HyperPolygon64

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
            string platform = INI.DeserialiseKey("Platform", mod); // Deserialise 'Platform' key
            bool merge = bool.Parse(INI.DeserialiseKey("Merge", mod)); // Deserialise 'Merge' key and parse as a Boolean value
            string[] custom = INI.DeserialiseKey("Custom", mod).Split(','); // Deserialise 'Custom' key
            string[] read_only = INI.DeserialiseKey("Read-only", mod).Split(','); // Deserialise 'Read-only' key
            
            //Skip the mod if the platform is invalid
            if ((Literal.System(Properties.Settings.Default.GameDirectory) == "Xbox 360" && platform == "PlayStation 3") ||
                (Literal.System(Properties.Settings.Default.GameDirectory) == "PlayStation 3" && platform == "Xbox 360")) {
                    skipped.Add($"► {name} (failed because the mod was not targeted for the {platform})");
                    return;
            }

            // Search for all files with specified LINQ filters
            List<string> files = Directory.GetFiles(Path.GetDirectoryName(mod), "*.*", SearchOption.AllDirectories)
                                .Where(s => s.EndsWith(".arc") ||
                                            s.EndsWith(".wmv") ||
                                            s.EndsWith(".xma") ||
                                            s.EndsWith("default.xex") ||
                                            s.EndsWith("EBOOT.BIN") ||
                                            s.EndsWith(".pam") ||
                                            s.EndsWith(".at3")).ToList();

            foreach (string file in files) {
                // Absolute file path (xenon/win32 and beyond)
                string filePath = file.Remove(0, Path.GetDirectoryName(mod).Length);

                // Absolute file path (from the mod) combined with the game directory
                string vanillaFilePath = Path.Combine(Path.GetDirectoryName(Properties.Settings.Default.GameDirectory), filePath.Substring(1));

                // Backup file path derived from the file about to be overwritten
                string targetFilePath = $"{vanillaFilePath}_back";

                // Checks if the processed file exists in the custom filesystem - if so, add to PKG preparation list
                if (custom.Contains(Path.GetFileName(file)) && Path.GetExtension(file) == ".arc") {
                    // If the absolute file path contains 'win32' - add to win32 PKG preparation list
                    if (filePath.Contains("win32")) win32pkg.Add(Path.GetFileName(file));

                    // If the absolute file path contains 'xenon' or 'ps3' - add to xenon/win32 PKG preparation list
                    else corepkg.Add(Path.GetFileName(file));
                }

                // Backup the original file
                if (File.Exists(vanillaFilePath) && !File.Exists(targetFilePath)) File.Copy(vanillaFilePath, targetFilePath, false);

                //Check if file should be merged
                if (Path.GetExtension(file) == ".arc" && merge && !read_only.Contains(Path.GetFileName(file)) && !custom.Contains(Path.GetFileName(file))) {
                    if (RushInterface._debug) Console.WriteLine($"Merging: {file}");
                    Merge(vanillaFilePath, file);
                } else { //If the file is not an archive or it shouldn't be merged, just copy it
                    if (RushInterface._debug) Console.WriteLine($"Copying: {file}");
                    File.Copy(file, vanillaFilePath, true);
                }

                // Generate custom filesystem in PKG if the lists are populated
                if (corepkg.Count != 0 || win32pkg.Count != 0) {
                    if (platform == "Xbox 360") CustomFilesystemPackage("xenon");
                    else if (platform == "PlayStation 3") CustomFilesystemPackage("ps3");
                    else {
                        skipped.Add($"► {name} (failed because the targeted platform was invalid)");
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Uninstalls all mods.
        /// </summary>
        public static void UninstallMods() {
            if (Properties.Settings.Default.GameDirectory != string.Empty ||
                File.Exists(Properties.Settings.Default.GameDirectory)) { // If the game directory is empty/doesn't exist, ignore request
                    // Search for all files with specified LINQ filters
                    List<string> files = Directory.GetFiles(Path.GetDirectoryName(Properties.Settings.Default.GameDirectory), "*.*", SearchOption.AllDirectories)
                                        .Where(s => s.EndsWith(".arc_back") ||
                                                    s.EndsWith(".arc_orig")).ToList();

                    foreach (string file in files) {
                        if (File.Exists(file.ToString().Remove(file.Length - 5))) {
                            if (RushInterface._debug) Console.WriteLine($"Removing: {file}");
                            File.Delete(file.ToString().Remove(file.Length - 5)); // Delete file with last five characters set to '_back' or '_orig'
                        }
                        File.Move(file, file.ToString().Remove(file.Length - 5)); // Remove last five characters ('_back' or '_orig')
                }
            }
        }

        /// <summary>
        /// Uninstalls user-made filesystems.
        /// </summary>
        public static void UninstallCustomFilesystem(ListView.ListViewItemCollection listViewItems) {
            if (Properties.Settings.Default.GameDirectory != string.Empty ||
                File.Exists(Properties.Settings.Default.GameDirectory)) { // If the game directory is empty/doesn't exist, ignore request
                    foreach (ListViewItem mod in listViewItems) {
                        string[] custom = INI.DeserialiseKey("Custom", mod.SubItems[6].Text).Split(','); // Deserialise 'Custom' key

                        if (custom[0] != string.Empty) { // Speeds things up a bit - ensures it's not checking a default null parameter
                            foreach (string file in custom) {
                                // Search for all files with filters from custom
                                List<string> files = Directory.GetFiles(Path.GetDirectoryName(Properties.Settings.Default.GameDirectory), file, SearchOption.AllDirectories).ToList();
                                
                                foreach (string customfile in files)
                                    try {
                                        if (RushInterface._debug) Console.WriteLine($"Removing: {file}");
                                        File.Delete(customfile); // If custom archive is found, erase...
                                    } catch { }
                            }
                        }
                    }
            }
        }

        /// <summary>
        /// Removes redirected save data.
        /// </summary>
        public static void UninstallSaves(ListView.ListViewItemCollection listViewItems) {
            if (Properties.Settings.Default.SaveData != string.Empty || File.Exists(Properties.Settings.Default.SaveData)) {
                foreach (ListViewItem mod in listViewItems) {
                    // Basically just to check 'SonicNextSaveData.bin' as a directory
                    string saveLocation = Path.GetDirectoryName(Path.GetDirectoryName(Properties.Settings.Default.SaveData));

                    // Deserialise 'Save' key
                    string savedata = INI.DeserialiseKey("Save", mod.SubItems[6].Text);

                    if (savedata != string.Empty) { // Speeds things up a bit - ensures it's not checking a default null parameter
                        if (Literal.Emulator(Properties.Settings.Default.GameDirectory) == "Xenia") {
                            string[] saves = Array.Empty<string>();

                            // Get all backup directories
                            if (Directory.Exists(saveLocation)) saves = Directory.GetDirectories(saveLocation, "SonicNextSaveData.bin_back", SearchOption.AllDirectories);

                            foreach (var dir in saves) {
                                // Original save data path
                                string saveFile = Path.Combine(dir.ToString().Remove(dir.Length - 5), Path.GetFileName(dir.ToString().Remove(dir.Length - 5)));

                                // Copy redirected save data back to the mod's directory (keeps user progress)
                                if (File.Exists(saveFile)) {
                                    Console.WriteLine($"Removing: {dir}");
                                    if (savedata != string.Empty) File.Copy(saveFile, Path.Combine(Path.GetDirectoryName(mod.SubItems[6].Text), "savedata.360"), true);
                                }

                                // Recursively erase redirected save data
                                if (Directory.Exists(dir.ToString().Remove(dir.Length - 5))) {
                                    Console.WriteLine($"Removing: {dir}");
                                    Directory.Delete(dir.ToString().Remove(dir.Length - 5), true);
                                }

                                // Restore original save data
                                Directory.Move(dir.ToString(), dir.ToString().Remove(dir.Length - 5));
                            }
                        } else if (Literal.Emulator(Properties.Settings.Default.GameDirectory) == "RPCS3") {
                            string[] saves = Array.Empty<string>();

                            // Original save data path
                            if (Directory.Exists(saveLocation)) saves = Directory.GetFiles(saveLocation, "SYS-DATA_back", SearchOption.AllDirectories);

                            foreach (var file in saves) {
                                string saveFile = Path.Combine(file.ToString().Remove(file.Length - 5), Path.GetFileName(file.ToString().Remove(file.Length - 5)));

                                // Copy redirected save data back to the mod's directory (keeps user progress)
                                if (File.Exists(saveFile)) {
                                    Console.WriteLine($"Removing: {file}");
                                    if (savedata != string.Empty) File.Copy(saveFile, Path.Combine(Path.GetDirectoryName(mod.SubItems[6].Text), "savedata.ps3"), true);
                                }

                                // Erase redirected save data
                                if (File.Exists(file.ToString().Remove(file.Length - 5))) {
                                    Console.WriteLine($"Removing: {file}");
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
        public static void CustomFilesystemPackage(string platform) { //Create a custom PKG based on all the custom arcs specified in mods
            string system = Path.Combine(Path.GetDirectoryName(Properties.Settings.Default.GameDirectory), platform, "archives", "system.arc");
            if (!File.Exists($"{system}_back"))
                File.Copy(system, $"{system}_back", true);
            string unpack = UnpackARC(system, Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()));

            // Decodes the PKG
            string directoryRoot = Path.Combine(unpack, $"system\\{platform}\\archive");
            PKG.PKGTool($"{directoryRoot}.pkg");
            List<string> basePKG = File.ReadAllLines($"{directoryRoot}.txt").ToList();

            // xenon/ps3 entries
            if (corepkg.Count != 0) {
                // Add new key to PKG (doesn't matter where, as long as it uses the same name)
                basePKG.Add("\"archive\"\n{");

                // Add entries to newly made key
                foreach (string arc in corepkg) basePKG.Add($"\t\"{Path.GetFileNameWithoutExtension(arc)}\" = \"archives/{arc}\";");

                // Finalise key
                basePKG.Add("}");
            }

            // win32 entries
            if (win32pkg.Count != 0) {
                // Add new key to PKG (doesn't matter where, as long as it uses the same name)
                basePKG.Add("\"archive_win32\"\n{");

                // Add entries to newly made key
                foreach (string arc in win32pkg) basePKG.Add($"\t\"{Path.GetFileNameWithoutExtension(arc)}\" = \"archives/{arc}\";");

                // Finalise key
                basePKG.Add("}");
            }

            File.WriteAllLines($"{directoryRoot}.txt", basePKG); //Save the edited text file

            //Encodes the PKG
            PKG.PKGTool($"{directoryRoot}.txt");
            RepackARC(unpack, system);

            //Clear lists
            corepkg.Clear();
            win32pkg.Clear();
        }

        /// <summary>
        /// Extracts an archive to a temporary location.
        /// </summary>
        public static string UnpackARC(string arc, string tempPath) {
            Directory.CreateDirectory(tempPath); // Create temporary location
            File.Copy(arc, Path.Combine(tempPath, Path.GetFileName(arc))); // Copy archive to temporary location

            // Extracts the archive in the temporary location
            var unpack = new ProcessStartInfo() {
                FileName = $"{Program.ApplicationData}\\Unify\\Tools\\arctool.exe",
                Arguments = $"-d \"{Path.Combine(tempPath, Path.GetFileName(arc))}\"",
                WorkingDirectory = $"{Program.ApplicationData}\\Unify\\Tools\\",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var Unpack = Process.Start(unpack);
            Unpack.WaitForExit();
            Unpack.Close();

            return tempPath;
        }

        /// <summary>
        /// Repacks an archive from a temporary location.
        /// </summary>
        public static string RepackARC(string arc, string output) {
            string tempPath = arc; // Location of directory to repack
            var tempData = new DirectoryInfo(tempPath);

            // Repacks the archive from the temporary location
            ProcessStartInfo repack = new ProcessStartInfo() {
                FileName = $"{Program.ApplicationData}\\Unify\\Tools\\arctool.exe",
                Arguments = $"-f -i \"{Path.Combine(tempPath, Path.GetFileNameWithoutExtension(output))}\" -c \"{output}\"",
                WorkingDirectory = $"{Program.ApplicationData}\\Unify\\Tools\\",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var Repack = Process.Start(repack);
            Repack.WaitForExit();
            Repack.Close();
            
            // Erases temporary repack data
            try {
                if (Directory.Exists(tempPath)) {
                    foreach (FileInfo file in tempData.GetFiles()) file.Delete();
                    foreach (DirectoryInfo directory in tempData.GetDirectories()) directory.Delete(true);
                }
            } catch { return tempPath; }

            return tempPath;
        }

        /// <summary>
        /// Merges two archives into a single archive.
        /// </summary>
        public static void Merge(string arc1, string arc2) {
            string tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()); // Defines the temporary path.
            Directory.CreateDirectory(tempPath);
            string unpack1 = UnpackARC(arc1, tempPath);
            ProcessStartInfo arctool;

            File.Copy(arc2, Path.Combine(tempPath, Path.GetFileName(arc2)), true); // Copies the input ARC to the temporary path.

            // Defines the arctool process.
            arctool = new ProcessStartInfo() {
                FileName = $"{Program.ApplicationData}\\Unify\\Tools\\arctool.exe",
                Arguments = $"-d \"{Path.Combine(tempPath, Path.GetFileName(arc2))}\"",
                WorkingDirectory = $"{Program.ApplicationData}\\Unify\\Tools\\",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var Unpack2 = Process.Start(arctool); // Unpacks the merge ARC.
            Unpack2.WaitForExit();

            File.Delete(Path.Combine(tempPath, Path.GetFileName(arc2))); // Deletes the temporary merge ARC.

            RepackARC(unpack1, arc1);
        }
    }

    class PatchEngine { }

    class PKG {

        /// <summary>
        /// Use the PKGTool to encode/decode the given file.
        /// </summary>
        public static void PKGTool(string filepath) {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo {
                FileName = $"{Program.ApplicationData}\\Unify\\Tools\\pkgtool.exe",
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = filepath
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            // Erase the TXT file once encoded as PKG
            if (Path.GetExtension(filepath) == ".txt") File.Delete(filepath);
        }

        /// <summary>
        /// Adds an entry to a specified PKG - should be used for patches.
        /// </summary>
        public static void AddEntry(string filepath, string directoryRoot, string key, string _event, string reference) {
            // Backs up the archive containing the PKG
            if (!File.Exists($"{filepath}_orig"))
                File.Copy(filepath, $"{filepath}_orig", true);

            // Extracts the archive containing the PKG
            string unpack = ModEngine.UnpackARC(filepath, Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()));

            // Decodes the PKG
            PKGTool($"{Path.Combine(unpack, directoryRoot)}.pkg");
            List<string> basePKG = File.ReadAllLines($"{Path.Combine(unpack, directoryRoot)}.txt").ToList();
            bool keyfound = false;
            int lineNum = 0;

            foreach (string line in basePKG) {
                // Look for the already existing key before adding a new one
                if (line.StartsWith($"\"{key}\"")) {
                    keyfound = true;
                    basePKG.Insert(lineNum + 2, $"\t\"{_event}\" = \"{reference}\";");
                    break;
                }
                lineNum++;
            }

            // Add new key to PKG if it doesn't exist already
            if (keyfound == false) {
                basePKG.Add($"\"{key}\"\n{"{"}");
                basePKG.Add($"\t\"{_event}\" = \"{reference}\";");
                basePKG.Add("}");
            }

            File.WriteAllLines($"{Path.Combine(unpack, directoryRoot)}.txt", basePKG); //Save the edited text file

            // Encodes the PKG
            PKGTool($"{Path.Combine(unpack, directoryRoot)}.txt");

            // Repacks the archive
            ModEngine.RepackARC(unpack, filepath);
        }
    }

    public static class ZIP
    {
        /// <summary>
        /// Extracts a ZIP file.
        /// </summary>
        /// <param name="ZipPath"></param>
        public static void InstallFromZip(string ZipPath) {
            try {
                // Extracts all contents inside of the zip file
                ZipFile.ExtractToDirectory(ZipPath, Properties.Settings.Default.ModsDirectory);
            } catch { InstallFrom7zArchive(ZipPath); }
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
        /// Requires 7-Zip to be installed.
        /// </summary>
        public static void InstallFrom7zArchive(string ArchivePath) {
            // Gets 7-Zip's Registry Key.
            var key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\7-Zip");
            // If null then try get it from the 64-bit Registry.
            if (key == null)
                key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                    .OpenSubKey("SOFTWARE\\7-Zip");
            // Checks if 7-Zip is installed by checking if the key and path value exists.
            if (key != null && key.GetValue("Path") is string path) {
                // Path to 7z.exe.
                string exe = Path.Combine(path, "7z.exe");

                // Extracts the archive to the temp folder.
                var psi = new ProcessStartInfo(exe, $"x \"{ArchivePath}\" -o \"{Properties.Settings.Default.ModsDirectory}\" -y");
                psi.CreateNoWindow = true;
                Process.Start(psi).WaitForExit(1000 * 60 * 5);

                key.Close();
            } else { InstallFromWinRAR(ArchivePath); }
        }

        /// <summary>
        /// Requires WinRAR to be installed.
        /// </summary>
        public static void InstallFromWinRAR(string ArchivePath) {
            // Gets WinRAR's Registry Key.
            var key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WinRAR");
            // If null then try to get it from the 64-bit registry.
            if (key == null)
                key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\WinRAR");
            if (key != null && key.GetValue("exe64") is string path) {
                // Extracts the archive to the temp folder.
                var psi = new ProcessStartInfo(path, $"x \"{ArchivePath}\" \"{Properties.Settings.Default.ModsDirectory}\"");
                psi.CreateNoWindow = true;
                Process.Start(psi).WaitForExit(1000 * 60 * 5);

                key.Close();

            } else {
                UnifyMessenger.UnifyMessage.ShowDialog("Failed to install from archive because 7-Zip and/or WinRAR is not installed.",
                                                       "I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
