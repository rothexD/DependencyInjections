using System;

namespace TryDependencyInjector
{
    public class HelloWorld
    {
        public HelloWorld(MyName myName, MyRandom a)
        {
            Console.WriteLine($"My name is: {myName.Name} and my next value is: {a.Next()}");
        }
    }
}