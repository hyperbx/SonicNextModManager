using System;
using System.IO;
using System.Linq;

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

namespace Unify.Serialisers
{
    class INI
    {
        /// <summary>
        /// If the specified key is found in the specified INI, return its value as a string.
        /// </summary>
        public static string DeserialiseKey(string key, string ini) {
            string line, entryValue = string.Empty;

            using (StreamReader configFile = new StreamReader(ini))
                try {
                    while ((line = configFile.ReadLine()) != null) {
                        if (line.StartsWith(key)) {
                            entryValue = line.Substring(line.IndexOf("=") + 2);
                            entryValue = entryValue.Remove(entryValue.Length - 1);
                        }
                    }
                } catch { }

            return entryValue;
        }
    }

    class Lua
    {
        /// <summary>
        /// If the specified parameter is found in the specified Lua script, return its value as a string.
        /// </summary>
        public static string DeserialiseParameter(string parameter, string script, bool fromScript) {
            string entryValue = string.Empty;

            if (fromScript) {
                string line = string.Empty;

                using (StreamReader scriptFile = new StreamReader(script))
                    try {
                        while ((line = scriptFile.ReadLine()) != null) {
                            if (line.StartsWith(parameter)) {
                                entryValue = line.Substring(line.IndexOf("(") + 1);
                                entryValue = entryValue.Remove(entryValue.Length - 2);
                                entryValue = entryValue.Substring(1);
                            }
                        }
                    } catch { }
            } else {
                if (script.StartsWith(parameter)) {
                    entryValue = script.Substring(script.IndexOf("(") + 1);
                    entryValue = entryValue.Remove(entryValue.Length - 2);
                    entryValue = entryValue.Substring(1);
                }
            }

            return entryValue;
        }

        /// <summary>
        /// If the specified parameter is found in the specified Lua script, return its value as a string array.
        /// </summary>
        public static string[] DeserialiseParameterList(string parameter, string script, bool fromScript) {
            string entryValue = string.Empty;
            string[] function = Array.Empty<string>();

            if (fromScript) {
                string line = string.Empty;

                using (StreamReader scriptFile = new StreamReader(script))
                    try {
                        while ((line = scriptFile.ReadLine()) != null) {
                            if (line.StartsWith(parameter)) {
                                entryValue = line.Substring(line.IndexOf("(") + 1);
                                entryValue = entryValue.Remove(entryValue.Length - 1);

                                function = entryValue.Split('|');
                                int valueCount = 0;
                                foreach (string value in function) {
                                    if (value.StartsWith("\"")) function[valueCount] = value.Remove(value.Length - 1).Substring(1);
                                    valueCount++;
                                }
                            }
                        }
                    } catch { }
            } else {
                if (script.StartsWith(parameter)) {
                    entryValue = script.Substring(script.IndexOf("(") + 1);
                    entryValue = entryValue.Remove(entryValue.Length - 1);

                    function = entryValue.Split('|');
                    int valueCount = 0;
                    foreach (string value in function) {
                        if (value.StartsWith("\"")) function[valueCount] = value.Remove(value.Length - 1).Substring(1);
                        valueCount++;
                    }
                }
            }

            return function;
        }
    }

    class Paths
    {
        /// <summary>
        /// Returns the first directory of a path.
        /// </summary>
        public static string GetRootFolder(string path) {
            while (true) {
                string temp = Path.GetDirectoryName(path);
                if (string.IsNullOrEmpty(temp))
                    break;
                path = temp;
            }
            return path;
        }

        /// <summary>
        /// Returns the full path without an extension.
        /// </summary>
        public static string GetPathWithoutExtension(string path) {
            return Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
        }

        /// <summary>
        /// Returns the folder containing the file.
        /// </summary>
        public static string GetContainingFolder(string path) {
            return Path.GetFileName(Path.GetDirectoryName(path));
        }

        /// <summary>
        /// Returns if the directory is empty.
        /// </summary>
        public static bool IsDirectoryEmpty(string path) {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
    }
}
