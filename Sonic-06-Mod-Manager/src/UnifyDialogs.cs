using Ookii.Dialogs;
using Unify.Globalisation;
using System.Windows.Forms;

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

namespace Unify.Dialogs
{
    class RequestPath
    {
        public static string GameExecutable() {
            OpenFileDialog browseGame = new OpenFileDialog() {
                Title = "Please select an executable for Sonic '06...",
                Filter = "Exectuables (*.xex; *.bin)|*.xex;*.bin|" +
                         "Xbox Executable (*.xex)|*.xex|" +
                         "PlayStation Executable (*.bin)|*.bin"
            };

            if (browseGame.ShowDialog() == DialogResult.OK) return browseGame.FileName;
            else return string.Empty;
        }

        public static string ModsDirectory() {
            VistaFolderBrowserDialog browseMods = new VistaFolderBrowserDialog() {
                Description = "Please select your mods directory...",
                UseDescriptionForTitle = true
            };

            if (browseMods.ShowDialog() == DialogResult.OK) return browseMods.SelectedPath;
            else return string.Empty;
        }

        public static string EmulatorExecutable() {
            string title = "Please select an executable...";

            if (Literal.Emulator(Properties.Settings.Default.Path_GameExecutable) != "unspecified")
                title = $"Please select an executable for {Literal.Emulator(Properties.Settings.Default.Path_GameExecutable)}...";

            OpenFileDialog browseEmulator = new OpenFileDialog() {
                Title = title,
                Filter = "Programs (*.exe)|*.exe"
            };

            if (browseEmulator.ShowDialog() == DialogResult.OK) return browseEmulator.FileName;
            else return string.Empty;
        }

        public static string SaveData() {
            OpenFileDialog browseSave = new OpenFileDialog() {
                Title = $"Please select Sonic '06 save data...",
                Filter = "Save Data|SonicNextSaveData.bin; SYS-DATA|" +
                         "Xbox 360 Save File|SonicNextSaveData.bin|" +
                         "PlayStation 3 Save File|SYS-DATA"
            };

            if (browseSave.ShowDialog() == DialogResult.OK) return browseSave.FileName;
            else return string.Empty;
        }
    }
}
