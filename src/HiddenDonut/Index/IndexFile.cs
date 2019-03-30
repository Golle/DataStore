using System.IO;
using System.Threading.Tasks;
using HiddenDonut.Models;

namespace HiddenDonut.Index
{
    internal class IndexFile : IIndexFile
    {
        private readonly IndexMetadata _metadata;
        private readonly Stream _stream;
        private readonly IIndexMetadataWriter _writer;

        public IndexFile(in IndexMetadata metadata, Stream stream, IIndexMetadataWriter writer)
        {
            _metadata = metadata;
            _stream = stream;
            _writer = writer;
        }

        public void Dispose()
        {
            _stream.Dispose();
        }

        public async ValueTask Commit()
        {
            await _writer.Write(0, _stream, _metadata);
        }
    }
}