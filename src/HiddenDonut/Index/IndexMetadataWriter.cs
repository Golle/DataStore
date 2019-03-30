using System;
using System.Buffers;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using HiddenDonut.Constants;
using HiddenDonut.Models;

namespace HiddenDonut.Index
{
    internal class IndexMetadataWriter : IIndexMetadataWriter
    {
        private const int Size = ModelSizes.IndexMetaData;

        // This is twice as fast as the async version.
        //public unsafe void Write(in IndexMetadata metadata)
        //{
        //    _stream.Seek(_offset, SeekOrigin.Begin);
        //    var buffer = stackalloc byte[Size];

        //    Marshal.StructureToPtr(metadata, (IntPtr)buffer, false);
        //    _stream.Write(new ReadOnlySpan<byte>(buffer, Size));
        //}

        public async ValueTask Write(long offset, Stream stream, IndexMetadata metadata)
        {
            stream.Seek(offset, SeekOrigin.Begin);
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
                await stream.WriteAsync(new ReadOnlyMemory<byte>(buffer, 0, Size));
                await stream.FlushAsync();
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }
    }
}