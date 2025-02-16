using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AlianInvasion.Core.Services.DI
{
    public class DIContainer : IServiceCollection
    {
        private readonly Dictionary<Type, Type> _registrations;
        private readonly Dictionary<Type, object> _createdInstances;

        public DIContainer()
        {
            _registrations = new Dictionary<Type, Type>();
            _createdInstances = new Dictionary<Type, object>();
        }

        public void Register<TInerface, TImplementation>() where TImplementation : TInerface
        {
            _registrations[typeof(TInerface)] = typeof(TImplementation);
        }

        public void Register<TInerface, TImplementation>(TImplementation instance) where TImplementation : TInerface
        {
            _createdInstances[typeof(TInerface)] = instance;
        }

        public T GetRequiredEntiry<T>() where T : class
        {
            var type = typeof(T);

            if (_createdInstances.TryGetValue(type, out var service))
            {
                return (T)service;
            }
            else
            {
                if (!_registrations.ContainsKey(type))
                    throw new InvalidOperationException($"Required service {type.Name} are not registered");

                return (T)Resolve(type);
            }
        }

        private object Resolve(Type type)
        {
            var implType = _registrations[type];
            ConstructorInfo constructorInfo = implType.GetConstructors()[0];

            ParameterInfo[] parameterInfos = constructorInfo.GetParameters();

            object[] parameterInstances = parameterInfos
                .Select(p => Resolve(p.ParameterType))
                .ToArray();

            var instance = Activator.CreateInstance(implType, parameterInstances);
            _createdInstances.Add(type, instance);

            return instance;
        }

    }
}