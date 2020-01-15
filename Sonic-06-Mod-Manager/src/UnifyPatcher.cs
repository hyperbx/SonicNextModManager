using System;
using System.IO;
using System.Text;
using System.Linq;
using Unify.Tools;
using Unify.Messages;
using System.Diagnostics;
using Sonic_06_Mod_Manager;
using System.Collections.Generic;

// Project Unify is licensed under the MIT License:
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
    class ARC
    {
        public static readonly ModManager modManager = new ModManager(Array.Empty<string>());
        public static List<string> skippedMods = new List<string>() { };
        public static string targetArcPath = string.Empty; //Modded ARC File
        public static string origArcPath = string.Empty; //Original Game ARC File
        public static string arcPath = string.Empty; //Paths to ARC in the game files
        public static List<string> coreList = new List<string>() { }; //List of custom core (xenon/ps3) arcs to add to our PKG
        public static List<string> win32List = new List<string>() { }; //List of custom win32 arcs to add to our PKG

        public static void InstallMods(string modPath, string modName) {
            bool merge = false;
            string[] read_only = { };
            string platform = string.Empty;
            string[] custom = { };
            skippedMods.Clear();

            //Check if Mod is a Merge Mod and if it contains any read-only files.
            using (Stream configRead = File.Open(Path.Combine(modPath, "mod.ini"), FileMode.Open))
            using (StreamReader configFile = new StreamReader(configRead, Encoding.Default)) {
                string line;
                string entryValue;
                while ((line = configFile.ReadLine()) != null) {
                    if (line.StartsWith("Platform")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        platform = entryValue;
                    }
                    if (line.StartsWith("Merge")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        merge = bool.Parse(entryValue);
                    }
                    if (line.StartsWith("Custom")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        custom = entryValue.Split(',');
                    }
                    if (line.StartsWith("Read-only")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        read_only = entryValue.Split(',');
                    }
                }
            }

            //Return if platform is not the desired target
            if (platform == "Xbox 360" && Sonic_06_Mod_Manager.Properties.Settings.Default.emulatorSystem == 1)
                skippedMods.Add(ModsMessages.ex_IncorrectTarget(Path.GetFileName(modPath), "PlayStation 3"));
            if (platform == "PlayStation 3" && Sonic_06_Mod_Manager.Properties.Settings.Default.emulatorSystem == 0)
                skippedMods.Add(ModsMessages.ex_IncorrectTarget(Path.GetFileName(modPath), "Xbox 360"));

            List<string> files = Directory.GetFiles(modPath, "*.*", SearchOption.AllDirectories)
            .Where(s => s.EndsWith(".arc") ||
                        s.EndsWith(".wmv") ||
                        s.EndsWith(".xma") ||
                        s.EndsWith("default.xex") ||
                        s.EndsWith("EBOOT.BIN") ||
                        s.EndsWith(".pam") ||
                        s.EndsWith(".at3")).ToList();
            string[] directories = Directory.GetDirectories(modPath, "*.arc", SearchOption.AllDirectories);
            foreach (var dir in directories) files.Add(dir);

            foreach (var file in files) {
                arcPath = file.Remove(0, modPath.Length);
                if (arcPath.StartsWith(@"\")) //Needed due to Microsoft fucking Path.Combine when the string begins with a \
                    origArcPath = Path.Combine(Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory, arcPath.Substring(1));
                else
                    origArcPath = Path.Combine(Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory, arcPath);
                targetArcPath = $"{origArcPath}_back";

                //Build lists for custom PKG
                if (custom.Contains(Path.GetFileName(file)) && file.EndsWith(".arc")) {
                    if (arcPath.Contains("win32")) win32List.Add(Path.GetFileName(file));
                    else coreList.Add(Path.GetFileName(file));
                }

                if (file.EndsWith(".arc")) {
                    if (merge && !read_only.Contains(Path.GetFileName(file))) {
                        //Pass off to MergeARCs
                        Console.WriteLine("Merging: " + file);
                        if (File.Exists(origArcPath)) MergeARCs(origArcPath, file, origArcPath, false, string.Empty);
                        else if (custom.Contains(Path.GetFileName(file))) File.Copy(file, origArcPath);
                    } else {
                        try {
                            if (!File.Exists(targetArcPath)) {
                                //Copy a file if it isn't part of a merge mod or is marked as read-only.
                                Console.WriteLine("Copying: " + file);
                                if (!custom.Contains(Path.GetFileName(file))) File.Move(origArcPath, targetArcPath);
                                File.Copy(file, origArcPath);
                            } else {
                                //Skip the file if it needs to be copied but can't due a modded file already existing on its slot.
                                skippedMods.Add(ModsMessages.ex_SkippedMod(modName, Path.GetFileName(file)));
                            }
                        } catch (FileNotFoundException) { skippedMods.Add(ModsMessages.ex_SkippedModMissingFile(modName, Path.GetFileName(file))); }
                    }
                } else {
                    try {
                        if (!File.Exists(targetArcPath)) {
                            //Copy a file if it isn't part of a merge mod or is marked as read-only.
                            Console.WriteLine("Copying: " + file);
                            if (File.Exists(origArcPath)) File.Move(origArcPath, targetArcPath); //Don't try and backup a file that doesn't exist in the base game
                            File.Copy(file, origArcPath);
                        } else {
                            //Skip the file if it needs to be copied but can't due a modded file already existing on its slot.
                            skippedMods.Add(ModsMessages.ex_SkippedMod(modName, Path.GetFileName(file)));
                        }
                    } catch (FileNotFoundException) { skippedMods.Add(ModsMessages.ex_SkippedModMissingFile(modName, Path.GetFileName(file))); }
                }
            }

            //Pass the current system to CustomFilesystemPackage
            if (coreList.Count != 0 || win32List.Count != 0) {
                if (platform == "Xbox 360") CustomFilesystemPackage("xenon");
                else if (platform == "PlayStation 3") CustomFilesystemPackage("ps3");
            }
        }

        public static void CustomFilesystemPackage(string platform) { //Create a custom PKG based on all the custom arcs specified in mods
            string system = Path.Combine(Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory, platform, "archives", "system.arc");
            if (!File.Exists($"{system}_back"))
                File.Copy(system, $"{system}_back", true);
            string unpack = UnpackARC(system);

            //Unpack PKG
            string directoryRoot = Path.Combine(unpack, $"system\\{platform}\\archive");
            PKG.PKGTool($"{directoryRoot}.pkg");
            List<string> basePKG = File.ReadAllLines($"{directoryRoot}.txt").ToList();

            //Edited text file
            if (coreList.Count != 0) {
                basePKG.Add("\"archive\"\n{");
                foreach (string arc in coreList) {
                    basePKG.Add($"\t\"{Path.GetFileNameWithoutExtension(arc)}\" = \"archives/{arc}\";");
                }
                basePKG.Add("}");
            }

            if (win32List.Count != 0) {
                basePKG.Add("\"archive_win32\"\n{");
                foreach (string arc in win32List) {
                    basePKG.Add($"\t\"{Path.GetFileNameWithoutExtension(arc)}\" = \"archives/{arc}\";");
                }
                basePKG.Add("}");
            }

            File.WriteAllLines($"{directoryRoot}.txt", basePKG); //Resave the edited text file

            //Resave PKG file
            PKG.PKGTool($"{directoryRoot}.txt");
            RepackARC(unpack, system);

            //Clear lists
            coreList.Clear();
            win32List.Clear();
        }

        public static void MergeARCs(string arc1, string arc2, string output, bool ftp, string ftpPath)
        {
            string tempPath = $"{Program.applicationData}\\Temp\\{Path.GetRandomFileName()}"; // Defines the temporary path.
            var tempData = new DirectoryInfo(tempPath); // Gets directory information on the temporary path.
            bool useDirectory = false;

            ProcessStartInfo arctool;

            if (ftp) { tempPath = ftpPath; } // Changes the temporary path to the FTP path.
            if (!ftp)
            {
                Directory.CreateDirectory(tempPath);
                File.Copy(arc1, Path.Combine(tempPath, Path.GetFileName(arc1))); // Copies the input ARC to the temporary path.
                if (!File.Exists(targetArcPath)) File.Move(origArcPath, targetArcPath);
            }

            // Defines the arctool process.
            arctool = new ProcessStartInfo($"{Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", $"-d \"{Path.Combine(tempPath, Path.GetFileName(arc1))}\"")
            {
                WorkingDirectory = $"{Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            //modManager.Status = SystemMessages.msg_MergingMod(modName);

            var Unpack1 = Process.Start(arctool); // Unpacks the input ARC.
            Unpack1.WaitForExit();

            File.Delete(Path.Combine(tempPath, Path.GetFileName(arc1))); // Deletes the temporary input ARC.

            if (File.Exists(arc2)) {
                useDirectory = false;
                File.Copy(arc2, Path.Combine(tempPath, Path.GetFileName(arc2))); // Copies the input ARC to the temporary path.
            }
            else if (Directory.Exists(arc2)) {
                useDirectory = true;
                DirectoryCopy(arc2, Path.Combine(tempPath, Path.GetFileNameWithoutExtension(arc2)), true);
            }

            if (!useDirectory)
            {
                // Defines the arctool process.
                arctool = new ProcessStartInfo($"{Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", $"-d \"{Path.Combine(tempPath, Path.GetFileName(arc2))}\"") {
                    WorkingDirectory = $"{Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                var Unpack2 = Process.Start(arctool); // Unpacks the merge ARC.
                Unpack2.WaitForExit();

                File.Delete(Path.Combine(tempPath, Path.GetFileName(arc2))); // Deletes the temporary merge ARC.
            }

            // Defines the arctool process.
            arctool = new ProcessStartInfo($"{Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", $"-f -i \"{Path.Combine(tempPath, Path.GetFileNameWithoutExtension(arc2))}\" -c \"{output}\"")
            {
                WorkingDirectory = $"{Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var Repack1 = Process.Start(arctool); // Repacks the merged ARC.
            Repack1.WaitForExit();

            if (!ftp)
            {
                // Erase temporary files on completion.
                try
                {
                    if (Directory.Exists(tempPath))
                    {
                        foreach (FileInfo file in tempData.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (DirectoryInfo directory in tempData.GetDirectories())
                        {
                            directory.Delete(true);
                        }
                    }
                }
                catch { return; }
            }
        }

        public static string UnpackARC(string arc)
        {
            string tempPath = $"{Program.applicationData}\\Temp\\{Path.GetRandomFileName()}";
            Directory.CreateDirectory(tempPath);
            File.Copy(arc, Path.Combine(tempPath, Path.GetFileName(arc)));

            var unpack = new ProcessStartInfo($"{Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", $"-d \"{Path.Combine(tempPath, Path.GetFileName(arc))}\"") {
                WorkingDirectory = $"{Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var Unpack = Process.Start(unpack);
            Unpack.WaitForExit();
            Unpack.Close();

            return tempPath;
        }

        public static string RepackARC(string arc, string output)
        {
            ProcessStartInfo repack;

            string tempPath = arc;
            var tempData = new DirectoryInfo(tempPath);

            repack = new ProcessStartInfo($"{Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", $"-f -i \"{Path.Combine(tempPath, Path.GetFileNameWithoutExtension(output))}\" -c \"{output}\"") {
                WorkingDirectory = $"{Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var Repack = Process.Start(repack);
            Repack.WaitForExit();
            Repack.Close();

            try
            {
                if (Directory.Exists(tempPath))
                {
                    foreach (FileInfo file in tempData.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo directory in tempData.GetDirectories())
                    {
                        directory.Delete(true);
                    }
                }
            }
            catch { return tempPath; }

            return tempPath;
        }

        public static void CleanupSaves(string modPath, string modName)
        {
            string saveLocation = Path.GetDirectoryName(Path.GetDirectoryName(Sonic_06_Mod_Manager.Properties.Settings.Default.saveData));
            string savedata = string.Empty;

            using (Stream configRead = File.Open(Path.Combine(modPath, "mod.ini"), FileMode.Open))
            using (StreamReader configFile = new StreamReader(configRead, Encoding.Default)) {
                string line;
                string entryValue;
                while ((line = configFile.ReadLine()) != null) {
                    if (line.StartsWith("Save")) {
                        entryValue = line.Substring(line.IndexOf("=") + 2);
                        entryValue = entryValue.Remove(entryValue.Length - 1);
                        savedata = entryValue;
                    }
                }
            }

            if (Sonic_06_Mod_Manager.Properties.Settings.Default.emulatorSystem == 0)
            {
                if (!Directory.Exists(Path.GetDirectoryName(Sonic_06_Mod_Manager.Properties.Settings.Default.xeniaPath))) return;

                string[] saves = Array.Empty<string>();
                if (Directory.Exists(saveLocation)) saves = Directory.GetDirectories(saveLocation, "SonicNextSaveData.bin_back", SearchOption.AllDirectories);

                modManager.Status = SystemMessages.msg_Cleanup;
                foreach (var file in saves)
                {
                    string saveFile = Path.Combine(file.ToString().Remove(file.Length - 5), Path.GetFileName(file.ToString().Remove(file.Length - 5)));
                    if (File.Exists(saveFile)) {
                        Console.WriteLine("Removing: " + file);
                        if (savedata != string.Empty) File.Copy(saveFile, Path.Combine(modPath, "savedata.360"), true);
                    }

                    if (Directory.Exists(file.ToString().Remove(file.Length - 5))) {
                        Console.WriteLine("Removing: " + file);
                        Directory.Delete(file.ToString().Remove(file.Length - 5), true);
                    }

                    Directory.Move(file.ToString(), file.ToString().Remove(file.Length - 5));
                }
                modManager.Status = SystemMessages.msg_DefaultStatus;
            }
            else if (Sonic_06_Mod_Manager.Properties.Settings.Default.emulatorSystem == 1)
            {
                string[] saves = Array.Empty<string>();
                if (Directory.Exists(saveLocation)) saves = Directory.GetFiles(saveLocation, "SYS-DATA_back", SearchOption.AllDirectories);

                modManager.Status = SystemMessages.msg_Cleanup;
                foreach (var file in saves)
                {
                    string saveFile = Path.Combine(file.ToString().Remove(file.Length - 5), Path.GetFileName(file.ToString().Remove(file.Length - 5)));
                    if (File.Exists(saveFile)) {
                        Console.WriteLine("Removing: " + file);
                        if (savedata != string.Empty) File.Copy(saveFile, Path.Combine(modPath, "savedata.ps3"), true);
                    }

                    if (File.Exists(file.ToString().Remove(file.Length - 5))) {
                        Console.WriteLine("Removing: " + file);
                        File.Delete(file.ToString().Remove(file.Length - 5));
                    }

                    File.Move(file.ToString(), file.ToString().Remove(file.Length - 5));
                }
                modManager.Status = SystemMessages.msg_DefaultStatus;
            }
        }

        public static void RedirectSaves(string modPath, string modName)
        {
            string saveLocation = Sonic_06_Mod_Manager.Properties.Settings.Default.saveData;
            bool savedata = false;

            using (Stream configRead = File.Open(Path.Combine(modPath, "mod.ini"), FileMode.Open))
            using (StreamReader configFile = new StreamReader(configRead, Encoding.Default)) {
                string line;
                while ((line = configFile.ReadLine()) != null)
                    if (line.StartsWith("Save"))
                        savedata = true;
            }

            if (savedata) {
                if (Sonic_06_Mod_Manager.Properties.Settings.Default.saveData != string.Empty &&
                    File.Exists(Sonic_06_Mod_Manager.Properties.Settings.Default.saveData)) {
                        if (Sonic_06_Mod_Manager.Properties.Settings.Default.emulatorSystem == 0) {
                            try {
                                if (!Directory.Exists($"{Path.GetDirectoryName(saveLocation)}_back")) {
                                    Directory.CreateDirectory($"{Path.GetDirectoryName(saveLocation)}_back");
                                    DirectoryInfo backupSave = new DirectoryInfo(Path.GetDirectoryName(saveLocation));
                                    foreach (FileInfo fi in backupSave.GetFiles())
                                        fi.CopyTo(Path.Combine($"{Path.GetDirectoryName(saveLocation)}_back", fi.Name), true);
                                    File.Copy(Path.Combine(modPath, "savedata.360"), saveLocation, true);
                                } else skippedMods.Add(ModsMessages.ex_SkippedSave(modName));
                            } catch { skippedMods.Add(ModsMessages.ex_IncorrectSaveTarget(modName, "Xbox 360")); }
                        } else if (Sonic_06_Mod_Manager.Properties.Settings.Default.emulatorSystem == 1) {
                            try {
                                if (File.Exists(Path.Combine(modPath, "savedata.ps3")) && Directory.Exists(Path.GetDirectoryName(saveLocation))) {
                                    if (!File.Exists($"{saveLocation}_back")) {
                                        File.Move(saveLocation, $"{saveLocation}_back");
                                        File.Copy(Path.Combine(modPath, "savedata.ps3"), saveLocation, true);
                                    } else skippedMods.Add(ModsMessages.ex_SkippedSave(modName));
                                }
                            } catch { skippedMods.Add(ModsMessages.ex_IncorrectSaveTarget(modName, "PlayStation 3")); }
                        }
                } else skippedMods.Add(ModsMessages.ex_NoSaveData(modName));
            }
            else return;
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }

    class XEX
    {
        public static void Decrypt(string filepath) {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = $"{Sonic_06_Mod_Manager.Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\xextool.exe",
                Arguments = $"-e u \"{filepath}\""
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        public static void DecompressBIN(string filepath) {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = $"{Sonic_06_Mod_Manager.Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\xextool.exe",
                Arguments = $"-c b \"{filepath}\""
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        public static void FieldOfView(string filepath, decimal fov) {
            using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Write)) {
                stream.Position = 0x4F4D; stream.WriteByte(decimal.ToByte(fov));
            }
        }

        public static void HomingFlips(string filepath) {
            using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Write)) {
                stream.Position = 0x21A3F0; stream.WriteByte(0x41);
            }
        }

        public static void BoardCollision(string filepath) {
            string platform = string.Empty;
            if (Sonic_06_Mod_Manager.Properties.Settings.Default.emulatorSystem == 0) platform = "xenon";
            else platform = "ps3";

            string playerArchiveDir = Path.Combine(Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory, platform, "archives", "player.arc");
            using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Write)) {
                stream.Position = 0x217A07; stream.WriteByte(0x0C);
            }
            PKG.AddEntry(playerArchiveDir, $"player\\{platform}\\player\\snow_board", "motion", "against", "player/sonic_new/so_brd_collision_Root.xnm");
        }

        public static void BoundRecovery(string filepath) {
            using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Write)) {
                stream.Position = 0x21ADC8; stream.WriteByte(0x40);
            }
        }

        public static void HomingSpam(string filepath) {
            using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Write)) {
                stream.Position = 0x21A4BC; stream.WriteByte(0x60);
                stream.Position = 0x21A4BD; stream.WriteByte(0x00);
                stream.Position = 0x21A4BE; stream.WriteByte(0x00);
                stream.Position = 0x21A4BF; stream.WriteByte(0x00);
            }
        }

        public static void MachSpeedAirControl(string filepath) {
            using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Write)) {
                stream.Position = 0x213380; stream.WriteByte(0x60);
                stream.Position = 0x213381; stream.WriteByte(0x00);
                stream.Position = 0x213382; stream.WriteByte(0x00);
                stream.Position = 0x213383; stream.WriteByte(0x00);
                stream.Position = 0x213384; stream.WriteByte(0x60);
                stream.Position = 0x213385; stream.WriteByte(0x00);
                stream.Position = 0x213386; stream.WriteByte(0x00);
                stream.Position = 0x213387; stream.WriteByte(0x00);
                stream.Position = 0x2133B4; stream.WriteByte(0x60);
                stream.Position = 0x2133B5; stream.WriteByte(0x00);
                stream.Position = 0x2133B6; stream.WriteByte(0x00);
                stream.Position = 0x2133B7; stream.WriteByte(0x00);
                stream.Position = 0x2133B8; stream.WriteByte(0x60);
                stream.Position = 0x2133B9; stream.WriteByte(0x00);
                stream.Position = 0x2133BA; stream.WriteByte(0x00);
                stream.Position = 0x2133BB; stream.WriteByte(0x00);
            }
        }

        public static void SnowboardAirControl(string filepath) {
            using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Write)) {
                stream.Position = 0x217710; stream.WriteByte(0x60);
                stream.Position = 0x217711; stream.WriteByte(0x00);
                stream.Position = 0x217712; stream.WriteByte(0x00);
                stream.Position = 0x217713; stream.WriteByte(0x00);
                stream.Position = 0x217878; stream.WriteByte(0x60);
                stream.Position = 0x217879; stream.WriteByte(0x00);
                stream.Position = 0x21787A; stream.WriteByte(0x00);
                stream.Position = 0x21787B; stream.WriteByte(0x00);
                stream.Position = 0x2175B8; stream.WriteByte(0x60);
                stream.Position = 0x2175B9; stream.WriteByte(0x00);
                stream.Position = 0x2175BA; stream.WriteByte(0x00);
                stream.Position = 0x2175BB; stream.WriteByte(0x00);
            }
        }

        public static void ChaosSmash(string filepath) {
            using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Write)) {
                stream.Position = 0xB1932B; stream.WriteByte(0x55);
                stream.Position = 0xB1935B; stream.WriteByte(0x42);
                stream.Position = 0x1AA1B3; stream.WriteByte(0x55);
            }
        }

        public static void ControllableSpinkick(string filepath) {
            using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Write)) {
                stream.Position = 0x2E1B9; stream.WriteByte(0x00);
                stream.Position = 0x19D987; stream.WriteByte(0xEF);
                stream.Position = 0x1A2A07; stream.WriteByte(0xEF);
            }
        }

        public static void DisableStumble(string filepath) {
            using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Write)) {
                // Sonic the Hedgehog
                stream.Position = 0xB10DB3; stream.WriteByte(0x29);
                stream.Position = 0xB10DB6; stream.WriteByte(0x15);
                stream.Position = 0xB10DB7; stream.WriteByte(0xD0);
                // Princess Elise
                stream.Position = 0xB110EB; stream.WriteByte(0x29);
                stream.Position = 0xB110EE; stream.WriteByte(0x15);
                stream.Position = 0xB110EF; stream.WriteByte(0xD0);
                // Shadow the Hedgehog
                stream.Position = 0xB1124B; stream.WriteByte(0x29);
                stream.Position = 0xB1124E; stream.WriteByte(0x15);
                stream.Position = 0xB1124F; stream.WriteByte(0xD0);
                // E-123 Omega
                stream.Position = 0xB1190B; stream.WriteByte(0x29);
                stream.Position = 0xB1190E; stream.WriteByte(0x15);
                stream.Position = 0xB1190F; stream.WriteByte(0xD0);
                // Amy Rose
                stream.Position = 0xB11A33; stream.WriteByte(0x29);
                stream.Position = 0xB11A36; stream.WriteByte(0x15);
                stream.Position = 0xB11A37; stream.WriteByte(0xD0);
                // Blaze the Cat
                stream.Position = 0xB11B83; stream.WriteByte(0x29);
                stream.Position = 0xB11B86; stream.WriteByte(0x15);
                stream.Position = 0xB11B87; stream.WriteByte(0xD0);
                // Knuckles the Echidna
                stream.Position = 0xB11CCB; stream.WriteByte(0x29);
                stream.Position = 0xB11CCE; stream.WriteByte(0x15);
                stream.Position = 0xB11CCF; stream.WriteByte(0xD0);
                // Rouge the Bat
                stream.Position = 0xB11E1B; stream.WriteByte(0x29);
                stream.Position = 0xB11E1E; stream.WriteByte(0x15);
                stream.Position = 0xB11E1F; stream.WriteByte(0xD0);
            }
        }
    }

    class PKG
    {
        //Use the PKGTool to encode/decode the given file
        public static void PKGTool(string filepath) {
            string pkgtool = $"{Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\pkgtool.exe";
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = pkgtool,
                Arguments = filepath
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            if (Path.GetExtension(filepath) == ".txt") File.Delete(filepath);
        }

        public static void AddEntry(string filepath, string directoryRoot, string key, string _event, string reference) {
            if (!File.Exists($"{filepath}_orig"))
                File.Copy(filepath, $"{filepath}_orig", true);
            string unpack = ARC.UnpackARC(filepath);

            //Unpack PKG
            PKGTool($"{Path.Combine(unpack, directoryRoot)}.pkg");
            List<string> basePKG = File.ReadAllLines($"{Path.Combine(unpack, directoryRoot)}.txt").ToList();
            bool keyfound = false;
            int lineNum = 0;

            foreach (string line in basePKG) {
                if (line.StartsWith($"\"{key}\"")) {
                    keyfound = true;
                    basePKG.Insert(lineNum + 2, $"\t\"{_event}\" = \"{reference}\";");
                    break;
                }
                lineNum++;
            }

            if (keyfound == false) {
                basePKG.Add($"\"{key}\"\n{"{"}");
                basePKG.Add($"\t\"{_event}\" = \"{reference}\";");
                basePKG.Add("}");
            }

            File.WriteAllLines($"{Path.Combine(unpack, directoryRoot)}.txt", basePKG); //Resave the edited text file

            //Resave PKG file
            PKGTool($"{Path.Combine(unpack, directoryRoot)}.txt");
            ARC.RepackARC(unpack, filepath);
        }

        public static void SilverGrindTrick(string filepath) {
            string hexString = BitConverter.ToString(File.ReadAllBytes(filepath).ToArray()).Replace("-", "");
            string brokenAnim = "73765F6772696E64747269636B30302E786E6D2E786E6D";

            if (hexString.Contains(brokenAnim)) {
                hexString = hexString.Replace(brokenAnim, "73765F6772696E64747269636B30302E786E6D00000000");
                File.WriteAllBytes(filepath, Bytes.StringToByteArrayExtended(hexString));
            }
        }
    }

    class Lua
    {
        public static void Decompile(string filepath)
        {
            string luaName = Path.Combine(Path.GetDirectoryName(filepath), $"{Path.GetFileNameWithoutExtension(filepath)}.lua"); //Get the name of the Lub with the file extension changed to Lua
            string[] readText = File.ReadAllLines(filepath); //Read the Lub into an array

            //Check if the array contains the LuaP string used to determine if the Lua is compiled. Decompile if true
            if (readText[0].Contains("LuaP")) {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = $"/C java.exe -jar \"{Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.jar\" \"{filepath}\" > \"{luaName}\""
                };
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();

                //Rename from .Lua to .Lub
                File.Delete(filepath);
                File.Move(luaName, filepath);
            }
        }

        public static void DebugMode(string directoryRoot, bool enabled) {
            var files = Directory.GetFiles(directoryRoot, "*.lub", SearchOption.AllDirectories);

            foreach (var lub in files) {
                if (!Path.GetFileName(lub).StartsWith("select_")) {
                    Decompile(lub);
                    string[] editedLua = File.ReadAllLines(lub);
                    int lineNum = 0;

                    foreach (string line in editedLua) {
                        if (line.StartsWith("debug")) {
                            string[] tempLine = line.Split(' '); //Split line into different sections
                            tempLine[2] = "use";
                            editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                        }
                        if (line.StartsWith("c_module_state")) {
                            string[] tempLine = line.Split(' '); //Split line into different sections
                            tempLine[2] = "state_module_debug";
                            editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                        }
                        if (line.StartsWith("c_posture_control")) {
                            string[] tempLine = line.Split(' '); //Split line into different sections
                            tempLine[2] = "posture_control_debug";
                            editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                        }
                        if (line.StartsWith("c_input_system")) {
                            string[] tempLine = line.Split(' '); //Split line into different sections
                            tempLine[2] = "input_system_debug";
                            editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                        }
                        lineNum++;
                    }
                    File.WriteAllLines(lub, editedLua); //Resave the Lua
                }
            }
        }

        public static void CameraDistance(string directoryRoot, int distance)
        {
            Decompile(directoryRoot);
            string[] editedLua = File.ReadAllLines(directoryRoot);
            int lineNum = 0;

            foreach (string line in editedLua) {
                if (line.StartsWith("distance")) {
                    string[] tempLine = line.Split(' '); //Split line into different sections
                    tempLine[2] = decimal.Divide(distance, 100).ToString(); //Replace the 2nd section (the original number) with our new number divided by 100
                    editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                }
                lineNum++;
            }
            File.WriteAllLines(directoryRoot, editedLua); //Resave the Lua
        }

        public static void CameraHeight(string directoryRoot, int distance)
        {
            Decompile(directoryRoot);
            string[] editedLua = File.ReadAllLines(directoryRoot);
            int lineNum = 0;

            foreach (string line in editedLua) {
                if (line.StartsWith("altitude")) {
                    string[] tempLine = line.Split(' '); //Split line into different sections
                    tempLine[2] = distance.ToString(); //Replace the 2nd section (the original number)
                    editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                }
                lineNum++;
            }
            File.WriteAllLines(directoryRoot, editedLua); //Resave the Lua
        }

        public static void Reflections(string directoryRoot, int scale)
        {
            Decompile(directoryRoot);
            string[] editedLua = File.ReadAllLines(directoryRoot);
            int lineNum = 0;

            foreach (string line in editedLua) {
                if (line.StartsWith("EnableReflection")) {
                    string[] tempLine = line.Split(' '); //Split line into different sections
                    if (scale == 0)
                        tempLine[2] = "false"; //Replace the 2nd section (the original number)
                    else
                        tempLine[2] = "true"; //Replace the 2nd section (the original number)
                    editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                }

                if (line.StartsWith("  texture_width") || line.StartsWith("  texture_height")) {
                    string[] tempLine = line.Split(' '); //Split line into different sections
                    if (scale == 1)
                        tempLine[7] = "4"; //Replace the 2nd section (the original number)
                    else if (scale == 2)
                        tempLine[7] = "2"; //Replace the 2nd section (the original number)
                    else if (scale == 3)
                        tempLine[6] = tempLine[7] = string.Empty; //Replace the 2nd section (the original number)
                    editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                }
                lineNum++;
            }
            File.WriteAllLines(directoryRoot, editedLua); //Resave the Lua
        }

        public static void CameraType(string directoryRoot, int type, decimal fov)
        {
            Decompile(directoryRoot);
            string[] editedLua = File.ReadAllLines(directoryRoot);
            int lineNum = 0;

            foreach (string line in editedLua) {
                if (line.StartsWith("distance")) {
                    string[] tempLine = line.Split(' '); //Split line into different sections
                    if (type == 0)
                        tempLine[2] = "6.5"; //Retail
                    else if (type == 1) {
                        if (fov > 90)
                            tempLine[2] = "3.5";
                        else
                            tempLine[2] = "4.5";
                    }
                    else if (type == 2)
                        tempLine[2] = "5.5"; //E3
                    editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                }
                if (line.StartsWith("springK")) {
                    string[] tempLine = line.Split(' '); //Split line into different sections
                    if (type == 1)
                    {
                        if (fov > 90)
                            tempLine[2] = "0.325";
                        else
                            tempLine[2] = "0.225";
                    }
                    else
                        tempLine[2] = "0.98";
                    editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                }
                if (line.StartsWith("altitude")) {
                    string[] tempLine = line.Split(' '); //Split line into different sections
                    if (type == 1)
                        tempLine[2] = "-15";
                    else
                        tempLine[2] = "15";
                    editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                }
                if (line.StartsWith("az_driveK")) {
                    string[] tempLine = line.Split(' '); //Split line into different sections
                    if (type == 1)
                        tempLine[2] = "50000"; //TGS (32500 old)
                    else if(type == 2)
                        tempLine[2] = "690";
                    else
                        tempLine[2] = "3250";
                    editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                }
                if (line.StartsWith("az_dampingK")) {
                    string[] tempLine = line.Split(' '); //Split line into different sections
                    if (type == 1)
                        tempLine[2] = "2500";
                    else if(type == 2)
                        tempLine[2] = "100";
                    else
                        tempLine[2] = "250";
                    editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                }
                lineNum++;
            }
            File.WriteAllLines(directoryRoot, editedLua); //Resave the Lua
        }

        public static void CameraHeight(string directoryRoot, decimal height)
        {
            Decompile(directoryRoot);
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
            File.WriteAllLines(directoryRoot, editedLua); //Resave the Lua
        }

        public static void HammerRange(string directoryRoot, decimal range)
        {
            Decompile(directoryRoot);
            string[] editedLua = File.ReadAllLines(directoryRoot);
            int lineNum = 0;

            foreach (string line in editedLua) {
                string[] tempLine = line.Split(' '); //Split line into different sections
                if (line.StartsWith("c_hammer_head")) {
                    if (editedLua[lineNum].Contains("c_hammer_head"))
                        editedLua[lineNum] = $"c_hammer_head = {range / 100} * meter";
                }
                lineNum++;
            }
            File.WriteAllLines(directoryRoot, editedLua); //Resave the Lua
        }

        public static void DisableBloom(string directoryRoot, bool enabled)
        {
            var files = Directory.GetFiles(directoryRoot, "*.lub", SearchOption.AllDirectories);

            foreach (var lub in files) {
                if (Path.GetFileName(lub) != "render_shadowmap.lub" && Path.GetFileName(lub) != "render_title.lub") {
                    Decompile(lub);
                    string[] editedLua = File.ReadAllLines(lub);
                    int lineNum = 0;

                    foreach (string line in editedLua) {
                        if (line.Contains("ApplyBloom")) {
                            string[] tempLine = line.Split(' '); //Split line into different sections
                            if (!enabled)
                                tempLine[2] = "--" + tempLine[2]; //Replace the 2nd section (the original number)
                            else {
                                if (tempLine[2].StartsWith("--"))
                                    tempLine[2] = tempLine[2].Substring(2);
                            }
                            editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                        }
                        lineNum++;
                    }
                    File.WriteAllLines(lub, editedLua); //Resave the Lua
                }
            }
        }

        public static void DisableHUD(string directoryRoot, bool enabled)
        {
            var files = Directory.GetFiles(directoryRoot, "*.lub", SearchOption.AllDirectories);

            foreach (var lub in files) {
                if (Path.GetFileName(lub) != "render_shadowmap.lub" && Path.GetFileName(lub) != "render_title.lub") {
                    Decompile(lub);
                    string[] editedLua = File.ReadAllLines(lub);
                    int lineNum = 0;
                    int modified = 0;

                    foreach (string line in editedLua) {
                        if (line.Contains("Render2D")) {
                            string[] tempLine = line.Split(' '); //Split line into different sections
                            if (!enabled) {
                                if (tempLine[0] != "function")
                                    tempLine[2] = "--" + tempLine[2]; //Replace the 2nd section (the original number)
                            } else {
                                if (tempLine[2].StartsWith("--"))
                                    tempLine[2] = tempLine[2].Substring(2);
                            }
                            editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                            modified++;
                        }
                        if (line.Contains("RenderWorld(_ARG_0_, \"afterpp\"")) {
                            string[] tempLine = line.Split(' '); //Split line into different sections
                            if (!enabled)
                                tempLine[2] = "--" + tempLine[2]; //Replace the 2nd section (the original number)
                            else {
                                if (tempLine[2].StartsWith("--"))
                                    tempLine[2] = tempLine[2].Substring(2);
                            }
                            editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                            modified++;
                        }
                        lineNum++;
                    }
                    if (modified != 0) File.WriteAllLines(lub, editedLua); //Resave the Lua
                }
            }
        }

        public static void MSAA(string directoryRoot, int MSAA, SearchOption searchOption)
        {
            var files = Directory.GetFiles(directoryRoot, "*.lub", searchOption);

            foreach (var lub in files) {
                Decompile(lub);

                if (Path.GetFileName(lub) == "render_utility.lub") {
                    List<string> editedLua = File.ReadAllLines(lub).ToList();

                    if (MSAA == 0)      editedLua.Add("MSAAType = \"1x\"");
                    else if (MSAA == 1) editedLua.Add("MSAAType = \"2x\"");
                    else if (MSAA == 2) editedLua.Add("MSAAType = \"4x\"");
                    File.WriteAllLines(lub, editedLua);
                } else {
                    string[] editedLua = File.ReadAllLines(lub);
                    int lineNum = 0;
                    int modified = 0;

                    foreach (string line in editedLua) {
                        if (line.Contains("MSAAType")) {
                            string[] tempLine = line.Split(' '); //Split line into different sections
                            if (MSAA == 0) tempLine[2] = "\"1x\"";
                            else if (MSAA == 1) tempLine[2] = "\"2x\"";
                            else if (MSAA == 2) tempLine[2] = "\"4x\"";
                            editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                            modified++;
                        }
                        lineNum++;
                    }
                    if (modified != 0) File.WriteAllLines(lub, editedLua); //Resave the Lua
                }
            }
        }

        public static void DisableShadows(string directoryRoot, bool enabled)
        {
            var files = Directory.GetFiles(directoryRoot, "*.lub", SearchOption.AllDirectories);

            foreach (var lub in files) {
                if (Path.GetFileName(lub) != "render_shadowmap.lub" && Path.GetFileName(lub) != "render_title.lub") {
                    Decompile(lub);
                    string[] editedLua = File.ReadAllLines(lub);
                    int lineNum = 0;

                    foreach (string line in editedLua) {
                        if (line.Contains("RenderCSM")) {
                            string[] tempLine = line.Split(' '); //Split line into different sections
                            if (!enabled)
                                tempLine[2] = "--" + tempLine[2]; //Replace the 2nd section (the original number)
                            else {
                                if (tempLine[2].StartsWith("--"))
                                    tempLine[2] = tempLine[2].Substring(2);
                            }
                            editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                        }
                        lineNum++;
                    }
                    File.WriteAllLines(lub, editedLua); //Resave the Lua
                }
            }
        }

        public static void UnlockMidairMomentum(string directoryRoot, bool enabled)
        {
            var files = Directory.GetFiles(directoryRoot, "*.lub", SearchOption.AllDirectories);

            foreach (var lub in files) {
                Decompile(lub);
                string[] editedLua = File.ReadAllLines(lub);
                int lineNum = 0;

                foreach (string line in editedLua) {
                    if (line.Contains("c_jump_brake")) {
                        string[] tempLine = line.Split(' '); //Split line into different sections
                        if (!enabled)
                            tempLine[2] = "20"; //Replace the 2nd section (the original number)
                        else {
                            if (tempLine[2] == "20")
                                tempLine[2] = "25";
                        }
                        editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                    }
                    if (line.Contains("c_jump_speed_acc")) {
                        string[] tempLine = line.Split(' '); //Split line into different sections
                        if (!enabled)
                            tempLine[2] = "2.5"; //Replace the 2nd section (the original number)
                        else {
                            if (tempLine[2] == "2.5")
                                tempLine[2] = "20";
                        }
                        editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                    }
                    if (lub.Contains("amy") || lub.Contains("knuckles") || lub.Contains("rouge") || lub.Contains("silver") || lub.Contains("tails")) {
                        if (line.Contains("c_jump_speed_brake")) {
                            string[] tempLine = line.Split(' '); //Split line into different sections
                            if (!enabled)
                                tempLine[2] = "20"; //Replace the 2nd section (the original number)
                            else {
                                if (tempLine[2] == "20")
                                    tempLine[2] = "10";
                            }
                            editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                        }
                        if (line.Contains("c_jump_run")) {
                            string[] tempLine = line.Split(' '); //Split line into different sections
                            if (!enabled)
                                tempLine[2] = "9"; //Replace the 2nd section (the original number)
                            else {
                                if (tempLine[2] == "9")
                                    tempLine[2] = "5.3";
                            }
                            editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                        }
                    }
                    if (line.Contains("c_jump_walk")) {
                        if (!enabled)
                            editedLua[lineNum] = "c_jump_walk = 9 * (meter / sec)"; //Replace the 2nd section (the original number)
                        else {
                            if (editedLua[lineNum] == "c_jump_walk = 9 * (meter / sec)")
                                editedLua[lineNum] = "c_jump_walk = HeightAndDistanceToSpeed(l_jump_walk, l_jump_hight)";
                        }
                    }
                    if (line.Contains("c_flight_speed_min")) {
                        string[] tempLine = line.Split(' '); //Split line into different sections
                        if (!enabled)
                            tempLine[2] = "0"; //Replace the 2nd section (the original number)
                        else {
                            if (tempLine[2] == "0")
                                tempLine[2] = "10";
                        }
                        editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                    }
                    lineNum++;
                }
                File.WriteAllLines(lub, editedLua); //Resave the Lua
            }
        }

        public static void UnlockTailsFlightLimit(string directoryRoot, bool enabled)
        {
            Decompile(directoryRoot);
            string[] editedLua = File.ReadAllLines(directoryRoot);
            int lineNum = 0;
            decimal origTimer = 0;

            foreach (string line in editedLua) {
                string[] tempLine = line.Split(' '); //Split line into different sections

                if (tempLine[0] == "c_flight_timer") {
                    origTimer = decimal.Parse(tempLine[2]);
                }
                if (tempLine[0] == "c_flight_timer_b") {
                    if (!enabled) tempLine[2] = (((origTimer * 1000) + 125) / 1000).ToString(); //Replace the 2nd section (the original number)
                    editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                }
                lineNum++;
            }
            File.WriteAllLines(directoryRoot, editedLua); //Resave the Lua
        }

        public static void ActionGaugeFixes(string directoryRoot, bool enabled)
        {
            Decompile(directoryRoot);
            string[] editedLua = File.ReadAllLines(directoryRoot);
            int lineNum = 0;

            foreach (string line in editedLua) {
                if (line.StartsWith("c_gauge_green") && enabled) {
                    string[] tempLine = line.Split(' ');
                    tempLine[0] = "c_green";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                else if (line.StartsWith("c_green") && !enabled) {
                    string[] tempLine = line.Split(' ');
                    tempLine[0] = "c_gauge_green";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                if (line.StartsWith("c_gauge_red") && enabled) {
                    string[] tempLine = line.Split(' ');
                    tempLine[0] = "c_red";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                else if (line.StartsWith("c_red") && !enabled) {
                    string[] tempLine = line.Split(' ');
                    tempLine[0] = "c_gauge_red";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                if (line.StartsWith("c_gauge_blue") && enabled) {
                    string[] tempLine = line.Split(' ');
                    tempLine[0] = "c_blue";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                else if (line.StartsWith("c_blue") && !enabled) {
                    string[] tempLine = line.Split(' ');
                    tempLine[0] = "c_gauge_blue";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                if (line.StartsWith("c_gauge_white") && enabled) {
                    string[] tempLine = line.Split(' ');
                    tempLine[0] = "c_white";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                else if (line.StartsWith("c_white") && !enabled) {
                    string[] tempLine = line.Split(' ');
                    tempLine[0] = "c_gauge_white";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                if (line.StartsWith("c_gauge_sky") && enabled) {
                    string[] tempLine = line.Split(' ');
                    tempLine[0] = "c_sky";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                else if (line.StartsWith("c_sky") && !enabled) {
                    string[] tempLine = line.Split(' ');
                    tempLine[0] = "c_gauge_sky";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                if (line.StartsWith("c_gauge_yellow") && enabled) {
                    string[] tempLine = line.Split(' ');
                    tempLine[0] = "c_yellow";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                else if (line.StartsWith("c_yellow") && !enabled) {
                    string[] tempLine = line.Split(' ');
                    tempLine[0] = "c_gauge_yellow";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                if (line.StartsWith("c_gauge_purple") && enabled) {
                    string[] tempLine = line.Split(' ');
                    tempLine[0] = "c_purple";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                else if (line.StartsWith("c_purple") && !enabled) {
                    string[] tempLine = line.Split(' ');
                    tempLine[0] = "c_gauge_purple";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                if (line.StartsWith("c_gauge_super") && enabled) {
                    string[] tempLine = line.Split(' ');
                    tempLine[0] = "c_super";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                else if (line.StartsWith("c_super") && !enabled) {
                    string[] tempLine = line.Split(' ');
                    tempLine[0] = "c_gauge_super";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                if (line.StartsWith("c_gauge_heal")) {
                    string[] tempLine = line.Split(' ');
                    if (!enabled)
                        tempLine[2] = "50";
                    else
                        tempLine[2] = "5";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                if (line.StartsWith("c_gauge_heal_delay")) {
                    string[] tempLine = line.Split(' ');
                    if (!enabled)
                        tempLine[2] = "0.5";
                    else
                        tempLine[2] = "0";
                    editedLua[lineNum] = string.Join(" ", tempLine);
                }
                lineNum++;
            }
            File.WriteAllLines(directoryRoot, editedLua);
        }

        public static void CurvedHomingAttack(string directoryRoot, bool enabled)
        {
            Decompile(directoryRoot);
            string[] editedLua = File.ReadAllLines(directoryRoot);
            int lineNum = 0;

            foreach (string line in editedLua) {
                if (line.Contains("OpenOther(_ARG_0_, other_module_sonic_homing)")) {
                    string[] tempLine = line.Split(' '); //Split line into different sections
                    if (!enabled)
                        tempLine[3] = "other_module_sonic_homing)"; //Replace the 2nd section (the original number)
                    else
                        tempLine[3] = "other_module_blaze_homing)";
                    editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                }
                lineNum++;
            }
            File.WriteAllLines(directoryRoot, editedLua); //Resave the Lua
        }

        public static void UseDynamicBonesForSnowboard(string directoryRoot, bool enabled)
        {
            Decompile(directoryRoot);
            string[] editedLua = File.ReadAllLines(directoryRoot);

            if (enabled)
                if (!editedLua.Contains("c_hair"))
                    File.WriteAllLines(directoryRoot, editedLua.Append("c_hair = {\n  \"TopHair\",\n  \"HighLeftHair\",\n  \"HighRightHair\",\n  \"LowLeftHair\",\n  \"LowRightHair\",\n  \"MiddleHair\"\n}")); //Resave the Lua
        }
    }

    class AV
    {
        public static void DisableMusic(string directoryRoot) {
            var files = Directory.GetFiles(directoryRoot, "*.*", SearchOption.TopDirectoryOnly)
            .Where(s => s.EndsWith(".xma") ||
                        s.EndsWith(".at3"));

            foreach (var sound in files)
                if (!File.Exists($"{sound}_back") && !File.Exists($"{sound}_orig"))
                    File.Move(sound, $"{sound}_orig");
                else if (File.Exists($"{sound}_back")) {
                    File.Move($"{sound}_back", $"{sound}_orig");
                    File.Delete(sound);
                }
        }
    }
}
