using HiddenDonut.Core.IOC;
using HiddenDonut.Core.Streams;

namespace HiddenDonut.Core
{
    internal class CoreRegistry : IRegistry
    {
        public void Register(IContainer container)
        {
            container
                .Register<IDateTime, DateTimeWrapper>()
                .Register<IFileStreamFactory, FileStreamFactory>()
                .Register<IFiles, Files>()
                ;
        }
    }
}
