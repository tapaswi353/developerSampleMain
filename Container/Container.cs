using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> bindings = new Dictionary<Type, Type>();

        public void Bind(Type interfaceType, Type implementationType)
        {
            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException("interfaceType must be an interface.", nameof(interfaceType));
            }

            if (!interfaceType.IsAssignableFrom(implementationType))
            {
                throw new ArgumentException("implementationType must implement interfaceType.", nameof(implementationType));
            }

            bindings[interfaceType] = implementationType;
        }

        public T Get<T>()
        {
            Type implementationType;
            if (bindings.TryGetValue(typeof(T), out implementationType))
            {
                return (T)Activator.CreateInstance(implementationType);
            }

            throw new InvalidOperationException($"No binding found for {typeof(T)}.");
        }
    }
}
