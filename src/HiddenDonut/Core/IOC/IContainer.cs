namespace HiddenDonut.Core.IOC
{
    internal interface IContainer
    {
        IContainer Register<TTypeToResolve, TConcrete>() where TConcrete : TTypeToResolve;
        IContainer RegisterInstance<TTypeToResolve>(TTypeToResolve instance);
        TTypeToResolve GetInstance<TTypeToResolve>();
        IContainer AddRegistry<T>() where T : IRegistry;
    }
}