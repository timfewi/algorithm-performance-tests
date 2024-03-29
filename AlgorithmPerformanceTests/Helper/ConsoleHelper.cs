using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPerformanceTests.Helper
{
    internal class ConsoleHelper
    {
        public static void Logo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
    _    _                  _ _   _                                        
   / \  | | __ _  ___  _ __(_) |_| |__  _ __ ___                           
  / _ \ | |/ _` |/ _ \| '__| | __| '_ \| '_ ` _ \   _____                  
 / ___ \| | (_| | (_) | |  | | |_| | | | | | | | | |_____|                 
/_/__ \_\_|\__, |\___/|_|  |_|\__|_| |_|_| |_| |_|_      _____         _   
| __ )  ___|___/   ___| |__  _ __ ___   __ _ _ __| | __ |_   _|__  ___| |_ 
|  _ \ / _ \ '_ \ / __| '_ \| '_ ` _ \ / _` | '__| |/ /   | |/ _ \/ __| __|
| |_) |  __/ | | | (__| | | | | | | | | (_| | |  |   <    | |  __/\__ \ |_ 
|____/ \___|_| |_|\___|_| |_|_| |_| |_|\__,_|_|  |_|\_\   |_|\___||___/\__|
");
        }

        public static void Line()
        {
            Console.WriteLine("----------------------------------------------------------------------------------");
        }

        public static void Message(string message)
        {
            Console.WriteLine($"[{DateTime.UtcNow:HH:mm:ss}]  - {message}");
        }


        public static void MessageHighlighted(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void End()
        {
            Console.WriteLine("Performance test completed. Press any key to exit...");
            Console.ReadKey();
        }
        public static void Start()
        {
            Console.WriteLine("Press any key to start the performance test...");
            Console.ReadKey();
        }
    }
}
