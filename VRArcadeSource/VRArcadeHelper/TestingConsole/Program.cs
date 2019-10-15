using System;
using VRArcadeHelper;

namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            VRArcadeHelperService ws = new VRArcadeHelperService();
            ws.VROnStart(args);
            while (true)
            {
                ConsoleKeyInfo key = System.Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                    break;
            }
            ws.VROnStop();
#endif
        }
    }
}
