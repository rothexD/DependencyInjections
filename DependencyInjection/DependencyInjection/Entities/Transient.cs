using System;
using System.Collections.Generic;
using System.Reflection;
using DependencyInjection.Interfaces;

namespace DependencyInjection.Entities
{
    internal class Transient<T> : IDependency
    {
        private readonly List<CustomConstructorInfo> _constructorInfo;
        private bool IsParsed = false;
        private object[] _info;
        public Transient(List<CustomConstructorInfo> constructorInfo)
        {
            _constructorInfo = constructorInfo;
        }

        public override bool IsSingleton()
        {
            return false;
        }
        public override object GetDependency()
        {
            if (!IsParsed)
            {
                _info = FillConstructorInfo<T>(_constructorInfo);
                IsParsed = true;
            }
            return Activator.CreateInstance(typeof(T),_info);
        }
    }
}