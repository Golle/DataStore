using System;
using System.Threading.Tasks;
using HiddenDonut.Constants;
using HiddenDonut.Index;

namespace HiddenDonut
{
    internal class DataStore : IDataStore
    {
        private readonly IIndexManager _indexManager;

        public DataStore(IIndexManager indexManager)
        {
            _indexManager = indexManager;
        }

        public async ValueTask Initialize(string name, string path, uint maxIndexSize = DefaultValues.MaxIndexSize)
        {
            var result = await _indexManager.Initialize(path, name);
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