using System.IO;
using System.Threading.Tasks;
using HiddenDonut.Models;

namespace HiddenDonut.Index
{
    internal interface IIndexMetadataWriter
    {
        ValueTask Write(long offset, Stream stream, IndexMetadata metadata);
    }
}
