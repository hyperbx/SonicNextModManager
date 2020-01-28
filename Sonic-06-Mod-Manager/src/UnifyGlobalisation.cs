using System;
using System.IO;
using Unify.Serialisers;

// Sonic '06 Mod Manager is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2020 Knuxfan24 & HyperPolygon64

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

namespace Unify.Globalisation
{
    class Literal
    {
        /// <summary>
        /// Translates a Boolean value to 'Yes' or 'No'
        /// </summary>
        public static string Bool(string value) {
            if (value == "True") return "Yes";
            else if (value == "False") return "No";
            else return "N/A";
        }

        /// <summary>
        /// Translates a file extension to 'Xbox 360' or 'PlayStation 3'
        /// </summary>
        public static string System(string path) {
            if (Path.GetExtension(path).ToLower() == ".xex") return "Xbox 360";
            if (Path.GetExtension(path).ToLower() == ".bin") return "PlayStation 3";
            else return "unspecified";
        }

        /// <summary>
        /// Translates a file extension to 'Xenia' or 'RPCS3'
        /// </summary>
        public static string Emulator(string path) {
            if (Path.GetExtension(path).ToLower() == ".xex") return "Xenia";
            if (Path.GetExtension(path).ToLower() == ".bin") return "RPCS3";
            else return "unspecified";
        }

        /// <summary>
        /// Translates a file extension to 'xenon' or 'ps3'
        /// </summary>
        public static string Core(string path) {
            if (Path.GetExtension(path).ToLower() == ".xex") return "xenon";
            if (Path.GetExtension(path).ToLower() == ".bin") return "ps3";
            else return "core";
        }

        /// <summary>
        /// Renames the 'core' folder to the appropriate system root.
        /// </summary>
        public static string CoreReplace(string path) {
            if (Paths.GetRootFolder(path) == "core") {
                string[] splitPath = path.Split('\\');

                for (int i = 0; i < splitPath.Length; i++) {
                    if (splitPath[i] == "core" && System(Properties.Settings.Default.Path_GameDirectory) == "Xbox 360") {
                        splitPath[i] = "xenon";
                        return string.Join("\\", splitPath);
                    }
                    else if (splitPath[i] == "core" && System(Properties.Settings.Default.Path_GameDirectory) == "PlayStation 3") {
                        splitPath[i] = "ps3";
                        return string.Join("\\", splitPath);
                    }
                }

                return string.Join("\\", splitPath);
            }
            else return path;
        }

        /// <summary>
        /// Formats a date string from a long.
        /// </summary>
        public static string Date(string prefix, long dateTime) {
            DateTime fromLong = new DateTime(dateTime);
            if (dateTime == 0) return $"{prefix}: Never";
            else {
                if (fromLong.Date == DateTime.Today)
                    return $"{prefix}: Today, {fromLong.ToString("hh:mm tt")}";
                else if (fromLong.Date == DateTime.Today.AddDays(-1))
                    return $"{prefix}: Yesterday, {fromLong.ToString("hh:mm tt")}";
                else
                    return $"{prefix}: {fromLong.ToString("dd/MM/yyyy, hh:mm tt")}";
            }
        }

        /// <summary>
        /// Compares two strings to check if one is a subdirectory of the other.
        /// </summary>
        public static bool IsPathSubdirectory(string candidate, string other) {
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
            } catch (Exception error) {
                var message = String.Format("Unable to check directories {0} and {1}: {2}", candidate, other, error);
                Console.WriteLine(message);
            }

            return isChild;
        }
    }
}
