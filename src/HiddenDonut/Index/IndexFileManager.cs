using System.IO;
using System.Threading.Tasks;
using HiddenDonut.Constants;
using HiddenDonut.Core;
using HiddenDonut.Core.Streams;
using HiddenDonut.Index.Metadata;
using HiddenDonut.Logging;

namespace HiddenDonut.Index
{
    internal class IndexFileManager : IIndexFileManager
    {
        private readonly ILogger _logger;
        private readonly IFileStreamFactory _fileStreamFactory;
        private readonly IIndexFileMetadataFactory _indexFileMetadataFactory;
        private readonly IFiles _files;

        public IndexFileManager(ILogger logger, IFileStreamFactory fileStreamFactory, IIndexFileMetadataFactory indexFileMetadataFactory, IFiles files)
        {
            _logger = logger;
            _fileStreamFactory = fileStreamFactory;
            _indexFileMetadataFactory = indexFileMetadataFactory;
            _files = files;
        }

        public void CreateIfNotExists(string path)
        {
            if (_files.Exists(path))
            {
                _logger.Log($"File at path {path} already exists.");
            }

            using (var stream = _fileStreamFactory.Create(path, FileMode.Create, FileAccess.Write))
            {
                var indexMetadata = _indexFileMetadataFactory.CreateDefault();
                stream.SetLength(ModelSizes.IndexMetaData + indexMetadata.IndexSize); // metadata + index size
                using (var writer = new IndexMetadataWriter(stream, disposeStream: false))
                {
                    writer.Write(in indexMetadata);
                }
            }
        }

        public ValueTask<IIndexMetadata> CreateMetadataStream(string path)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<object> CreateRowsStream(string path)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<object> CreateIndexStream(string path)
        {
            throw new System.NotImplementedException();
        }

        //public async ValueTask<IIndexFile> CreateOrOpen(string path)
        //{
        
            //Stream stream;
            //try
            //{
            //    stream = _fileStreamFactory.Create(path, FileMode.Open, FileAccess.ReadWrite);
            //    var meta = await _reader.Read(0, stream);
            //    return new IndexFile(in meta, stream, _writer);
            //}
            //catch (FileNotFoundException)
            //{
            //    _logger.Log($"Index data file could not be found at path {path}. Creating a new one.");
            //}
            //stream = _fileStreamFactory.Create(path, FileMode.Create, FileAccess.ReadWrite);
            //var indexMetadata = _indexFileMetadataFactory.Create();
            //var indexFile = new IndexFile(in indexMetadata, stream, _writer);
            //await indexFile.Commit();
            //return indexFile;
        //}
    }
}