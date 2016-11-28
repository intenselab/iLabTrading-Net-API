using System;

namespace ILabFramework.Example
{
    internal class Logger
    {
        private static Logger instance;
        public static Logger Instance => instance ?? (instance = new Logger());

        public void WriteLog(string message,ConsoleColor color = ConsoleColor.White)
        {
            var localColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ForegroundColor = localColor;
        }
    }
}