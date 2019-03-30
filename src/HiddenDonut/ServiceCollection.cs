using HiddenDonut.Core;
using HiddenDonut.Core.IOC;
using HiddenDonut.Index;

namespace HiddenDonut
{
    internal class ServiceCollection : IServiceCollection
    {
        private readonly IContainer _container;

        public ServiceCollection()
        {
            _container = new Container()
                    .AddRegistry<CoreRegistry>()
                    .AddRegistry<ServicesRegistry>()
                    .AddRegistry<IndexRegistry>()

                ;

        }

        public T GetInstance<T>()
        {
            return _container.GetInstance<T>();
        }

        public IServiceCollection Register<TTypeToResolve, TConcrete>() where TConcrete : TTypeToResolve
        {
            _container.Register<TTypeToResolve, TConcrete>();
            return this;
        }

        public IServiceCollection RegisterSingleton<TTypeToResolve>(TTypeToResolve instance)
        {
            _container.RegisterInstance(instance);
            return this;
        }
    }
}