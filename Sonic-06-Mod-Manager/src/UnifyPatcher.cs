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

namespace Unify.Patcher
{
    class ARC
    {
        public static readonly ModManager modManager = new ModManager(Array.Empty<string>());
        public static List<string> skippedMods = new List<string>() { };
        public static string targetArcPath = string.Empty; //Modded ARC File
        public static string origArcPath = string.Empty; //Original Game ARC File
        public static string arcPath = string.Empty; //Paths to ARC in the game files

        public static void InstallMods(string modPath, string modName) {
            bool merge = false;
            string[] read_only = { };
            string platform = string.Empty;
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

                if (file.EndsWith(".arc")) {
                    if (merge && !read_only.Contains(Path.GetFileName(file))) {
                        //Pass off to MergeARCs
                        Console.WriteLine("Merging: " + file);
                        MergeARCs(origArcPath, file, origArcPath, false, string.Empty);
                    }
                    else {
                        try {
                            if (!File.Exists(targetArcPath)) {
                                //Copy a file if it isn't part of a merge mod or is marked as read-only.
                                Console.WriteLine("Copying: " + file);
                                File.Move(origArcPath, targetArcPath);
                                File.Copy(file, origArcPath);
                            }
                            else {
                                //Skip the file if it needs to be copied but can't due a modded file already existing on its slot.
                                skippedMods.Add(ModsMessages.ex_SkippedMod(modName, Path.GetFileName(file)));
                            }
                        }
                        catch (FileNotFoundException) { skippedMods.Add(ModsMessages.ex_SkippedModMissingFile(modName, Path.GetFileName(file))); }
                    }
                }
                else {
                    try {
                        if (!File.Exists(targetArcPath)) {
                            //Copy a file if it isn't part of a merge mod or is marked as read-only.
                            Console.WriteLine("Copying: " + file);
                            File.Move(origArcPath, targetArcPath);
                            File.Copy(file, origArcPath);
                        }
                        else {
                            //Skip the file if it needs to be copied but can't due a modded file already existing on its slot.
                            skippedMods.Add(ModsMessages.ex_SkippedMod(modName, Path.GetFileName(file)));
                        }
                    }
                    catch (FileNotFoundException) { skippedMods.Add(ModsMessages.ex_SkippedModMissingFile(modName, Path.GetFileName(file))); }
                }
            }
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

        public static void CleanupMods(int state)
        {
            if (!Directory.Exists(Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory)) return;

            string[] files = Array.Empty<string>();
            if (state == 0) files = Directory.GetFiles(Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory, "*.*_back", SearchOption.AllDirectories);
            else if (state == 1) files = Directory.GetFiles(Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory, "*.*_orig", SearchOption.AllDirectories);

            modManager.Status = SystemMessages.msg_Cleanup;
            foreach (var file in files)
            {
                if (File.Exists(file.ToString().Remove(file.Length - 5)))
                {
                    Console.WriteLine("Removing: " + file);
                    File.Delete(file.ToString().Remove(file.Length - 5));
                }

                File.Move(file.ToString(), file.ToString().Remove(file.Length - 5));
            }
            modManager.Status = SystemMessages.msg_DefaultStatus;
        }

        public static void CleanupSaves(string modPath, string modName)
        {
            string savedata = string.Empty;

            //Check if Mod is a Merge Mod and if it contains any read-only files.
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
                if (File.Exists(Path.Combine(Path.GetDirectoryName(Sonic_06_Mod_Manager.Properties.Settings.Default.xeniaPath), "portable.txt"))) {
                    string xeniaPortableContent = Path.Combine(Path.GetDirectoryName(Sonic_06_Mod_Manager.Properties.Settings.Default.xeniaPath), "content");
                    if (Directory.Exists(xeniaPortableContent)) saves = Directory.GetDirectories(xeniaPortableContent, "SonicNextSaveData.bin_back", SearchOption.AllDirectories);
                } else {
                    string xeniaDocumentsContent = Path.Combine(Path.GetDirectoryName(Sonic_06_Mod_Manager.Properties.Settings.Default.xeniaPath), "content");
                    if (Directory.Exists(xeniaDocumentsContent)) saves = Directory.GetDirectories(xeniaDocumentsContent, "SonicNextSaveData.bin_back", SearchOption.AllDirectories);
                }

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
                if (!Directory.Exists(Path.GetDirectoryName(Sonic_06_Mod_Manager.Properties.Settings.Default.RPCS3Path))) return;

                string[] saves = Array.Empty<string>();
                string getEUSaveData = Path.Combine(Path.GetDirectoryName(Sonic_06_Mod_Manager.Properties.Settings.Default.RPCS3Path), "dev_hdd0", "home", "00000001", "savedata", "BLES00028");
                string getEUSaveData2 = Path.Combine(Path.GetDirectoryName(Sonic_06_Mod_Manager.Properties.Settings.Default.RPCS3Path), "dev_hdd0", "home", "00000001", "savedata", "BLES00028-0000");
                string getUSSaveData = Path.Combine(Path.GetDirectoryName(Sonic_06_Mod_Manager.Properties.Settings.Default.RPCS3Path), "dev_hdd0", "home", "00000001", "savedata", "BLUS30008");
                string getUSSaveData2 = Path.Combine(Path.GetDirectoryName(Sonic_06_Mod_Manager.Properties.Settings.Default.RPCS3Path), "dev_hdd0", "home", "00000001", "savedata", "BLUS30008-0000");

                if (Directory.Exists(getEUSaveData))
                    if (Directory.Exists(getEUSaveData)) saves = Directory.GetFiles(getEUSaveData, "SYS-DATA_back", SearchOption.AllDirectories);
                    else if (Directory.Exists(getEUSaveData2))
                        if (Directory.Exists(getEUSaveData2)) saves = Directory.GetFiles(getEUSaveData2, "SYS-DATA_back", SearchOption.AllDirectories);
                        else if (Directory.Exists(getUSSaveData))
                            if (Directory.Exists(getUSSaveData)) saves = Directory.GetFiles(getUSSaveData, "SYS-DATA_back", SearchOption.AllDirectories);
                            else if (Directory.Exists(getUSSaveData2))
                                if (Directory.Exists(getUSSaveData2)) saves = Directory.GetFiles(getUSSaveData2, "SYS-DATA_back", SearchOption.AllDirectories);

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
            string[] saves = Array.Empty<string>();
            bool savedata = false;

            //Check if Mod is a Merge Mod and if it contains any read-only files.
            using (Stream configRead = File.Open(Path.Combine(modPath, "mod.ini"), FileMode.Open))
            using (StreamReader configFile = new StreamReader(configRead, Encoding.Default)) {
                string line;

                while ((line = configFile.ReadLine()) != null)
                    if (line.StartsWith("Save"))
                        savedata = true;
            }

            if (savedata)
            {
                if (Sonic_06_Mod_Manager.Properties.Settings.Default.emulatorSystem == 0) {
                    if (File.Exists(Path.Combine(Path.GetDirectoryName(Sonic_06_Mod_Manager.Properties.Settings.Default.xeniaPath), "portable.txt"))) {
                        string xeniaPortableContent = Path.Combine(Path.GetDirectoryName(Sonic_06_Mod_Manager.Properties.Settings.Default.xeniaPath), "content");
                        if (Directory.Exists(xeniaPortableContent)) saves = Directory.GetFiles(xeniaPortableContent, "SonicNextSaveData.bin", SearchOption.AllDirectories);
                    } else {
                        string xeniaDocumentsContent = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Xenia", "content");
                        if (Directory.Exists(xeniaDocumentsContent)) saves = Directory.GetFiles(xeniaDocumentsContent, "SonicNextSaveData.bin", SearchOption.AllDirectories);
                    }
                }
                else if (Sonic_06_Mod_Manager.Properties.Settings.Default.emulatorSystem == 1)
                {
                    string getEUSaveData = Path.Combine(Path.GetDirectoryName(Sonic_06_Mod_Manager.Properties.Settings.Default.RPCS3Path), "dev_hdd0", "home", "00000001", "savedata", "BLES00028");
                    string getEUSaveData2 = Path.Combine(Path.GetDirectoryName(Sonic_06_Mod_Manager.Properties.Settings.Default.RPCS3Path), "dev_hdd0", "home", "00000001", "savedata", "BLES00028-0000");
                    string getUSSaveData = Path.Combine(Path.GetDirectoryName(Sonic_06_Mod_Manager.Properties.Settings.Default.RPCS3Path), "dev_hdd0", "home", "00000001", "savedata", "BLUS30008");
                    string getUSSaveData2 = Path.Combine(Path.GetDirectoryName(Sonic_06_Mod_Manager.Properties.Settings.Default.RPCS3Path), "dev_hdd0", "home", "00000001", "savedata", "BLUS30008-0000");

                    if (Directory.Exists(getEUSaveData))
                        if (Directory.Exists(getEUSaveData)) saves = Directory.GetFiles(getEUSaveData, "SYS-DATA", SearchOption.AllDirectories);
                        else if (Directory.Exists(getEUSaveData2))
                            if (Directory.Exists(getEUSaveData2)) saves = Directory.GetFiles(getEUSaveData2, "SYS-DATA", SearchOption.AllDirectories);
                            else if (Directory.Exists(getUSSaveData))
                                if (Directory.Exists(getUSSaveData)) saves = Directory.GetFiles(getUSSaveData, "SYS-DATA", SearchOption.AllDirectories);
                                else if (Directory.Exists(getUSSaveData2))
                                    if (Directory.Exists(getUSSaveData2)) saves = Directory.GetFiles(getUSSaveData2, "SYS-DATA", SearchOption.AllDirectories);
                }

                foreach (var save in saves) {
                    if (Sonic_06_Mod_Manager.Properties.Settings.Default.emulatorSystem == 0) {
                        try {
                            if (!Directory.Exists($"{Path.GetDirectoryName(save)}_back")) {
                                Directory.CreateDirectory($"{Path.GetDirectoryName(save)}_back");
                                DirectoryInfo backupSave = new DirectoryInfo(Path.GetDirectoryName(save));
                                foreach (FileInfo fi in backupSave.GetFiles())
                                    fi.CopyTo(Path.Combine($"{Path.GetDirectoryName(save)}_back", fi.Name), true);
                                File.Copy(Path.Combine(modPath, "savedata.360"), save, true);
                            }
                            else { skippedMods.Add(ModsMessages.ex_SkippedSave(modName)); break; }
                        }
                        catch { skippedMods.Add(ModsMessages.ex_IncorrectSaveTarget(modName, "Xbox 360")); }
                    }
                    else if (Sonic_06_Mod_Manager.Properties.Settings.Default.emulatorSystem == 1) {
                        try { if (File.Exists(Path.Combine(modPath, "savedata.ps3")) && Directory.Exists(Path.GetDirectoryName(save))) {
                                if (!File.Exists($"{save}_back")) {
                                    File.Move(save, $"{save}_back");
                                    File.Copy(Path.Combine(modPath, "savedata.ps3"), save, true);
                                }
                                else { skippedMods.Add(ModsMessages.ex_SkippedSave(modName)); break; }
                            }
                        }
                        catch { skippedMods.Add(ModsMessages.ex_IncorrectSaveTarget(modName, "PlayStation 3")); }
                    }
                }
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

        public static void FieldOfView(string filepath, decimal fov) {
            using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Write)) {
                stream.Position = 0x4F4D;
                stream.WriteByte(decimal.ToByte(fov));
            }
        }
    }

    class PKG
    {
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
                    Arguments = $"/C java.exe -jar \"{Sonic_06_Mod_Manager.Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\unlub\\unlub.jar\" \"{filepath}\" > \"{luaName}\""
                };
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();

                //Rename from .Lua to .Lub
                File.Delete(filepath);
                File.Move(luaName, filepath);
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

        public static void MSAA(string directoryRoot, int scale)
        {
            Decompile(directoryRoot);
            string[] editedLua = File.ReadAllLines(directoryRoot);
            int lineNum = 0;

            foreach (string line in editedLua) {
                if (line.StartsWith("MSAAType")) {
                    string[] tempLine = line.Split(' '); //Split line into different sections
                    if (scale == 0)
                        tempLine[2] = "\"0x\""; //Replace the 2nd section (the original number)
                    else if (scale == 1)
                        tempLine[2] = "\"2x\""; //Replace the 2nd section (the original number)
                    else if (scale == 2)
                        tempLine[2] = "\"4x\""; //Replace the 2nd section (the original number)
                    editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                }
                if (line.EndsWith("MSAAType)")) {
                    string[] tempLine = line.Split(' '); //Split line into different sections
                    if (scale == 0) {
                        tempLine[13] = "0)"; //Replace the 2nd section (the original number)
                        tempLine[14] = string.Empty; //Replace the 2nd section (the original number)
                    }
                    else
                        tempLine[14] = "MSAAType)"; //Replace the 2nd section (the original number)
                    editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                }
                lineNum++;
            }
            File.WriteAllLines(directoryRoot, editedLua); //Resave the Lua
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
