using System;
using System.IO;
using System.Reflection;
using Unify.Serialisers;

// Sonic '06 Mod Manager is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2020 Knuxfan24
 * Copyright (c) 2020 HyperPolygon64

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
        /// Returns the opposite system.
        /// </summary>
        public static string OppositeSystem(string path) {
            if (System(Properties.Settings.Default.Path_GameDirectory) == "Xbox 360") return "PlayStation 3";
            else if (System(Properties.Settings.Default.Path_GameDirectory) == "PlayStation 3") return "Xbox 360";
            else return "unspecified";
        }

        /// <summary>
        /// Translates a file extension to 'Xenia' or 'RPCS3'
        /// </summary>
        public static string Emulator(string path) {
            if (Path.GetExtension(path).ToLower() == ".xex") return "Xenia";
            else if (Path.GetExtension(path).ToLower() == ".bin") return "RPCS3";
            else return "unspecified";
        }

        /// <summary>
        /// Translates a file extension to 'xenon' or 'ps3'
        /// </summary>
        public static string Core(string path) {
            if (Path.GetExtension(path).ToLower() == ".xex") return "xenon";
            else if (Path.GetExtension(path).ToLower() == ".bin") return "ps3";
            else return "core";
        }

        /// <summary>
        /// Renames the 'core' folder to the appropriate system root.
        /// </summary>
        public static string CoreReplace(string path) {
            string system = System(Properties.Settings.Default.Path_GameDirectory);

            if (Paths.GetRootFolder(path) == "core") {
                string[] splitPath = path.Split('\\');

                for (int i = 0; i < splitPath.Length; i++) {
                    if (splitPath[i] == "core" && system == "Xbox 360") {
                        splitPath[i] = "xenon";
                        return string.Join("\\", splitPath);
                    }
                    else if (splitPath[i] == "core" && system == "PlayStation 3") {
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
                    return $"{prefix}: Today, {fromLong:hh:mm tt}";
                else if (fromLong.Date == DateTime.Today.AddDays(-1))
                    return $"{prefix}: Yesterday, {fromLong:hh:mm tt}";
                else
                    return $"{prefix}: {fromLong:dd/MM/yyyy, hh:mm tt}";
            }
        }

        /// <summary>
        /// Formats bytes into human readable values.
        /// </summary>
        public static string FormatBytes(long bytes) {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;

            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
                dblSByte = bytes / 1024.0;

            return string.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }

        /// <summary>
        /// Removes illegal characters from the path in a cleaner format.
        /// </summary>
        public static string UseSafeFormattedCharacters(string text) {
            return text.Replace(@"\", "")
                       .Replace("/",  "-")
                       .Replace(":",  "-")
                       .Replace("*",  "")
                       .Replace("?",  "")
                       .Replace("\"", "'")
                       .Replace("<",  "")
                       .Replace(">",  "")
                       .Replace("|",  "");
        }
    }
}
