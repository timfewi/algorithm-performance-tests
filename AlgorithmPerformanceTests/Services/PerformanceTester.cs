using AlgorithmPerformanceTests.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPerformanceTests.Services
{
    public class PerformanceTester
    {
        public void TestSortAlgorithm(Action<int[]> sortAlgorithm, int[] data)
        {
            int[] dataCopy = (int[])data.Clone();

            Stopwatch stopwatch = new Stopwatch();
            ConsoleHelper.Message("Starte Performance-Test...");
            stopwatch.Start();

            sortAlgorithm(dataCopy);

            stopwatch.Stop();
            ConsoleHelper.MessageHighlighted($"Ausführungszeit: {stopwatch.ElapsedMilliseconds} ms", ConsoleColor.DarkYellow);
        }



        public void TestSortAlgorithmWithValidation(Action<int[]> sortAlgorithm, int[] data)
        {
            int[] dataCopy = (int[])data.Clone();

            Stopwatch stopwatch = new Stopwatch();
            ConsoleHelper.Message("Starting Performance-Test...");
            stopwatch.Start();

            sortAlgorithm(dataCopy);

            stopwatch.Stop();
            ConsoleHelper.MessageHighlighted($"Ausführungszeit: {stopwatch.ElapsedMilliseconds} ms", ConsoleColor.DarkYellow);

            if (IsValidSortedOrder(dataCopy))
            {
                ConsoleHelper.Message("Sortierung erfolgreich!");
            }
            else
            {
                ConsoleHelper.Message("Sortierung fehlgeschlagen!");
            }
        }


        private static bool IsValidSortedOrder(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
