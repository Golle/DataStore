using HiddenDonut.Constants;
using HiddenDonut.Core;
using HiddenDonut.Index.Metadata;

namespace HiddenDonut.Index
{
    internal class IndexFileMetadataFactory : IIndexFileMetadataFactory
    {
        private readonly IDateTime _dateTime;

        public IndexFileMetadataFactory(IDateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public IndexMetadataStruct CreateDefault()
        {
            return new IndexMetadataStruct
            {
                Date = _dateTime.Now.Ticks,
                Ids = 0,
                Rows = 0,
                Version = Versions.IndexMetadataVersion,
                IndexSize = DefaultValues.MaxIndexSize
            };
        }
    }
}