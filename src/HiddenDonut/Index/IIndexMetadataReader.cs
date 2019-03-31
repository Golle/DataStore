using System.IO;
using System.Threading.Tasks;
using HiddenDonut.Index.Metadata;

namespace HiddenDonut.Index
{
    internal interface IIndexMetadataReader
    {
        ValueTask<IndexMetadataStruct> Read(long offset, Stream stream);
    }
}