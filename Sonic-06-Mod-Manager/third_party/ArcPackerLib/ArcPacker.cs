/**
 * Sonic'06 ARC packer class
 *
 * Copyright (c) 2020 Gabriel (HyperPolygon64)
 * Copyright (c) 2020 David Korth <gerbilsoft@gerbilsoft.com>
 *
 * MIT License
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace ArcPackerLib
{
    class ArcPacker
    {
        // Nodes: Count is total number of files and subdirectories,
        // plus 1 for the root node.
        // NOTE: class, not struct, for pass-by-reference behavior.
        protected class U8Node
        {
            // Original U8 fields.
            public uint type_name;          // High U8 is type: 0 == file, 1 == dir
                                            // Low 24-bit value is name offset.
            public uint data_offset;        // File: Offset to data.
                                            // Dir: Parent node number.
            public uint compressed_size;    // File: Compressed file size. (0 if uncompressed)
                                            // Dir: Last child node index, plus one.
            public uint file_size;          // File: Actual file size.

            // Temporary data for packing.
            public uint node_idx;            // Node index for convenience.
            public string srcFilename;      // File: Source filename.
        };

        // Node structures.
        private List<U8Node> _nodes = new List<U8Node>();

        // String table.
        // NOTE: The first byte is *always* 0. (root node name)
        private List<byte> _stringTable = new List<byte>();

        /// <summary>
        /// Create a directory node.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parentNode"></param>
        /// <param name="childCount"></param>        /// <returns></returns>
        private U8Node createDirNode(string dirName, uint parentNode)
        {
            U8Node dirNode = new U8Node();
            dirNode.type_name = 0x01000000 | (uint)_stringTable.Count;
            dirNode.data_offset = parentNode;
            dirNode.compressed_size = 0;    // initialized later
            dirNode.file_size = 0;

            // Append the name to the string table.
            string name = Path.GetFileName(dirName);
            byte[] utfBytes = Encoding.UTF8.GetBytes(name);
            _stringTable.AddRange(utfBytes);
            _stringTable.Add(0);

            _nodes.Add(dirNode);
            dirNode.node_idx = (uint)_nodes.Count - 1;
            uint nodeIdxPlusOne = dirNode.node_idx + 1;

            // Update the "last child index" value of all parent nodes.
            if (_nodes.Count > 1)
            {
                U8Node nextParent = _nodes[(int)parentNode];
                U8Node curParent;
                do
                {
                    curParent = nextParent;
                    curParent.compressed_size = nodeIdxPlusOne;
                    nextParent = _nodes[(int)curParent.data_offset];
                } while (nextParent != curParent);
            }

            return dirNode;
        }

        /// <summary>
        /// Create a file node.
        /// </summary>
        /// <param name="parentNode">Parent node.</param>
        /// <param name="srcFilename">Source filename.</param>
        /// <returns></returns>
        private U8Node createFileNode(U8Node parentNode, string srcFilename)
        {
            U8Node fileNode = new U8Node();
            fileNode.type_name = (uint)_stringTable.Count;
            // These are initialized later.
            fileNode.data_offset = 0;
            fileNode.compressed_size = 0;
            fileNode.file_size = 0;
            fileNode.srcFilename = srcFilename;

            // Append the name to the string table.
            string name = Path.GetFileName(srcFilename);
            byte[] utfBytes = Encoding.UTF8.GetBytes(name);
            _stringTable.AddRange(utfBytes);
            _stringTable.Add(0);

            _nodes.Add(fileNode);
            fileNode.node_idx = (uint)_nodes.Count - 1;
            uint nodeIdxPlusOne = fileNode.node_idx + 1;

            // Update the "last child index" value of all parent nodes.
            U8Node nextParent = parentNode;
            U8Node curParent;
            do
            {
                curParent = nextParent;
                curParent.compressed_size = nodeIdxPlusOne;
                nextParent = _nodes[(int)curParent.data_offset];
            } while (nextParent != curParent);

            return fileNode;
        }

        /// <summary>
        /// Align a FileStream to 32 bytes.
        /// </summary>
        /// <param name="fs">FileStream</param>
        private void alignFileStreamTo32Bytes(FileStream fs)
        {
            byte[] zero = new byte[] { 0 };
            for (long pos = fs.Position; pos % 32 != 0; pos++)
            {
                fs.Write(zero, 0, zero.Length);
            }
        }

        /// <summary>
        /// Recursively add files and subdirectories from the specified source directory.
        /// </summary>
        /// <param name="parentNode">Parent node.</param>
        /// <param name="srcDirectory">Source directory.</param>
        protected void addSubdirNodes(U8Node parentNode, string srcDirectory)
        {
            // Get files in the specified directory, non-recursive.
            string[] files = Directory.GetFiles(srcDirectory, "*", SearchOption.TopDirectoryOnly);
            Array.Sort(files);
            foreach (string file in files)
            {
                createFileNode(parentNode, file);
            }

            // Get subdirectories in this directory.
            string[] subdirs = Directory.GetDirectories(srcDirectory, "*", SearchOption.TopDirectoryOnly);
            Array.Sort(subdirs);
            foreach (string subdir in subdirs)
            {
                U8Node dirNode = createDirNode(subdir, parentNode.node_idx);
                addSubdirNodes(dirNode, subdir);
            }
        }

        /// <summary>
        /// Write the ARC file using the specified file list.
        /// </summary>
        /// <param name="arcFile">ARC file.</param>
        /// <param name="srcDirectory">Source directory.</param>
        public void WriteArc(string arcFile, string srcDirectory)
        {
            // Standard U8 header
            // To be filled in:
            // - $0008 (BE32): Total size of node table and string table.
            // - $000C (BE32): Start of data.
            byte[] U8Header = new byte[32]
            {
                0x55, 0xAA, 0x38, 0x2D, 0x00, 0x00, 0x00, 0x20,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0xE4, 0xF9, 0x12, 0x00, 0x00, 0x00, 0x04, 0x02,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            };

            // Create the root node.
            _nodes.Clear();
            _stringTable.Clear();
            U8Node rootNode = createDirNode("", 0);

            // Add nodes recursively.
            addSubdirNodes(rootNode, srcDirectory);

            // Update the U8 header for the string table length
            // and data offset.
            int tableLength = (_nodes.Count * 16) + _stringTable.Count;
            int dataOffset = U8Header.Length + tableLength;
            dataOffset = ((dataOffset + 0x1F) & ~0x1F);

            byte[] b_tableLength = BitConverter.GetBytes((uint)tableLength);
            byte[] b_dataOffset = BitConverter.GetBytes((uint)dataOffset);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b_tableLength);
                Array.Reverse(b_dataOffset);
            }
            Array.Copy(b_tableLength, 0, U8Header, 0x08, 4);
            Array.Copy(b_dataOffset, 0, U8Header, 0x0C, 4);

            // Write stuff.
            using (FileStream fs = File.Create(arcFile))
            {
                // Write files, uncompressed, starting at the data offset.
                // NOTE: Files are aligned on 32-byte offsets.
                fs.Seek(dataOffset, SeekOrigin.Begin);

                foreach (U8Node node in _nodes) {
                    if ((node.type_name & 0xFF000000) != 0)
                    {
                        // Directory node.
                        continue;
                    }

                    // Open the file.
                    using (FileStream fs_src = File.OpenRead(node.srcFilename))
                    {
                        node.data_offset = (uint)fs.Position;
                        node.file_size = (uint)fs_src.Length;

                        // Compress the source data using zlib.
                        using (MemoryStream memStream = new MemoryStream())
                        {
                            using (ZlibStream zStream = new ZlibStream(memStream, CompressionLevel.Fastest, true))
                            {
                                fs_src.CopyTo(zStream);
                            }

                            node.compressed_size = (uint)memStream.Length;
                            if (memStream.Length > 0)
                            {
                                // Write the compressed data.
                                memStream.Seek(0, SeekOrigin.Begin);
                                memStream.CopyTo(fs);
                            }
                        }

                        // Make sure we're aligned to 32 bytes.
                        alignFileStreamTo32Bytes(fs);
                    }
                }

                // Write the U8 header.
                fs.Seek(0, SeekOrigin.Begin);
                fs.Write(U8Header, 0, U8Header.Length);

                // Write the nodes.
                foreach (U8Node node in _nodes) {
                    byte[] b_type_name = BitConverter.GetBytes(node.type_name);
                    byte[] b_data_offset = BitConverter.GetBytes(node.data_offset);
                    byte[] b_compressed_size = BitConverter.GetBytes(node.compressed_size);
                    byte[] b_file_size = BitConverter.GetBytes(node.file_size);

                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(b_type_name);
                        Array.Reverse(b_data_offset);
                        Array.Reverse(b_compressed_size);
                        Array.Reverse(b_file_size);
                    }

                    fs.Write(b_type_name, 0, b_type_name.Length);
                    fs.Write(b_data_offset, 0, b_data_offset.Length);
                    fs.Write(b_compressed_size, 0, b_compressed_size.Length);
                    fs.Write(b_file_size, 0, b_file_size.Length);
                }

                // Write the string table.
                fs.Write(_stringTable.ToArray(), 0, _stringTable.Count);

                fs.Flush();
                fs.Close();
            }
        }
    }
}