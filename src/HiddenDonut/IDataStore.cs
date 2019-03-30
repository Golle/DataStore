using System;
using System.Threading.Tasks;
using HiddenDonut.Constants;
using HiddenDonut.Index;

namespace HiddenDonut
{
    public interface IDataStore
    {
        ValueTask Initialize(string name, string path, uint maxIndexSize = DefaultValues.MaxIndexSize);
        ValueTask Append(Guid id, byte[] data);
        ValueTask<byte[]> ReadStream(Guid id);
    }

    internal class DataStore : IDataStore
    {
        private readonly IIndexFileManager _indexFileManager;

        public DataStore(IIndexFileManager indexFileManager)
        {
            _indexFileManager = indexFileManager;
        }

        public async ValueTask Initialize(string name, string path, uint maxIndexSize = DefaultValues.MaxIndexSize)
        {
            await _indexFileManager.Initialize(name, path);

            // create or open index file with metadata
            // create or open data file with metadata
        }

        public ValueTask Append(Guid id, byte[] data)
        {
            // begin transaction
            // get next offset to write at (index + data)
            // write to data file
            // write to index file
            // commit transaction (update the meta)
            throw new NotImplementedException();
        }

        public ValueTask<byte[]> ReadStream(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
