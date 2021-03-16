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

using System;
using System.IO;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.Generic;
using Unify.Serialisers;
using Unify.Globalisation;
using Unify.Messenger;

namespace Unify
{
    public class Profile
    {
        public static List<string> Mods = new List<string>(),
                                   Patches = new List<string>(),
                                   Tweaks = new List<string>();

        /// <summary>
        /// Clears the lists.
        /// </summary>
        public static void Clear()
        {
            Mods.Clear();
            Patches.Clear();
            Tweaks.Clear();
        }

        public static void Create(string name, ListView modsList, ListView patchesList)
        {
#if !DEBUG
            try
            {
#endif
                string profile = Path.Combine(Program.Profiles, $"{Literal.UseSafeFormattedCharacters(name)}.06mm");

                if (File.Exists(profile))
                {
                    DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog
                    (
                        "A profile already exists with this name! Would you like to overwrite it?",
                        "Profile already exists...",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirmation == DialogResult.No)
                    {
                        return;
                    }
                }

                using (StreamWriter sw = File.CreateText(profile))
                {
                    sw.WriteLine($"Sonic '06 Mod Manager\n{DateTime.Now}");

                    // Print list of checked mods
                    if (modsList.CheckedItems.Count != 0)
                    {
                        sw.WriteLine("\nMods:");

                        // Writes the list in reverse so the mods list writes it in it's preferred order
                        for (int i = modsList.Items.Count - 1; i >= 0; i--)
                        {
                            if (modsList.Items[i].Checked) // Get checked state
                            {
                                // Write mod name by folder name to prevent duplicate mod names conflicting
                                sw.WriteLine(Path.GetFileName(Path.GetDirectoryName(modsList.Items[i].SubItems[6].Text)));
                            }
                        }
                    }

                    // Print list of checked patches
                    if (patchesList.CheckedItems.Count != 0)
                    {
                        sw.WriteLine("\nPatches:");

                        // Writes in reverse so the patches list writes it in it's preferred order
                        for (int i = patchesList.Items.Count - 1; i >= 0; i--)
                        {
                            if (patchesList.Items[i].Checked) // Get checked state
                            {
                                // Write patch name by file name to prevent duplicate patch names conflicting
                                sw.WriteLine(Path.GetFileName(patchesList.Items[i].SubItems[5].Text));
                            }
                        }
                    }

                    // Print list of current tweaks
                    sw.WriteLine("\nTweaks:");

                    // Order doesn't matter, so just write normally
                    foreach (SettingsPropertyValue property in Properties.Settings.Default.PropertyValues)
                    {
                        if (property.Name.StartsWith("Tweak_"))
                        {
                            sw.WriteLine($"{property.Name}: {property.PropertyValue}");
                        }
                    }

                    // Set last used profile to the newly created one
                    Properties.Settings.Default.General_Profile = name;

                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Success] Created profile successfully!");
                }
#if !DEBUG
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Error] Failed to create profile...\n{ex}");
            }
#endif
        }

        public static void GetInfo(string path)
        {
            // Clear previous lists
            Clear();

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string section = string.Empty, line;

                while ((line = sr.ReadLine()) != null)
                {
                    if
                    (
                        line == "Mods:" ||
                        line == "Patches:" ||
                        line == "Tweaks:"
                    )
                    {
                        section = line;
                    }

                    if (line != string.Empty && line != section)
                    {
                        switch (section)
                        {
                            case "Mods:":
                            {
                                Mods.Add(line);
                                break;
                            }

                            case "Patches:":
                            {
                                Patches.Add(line);
                                break;
                            }

                            case "Tweaks:":
                            {
                                Tweaks.Add(line);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public static void Load(string path)
        {
#if !DEBUG
            try
            {
#endif
                // Get info about this profile
                GetInfo(path);

                if (Paths.CheckPathLegitimacy(Properties.Settings.Default.Path_ModsDirectory))
                {
                    //Save the names of the selected mods and the indexes of the selected patches to their appropriate INI files
                    string modCheckList = Path.Combine(Properties.Settings.Default.Path_ModsDirectory, "mods.ini");
                    string patchCheckList = Path.Combine(Properties.Settings.Default.Path_ModsDirectory, "patches.ini");

                    // Create 'mods.ini'
                    using (StreamWriter sw = File.CreateText(modCheckList))
                        sw.WriteLine("[Main]"); // [Main] specification

                    // Writes the list in reverse so the mods list writes it in it's preferred order
                    foreach (string mod in Mods)
                    {
                        using (StreamWriter sw = File.AppendText(modCheckList))
                        {
                            // Write mod name by folder name to prevent duplicate mod names conflicting
                            sw.WriteLine(mod);
                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Profile] Written mod '{mod}' to configuration");
                        }
                    }

                    // Create 'patches.ini'
                    try
                    {
                        using (StreamWriter sw = File.CreateText(patchCheckList))
                            sw.WriteLine("[Main]"); // [Main] specification

                        // Writes in reverse so the patches list writes it in it's preferred order
                        foreach (string patch in Patches)
                        {
                            using (StreamWriter sw = File.AppendText(patchCheckList))
                            {
                                // Write patch name by file name to prevent duplicate patch names conflicting
                                sw.WriteLine(patch);
                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Profile] Written patch '{patch}' to configuration");
                            }
                        }
                    }
                    catch { }
                }

                foreach (SettingsPropertyValue property in Properties.Settings.Default.PropertyValues)
                {
                    foreach (string tweak in Tweaks)
                    {
                        int valueSplit = tweak.Split(' ')[0].Length + 1;

                        if (tweak.StartsWith(property.Name))
                        {
                            property.PropertyValue = Convert.ChangeType(tweak.Remove(0, valueSplit), property.PropertyValue.GetType());

                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Profile] Configured tweak '{property.Name}'");
                        }
                    }
                }

                Properties.Settings.Default.Save();

                Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Success] Loaded profile successfully!");
#if !DEBUG
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss tt}] [Error] Failed to load profile...\n{ex}");
            }
#endif
        }
    }
}
