using System;
using VRArcadeServerService;

namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            VRArcadeServerService.VRArcadeServerService ms = new VRArcadeServerService.VRArcadeServerService();
            ms.VROnStart(args);
            while (true)
            {
                ConsoleKeyInfo key = System.Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                    break;
            }
            ms.VROnStop();
#endif

        }
    }
}
