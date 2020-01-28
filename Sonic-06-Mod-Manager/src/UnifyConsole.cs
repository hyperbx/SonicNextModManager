using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

// Sonic '06 Mod Manager is licensed under the MIT License:
/*
 * MIT License

 * Copyright (c) 2020 Knuxfan24
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
    public class ListBoxWriter : TextWriter
    {
        private readonly ListBox _list;
        private StringBuilder _content = new StringBuilder();

        public ListBoxWriter(ListBox list) { _list = list; }

        public override Encoding Encoding { get { return Encoding.UTF8; } }

        public override void Write(char value) {
            base.Write(value);
            _content.Append(value);

            if (value != '\n') return;

            if (_list.InvokeRequired) {
                try {
                    _list.Invoke(new MethodInvoker(() => _list.Items.Add(_content.ToString())));
                    _list.Invoke(new MethodInvoker(() => _list.SelectedIndex = _list.Items.Count - 1));
                    _list.Invoke(new MethodInvoker(() => _list.SelectedIndex = -1));
                } catch (ObjectDisposedException ex) { Console.WriteLine(ex); }
            } else {
                _list.Items.Add(_content.ToString());
                _list.SelectedIndex = _list.Items.Count - 1;
                _list.SelectedIndex = -1;
            }

            _content = new StringBuilder();
        }
    }
}
