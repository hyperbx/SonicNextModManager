using System;
using System.IO;
using System.Text;
using System.Linq;
using Ookii.Dialogs;
using System.Drawing;
using System.Management;
using Unify.Environment3;
using Unify.Globalisation;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.VisualBasic.Devices;

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

namespace Unify.Serialisers
{
    class INI
    {
        /// <summary>
        /// If the specified key is found in the specified INI, return its value as a string.
        /// </summary>
        public static string DeserialiseKey(string key, string ini) {
            string line, entryValue = string.Empty;

            using (StreamReader configFile = new StreamReader(ini))
                try {
                    while ((line = configFile.ReadLine()) != null) {
                        if (line.Split('=')[0] == key) {
                            entryValue = line.Substring(line.IndexOf("=") + 2);
                            entryValue = entryValue.Remove(entryValue.Length - 1);
                        }
                    }
                } catch { }

            return entryValue;
        }
    }

    class Lua
    {
        /// <summary>
        /// If the specified parameter is found in the specified Lua script, return its value as a string.
        /// </summary>
        public static string DeserialiseParameter(string parameter, string script, bool fromScript) {
            string entryValue = string.Empty;

            if (fromScript) {
                string line = string.Empty;

                using (StreamReader scriptFile = new StreamReader(script))
                    try {
                        while ((line = scriptFile.ReadLine()) != null) {
                            if (line.StartsWith(parameter)) {
                                entryValue = line.Substring(line.IndexOf("(") + 1);
                                entryValue = entryValue.Remove(entryValue.Length - 2);
                                entryValue = entryValue.Substring(1);
                            }
                        }
                    } catch { }
            } else {
                if (script.StartsWith(parameter)) {
                    entryValue = script.Substring(script.IndexOf("(") + 1);
                    entryValue = entryValue.Remove(entryValue.Length - 2);
                    entryValue = entryValue.Substring(1);
                }
            }

            return entryValue;
        }

        /// <summary>
        /// If the specified parameter is found in the specified Lua script, return its value as a string array.
        /// </summary>
        public static string[] DeserialiseParameterList(string parameter, string script, bool fromScript) {
            string entryValue = string.Empty;
            string[] function = Array.Empty<string>();

            if (fromScript) {
                string line = string.Empty;

                using (StreamReader scriptFile = new StreamReader(script))
                    try {
                        while ((line = scriptFile.ReadLine()) != null) {
                            if (line.StartsWith(parameter)) {
                                entryValue = line.Substring(line.IndexOf("(") + 1);
                                entryValue = entryValue.Remove(entryValue.Length - 1);

                                function = entryValue.Split('|');
                                int valueCount = 0;
                                foreach (string value in function) {
                                    if (value.StartsWith("\"")) function[valueCount] = value.Remove(value.Length - 1).Substring(1);
                                    valueCount++;
                                }
                            }
                        }
                    } catch { }
            } else {
                if (script.StartsWith(parameter)) {
                    entryValue = script.Substring(script.IndexOf("(") + 1);
                    entryValue = entryValue.Remove(entryValue.Length - 1);

                    function = entryValue.Split('|');
                    int valueCount = 0;
                    foreach (string value in function) {
                        if (value.StartsWith("\"")) function[valueCount] = value.Remove(value.Length - 1).Substring(1);
                        valueCount++;
                    }
                }
            }

            return function;
        }
    }

    class Snapshot
    {
        public static void Create(ListView modsList, ListView patchesList) {
            // Save location for snapshot
            SaveFileDialog snapshot = new SaveFileDialog() {
                Title = "Save snapshot...",
                Filter = "Snapshot (*.06mm)|*.06mm",
                FileName = $"sonic06mm-snapshot-{DateTime.Now:ddMMyy}.06mm"
            };

            if (snapshot.ShowDialog() == DialogResult.OK) {
                string architecture = "x86";
                int gpuCount = 0;

                // Get application architecture
                if (IntPtr.Size == 4) architecture = "x86";
                else if (IntPtr.Size == 8) architecture = "x64";
                else architecture = "Unknown";

                // Create snapshot
                using (StreamWriter sw = File.CreateText(snapshot.FileName)) {
#if !DEBUG
                    try {
#endif
                        sw.WriteLine($"Sonic '06 Mod Manager\n{DateTime.Now}");

                        sw.WriteLine("\nBuild:");
#if !DEBUG
                        sw.WriteLine($"Type: Release");
#elif DEBUG
                        sw.WriteLine($"Type: Debug");
#endif
                        sw.WriteLine($"Version: {Program.VersionNumber}");
                        sw.WriteLine($"Architecture: {architecture}");

                        sw.WriteLine("\nSpecifications:");

                        // Get OS version
                        sw.WriteLine($"OS: {new ComputerInfo().OSFullName}");

                        // Get CPU name
                        ManagementObjectSearcher getCPU = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                        foreach (ManagementObject mo in getCPU.Get())
                            sw.WriteLine($"CPU: {mo["Name"]}");

                        // Format RAM as long to readable bytes
                        sw.WriteLine($"RAM: {Literal.FormatBytes(new ManagementObjectSearcher("SELECT Capacity FROM Win32_PhysicalMemory").Get().Cast<ManagementObject>().Sum(x => Convert.ToInt64(x.Properties["Capacity"].Value)))}");

                        // Get GPU names
                        ManagementObjectSearcher getGPU = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
                        foreach (ManagementObject mo in getGPU.Get())
                            foreach (PropertyData property in mo.Properties)
                                if (property.Name == "Description") {
                                    sw.WriteLine($"GPU #{gpuCount}: {property.Value}");
                                    gpuCount++;
                                }

                        // Print list of checked mods
                        if (modsList.CheckedItems.Count != 0) {
                            sw.WriteLine("\nMods:");
                            // Writes the list in reverse so the mods list writes it in it's preferred order
                            for (int i = modsList.Items.Count - 1; i >= 0; i--) {
                                if (modsList.Items[i].Checked) // Get checked state
                                    // Write mod name by folder name to prevent duplicate mod names conflicting
                                    sw.WriteLine(Path.GetFileName(Path.GetDirectoryName(modsList.Items[i].SubItems[6].Text)));
                            }
                        }

                        // Print list of checked patches
                        if (patchesList.CheckedItems.Count != 0) {
                            sw.WriteLine("\nPatches:");
                            // Writes in reverse so the patches list writes it in it's preferred order
                            for (int i = patchesList.Items.Count - 1; i >= 0; i--) {
                                if (patchesList.Items[i].Checked) // Get checked state
                                    // Write patch name by file name to prevent duplicate patch names conflicting
                                    sw.WriteLine(Path.GetFileName(patchesList.Items[i].SubItems[5].Text));
                            }
                        }

                        // Print list of current settings
                        sw.WriteLine("\nSettings:");
                        foreach (SettingsPropertyValue property in Properties.Settings.Default.PropertyValues) {
                            if (property.Name == "General_AccentColour") {
                                Color colour = Properties.Settings.Default.General_AccentColour;
                                sw.WriteLine($"{property.Name}: {colour.R}, {colour.G}, {colour.B}");
                            }
                            else sw.WriteLine($"{property.Name}: {property.PropertyValue}");
                        }

                        Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Success] Created a snapshot");
#if !DEBUG
                    } catch (Exception ex) {
                        // Print exception if something failed
                        sw.WriteLine($"\nExceptions:\n{ex}");
                        Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Error] Failed to create snapshot...\n{ex}");
                    }
#endif
                }
            }
        }

        public static void Load(ListView modsList, ListView patchesList) {
            // Location for snapshot
            OpenFileDialog snapshot = new OpenFileDialog() {
                Title = "Load snapshot...",
                Filter = "Snapshot (*.06mm)|*.06mm"
            };

            if (snapshot.ShowDialog() == DialogResult.OK) {
                List<string> mods = new List<string>();
                List<string> patches = new List<string>();

#if !DEBUG
                try {
#endif
                    using (StreamReader sr = new StreamReader(snapshot.FileName, Encoding.Default)) {
                        string section = string.Empty, line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line == "Mods:" || line == "Patches:" || line == "Settings:") section = line;

                            if (line != string.Empty && line != section) {
                                if (section == "Mods:")         mods.Add(line);
                                else if (section == "Patches:") patches.Add(line);
                                else if (section == "Settings:") {
                                    foreach (SettingsPropertyValue property in Properties.Settings.Default.PropertyValues) {
                                        int valueSplit = line.Split(' ')[0].Length + 1;
                                        if (line.StartsWith(property.Name) && property.Name == "General_AccentColour") {
                                            string[] splitArray = line.Remove(0, valueSplit).Split(',');
                                            int[] colourArray = splitArray.Select(x => int.Parse(x)).ToArray();
                                            property.PropertyValue = Color.FromArgb(colourArray[0], colourArray[1], colourArray[2]);
                                            Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Snapshot] Configured property '{property.Name}'");
                                        }
                                        else if (line.StartsWith(property.Name)) {
                                            property.PropertyValue = Convert.ChangeType(line.Remove(0, valueSplit), property.PropertyValue.GetType());
                                            Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Snapshot] Configured property '{property.Name}'");
                                        }
                                    }
                                    Properties.Settings.Default.Save();
                                }
                            }
                        }
                    }

                    if (Paths.CheckPathLegitimacy(Properties.Settings.Default.Path_ModsDirectory)) {
                        //Save the names of the selected mods and the indexes of the selected patches to their appropriate INI files
                        string modCheckList = Path.Combine(Properties.Settings.Default.Path_ModsDirectory, "mods.ini");
                        string patchCheckList = Path.Combine(Properties.Settings.Default.Path_ModsDirectory, "patches.ini");

                        // Create 'mods.ini'
                        using (StreamWriter sw = File.CreateText(modCheckList))
                            sw.WriteLine("[Main]"); // [Main] specification

                        // Writes the list in reverse so the mods list writes it in it's preferred order
                        for (int i = mods.Count - 1; i >= 0; i--) {
                            using (StreamWriter sw = File.AppendText(modCheckList)) {
                                // Write mod name by folder name to prevent duplicate mod names conflicting
                                sw.WriteLine(mods[i]);
                                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Snapshot] Written mod '{mods[i]}' to configuration");
                            }
                        }

                        // Create 'patches.ini'
                        try {
                            using (StreamWriter sw = File.CreateText(patchCheckList))
                                sw.WriteLine("[Main]"); // [Main] specification

                            // Writes in reverse so the patches list writes it in it's preferred order
                            foreach (string patch in patches) {
                                using (StreamWriter sw = File.AppendText(patchCheckList)) {
                                    // Write patch name by file name to prevent duplicate patch names conflicting
                                    sw.WriteLine(patch);
                                    Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Snapshot] Written patch '{patch}' to configuration");
                                }
                            }
                        } catch { }
                    }

                    Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Success] Loaded a snapshot");
#if !DEBUG
                } catch (Exception ex) {
                    Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Error] Failed to load snapshot...\n{ex}");
                }
#endif
            }
        }
    }

    class Troubleshoot
    {
        public static string Mod() {
            // Location for mod
            VistaFolderBrowserDialog mod = new VistaFolderBrowserDialog() {
                Description = "Select a mod folder...",
                UseDescriptionForTitle = true
            };

            if (mod.ShowDialog() == DialogResult.OK) {
                string config = Path.Combine(mod.SelectedPath, "mod.ini");

                if (File.Exists(config)) {
                    string system = INI.DeserialiseKey("Platform", config);

                    foreach (string file in Paths.CollectModData(mod.SelectedPath)) {
                        // Absolute file path (core/xenon/win32 and beyond)
                        string filePath = Literal.CoreReplace(file.Remove(0, mod.SelectedPath.Length).Substring(1));

                        // Absolute file path (from the mod) combined with the game directory
                        string vanillaFilePath = Path.Combine(Path.GetDirectoryName(Properties.Settings.Default.Path_GameExecutable), filePath);

                        if (!File.Exists(vanillaFilePath)) return "The selected mod contains an incompatible filesystem...";
                        else {
                            if (Path.GetExtension(file) == ".arc") {
                                string incompatibleArc = "The selected mod contains incompatible archives...";

                                switch (system) {
                                    case "Xbox 360":
                                        if (!File.ReadAllText(file).Contains("xenon") && !File.ReadAllText(file).Contains("win32")) return incompatibleArc;
                                        break;
                                    case "PlayStation 3":
                                        if (!File.ReadAllText(file).Contains("ps3") && !File.ReadAllText(file).Contains("win32")) return incompatibleArc;
                                        break;
                                    case "All Systems":
                                        break;
                                    default:
                                        return incompatibleArc;
                                }
                            }
                        }
                    }

                    return "The selected mod should work properly with your configuration.";
                }
                else
                    return "The selected mod doesn't have a configuration file.";
            }

            return string.Empty;
        }
    }

    class Paths
    {
        /// <summary>
        /// Returns the first directory of a path.
        /// </summary>
        public static string GetRootFolder(string path) {
            while (true) {
                string temp = Path.GetDirectoryName(path);
                if (string.IsNullOrEmpty(temp))
                    break;
                path = temp;
            }
            return path;
        }

        /// <summary>
        /// Returns the full path without an extension.
        /// </summary>
        public static string GetPathWithoutExtension(string path) {
            return Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
        }

        /// <summary>
        /// Returns the folder containing the file.
        /// </summary>
        public static string GetContainingFolder(string path) {
            return Path.GetFileName(Path.GetDirectoryName(path));
        }

        /// <summary>
        /// Returns if the directory is empty.
        /// </summary>
        public static bool IsDirectoryEmpty(string path) {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        /// <summary>
        /// Checks if the path is valid and exists.
        /// </summary>
        public static bool CheckPathLegitimacy(string path) {
            if (Directory.Exists(path) && path != string.Empty) return true;
            else return false;
        }

        /// <summary>
        /// Checks if the path is valid and exists.
        /// </summary>
        public static bool CheckFileLegitimacy(string path) {
            if (File.Exists(path) && path != string.Empty) return true;
            else return false;
        }

        /// <summary>
        /// Returns a new path with the specified filename.
        /// </summary>
        public static string ReplaceFilename(string path, string newFile) {
            return Path.Combine(Path.GetDirectoryName(path), Path.GetFileName(newFile));
        }

        /// <summary>
        /// Collects the general file structure for '06 mods.
        /// </summary>
        public static List<string> CollectModData(string path) {
            return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)
                    .Where(s => Path.GetExtension(s) == ".arc"        ||
                                Path.GetExtension(s) == ".wmv"        ||
                                Path.GetExtension(s) == ".xma"        ||
                                Path.GetFileName(s)  == "default.xex" ||
                                Path.GetFileName(s)  == "EBOOT.BIN"   ||
                                Path.GetExtension(s) == ".pam"        ||
                                Path.GetExtension(s) == ".at3").ToList();
        }

        /// <summary>
        /// Compares two strings to check if one is a subdirectory of the other.
        /// </summary>
        public static bool IsSubdirectory(string candidate, string other) {
            var isChild = false;

            try {
                var candidateInfo = new DirectoryInfo(candidate);
                var otherInfo = new DirectoryInfo(other);

                while (candidateInfo.Parent != null) {
                    if (candidateInfo.Parent.FullName == otherInfo.FullName) {
                        isChild = true;
                        break;
                    } else candidateInfo = candidateInfo.Parent;
                }
            } catch (Exception ex) {
                Console.WriteLine($"[{DateTime.Now:hh:mm:ss tt}] [Error] Failed to check directories...\n{ex}");
            }

            return isChild;
        }
    }

    class Bytes
    {
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        /// <summary>
        /// Converts a virtual address to physical for writing to the executable.
        /// </summary>
        /// <param name="virtualAddr">The virtual address to convert to physical.</param>
        public static int GetPhysicalFromVirtual(int virtualAddr)
        {
            switch (Literal.System(Properties.Settings.Default.Path_GameExecutable))
            {
                case "Xbox 360":
                    return (int)((virtualAddr - 0x82000000) + 0x3000);

                case "PlayStation 3":
                    return virtualAddr - 0x10000;
            }

            return virtualAddr;
        }
    }
}
