using System;
using System.Buffers;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using HiddenDonut.Constants;
using HiddenDonut.Index.Metadata;

namespace HiddenDonut.Index
{
    internal class IndexMetadataWriter : IIndexMetadataWriter
    {
        private readonly Stream _stream;
        private readonly long _offset;
        private readonly bool _disposeStream;
        private const int Size = ModelSizes.IndexMetaData;

        public IndexMetadataWriter(Stream stream, long offset = 0, bool disposeStream = true)
        {
            _stream = stream;
            _offset = offset;
            _disposeStream = disposeStream;
        }

        // This is twice as fast as the async version.
        public unsafe void Write(in IndexMetadataStruct metadata)
        {
            _stream.Seek(_offset, SeekOrigin.Begin);
            var buffer = stackalloc byte[Size];

            Marshal.StructureToPtr(metadata, (IntPtr)buffer, false);
            _stream.Write(new ReadOnlySpan<byte>(buffer, Size));
        }

        public async ValueTask WriteAsync(IndexMetadataStruct metadata)
        {
            _stream.Seek(_offset, SeekOrigin.Begin);
            var buffer = ArrayPool<byte>.Shared.Rent(Size);
            try
            {
                unsafe
                {
                    fixed (byte* ptr = buffer)
                    {
                        Marshal.StructureToPtr(metadata, (IntPtr)ptr, false);
                    }
                }
                await _stream.WriteAsync(new ReadOnlyMemory<byte>(buffer, 0, Size));
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }
        public void Dispose()
        {
            if (_disposeStream)
            {
                _stream?.Dispose();
            }
        }
    }
}