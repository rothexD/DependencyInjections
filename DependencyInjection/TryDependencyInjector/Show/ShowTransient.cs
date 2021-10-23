using System;
using System.Collections.Generic;
using DependencyInjection;
using DependencyInjection.Entities;

namespace TryDependencyInjector.Show
{
    public static class ShowTransitive
    {
        public static void Show()
        {
            Console.WriteLine("Adding Transient for MyName with name Hans");
            Console.WriteLine("///////////////////////////////////////////");
            DependencyService.AddTransient<MyName>(
                new List<CustomConstructorInfo> {new() {ParamName = "name", ParamValue = "Lukas"}}, true);
            DependencyService.AddTransient<MyRandom>(null, true);
            Console.WriteLine("Adding Transient for MyRandom (random class with set seed to 32)");
            Console.WriteLine("///////////////////////////////////////////");
            Console.WriteLine("First: Retrieving MyName and MyRandom and invoking MyRandom.next()");
            new HelloWorld(DependencyService.GetDependency<MyName>(), DependencyService.GetDependency<MyRandom>());
            Console.WriteLine("Second: Retrieving MyName and MyRandom and invoking MyRandom.next()");
            new HelloWorld(DependencyService.GetDependency<MyName>(), DependencyService.GetDependency<MyRandom>());
            Console.WriteLine("Third: Retrieving MyName and MyRandom and invoking MyRandom.next()");
            new HelloWorld(DependencyService.GetDependency<MyName>(), DependencyService.GetDependency<MyRandom>());
            Console.WriteLine("Fourth: Retrieving MyName and MyRandom and invoking MyRandom.next()");
            new HelloWorld(DependencyService.GetDependency<MyName>(), DependencyService.GetDependency<MyRandom>());

            Console.WriteLine("Getting Transient and printing 5x next");
            var i = DependencyService.GetDependency<MyRandom>();
            Console.WriteLine(i.Next());
            Console.WriteLine(i.Next());
            Console.WriteLine(i.Next());
            Console.WriteLine(i.Next());
            Console.WriteLine(i.Next());
            Console.WriteLine("Getting Transient and printing 5x next");
            i = DependencyService.GetDependency<MyRandom>();
            Console.WriteLine(i.Next());
            Console.WriteLine(i.Next());
            Console.WriteLine(i.Next());
            Console.WriteLine(i.Next());
            Console.WriteLine(i.Next());
        }
    }
}