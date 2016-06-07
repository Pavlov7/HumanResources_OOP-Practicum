using System;
using HumanResources.Interfaces;

namespace HumanResources.IO
{
    public class ConsoleWriter : IOutputWriter
    {
        public void Write(string output)
        {
            Console.Write(output);
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
