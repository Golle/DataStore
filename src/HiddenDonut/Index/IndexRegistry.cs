using HiddenDonut.Core.IOC;

namespace HiddenDonut.Index
{
    internal class IndexRegistry : IRegistry
    {
        public void Register(IContainer container)
        {
            container
                .Register<IIndexFileManager, IndexFileManager>()
                .Register<IIndexFileMetadataFactory, IndexFileMetadataFactory>()
                .Register<IIndexFilePathFormatter, IndexFilePathFormatter>()
                .Register<IIndexManager, IndexManager>()
                ;
        }
    }
}
