using System.Threading.Tasks;
using HiddenDonut.Models;

namespace HiddenDonut.Writer
{
    internal interface IIndexMetadataWriter
    {
        ValueTask Write(IndexMetadata metadata);
    }
}
