using HiddenDonut.Index.Metadata;

namespace HiddenDonut.Index
{
    internal interface IIndexFileMetadataFactory
    {
        IndexMetadataStruct CreateDefault();
    }
}