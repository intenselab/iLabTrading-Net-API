using System;
using System.Threading;

namespace ILabFramework.Example
{
    internal class Program
    {
        private static User User { get; set; }
        private static ExecutionData ExecutionData { get; set; }
        private static MarketData MarketData { get; set; }
        private static HistoricalData HistoricalData { get; set; }

        private static void Main()
        {
            Initialize();
            StartMenu();
            while (true)
            {
                Thread.Sleep(1);
            }
        }

        private static void StartMenu()
        {
            Console.Clear();
            Logger.Instance.WriteLog("Select demo number", ConsoleColor.DarkMagenta);
            Logger.Instance.WriteLog("1 - Market demo.");
            Logger.Instance.WriteLog("2 - Execution demo.");
            Logger.Instance.WriteLog("3 - Historical demo.");

            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Market();
                    break;
                case ConsoleKey.D2:
                    Execution();
                    break;
                case ConsoleKey.D3:
                    Historical();
                    break;
                default:
                    if (key.Modifiers != ConsoleModifiers.Control || key.Key != ConsoleKey.C)
                        StartMenu();
                    break;
            }
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            MarketData?.StopDemo();
            ExecutionData?.StopDemo();
            HistoricalData?.StopDemo();

            e.Cancel = true;
            StartMenu();
        }

        private static void Initialize()
        {
            User = new User();
            Console.CancelKeyPress += Console_CancelKeyPress;
        }

        private static void Market()
        {
            MarketData = new MarketData(User);
            MarketData.StartDemo();
        }

        private static void Execution()
        {
            ExecutionData = new ExecutionData(User);
            ExecutionData.StartDemo();
        }

        private static void Historical()
        {
            HistoricalData = new HistoricalData(User);
            HistoricalData.StartDemo();
        }
    }
}