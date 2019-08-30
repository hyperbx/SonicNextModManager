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
        public static List<string> skippedMods = new List<string>() {};
        public static string targetArcPath = string.Empty; //Modded ARC File
        public static string origArcPath = string.Empty; //Original Game ARC File
        public static string arcPath = string.Empty; //Paths to ARC in the game files

        public static void InstallMods(string modPath) {
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
            if (platform == "Xbox 360" && Sonic_06_Mod_Manager.Properties.Settings.Default.emulatorSystem == 1) { 
                skippedMods.Add(ModsMessages.ex_IncorrectTarget(Path.GetFileName(modPath), "PlayStation 3"));
                return;
            }
            if (platform == "PlayStation 3" && Sonic_06_Mod_Manager.Properties.Settings.Default.emulatorSystem == 0) {
                skippedMods.Add(ModsMessages.ex_IncorrectTarget(Path.GetFileName(modPath), "Xbox 360"));
                return;
            }

            var files = Directory.GetFiles(modPath, "*.*", SearchOption.AllDirectories)
            .Where(s => s.EndsWith(".arc") ||
                        s.EndsWith(".wmv") ||
                        s.EndsWith(".xma") ||
                        s.EndsWith(".xex") ||
                        s.EndsWith(".bin") ||
                        s.EndsWith(".pam") ||
                        s.EndsWith(".at3"));

            foreach (var file in files) {
                arcPath = file.Remove(0, $"{modPath}".Length);
                if (arcPath.StartsWith(@"\")) //Needed due to Microsoft fucking Path.Combine when the string begins with a \
                    origArcPath = Path.Combine(Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory, arcPath.Substring(1));
                else
                    origArcPath = Path.Combine(Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory, arcPath);
                targetArcPath = $"{origArcPath}_back";

                if (file.EndsWith(".arc")) {
                    if (merge && !read_only.Contains(Path.GetFileName(file))) {
                        //Pass off to MergeARCs
                        Console.WriteLine("Merging: " + file);
                        MergeARCs(origArcPath, file, origArcPath, false, string.Empty, Path.GetFileName(modPath));
                    }
                    else {
                        if (!File.Exists(targetArcPath)) {
                            //Copy a file if it isn't part of a merge mod or is marked as read-only.
                            Console.WriteLine("Copying: " + file);
                            File.Move(origArcPath, targetArcPath);
                            File.Copy(file, origArcPath);
                        }
                        else {
                            //Skip the file if it needs to be copied but can't due a modded file already existing on its slot.
                            skippedMods.Add(ModsMessages.ex_SkippedMod(Path.GetFileName(modPath), Path.GetFileName(file)));
                        }
                    }
                }
                else {
                    if (!File.Exists(targetArcPath)) {
                        //Copy a file if it isn't part of a merge mod or is marked as read-only.
                        Console.WriteLine("Copying: " + file);
                        File.Move(origArcPath, targetArcPath);
                        File.Copy(file, origArcPath);
                    }
                    else {
                        //Skip the file if it needs to be copied but can't due a modded file already existing on its slot.
                        skippedMods.Add(ModsMessages.ex_SkippedMod(Path.GetFileName(modPath), Path.GetFileName(file)));
                    }
                }
            }
        }

        public static void MergeARCs(string arc1, string arc2, string output, bool ftp, string ftpPath, string modName)
        {
            string tempPath = $"{Program.applicationData}\\Temp\\{Path.GetRandomFileName()}"; // Defines the temporary path.
            var tempData = new DirectoryInfo(tempPath); // Gets directory information on the temporary path.
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

            File.Copy(arc2, Path.Combine(tempPath, Path.GetFileName(arc2))); // Copies the merge ARC.

            // Defines the arctool process.
            arctool = new ProcessStartInfo($"{Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", $"-d \"{Path.Combine(tempPath, Path.GetFileName(arc2))}\"")
            {
                WorkingDirectory = $"{Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var Unpack2 = Process.Start(arctool); // Unpacks the merge ARC.
            Unpack2.WaitForExit();

            File.Delete(Path.Combine(tempPath, Path.GetFileName(arc2))); // Deletes the temporary merge ARC.

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
            ProcessStartInfo unpack;

            string tempPath = $"{Program.applicationData}\\Temp\\{Path.GetRandomFileName()}";
            Directory.CreateDirectory(tempPath);
            File.Copy(arc, Path.Combine(tempPath, Path.GetFileName(arc)));

            unpack = new ProcessStartInfo($"{Program.applicationData}\\Sonic_06_Mod_Manager\\Tools\\arctool.exe", $"-d \"{Path.Combine(tempPath, Path.GetFileName(arc))}\"") {
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

        public static void CleanupMods()
        {
            if (!Directory.Exists(Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory)) return;

            var files = Directory.GetFiles(Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory, "*.*_back", SearchOption.AllDirectories);

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

        public static void CleanupPatches()
        {
            if (!Directory.Exists(Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory)) return;

            var files = Directory.GetFiles(Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory, "*.*_orig", SearchOption.AllDirectories);

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

            foreach (string line in editedLua)
            {
                if (line.StartsWith("altitude"))
                {
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

            foreach (string line in editedLua)
            {
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
                    else if (scale == 3) {
                        tempLine[6] = tempLine[7] = string.Empty; //Replace the 2nd section (the original number)
                    }
                    editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                }

                lineNum++;
            }
            File.WriteAllLines(directoryRoot, editedLua); //Resave the Lua
        }

        public static void DisableHUD(string directoryRoot, bool enabled)
        {
            Decompile(directoryRoot);
            string[] editedLua = File.ReadAllLines(directoryRoot);
            int lineNum = 0;

            foreach (string line in editedLua)
            {
                if (line.Contains("Render2D"))
                {
                    string[] tempLine = line.Split(' '); //Split line into different sections
                    if (!enabled)
                    {
                        tempLine[2] = "--" + tempLine[2]; //Replace the 2nd section (the original number)
                    }
                    else {
                        if (tempLine[2].StartsWith("--")) {
                            tempLine[2] = tempLine[2].Substring(2);
                        }
                    }
                    editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                }

                lineNum++;
            }
            File.WriteAllLines(directoryRoot, editedLua); //Resave the Lua
        }

        public static void DisableShadows(string directoryRoot, bool enabled)
        {
            Decompile(directoryRoot);
            string[] editedLua = File.ReadAllLines(directoryRoot);
            int lineNum = 0;

            foreach (string line in editedLua)
            {
                if (line.Contains("RenderCSM"))
                {
                    string[] tempLine = line.Split(' '); //Split line into different sections
                    if (!enabled)
                    {
                        tempLine[2] = "--" + tempLine[2]; //Replace the 2nd section (the original number)
                    }
                    else
                    {
                        if (tempLine[2].StartsWith("--"))
                        {
                            tempLine[2] = tempLine[2].Substring(2);
                        }
                    }
                    editedLua[lineNum] = string.Join(" ", tempLine); //Place the edited line back into the Lua
                }

                lineNum++;
            }
            File.WriteAllLines(directoryRoot, editedLua); //Resave the Lua
        }
    }
}
