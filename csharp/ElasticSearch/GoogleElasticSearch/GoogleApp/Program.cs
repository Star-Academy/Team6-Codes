using System;
using GoogleApp.Controller;
using GoogleApp.View;

namespace GoogleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager m = new Manager(new ConsoleInputReader() , new ConsoleOutputWriter());
            m.Run();
        }
    }
}
