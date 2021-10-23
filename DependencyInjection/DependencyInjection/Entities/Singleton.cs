using System;
using System.Collections.Generic;
using DependencyInjection.Interfaces;

namespace DependencyInjection.Entities
{
    internal class Singleton<T> : IDependency
    {
        private readonly List<CustomConstructorInfo> _info;
        private object _singleTon;
        private readonly bool IsInstancd;
        private object[] ParamInfo;

        public Singleton(List<CustomConstructorInfo> info)
        {
            _info = info;
        }

        public Singleton(object reference)
        {
            _singleTon = reference;
            IsInstancd = true;
        }

        public override bool IsSingleton()
        {
            return true;
        }

        public override object GetDependency()
        {
            if (!IsInstancd)
            {
                ParamInfo = FillConstructorInfo<T>(_info);
                _singleTon = Activator.CreateInstance(typeof(T), ParamInfo);
            }

            return _singleTon;
        }
    }
}