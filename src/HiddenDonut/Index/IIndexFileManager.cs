using System.Threading.Tasks;
using HiddenDonut.Index.Metadata;

namespace HiddenDonut.Index
{
    internal interface IIndexFileManager
    {
        void CreateIfNotExists(string path);
        ValueTask<IIndexMetadata> CreateMetadataStream(string path);
        ValueTask<object> CreateRowsStream(string path);
        ValueTask<object> CreateIndexStream(string path);
    }
}