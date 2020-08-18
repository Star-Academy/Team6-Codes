using InvertedSearch.Controller;
using InvertedSearch.View;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(new ConsoleInputReader() ,new ConsoleOutputWriter());
            manager.Run();
        }
    }
}