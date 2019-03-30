using HiddenDonut.Constants;
using HiddenDonut.Core;
using HiddenDonut.Models;

namespace HiddenDonut.Index
{
    internal class IndexFileMetadataFactory : IIndexFileMetadataFactory
    {
        private readonly IDateTime _dateTime;

        public IndexFileMetadataFactory(IDateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public IndexMetadata Create()
        {
            return new IndexMetadata
            {
                Date = _dateTime.Now.Ticks,
                Ids = 0,
                Rows = 0,
                Version = Versions.IndexMetadataVersion
            };
        }
    }
}