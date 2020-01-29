using System;
using System.IO;
using System.Linq;
using Unify.Messenger;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using Unify.Networking.GameBanana;

// Sonic '06 Mod Manager is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2020 Knuxfan24
 * Copyright (c) 2020 Gabriel (HyperPolygon64)

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

namespace Unify.Environment3
{
    static class Program
    {
        public static readonly string VersionNumber = "Version 3.0-indev-290120r1";
        public static string ApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                             Arctool         = $"{ApplicationData}\\Unify\\Tools\\arctool.exe",
                             XexTool         = $"{ApplicationData}\\Unify\\Tools\\xextool.exe",
                             pkgtool         = $"{ApplicationData}\\Unify\\Tools\\pkgtool.exe",
                             vcruntime       = $"{ApplicationData}\\Unify\\Tools\\vcruntime140_1.dll",
                             unlub           = $"{ApplicationData}\\Unify\\Tools\\unlub.jar",
                             Patches         = $"{ApplicationData}\\Unify\\Patches\\",
                             ProtocolManager = $"{ApplicationData}\\Unify\\Tools\\Protocol Manager.exe";

        [STAThread]

        static void Main(string[] args) {
            // Write required pre-requisites to the Tools directory
            if (!Directory.Exists($"{ApplicationData}\\Unify\\Tools\\"))
                Directory.CreateDirectory($"{ApplicationData}\\Unify\\Tools\\");

            if (!Directory.Exists(Patches))
                Directory.CreateDirectory(Patches);

            if (!File.Exists(Arctool))
                File.WriteAllBytes(Arctool, Properties.Resources.arctool);

            if (!File.Exists(XexTool))
                File.WriteAllBytes(XexTool, Properties.Resources.xextool);

            if (!File.Exists(pkgtool))
                File.WriteAllBytes(pkgtool, Properties.Resources.pkgtool);

            if (!File.Exists(vcruntime))
                File.WriteAllBytes(vcruntime, Properties.Resources.vcruntime140_1);

            if (!File.Exists(unlub))
                File.WriteAllBytes(unlub, Properties.Resources.unlub);

            if (!File.Exists(ProtocolManager))
                File.WriteAllBytes(ProtocolManager, Properties.Resources.Protocol_Manager);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if !DEBUG
            try {
#endif
                // Ensure application can't be run more than once
                if ((Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)).Count() > 1) == false) {
                    if (args.Length > 0) {
                        if (args[0] == "-banana") {
                            string[] getIDs = args[1].Remove(0, 40).Split(','); // Split URL
                            string modType = string.Empty;
                            int downloadID = 0;
                            int modID = 0;
                            int i = 0;

                            //Get IDs from URL
                            foreach (var item in getIDs)
                                if      (i == 0) { int.TryParse(item, out downloadID); { i++; } }
                                else if (i == 1) { modType = item; i++; }
                                else if (i == 2) { int.TryParse(item, out modID); { i++; } }

                            var mod = new GBAPIItemDataBasic(modType, modID);
                            if (GBAPI.RequestItemData(mod)) {
                                new ModOneClickInstall(mod, args[1], downloadID, modID).ShowDialog(); // Load 1-Click Installer
                                Application.Run(new UnifyEnvironment()); // Load everything after
                            }
                        }
                    } else
                        // Load everything
                        Application.Run(new UnifyEnvironment());

                // If application is running, just load the 1-Click Installer only
                } else if (args.Length > 0) {
                    if (args[0] == "-banana") {
                        string[] getIDs = args[1].Remove(0, 40).Split(','); // Split URL
                        string modType = string.Empty;
                        int downloadID = 0;
                        int modID = 0;
                        int i = 0;

                        //Get IDs from URL
                        foreach (var item in getIDs)
                            if      (i == 0) { int.TryParse(item, out downloadID); { i++; } }
                            else if (i == 1) { modType = item; i++; }
                            else if (i == 2) { int.TryParse(item, out modID); { i++; } }

                        var mod = new GBAPIItemDataBasic(modType, modID);
                        if (GBAPI.RequestItemData(mod)) new ModOneClickInstall(mod, args[1], downloadID, modID).ShowDialog();
                    }
                }
#if !DEBUG
            } catch (Exception ex) {
                DialogResult confirmation = UnifyMessenger.UnifyMessage.ShowDialog($"Failed to load your settings... Please report this error immediately!\n\n{ex.ToString()}\n\n" +
                                                                                   "Click OK to reset Sonic '06 Mod Manager.",
                                                                                   "Settings failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                if (confirmation == DialogResult.OK) Program.Reset(); // Reset settings
                else Process.GetCurrentProcess().Kill(); // Quit immediately
            }
#endif
        }

        /// <summary>
        /// Erases all user settings for Sonic '06 Mod Manager.
        /// </summary>
        public static void Reset() {
            try {
                string modManagerDataPath = Path.Combine(ApplicationData, "Unify");

                // Erases the Unify directory, containing Tools and user settings
                DirectoryInfo modManagerData = new DirectoryInfo(modManagerDataPath);
                if (Directory.Exists(modManagerDataPath)) {
                    foreach (FileInfo file in modManagerData.GetFiles()) file.Delete();
                    foreach (DirectoryInfo directory in modManagerData.GetDirectories()) directory.Delete(true);
                }
                Application.Restart();
            } catch { }
        }
    }
}
