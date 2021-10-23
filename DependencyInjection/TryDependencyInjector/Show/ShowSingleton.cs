using System;
using DependencyInjection;

namespace TryDependencyInjector.Show
{
    public class ShowSingleton
    {
        public static void Show()
        {
            Console.WriteLine("Adding Singleton for MyName with name Hans");
            Console.WriteLine("///////////////////////////////////////////");
            DependencyService.AddSingleton(new MyName("hans"), true);
            DependencyService.AddSingleton(new MyRandom(), true);
            Console.WriteLine("Adding Singleton for MyRandom (random class with set seed to 32)");
            Console.WriteLine("///////////////////////////////////////////");
            Console.WriteLine("First: Retrieving MyName and MyRandom and invoking MyRandom.next()");
            new HelloWorld(DependencyService.GetDependency<MyName>(), DependencyService.GetDependency<MyRandom>());
            Console.WriteLine("Second: Retrieving MyName and MyRandom and invoking MyRandom.next()");
            new HelloWorld(DependencyService.GetDependency<MyName>(), DependencyService.GetDependency<MyRandom>());
            Console.WriteLine("Third: Retrieving MyName and MyRandom and invoking MyRandom.next()");
            new HelloWorld(DependencyService.GetDependency<MyName>(), DependencyService.GetDependency<MyRandom>());
            Console.WriteLine("Fourth: Retrieving MyName and MyRandom and invoking MyRandom.next()");
            new HelloWorld(DependencyService.GetDependency<MyName>(), DependencyService.GetDependency<MyRandom>());


            Console.WriteLine("Getting Singleton and printing 5x next");
            var i = DependencyService.GetDependency<MyRandom>();
            Console.WriteLine(i.Next());
            Console.WriteLine(i.Next());
            Console.WriteLine(i.Next());
            Console.WriteLine(i.Next());
            Console.WriteLine(i.Next());
            Console.WriteLine("Getting Singleton and printing 5x next");
            i = DependencyService.GetDependency<MyRandom>();
            Console.WriteLine(i.Next());
            Console.WriteLine(i.Next());
            Console.WriteLine(i.Next());
            Console.WriteLine(i.Next());
            Console.WriteLine(i.Next());
        }
    }
}