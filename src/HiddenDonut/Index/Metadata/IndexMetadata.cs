using System;

namespace HiddenDonut.Index.Metadata
{
    internal class IndexMetadata : IIndexMetadata
    {
        private readonly IIndexMetadataWriter _writer;
        private IndexMetadataStruct _metadata;

        public IndexMetadata(in IndexMetadataStruct metadata, IIndexMetadataWriter writer)
        {
            _metadata = metadata;
            _writer = writer;
        }

        public void IncreaseRows()
        {
            _metadata.Rows++;
            _writer.Write(in _metadata);
        }

        public uint IndexOf(in Guid id)
        {
            return 0;
        }

        public void Dispose()
        {
            _writer.Dispose();
        }
    }
}