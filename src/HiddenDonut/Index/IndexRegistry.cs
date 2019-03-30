using HiddenDonut.Core.IOC;

namespace HiddenDonut.Index
{
    class IndexRegistry : IRegistry
    {
        public void Register(IContainer container)
        {
            container
                .Register<IIndexFileInitializer, IndexFileInitializer>()
                .Register<IIndexFileMetadataFactory, IndexFileMetadataFactory>()
                .Register<IIndexFileManager, IndexFileManager>()
                .Register<IIndexMetadataWriter, IndexMetadataWriter>()
                .Register<IIndexMetadataReader, IndexMetadataReader>()
                ;
        }
    }
}
