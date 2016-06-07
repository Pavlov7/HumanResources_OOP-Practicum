using System;
using HumanResources.Interfaces;

namespace HumanResources.IO
{
    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            string input = Console.ReadLine();
            return input;
        }
    }
}
