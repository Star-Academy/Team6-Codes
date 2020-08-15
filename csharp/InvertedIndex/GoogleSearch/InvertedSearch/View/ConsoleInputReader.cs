using System;

namespace InvertedSearch.View
{
    public class ConsoleInputReader : IInputReader
    {
        public string GetPath()
        {
            return Console.ReadLine();
        }

        public string GetQuery()
        {
            return Console.ReadLine();
        }
    }
}