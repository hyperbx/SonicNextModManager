using System;
using System.IO;
using System.Linq;
using System.Drawing;

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
        public static string System() {
            if (Path.GetExtension(Properties.Settings.Default.GameDirectory).ToLower() == ".xex") return "Xbox 360";
            if (Path.GetExtension(Properties.Settings.Default.GameDirectory).ToLower() == ".bin") return "PlayStation 3";
            else return "unspecified";
        }

        /// <summary>
        /// Translates a file extension to 'Xenia' or 'RPCS3'
        /// </summary>
        public static string Emulator() {
            if (Path.GetExtension(Properties.Settings.Default.GameDirectory).ToLower() == ".xex") return "Xenia";
            if (Path.GetExtension(Properties.Settings.Default.GameDirectory).ToLower() == ".bin") return "RPCS3";
            else return "unspecified";
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
        /// Converts an ARGB string to a Color.
        /// </summary>
        public static Color StringToColorArray(string stringAsColour) {
            Color colourFromString = Color.FromArgb(0, 0, 0);
            for (int i = 0; i < 3; i++) {
                // Split the string on the comma
                string[] splitString = stringAsColour.Split(','); 

                // Converts the strings to integers
                var splitInts = splitString.Select(item => int.Parse(item)).ToArray();

                // Combines integers to colours
                colourFromString = Color.FromArgb(splitInts[0], splitInts[1], splitInts[2]); 
            }
            return colourFromString;
        }

        public static string ColorToString(Color color) { return $"{color.R.ToString()},{color.G.ToString()},{color.B.ToString()}"; }
    }
}
