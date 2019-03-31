using HiddenDonut.Core.IOC;

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