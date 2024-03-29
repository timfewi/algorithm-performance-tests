using AlgorithmPerformanceTests.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPerformanceTests.Data
{
    public static class DataGenerator
    {
        public static int[] GenerateRandomArray(int length, int min = 0, int max = 100)
        {
            ConsoleHelper.Message($"Generating random array of length {length} with values between {min} and {max}...");
            Random random = new Random();
            int[] data = new int[length];
            for (int i = 0; i < length; i++)
            {
                data[i] = random.Next(min, max + 1);
            }
            return data;
        }
    }
}
