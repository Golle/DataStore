using System;
using System.Buffers;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using HiddenDonut.Models;

namespace HiddenDonut.Writer
{
    internal class IndexMetadataReader : IIndexMetadataReader
    {
        private readonly Stream _stream;
        private readonly long _offset;
        private const int Size = ModelSizes.IndexMetaData;

        public IndexMetadataReader(Stream stream, long offset)
        {
            _stream = stream;
            _offset = offset;
        }

        public async ValueTask<IndexMetadata> Read()
        {
            _stream.Seek(_offset, SeekOrigin.Begin);
            var buffer = ArrayPool<byte>.Shared.Rent(Size);
            var result = await _stream.ReadAsync(buffer.AsMemory());
            // TODO: handle result?
            unsafe
            {
                fixed (byte* bufferPtr = buffer)
                {
                    return Marshal.PtrToStructure<IndexMetadata>((IntPtr) bufferPtr);
                }
            }
        }
    }
}