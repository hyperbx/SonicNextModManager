using System;
using System.IO;
using System.Windows.Forms;

// Sonic '06 Toolkit is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2020 Gabriel (HyperPolygon64)

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

namespace Unify.Environment3
{
    static class Program
    {
        public static readonly string VersionNumber = "Version 3.0-prototype_rush-230120r1";
        public static string ApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        [STAThread]

        static void Main() {
            // Write required pre-requisites to the Tools directory
            if (!Directory.Exists($"{ApplicationData}\\Unify\\Tools\\"))
                Directory.CreateDirectory($"{ApplicationData}\\Unify\\Tools\\");

            if (!File.Exists($"{ApplicationData}\\Unify\\Tools\\arctool.exe"))
                File.WriteAllBytes($"{ApplicationData}\\Unify\\Tools\\arctool.exe", Properties.Resources.arctool);

            if (!File.Exists($"{ApplicationData}\\Unify\\Tools\\pkgtool.exe"))
                File.WriteAllBytes($"{ApplicationData}\\Unify\\Tools\\pkgtool.exe", Properties.Resources.pkgtool);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UnifyEnvironment());
        }
    }
}
