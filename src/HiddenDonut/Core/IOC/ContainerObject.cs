using System;
using System.Reflection;

namespace HiddenDonut.Core.IOC
{
    internal class ContainerObject
    {
        public ParameterInfo[] Parameters => _registeredObject.Parameters;
        public object Instance { get; private set; }
        private readonly RegisteredObject _registeredObject;
        public ContainerObject(Type concreteType, object instance = null)
        {
            _registeredObject = new RegisteredObject(concreteType);
            Instance = instance;
        }

        public ContainerObject(object instance = null)
        {
            Instance = instance;
        }

        public object CreateInstance(params object[] args)
        {
            if (_registeredObject == null)
            {
                throw new InvalidOperationException("Singleton does not support creating instance.");
            }
            return Instance = _registeredObject.CreateInstance(args);
        }
    }
}