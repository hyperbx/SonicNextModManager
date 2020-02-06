using Ookii.Dialogs;
using Unify.Globalisation;
using System.Windows.Forms;

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

            if (Literal.Emulator(Properties.Settings.Default.Path_GameDirectory) != "unspecified")
                title = $"Please select an executable for {Literal.Emulator(Properties.Settings.Default.Path_GameDirectory)}...";

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
