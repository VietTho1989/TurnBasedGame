#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)
using System;
using System.IO;

namespace Org.BouncyCastle.Asn1.Utilities
{
    public class FilterStream : Stream
    {
        public FilterStream(Stream s)
        {
            this.s = s;
        }
        public override bool CanRead
        {
            get { return s.CanRead; }
        }
        public override bool CanSeek
        {
            get { return s.CanSeek; }
        }
        public override bool CanWrite
        {
            get { return s.CanWrite; }
        }
        public override long Length
        {
            get { return s.Length; }
        }
        public override long Position
        {
            get { return s.Position; }
            set { s.Position = value; }
        }
        protected override void Dispose(bool disposing)
        {
            try
            {
                s.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }
        public override void Flush()
        {
            s.Flush();
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return s.Seek(offset, origin);
        }
        public override void SetLength(long value)
        {
            s.SetLength(value);
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            return s.Read(buffer, offset, count);
        }
        public override int ReadByte()
        {
            return s.ReadByte();
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            s.Write(buffer, offset, count);
        }
        public override void WriteByte(byte value)
        {
            s.WriteByte(value);
        }
        protected readonly Stream s;
    }
}

#endif
