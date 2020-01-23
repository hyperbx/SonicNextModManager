using System.IO;
using System.Linq;
using Unify.Serialisers;
using Unify.Environment3;
using System.Diagnostics;
using Unify.Globalisation;
using System.Collections.Generic;

namespace Unify.Patcher
{
    class ModEngine
    {
        public static List<string> skipped = new List<string>(),
                                   corepkg = new List<string>(),
                                   win32pkg = new List<string>();

        public static void InstallMods(string mod, string name) {
            string platform = INISerialiser.DeserialiseKey("Platform", mod);
            bool merge = bool.Parse(INISerialiser.DeserialiseKey("Merge", mod));
            string[] custom = INISerialiser.DeserialiseKey("Custom", mod).Split(',');
            string[] read_only = INISerialiser.DeserialiseKey("Read-only", mod).Split(',');
            
            //Handle skipping the mod if the platform is wrong
            if ((Literal.System() == "Xbox 360" && platform == "PlayStation 3") ||
                (Literal.System() == "PlayStation 3" && platform == "Xbox 360")) {
                    skipped.Add($"► {name} (failed because the mod was not targeted for the {platform})");
                    return;
            }

            List<string> files = Directory.GetFiles(Path.GetDirectoryName(mod), "*.*", SearchOption.AllDirectories)
                                .Where(s => s.EndsWith(".arc") ||
                                            s.EndsWith(".wmv") ||
                                            s.EndsWith(".xma") ||
                                            s.EndsWith("default.xex") ||
                                            s.EndsWith("EBOOT.BIN") ||
                                            s.EndsWith(".pam") ||
                                            s.EndsWith(".at3")).ToList();

            foreach (string file in files) {
                string filePath = file.Remove(0, Path.GetDirectoryName(mod).Length);
                string vanillaFilePath = Path.Combine(Path.GetDirectoryName(Properties.Settings.Default.GameDirectory), filePath.Substring(1));
                string targetFilePath = $"{vanillaFilePath}_back";

                if (custom.Contains(Path.GetFileName(file)) && Path.GetExtension(file) == ".arc") {
                    if (filePath.Contains("win32")) win32pkg.Add(Path.GetFileName(file));
                    else corepkg.Add(Path.GetFileName(file));
                }

                if (File.Exists(vanillaFilePath) && !File.Exists(targetFilePath)) File.Copy(vanillaFilePath, targetFilePath, false);

                if (Path.GetExtension(file) == ".arc" && merge && !read_only.Contains(Path.GetFileName(file)) && !custom.Contains(Path.GetFileName(file))) { //Check if file should be merged
                    if (Properties.Settings.Default.Debug) RushInterface.Log = $"Merging: {file}";
                    Merge(vanillaFilePath, file);
                } else { //Copy file
                    if (Properties.Settings.Default.Debug) RushInterface.Log = $"Copying: {file}";
                    File.Copy(file, vanillaFilePath, true);
                }

                if (corepkg.Count != 0 || win32pkg.Count != 0) {
                    if (platform == "Xbox 360") CustomFilesystemPackage("xenon");
                    else if (platform == "PlayStation 3") CustomFilesystemPackage("ps3");
                    else {
                        skipped.Add($"► {name} (failed because the targeted platform was invalid)");
                        return;
                    }
                }
            }
        }

        public static void CustomFilesystemPackage(string platform) { //Create a custom PKG based on all the custom arcs specified in mods
            string system = Path.Combine(Path.GetDirectoryName(Properties.Settings.Default.GameDirectory), platform, "archives", "system.arc");
            if (!File.Exists($"{system}_back"))
                File.Copy(system, $"{system}_back", true);
            string unpack = UnpackARC(system, Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()));

            //Unpack PKG
            string directoryRoot = Path.Combine(unpack, $"system\\{platform}\\archive");
            PKG.PKGTool($"{directoryRoot}.pkg");
            List<string> basePKG = File.ReadAllLines($"{directoryRoot}.txt").ToList();

            //Edited text file
            if (corepkg.Count != 0) {
                basePKG.Add("\"archive\"\n{");
                foreach (string arc in corepkg) {
                    basePKG.Add($"\t\"{Path.GetFileNameWithoutExtension(arc)}\" = \"archives/{arc}\";");
                }
                basePKG.Add("}");
            }

            if (win32pkg.Count != 0) {
                basePKG.Add("\"archive_win32\"\n{");
                foreach (string arc in win32pkg) {
                    basePKG.Add($"\t\"{Path.GetFileNameWithoutExtension(arc)}\" = \"archives/{arc}\";");
                }
                basePKG.Add("}");
            }

            File.WriteAllLines($"{directoryRoot}.txt", basePKG); //Resave the edited text file

            //Resave PKG file
            PKG.PKGTool($"{directoryRoot}.txt");
            RepackARC(unpack, system);

            //Clear lists
            corepkg.Clear();
            win32pkg.Clear();
        }

        public static string UnpackARC(string arc, string tempPath) {
            Directory.CreateDirectory(tempPath);
            File.Copy(arc, Path.Combine(tempPath, Path.GetFileName(arc)));

            var unpack = new ProcessStartInfo($"{Program.ApplicationData}\\Unify\\Tools\\arctool.exe", $"-d \"{Path.Combine(tempPath, Path.GetFileName(arc))}\"") {
                WorkingDirectory = $"{Program.ApplicationData}\\Unify\\Tools\\",
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

            repack = new ProcessStartInfo($"{Program.ApplicationData}\\Unify\\Tools\\arctool.exe", $"-f -i \"{Path.Combine(tempPath, Path.GetFileNameWithoutExtension(output))}\" -c \"{output}\"") {
                WorkingDirectory = $"{Program.ApplicationData}\\Unify\\Tools\\",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var Repack = Process.Start(repack);
            Repack.WaitForExit();
            Repack.Close();
            
            try {
                if (Directory.Exists(tempPath)) {
                    foreach (FileInfo file in tempData.GetFiles()) file.Delete();
                    foreach (DirectoryInfo directory in tempData.GetDirectories()) directory.Delete(true);
                }
            } catch { return tempPath; }

            return tempPath;
        }

        public static void Merge(string arc1, string arc2) {
            string tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()); // Defines the temporary path.
            Directory.CreateDirectory(tempPath);
            string unpack1 = UnpackARC(arc1, tempPath);
            ProcessStartInfo arctool;

            RushInterface.Log = unpack1;
            File.Copy(arc2, Path.Combine(tempPath, Path.GetFileName(arc2)), true); // Copies the input ARC to the temporary path.
            RushInterface.Log = Path.Combine(tempPath, Path.GetFileName(arc2));

            // Defines the arctool process.
            arctool = new ProcessStartInfo() {
                FileName = $"{Program.ApplicationData}\\Unify\\Tools\\arctool.exe",
                Arguments = $"-d \"{Path.Combine(tempPath, Path.GetFileName(arc2))}\"",
                WorkingDirectory = $"{Program.ApplicationData}\\Unify\\Tools\\",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var Unpack2 = Process.Start(arctool); // Unpacks the merge ARC.
            Unpack2.WaitForExit();

            File.Delete(Path.Combine(tempPath, Path.GetFileName(arc2))); // Deletes the temporary merge ARC.

            RepackARC(unpack1, arc1);
        }
    }

    //To-Do later
    class PatchEngine { }

    class PKG
    {
        //Use the PKGTool to encode/decode the given file
        public static void PKGTool(string filepath) {
            string pkgtool = $"{Program.ApplicationData}\\Unify\\Tools\\pkgtool.exe";
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = pkgtool,
                Arguments = filepath
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            if (Path.GetExtension(filepath) == ".txt") File.Delete(filepath);
        }

        public static void AddEntry(string filepath, string directoryRoot, string key, string _event, string reference) {
            if (!File.Exists($"{filepath}_orig"))
                File.Copy(filepath, $"{filepath}_orig", true);
            string unpack = ModEngine.UnpackARC(filepath, Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()));

            //Unpack PKG
            PKGTool($"{Path.Combine(unpack, directoryRoot)}.pkg");
            List<string> basePKG = File.ReadAllLines($"{Path.Combine(unpack, directoryRoot)}.txt").ToList();
            bool keyfound = false;
            int lineNum = 0;

            foreach (string line in basePKG) {
                if (line.StartsWith($"\"{key}\"")) {
                    keyfound = true;
                    basePKG.Insert(lineNum + 2, $"\t\"{_event}\" = \"{reference}\";");
                    break;
                }
                lineNum++;
            }

            if (keyfound == false) {
                basePKG.Add($"\"{key}\"\n{"{"}");
                basePKG.Add($"\t\"{_event}\" = \"{reference}\";");
                basePKG.Add("}");
            }

            File.WriteAllLines($"{Path.Combine(unpack, directoryRoot)}.txt", basePKG); //Resave the edited text file

            //Resave PKG file
            PKGTool($"{Path.Combine(unpack, directoryRoot)}.txt");
            ModEngine.RepackARC(unpack, filepath);
        }
    }
}
