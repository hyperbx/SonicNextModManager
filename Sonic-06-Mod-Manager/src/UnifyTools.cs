using System;
using System.IO;
using Ookii.Dialogs;
using Unify.Messages;
using Microsoft.Win32;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO.Compression;
using System.Threading.Tasks;

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

namespace Unify.Tools
{
    class Locations
    {
        public static string LocateGame()
        {
            //Select game directory and save.
            VistaFolderBrowserDialog game = new VistaFolderBrowserDialog {
                Description = EmulatorMessages.msg_LocateGame,
                UseDescriptionForTitle = true,
            };

            if (game.ShowDialog() == DialogResult.OK) {
                Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory = game.SelectedPath;
                Sonic_06_Mod_Manager.Properties.Settings.Default.Save();
            }

            return game.SelectedPath;
        }

        public static string LocateMods()
        {
            //Select mods directory and save.
            VistaFolderBrowserDialog mods = new VistaFolderBrowserDialog {
                Description = SettingsMessages.msg_LocateMods,
                UseDescriptionForTitle = true,
            };

            if (mods.ShowDialog() == DialogResult.OK) {
                Sonic_06_Mod_Manager.Properties.Settings.Default.modsDirectory = mods.SelectedPath;
                Sonic_06_Mod_Manager.Properties.Settings.Default.Save();
            }

            return mods.SelectedPath;
        }

        public static string LocateEmulator()
        {
            //Select Emulator Executable and save.
            OpenFileDialog emulator;

            if (Sonic_06_Mod_Manager.Properties.Settings.Default.emulatorSystem == 0)
                emulator = new OpenFileDialog {
                    Title = EmulatorMessages.msg_LocateXenia,
                    Filter = "Programs (*.exe)|*.exe"
                };
            else
                emulator = new OpenFileDialog {
                    Title = EmulatorMessages.msg_LocateRPCS3,
                    Filter = "Programs (*.exe)|*.exe"
                };

            if (emulator.ShowDialog() == DialogResult.OK) {
                //Depending on the selected system, save to their respective Property.
                if (Sonic_06_Mod_Manager.Properties.Settings.Default.emulatorSystem == 0)
                    Sonic_06_Mod_Manager.Properties.Settings.Default.xeniaPath = emulator.FileName;
                else
                    Sonic_06_Mod_Manager.Properties.Settings.Default.RPCS3Path = emulator.FileName;
                Sonic_06_Mod_Manager.Properties.Settings.Default.Save();
            }

            return emulator.FileName;
        }

        public static string LocateARCs()
        {
            string csvList = string.Empty;

            //Select ARCs for Read-only parameters and save.
            OpenFileDialog readonlyARC = new OpenFileDialog {
                Title = ModsMessages.msg_LocateARCs,
                Filter = "ARC files (*.arc)|*.arc",
                Multiselect = true
            };

            if (readonlyARC.ShowDialog() == DialogResult.OK)
                foreach (string name in readonlyARC.FileNames)
                    csvList += $"{Path.GetFileName(name)},";
            else return string.Empty;

            return csvList;
        }

        public static string LocateSaves(int system)
        {
            OpenFileDialog save;

            //Select ARCs for Read-only parameters and save.
            if (system == 0) {
                save = new OpenFileDialog {
                    Title = ModsMessages.msg_LocateSaveX,
                    Filter = "Xbox 360 Save File (*.bin)|*.bin",
                    Multiselect = true
                };
            }
            else if (system == 1) {
                save = new OpenFileDialog {
                    Title = ModsMessages.msg_LocateSavePS,
                    Filter = "PlayStation 3 Save File|SYS-DATA",
                    Multiselect = true
                };
            }
            else {
                save = new OpenFileDialog {
                    Title = ModsMessages.msg_LocateSave,
                    Filter = "Xbox 360 Save File (*.bin)|*.bin|PlayStation 3 Save File|SYS-DATA",
                    Multiselect = true
                };
            }

            if (save.ShowDialog() == DialogResult.OK)
                return save.FileName;
            else
                return string.Empty;
        }
    }

    public static class Threading
    {
        public static async Task WaitForExitAsync(this Process process, CancellationToken cancellationToken = default)
        {
            var tcs = new TaskCompletionSource<bool>();

            void Process_Exited(object sender, EventArgs e)
            {
                tcs.TrySetResult(true);
            }

            process.EnableRaisingEvents = true;
            process.Exited += Process_Exited;

            try
            {
                if (process.HasExited)
                {
                    return;
                }

                using (cancellationToken.Register(() => tcs.TrySetCanceled()))
                {
                    await tcs.Task;
                }
            }
            finally
            {
                process.Exited -= Process_Exited;
            }
        }
    }

    public static class GB_Registry
    {
        public static string protocol = "sonic06mm";
        public static RegistryKey sonic06mmKey = Registry.ClassesRoot.OpenSubKey($"{protocol}\\shell\\open\\command");

        public static void AddRegistry()
        {
            sonic06mmKey = Registry.ClassesRoot.OpenSubKey(protocol, true);
            if (sonic06mmKey == null)
                sonic06mmKey = Registry.ClassesRoot.CreateSubKey(protocol);
            sonic06mmKey.SetValue("", "URL:Sonic '06 Mod Manager");
            sonic06mmKey.SetValue("URL Protocol", "");
            var prevkey = sonic06mmKey;
            sonic06mmKey = sonic06mmKey.OpenSubKey("shell", true);
            if (sonic06mmKey == null)
                sonic06mmKey = prevkey.CreateSubKey("shell");
            prevkey = sonic06mmKey;
            sonic06mmKey = sonic06mmKey.OpenSubKey("open", true);
            if (sonic06mmKey == null)
                sonic06mmKey = prevkey.CreateSubKey("open");
            prevkey = sonic06mmKey;
            sonic06mmKey = sonic06mmKey.OpenSubKey("command", true);
            if (sonic06mmKey == null)
                sonic06mmKey = prevkey.CreateSubKey("command");

            sonic06mmKey.SetValue("", $"\"{Application.ExecutablePath}\" \"-banana\" \"%1\"");
            sonic06mmKey.Close();
        }

        public static void RemoveRegistry()
        {
            // Delete the key instead of trying to change it
            var CurrentUser = Registry.ClassesRoot;
            CurrentUser.DeleteSubKeyTree(protocol, false);
            CurrentUser.Close();
        }
    }

    public static class Archives
    {
        public static void InstallFromZip(string ZipPath, string cache) {
            try {
                // Extracts all contents inside of the zip file
                ZipFile.ExtractToDirectory(ZipPath, Sonic_06_Mod_Manager.Properties.Settings.Default.modsDirectory);

                // Deletes the temp folder with all of its contents
                Directory.Delete(cache, true);
            }
            catch { InstallFrom7zArchive(ZipPath, cache); }
        }

        // Requires 7-Zip to be installed.
        public static void InstallFrom7zArchive(string ArchivePath, string cache) {
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
                var psi = new ProcessStartInfo(exe, $"x \"{ArchivePath}\" -o\"{Sonic_06_Mod_Manager.Properties.Settings.Default.modsDirectory}\" -y");
                psi.CreateNoWindow = true;
                Process.Start(psi).WaitForExit(1000 * 60 * 5);

                // Deletes the temp folder with all of its contents.
                Directory.Delete(cache, true);
                key.Close();
            }
            else { InstallFromWinRAR(ArchivePath, cache); }

        }

        // Requires WinRAR to be installed.
        public static void InstallFromWinRAR(string ArchivePath, string cache) {
            // Gets WinRAR's Registry Key.
            var key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WinRAR");
            // If null then try to get it from the 64-bit registry.
            if (key == null)
                key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\WinRAR");
            if (key != null && key.GetValue("exe64") is string path) {
                // Extracts the archive to the temp folder.
                var psi = new ProcessStartInfo(path, $"x \"{ArchivePath}\" \"{Sonic_06_Mod_Manager.Properties.Settings.Default.modsDirectory}\"");
                psi.CreateNoWindow = true;
                Process.Start(psi).WaitForExit(1000 * 60 * 5);

                // Deletes the temp folder with all of its contents.
                Directory.Delete(cache, true);
                key.Close();

            } else { UnifyMessages.UnifyMessage.Show(ModsMessages.ex_ExtractFailNoApp, SystemMessages.tl_ExtractError, "OK", "Error"); }
        }
    }

    public class Prerequisites
    {
        public static bool JavaCheck()
        {
            try {
                var javaArg = new ProcessStartInfo("java", "-version") {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                var javaProcess = new Process { StartInfo = javaArg };
                javaProcess.Start();

                return true;
            }
            catch { return false; }
        }
    }

    public class Bytes
    {
        public static byte[] StringToByteArray(string hex) {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static byte[] StringToByteArrayExtended(string hex) {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static bool ByteArrayToFile(string fileName, byte[] byteArray) {
            using (var fs = new FileStream(fileName, FileMode.Append, FileAccess.Write)) {
                fs.Write(byteArray, 0, byteArray.Length);
                return true;
            }
        }
    }
}
