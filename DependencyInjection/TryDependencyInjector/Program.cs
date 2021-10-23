using System;
using System.Net.Http.Headers;
using DependencyInjection;
using TryDependencyInjector.Show;

namespace TryDependencyInjector
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowSingleton.Show();
            ShowTransitive.Show();
        }
        
    }
}