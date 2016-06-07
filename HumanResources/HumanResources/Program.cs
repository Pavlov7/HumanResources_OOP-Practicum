using HumanResources.IO;

namespace HumanResources
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Daniel Pavlov 61880
            Company company = new Company();
            ConsoleReader reader = new ConsoleReader();
            ConsoleWriter writer = new ConsoleWriter();
            Engine engine = new Engine(reader, writer, company);
            engine.Run();
        }
    }
}
