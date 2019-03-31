using System;
using System.Buffers;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using HiddenDonut.Constants;
using HiddenDonut.Index.Metadata;

namespace HiddenDonut.Index
{
    internal class IndexMetadataReader : IIndexMetadataReader
    {
        private const int Size = ModelSizes.IndexMetaData;
        
        public async ValueTask<IndexMetadataStruct> Read(long offset, Stream stream)
        {
            stream.Seek(offset, SeekOrigin.Begin);
            var buffer = ArrayPool<byte>.Shared.Rent(Size);
            var result = await stream.ReadAsync(buffer.AsMemory());
            // TODO: handle result?
            unsafe
            {
                fixed (byte* bufferPtr = buffer)
                {
                    return Marshal.PtrToStructure<IndexMetadataStruct>((IntPtr)bufferPtr);
                }
            }
        }
    }
}