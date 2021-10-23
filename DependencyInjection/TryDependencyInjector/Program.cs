using TryDependencyInjector.Show;

namespace TryDependencyInjector
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ShowSingleton.Show();
            ShowTransitive.Show();
        }
    }
}