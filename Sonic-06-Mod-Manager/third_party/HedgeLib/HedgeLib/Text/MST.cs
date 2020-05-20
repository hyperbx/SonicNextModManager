using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HedgeLib.IO;
using HedgeLib.Exceptions;
using HedgeLib.Headers;
using System.IO;
using System.Xml.Linq;

namespace HedgeLib.Text
{
    public class MST : FileBase
    {
        public BINAHeader Header = new BINAv1Header();
        public string Name;
        public List<MSTEntries> entries = new List<MSTEntries>();

        public const string Signature = "WTXT", Extension = ".mst";

        // Methods
        public override void Load(Stream fileStream)
        {
            // Header
            var reader = new BINAReader(fileStream);
            Header = reader.ReadHeader();

            string sig = reader.ReadSignature(4);
            if (sig != Signature)
                throw new InvalidSignatureException(Signature, sig);

            uint messageTableOffset = reader.ReadUInt32();
            uint messageCount = reader.ReadUInt32();

            long namePos = reader.BaseStream.Position;
            reader.JumpTo(messageTableOffset, false);
            Name = reader.ReadNullTerminatedString();
            reader.JumpTo(namePos, true);

            for (uint i = 0; i < messageCount; i++)
            {
                string name = string.Empty;
                string text = string.Empty;
                string placeholder = string.Empty;

                uint nameOffset = reader.ReadUInt32();
                uint textOffset = reader.ReadUInt32();
                uint placeholderOffset = reader.ReadUInt32();

                long pos = reader.BaseStream.Position;

                reader.JumpTo(nameOffset, false);
                name = reader.ReadNullTerminatedString();
                reader.JumpTo(textOffset, false);
                text = reader.ReadNullTerminatedStringUTF16();
                if (placeholderOffset != 0)
                {
                    reader.JumpTo(placeholderOffset, false);
                    placeholder = reader.ReadNullTerminatedString();
                }

                MSTEntries entry = new MSTEntries(name, text, placeholder);
                entries.Add(entry);

                reader.JumpTo(pos, true);
            }
        }

        public override void Save(Stream fileStream)
        {
            var writer = new BINAWriter(fileStream, Header);
            char[] WTXTMagic = { 'W', 'T', 'X', 'T' };
            writer.Write(WTXTMagic);
            writer.AddString($"mstName", $"{Name}");
            writer.Write(entries.Count);
            for (int i = 0; i < entries.Count; i++)
            {
                writer.AddString($"nameOffset{i}", $"{entries[i].Name}");
                writer.AddOffset($"textOffset{i}");
                writer.AddOffset($"placeholderOffset{i}");
            }
            for (int i = 0; i < entries.Count; i++)
            {
                writer.FillInOffset($"textOffset{i}", false);
                writer.WriteNullTerminatedStringUTF16(entries[i].Text);
            }
            for (int i = 0; i < entries.Count; i++)
            {
                writer.FillInOffset($"placeholderOffset{i}", false);
                writer.WriteNullTerminatedString(entries[i].Placeholder);
            }
            writer.FinishWrite(Header);
        }

        public void ExportXML(string filePath)
        {
            var rootElem = new XElement("MST");
            var rootNameAttr = new XAttribute("Name", Name);
            rootElem.Add(rootNameAttr);

            int index = 0;
            foreach (var entry in entries)
            {
                var text = entry.Text.Replace("\f", "\\f");
                text = text.Replace("\n", "\\n");
                var message = new XElement("Message", text);
                var indexAttr = new XAttribute("Index", index);
                var nameAttr = new XAttribute("Name", entry.Name);
                var placeholderAttr = new XAttribute("Placeholder", entry.Placeholder);
                message.Add(indexAttr, nameAttr, placeholderAttr);
                rootElem.Add(message);
                index++;
            }

            var xml = new XDocument(rootElem);
            xml.Save(filePath);
        }
        public void ImportXML(string filepath)
        {
            var xml = XDocument.Load(filepath);
            Name = xml.Root.Attribute("Name").Value;
            foreach (var msgElement in xml.Root.Elements("Message"))
            {
                MSTEntries entry = new MSTEntries();
                entry.Name = msgElement.Attribute("Name").Value;
                entry.Placeholder = msgElement.Attribute("Placeholder").Value;
                string entryText = msgElement.Value;
                entryText = entryText.Replace("\\n", "\n");
                entryText = entryText.Replace("\\f", "\f");
                entry.Text = entryText;
                entries.Add(entry);
            }
        }
    }
}