using System;
using System.IO;
using Ookii.Dialogs;
using Unify.Messages;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
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
            VistaFolderBrowserDialog game = new VistaFolderBrowserDialog
            {
                Description = EmulatorMessages.msg_LocateGame,
                UseDescriptionForTitle = true,
            };

            if (game.ShowDialog() == DialogResult.OK)
            {
                Sonic_06_Mod_Manager.Properties.Settings.Default.gameDirectory = game.SelectedPath;
                Sonic_06_Mod_Manager.Properties.Settings.Default.Save();
            }

            return game.SelectedPath;
        }

        public static string LocateMods()
        {
            //Select mods directory and save.
            VistaFolderBrowserDialog mods = new VistaFolderBrowserDialog
            {
                Description = SettingsMessages.msg_LocateMods,
                UseDescriptionForTitle = true,
            };

            if (mods.ShowDialog() == DialogResult.OK)
            {
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
            {
                emulator = new OpenFileDialog
                {
                    Title = EmulatorMessages.msg_LocateXenia,
                    Filter = "Programs (*.exe)|*.exe"
                };
            }
            else
            {
                emulator = new OpenFileDialog
                {
                    Title = EmulatorMessages.msg_LocateRPCS3,
                    Filter = "Programs (*.exe)|*.exe"
                };
            }

            if (emulator.ShowDialog() == DialogResult.OK)
            {
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
            OpenFileDialog readonlyARC = new OpenFileDialog
            {
                Title = ModsMessages.msg_LocateARCs,
                Filter = "ARC files (*.arc)|*.arc",
                Multiselect = true
            };

            if (readonlyARC.ShowDialog() == DialogResult.OK)
            {
                foreach (string name in readonlyARC.FileNames)
                {
                    csvList += $"{Path.GetFileName(name)},";
                }
            }
            else return string.Empty;

            return csvList;
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
}
