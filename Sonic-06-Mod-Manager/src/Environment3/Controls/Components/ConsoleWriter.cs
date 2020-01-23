using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

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
