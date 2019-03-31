using System;
using System.Threading.Tasks;
using HiddenDonut.Index.Metadata;

namespace HiddenDonut.Index
{
    internal interface IIndexMetadataWriter : IDisposable
    {
        void Write(in IndexMetadataStruct metadata);
        ValueTask WriteAsync(IndexMetadataStruct metadata);
    }
}
