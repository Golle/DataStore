using System.IO;
using System.Threading.Tasks;
using HiddenDonut.Core.Streams;
using HiddenDonut.Logging;

namespace HiddenDonut.Index
{
    internal class IndexFileInitializer : IIndexFileInitializer
    {
        private readonly ILogger _logger;
        private readonly IFileStreamFactory _fileStreamFactory;
        private readonly IIndexMetadataReader _reader;
        private readonly IIndexMetadataWriter _writer;
        private readonly IIndexFileMetadataFactory _indexFileMetadataFactory;

        public IndexFileInitializer(ILogger logger, IFileStreamFactory fileStreamFactory, IIndexMetadataReader reader, IIndexMetadataWriter writer, IIndexFileMetadataFactory indexFileMetadataFactory)
        {
            _logger = logger;
            _fileStreamFactory = fileStreamFactory;
            _reader = reader;
            _writer = writer;
            _indexFileMetadataFactory = indexFileMetadataFactory;
        }

        public async ValueTask<IIndexFile> CreateOrOpen(string path)
        {
            Stream stream;
            try
            {
                stream = _fileStreamFactory.Create(path, FileMode.Open, FileAccess.ReadWrite);
                var meta = await _reader.Read(0, stream);
                return new IndexFile(in meta, stream, _writer);
            }
            catch (FileNotFoundException)
            {
                _logger.Log($"Index data file could not be found at path {path}. Creating a new one.");
            }
            stream = _fileStreamFactory.Create(path, FileMode.Create, FileAccess.ReadWrite);
            var indexMetadata = _indexFileMetadataFactory.Create();
            var indexFile = new IndexFile(in indexMetadata, stream, _writer);
            await indexFile.Commit();
            return indexFile;
        }
    }
}