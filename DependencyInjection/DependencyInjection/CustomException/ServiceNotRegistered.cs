using System;

namespace DependencyInjection.CustomException
{
    internal class ServiceNotRegistered : Exception
    {
        public ServiceNotRegistered()
        {
        }

        public ServiceNotRegistered(string message)
            : base(message)
        {
        }

        public ServiceNotRegistered(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}