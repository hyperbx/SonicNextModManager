using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HedgeLib.Text
{
    public class MSTEntries
    {
        public string Name;
        public string Text;
        public string Placeholder;

        public MSTEntries() { }

        public MSTEntries(string name, string text, string placeholder)
        {
            Name = name;
            Text = text;
            Placeholder = placeholder;
        }
    }
}