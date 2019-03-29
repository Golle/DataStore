using System.Threading.Tasks;
using HiddenDonut.Models;

namespace HiddenDonut.Writer
{
    internal interface IIndexMetadataReader
    {
        ValueTask<IndexMetadata> Read();
    }
}