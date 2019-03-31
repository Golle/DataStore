using System.Threading.Tasks;

namespace HiddenDonut.Index
{
    internal class IndexManager : IIndexManager
    {
        private readonly IIndexFilePathFormatter _indexFilePathFormatter;
        private readonly IIndexFileManager _indexFileManager;

        public IndexManager(IIndexFilePathFormatter indexFilePathFormatter, IIndexFileManager indexFileManager)
        {
            _indexFilePathFormatter = indexFilePathFormatter;
            _indexFileManager = indexFileManager;
        }

        public async ValueTask<IIndexSomething> Initialize(string path, string name)
        {
            var indexFilePath = _indexFilePathFormatter.Format(path, name);
            _indexFileManager.CreateIfNotExists(indexFilePath);



            return null;
            // setup the metadata
            // setup the indexes
            // create filestreams for writing rows 
        }
    }
}