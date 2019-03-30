namespace HiddenDonut
{
    internal interface IServiceCollection
    {
        T GetInstance<T>();
        IServiceCollection Register<TTypeToResolve, TConcrete>() where TConcrete : TTypeToResolve;
        IServiceCollection RegisterSingleton<TTypeToResolve>(TTypeToResolve instance);
    }
}