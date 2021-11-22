using System.Diagnostics;
using Marathon.Formats.Archive;
using Marathon.Formats.Script.Lua;
using Marathon.IO;

namespace SonicNextModManager.IO.Callback
{
    public class IOFunctions
    {
        private static Dictionary<string, U8Archive> _archives = new();

        /// <summary>
        /// Loads an archive from the input path.
        /// </summary>
        /// <param name="path">Path to archive.</param>
        public static void LoadArchive(string path)
        {
            if (_archives.ContainsKey(path))
                _archives[path].Dispose();

            _archives[path] = new U8Archive(path, ReadMode.IndexOnly);
        }

        /// <summary>
        /// Saves an archive from the input path.
        /// </summary>
        /// <param name="path">Path to archive.</param>
        public static void SaveArchive(string path)
        {
            _archives[path].Save();
            _archives.Remove(path);
        }

        /// <summary>
        /// Writes a file to the loaded archive.
        /// </summary>
        /// <param name="path">Archive to write data to.</param>
        /// <param name="internalPath">Path to write the file to inside the archive.</param>
        /// <param name="filePath">Path to the file to read data from.</param>
        public static void WriteFile(string path, string internalPath, string filePath)
        {
            _archives[path].Root.CreateDirectories(Path.GetDirectoryName(internalPath)).Add
            (
                new U8ArchiveFile(filePath)
                {
                    Name = Path.GetFileName(internalPath)
                }
            );
        }

        /// <summary>
        /// Encrypts the current game executable (required step for PlayStation executable patching).
        /// </summary>
        public static bool EncryptExecutable()
        {
            string? executable = App.Settings.Path_GameExecutable;

            switch (App.CurrentPlatform)
            {
                case Platform.Xbox:
                {
                    Process.Start
                    (
                        new ProcessStartInfo()
                        {
                            Arguments = $"-e e \"{executable}\"",
                            FileName = App.Modules["xextool"],
                            WindowStyle = ProcessWindowStyle.Hidden
                        }
                    )
                    .WaitForExit();

                    return true;
                }

                case Platform.PlayStation:
                {
                    string encrypt = $"{executable}_ENC";

                    Process.Start
                    (
                        new ProcessStartInfo()
                        {
                            Arguments = $"\"{executable}\" \"{encrypt}\"",
                            FileName = App.Modules["make_fself"],
                            WindowStyle = ProcessWindowStyle.Hidden
                        }
                    )
                    .WaitForExit();

                    // Overwrite decrypted executable with the encrypted result.
                    if (File.Exists(encrypt))
                        File.Move(encrypt, executable, true);

                    return true;
                }

                default:
                    return false;
            }
        }

        /// <summary>
        /// Decrypts the current game executable.
        /// </summary>
        public static bool DecryptExecutable()
        {
            string? executable = App.Settings.Path_GameExecutable;

            switch (App.CurrentPlatform)
            {
                case Platform.Xbox:
                {
                    Process.Start
                    (
                        new ProcessStartInfo()
                        {
                            Arguments = $"-e u -c b \"{executable}\"",
                            FileName = App.Modules["xextool"],
                            WindowStyle = ProcessWindowStyle.Hidden
                        }
                    )
                    .WaitForExit();

                    return true;
                }

                case Platform.PlayStation:
                {
                    Process.Start
                    (
                        new ProcessStartInfo()
                        {
                            Arguments = $"-d \"{executable}\" \"{executable}\"",
                            FileName = App.Modules["scetool"],
                            WindowStyle = ProcessWindowStyle.Hidden
                        }
                    )
                    .WaitForExit();

                    return true;
                }

                default:
                    return false;
            }
        }

        /// <summary>
        /// Decompiles the input Lua script.
        /// </summary>
        public static bool DecompileLua(string path)
        {
            LuaBinary lub = new(path);
            lub.Decompile();

            return false;
        }
    }
}
