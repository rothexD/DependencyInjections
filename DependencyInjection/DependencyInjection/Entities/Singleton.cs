﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DependencyInjection.Interfaces;

namespace DependencyInjection.Entities
{
    internal class Singleton<T> : IDependency
    {
        private object _singleTon;
        private object[] ParamInfo;
        private bool IsInstancd = false;
        private List<CustomConstructorInfo> _info;
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
                _singleTon = Activator.CreateInstance(typeof(T),ParamInfo);
            }
            return _singleTon;
        }
    }
}