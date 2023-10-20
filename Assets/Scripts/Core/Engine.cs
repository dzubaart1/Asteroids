using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Platform;
using Services;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core
{
    public class Engine
    {
        public static RuntimeBehaviour Behaviour { get; private set; }
        public static bool IsInitialized { get; private set; }
        
        public static IReadOnlyCollection<Type> Types => _typesCache ?? (_typesCache = GetEngineTypes());

        private static Dictionary<Type, IService> _services = new Dictionary<Type, IService>();
        private static ConfigurationProvider _configurationProvider;
        private static IReadOnlyCollection<Type> _typesCache;
        
        public static Task Initialize(ConfigurationProvider configurationProvider, RuntimeBehaviour behaviour)
        {
            Behaviour = behaviour;
            _configurationProvider = configurationProvider;

            AddService(new FactoryService());
            AddService(new GameplayService());
            AddService(new InputService());
            AddService(new SceneService());
            AddService(new SpawnerService());

            foreach (var service in _services.Values)
                service.InitializeServiceAsync();
            
            IsInitialized = true;
            Behaviour.BehaviourDestroyEvent += Destroy;
            
            return Task.CompletedTask;
        }
        
        public static void Destroy()
        {
            foreach (var service in _services.Values)
                service.DestroyService();
            
            _services.Clear();
        }
        
        public static T Instantiate<T>(T prototype, Transform parent = default) where T : Object
        {
            if (Behaviour is null)
            {
                throw new Exception("Engine is not initialized");
            }

            var newObj = Object.Instantiate(prototype, parent ? parent : Behaviour.transform);
            return newObj;
        }

        public static GameObject CreateObject(string name = default, Transform parent = default,
            params Type[] components)
        {
            if (Behaviour is null)
            {
                throw new Exception("Engine is not initialized");
            }

            var objName = name ?? "PlatformObject";
            var newObj = components != null ? new GameObject(objName, components) : new GameObject(objName);
            newObj.transform.SetParent(parent ? parent : Behaviour.transform);

            return newObj;
        }
        
        public static void AddService<T>(T service) where T: IService
        {
            if (_services.ContainsKey(typeof(T)))
            {
                throw new Exception($"Service {typeof(T)} already exists");
            }
                
            _services.Add(typeof(T), service);
        }
        
        public static void RemoveService<T>() where T: IService
        {
            if (_services.ContainsKey(typeof(T)))
            {
                _services.Remove(typeof(T));
            }
            else
            {
                throw new Exception($"Service {typeof(T)} doesn't exists");
            }
        }
        
        public static T GetService<T>() where T : class, IService
        {
            if (_services.ContainsKey(typeof(T)))
                return (T) _services[typeof(T)];

            Type type = typeof(T);
            var result = _services.FirstOrDefault(x => type.IsInstanceOfType(x.Value));

            if (result.Value is null)
                throw new Exception($"Service {typeof(T)} doesn't exists");

            return (T) result.Value;
        }
        
        public static T GetConfiguration<T>() where T: Configuration
        {
            if (_configurationProvider is null)
                throw new Exception($"Failed to provide `{typeof(T).Name}` configuration object: Configuration provider is not available or the engine is not initialized.");

            return (T) _configurationProvider.GetConfiguration(typeof(T));
        }

        private static IReadOnlyCollection<Type> GetEngineTypes()
        {
            var engineTypes = new List<Type>(1000);
            var engineConfig = ConfigurationProvider.LoadOrDefault<EngineConfiguration>();
            var domainAssemblies = ReflectionUtils.GetDomainAssemblies(true, true, true);
            
            foreach (var assemblyName in engineConfig.TypeAssemblies)
            {
                var assembly = domainAssemblies.FirstOrDefault(a => a.FullName.StartsWithFast($"{assemblyName}"));
                if (assembly is null) continue;
                engineTypes.AddRange(assembly.GetExportedTypes());
            }

            return engineTypes;
        }
    }
}