using System.IO;
using System.Threading.Tasks;
using HiddenDonut.Models;

namespace HiddenDonut.Index
{
    internal interface IIndexMetadataReader
    {
        ValueTask<IndexMetadata> Read(long offset, Stream stream);
    }
}