/**
 * ZlibStream wrapper class for DeflateStream.
 * Adds the zlib header and Adler-32 checksum footer.
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

using System;
using System.IO;
using System.IO.Compression;

namespace ArcPackerLib
{
    public class ZlibStream : Stream
    {
        protected Stream _stream = null;        // Stream we're reading from or writing to.
        protected Stream _deflateStream = null; // Internal DeflateStream for compression.
        protected CompressionMode _mode;        // Compression mode.
        protected bool _leaveOpen = true;       // If true, don't close _baseStream on Dispose.
        protected bool _isDisposed = false;

        // Adler-32 checksum.
        protected const uint A32Mod = 65521;
        protected uint _s1 = 1;
        protected uint _s2 = 0;

        // Number of bytes processed.
        protected long _bytesProcessed = 0;

        // Implies mode == Compress
        public ZlibStream(Stream stream, CompressionLevel compressionLevel, bool leaveOpen)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            if (!stream.CanWrite)
            {
                // Can't write to this stream.
                throw new ArgumentException("Specified stream is not writable.", "stream");
            }

            _stream = stream;
            _mode = CompressionMode.Compress;
            _leaveOpen = leaveOpen;

            writeZlibHeader(compressionLevel);
            _deflateStream = new DeflateStream(stream, compressionLevel, true);
        }

        // Implies mode == Compress
        public ZlibStream(Stream stream, CompressionLevel compressionLevel)
            : this(stream, compressionLevel, false)
        { }

        // Implies compressionLevel == Optimal
        public ZlibStream(Stream stream, CompressionMode mode, bool leaveOpen)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            if (mode == CompressionMode.Compress && !stream.CanWrite)
            {
                // Can't write to this stream.
                throw new ArgumentException("Specified stream is not writable.", "stream");
            }
            else if (mode == CompressionMode.Decompress && !stream.CanRead)
            {
                // Can't read from this stream.
                throw new ArgumentException("Specified stream is not writable.", "stream");
            }
            else if (mode != CompressionMode.Compress && mode != CompressionMode.Decompress)
            {
                // Invalid CompressionMode.
                throw new ArgumentException("Invalid CompressionMode.", "mode");
            }

            _stream = stream;
            _mode = mode;
            _leaveOpen = leaveOpen;

            if (mode == CompressionMode.Compress)
            {
                writeZlibHeader(CompressionLevel.Optimal);
            }
            else
            {
                // Verify the zlib header.
                // Reference: https://tools.ietf.org/html/rfc1950
                // Two bytes: CMF FLG
                // CMF: Compression method
                //      bits 0-3 = CM: compression method (8 for Deflate)
                //      bits 4-7 = CINFO: window size (7 for 2^(7+8) == 2^15 == 32 KB)
                //      zlib is *always* 0x78. (Deflate, 32 KB)
                // FLG: Flags
                //      bits 0-4 = FCHECK: check bits for CMF and FLG
                //      bit    5 = FDICT: preset dictionary
                //      bits 6-7 = FLEVEL: compression level
                // FCHECK must be set such that when CMF/FLG is viewed as
                // a 16-bit BE unsigned int, CMFFLG % 31 == 0.
                byte[] zlibHeader = new byte[2];
                _stream.Read(zlibHeader, 0, zlibHeader.Length);

                // Check CMF.
                if (zlibHeader[0] != 0x78)
                {
                    // Not Deflate with 32 KB window.
                    throw new FileFormatException("zlib header has an incorrect CMF byte.");
                }

                // Check FCHECK.
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(zlibHeader);
                }
                UInt16 CMFFLG = BitConverter.ToUInt16(zlibHeader, 0);
                if (CMFFLG % 31 != 0)
                {
                    // Checksum error.
                    throw new FileFormatException("zlib header has an incorrect checksum.");
                }
            }

            // TODO: Adler-32 checksum handling. (Check GzipStream?)
            _deflateStream = new DeflateStream(stream, mode, true);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                if (_deflateStream != null)
                {
                    _deflateStream.Close();
                }

                if (_mode == CompressionMode.Compress)
                {
                    if (_bytesProcessed <= 0)
                    {
                        // Special case: Zero-length file needs "\x03\x00" in order to
                        // not be misdetected as uncompressed.
                        byte[] b_extra03 = new byte[] { 0x03, 0x00 };
                        processAdler32(b_extra03, 0, b_extra03.Length);
                        _stream.Write(b_extra03, 0, b_extra03.Length);
                    }

                    // Write the Adler-32 checksum.
                    uint adler32 = unchecked((uint)((_s2 << 16) | _s1));
                    byte[] b_adler32 = BitConverter.GetBytes(adler32);
                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(b_adler32);
                    }
                    _stream.Write(b_adler32, 0, b_adler32.Length);
                    _stream.Flush();
                }

                if (!_leaveOpen)
                {
                    _stream.Close();
                }
                _isDisposed = true;
            }
        }

        // Implies compressionLevel == Optimal
        public ZlibStream(Stream stream, CompressionMode mode)
            : this(stream, mode, false)
        { }

        /// <summary>
        /// Write the zlib header to the stream.
        /// </summary>
        /// <param name="compressionLevel">Compression level.</param>
        protected void writeZlibHeader(CompressionLevel compressionLevel)
        {
            // NOTE: There doesn't appear to be a "maximum" compression option.
            // This would be zlib level 9, or byte 0xDA.
            // Also, "Optimal" is level 6; zlib default is level 5.
            // References:
            // - https://stackoverflow.com/questions/9050260/what-does-a-zlib-header-look-like
            // - https://stackoverflow.com/a/17176881
            byte[] zlibHeader = new byte[] { 0x78, 0x00 };

            switch (compressionLevel)
            {
                default:
                case CompressionLevel.NoCompression:    // zlib level 0
                case CompressionLevel.Fastest:          // zlib level 1
                    zlibHeader[1] = 0x01;
                    break;

                case CompressionLevel.Optimal:          // zlib level 6
                    zlibHeader[1] = 0x9C;
                    break;
            }

            _stream.Write(zlibHeader, 0, zlibHeader.Length);
        }

        /** The following properties are from the reference source for DeflateStream. **/
        /** https://referencesource.microsoft.com/#system/sys/System/IO/compression/DeflateStream.cs **/

        private void ValidateParameters(byte[] array, int offset, int count)
        {
            if (array == null)
                throw new ArgumentNullException("array");

            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");

            if (count < 0)
                throw new ArgumentOutOfRangeException("count");

            if (array.Length - offset < count)
                throw new ArgumentException("Invalid values for offset and count.");
        }

        private void EnsureNotDisposed()
        {
            if (_stream == null)
                throw new ObjectDisposedException(null, "Object has been disposed.");
        }

        private void EnsureDecompressionMode()
        {
            if (_mode != CompressionMode.Decompress)
                throw new InvalidOperationException("Cannot read from a stream opened for compression.");
        }

        private void EnsureCompressionMode()
        {
            if (_mode != CompressionMode.Compress)
                throw new InvalidOperationException("Cannot write to a stream opened for decompression.");
        }

        public override bool CanRead
        {
            get
            {
                if (_stream == null)
                    return false;
                return (_mode == CompressionMode.Decompress && _stream.CanRead);
            }
        }

        public override bool CanWrite
        {
            get
            {
                if (_stream == null)
                    return false;
                return (_mode == CompressionMode.Compress && _stream.CanWrite);
            }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override long Length
        {
            get { throw new NotSupportedException("ZlibStream does not support getting the stream length."); }
        }

        public override long Position
        {
            get { throw new NotSupportedException("ZlibStream does not support getting the stream position."); }
            set { throw new NotSupportedException("ZlibStream does not support setting the stream position."); }
        }

        public override void Flush()
        {
            EnsureNotDisposed();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException("ZlibStream does not support seeking.");
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException("ZlibStream does not support setting the stream length.");
        }

        /// <summary>
        /// Process the Adler-32 checksum on a chunk of data.
        /// </summary>
        /// <param name="buffer">Data buffer.</param>
        /// <param name="offset">Offset within buffer.</param>
        /// <param name="count">Number of bytes to process.</param>
        protected void processAdler32(byte[] buffer, int offset, int count)
        {
            int end = offset + count;
            for (int i = offset; i < end; i++)
            {
                _s1 = (_s1 + buffer[i]) % A32Mod;
                _s2 = (_s2 + _s1) % A32Mod;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            EnsureDecompressionMode();
            ValidateParameters(buffer, offset, count);
            EnsureNotDisposed();

            // TODO: If we reach the end of the stream, verify the Adler-32 checksum.
            int bytesRead = _deflateStream.Read(buffer, offset, count);
            processAdler32(buffer, offset, bytesRead);
            _bytesProcessed += bytesRead;
            return bytesRead;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            EnsureCompressionMode();
            ValidateParameters(buffer, offset, count);
            EnsureNotDisposed();

            processAdler32(buffer, offset, count);
            _deflateStream.Write(buffer, offset, count);
            _bytesProcessed += count;
        }
    }
}