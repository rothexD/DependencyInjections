using System;

namespace TryDependencyInjector
{
    public class MyRandom : Random
    {
        public MyRandom():base(32)
        {
            
        }
    }
}