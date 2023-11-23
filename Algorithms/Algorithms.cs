using System;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException(nameof(n), "Input must be a non-negative integer.");
            if (n == 0 || n == 1)
                return 1;

            int factorial = 1;
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        public static string FormatSeparators(params string[] items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (items.Length == 0)
                return "";

            if (items.Length == 1)
                return items[0];

            if (items.Length == 2)
                return $"{items[0]} and {items[1]}";

            string lastItem = items.Last();
            string formatted = string.Join(", ", items.Take(items.Length - 1));
            formatted += $" and {lastItem}";

            return formatted;
        }
    }
}