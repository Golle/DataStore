using HiddenDonut.Core.IOC;
using HiddenDonut.Index;

namespace HiddenDonut
{
    internal class ServicesRegistry : IRegistry
    {
        public void Register(IContainer container)
        {
            container
                .Register<IDataStore, DataStore>()
                ;
        }
    }
}