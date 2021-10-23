using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DependencyInjection.CustomException;
using DependencyInjection.Entities;
using DependencyInjection.Interfaces;

namespace DependencyInjection
{
    public static class DependencyService
    {
        private static readonly Dictionary<Type,IDependency> DependencyRepository = new ();
        
        public static bool AddSingleton<T>(List<CustomConstructorInfo> info,bool force = false)
        {
            if (DependencyRepository.ContainsKey(typeof(T)) && force == false)
            {
                return false;
            }
            var newDependency = new Singleton<T>(info);
            DependencyRepository[typeof(T)] = newDependency;
            return true;
        }
        public static bool AddSingleton<T>(T obj,bool force = false)
        {
            if (DependencyRepository.ContainsKey(typeof(T)) && force == false)
            {
                
                return false;
            }
            var newDependency = new Singleton<T>(obj);
            DependencyRepository[typeof(T)] = newDependency;
            return true;
        }
        public static bool AddTransient<T>(List<CustomConstructorInfo> info, bool force = false)
        {
            
            if (DependencyRepository.ContainsKey(typeof(T)) && force == false)
            {
                return false;
            }
            var newDependency = new Transient<T>(info);
            DependencyRepository[typeof(T)] = newDependency;
            return true;
        }
        public static bool AddTransient<T>(T obj,List<CustomConstructorInfo> info,bool force = false)
        {
            if (DependencyRepository.ContainsKey(typeof(T)) && force == false)
            {
                return false;
            }
            var newDependency = new Transient<T>(info);
            DependencyRepository[typeof(T)] = newDependency;
            return true;
        }

        public static T GetDependency<T>()
        {
            if (DependencyRepository.TryGetValue(typeof(T), out IDependency dependency))
            {
                return (T) dependency.GetDependency();
            }
            throw new ServiceNotRegistered($"{nameof(T)} is not registered as a Dependency / Service");
        }
        
        public static object GetDependency(Type t)
        {
            if (DependencyRepository.TryGetValue(t, out IDependency dependency))
            {
                return  dependency.GetDependency();
            }
            throw new ServiceNotRegistered($"{nameof(t)} is not registered as a Dependency / Service");
        }
    }
}