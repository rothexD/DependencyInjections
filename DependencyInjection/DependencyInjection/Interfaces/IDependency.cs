using System;
using System.Collections.Generic;
using System.Linq;
using DependencyInjection.Entities;

namespace DependencyInjection.Interfaces
{
    public abstract class IDependency
    {
        public abstract bool IsSingleton();

        public abstract object GetDependency();

        protected object[] FillConstructorInfo<T>(List<CustomConstructorInfo> customInfo)
        {
            if (customInfo is null) return Array.Empty<object>();
            var constructor = typeof(T).GetConstructors().First();
            var parameterInfo = constructor.GetParameters();

            if (parameterInfo.Length == 0) return Array.Empty<object>();
            var parameterList = new object[parameterInfo.Length];
            for (var i = 0; i < parameterInfo.Length; i++)
            {
                var matches = customInfo.Where(x => { return x.ParamName == parameterInfo[0].Name; }).ToList();
                if (matches.Count == 1)
                {
                    parameterList[i] = matches[0].ParamValue;
                }
                else if (matches.Count == 0)
                {
                    Console.WriteLine(parameterInfo[i].Name);
                    parameterList[i] = DependencyService.GetDependency(parameterInfo[i].ParameterType);
                }
                else
                {
                    throw new Exception("Could not resolve param, custominfo param name is unique");
                }
            }

            return parameterList;
        }
    }
}