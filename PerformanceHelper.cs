using System.Diagnostics;

namespace Arm64.Performance
{
    public static class PerformanceHelper
    {
        private static readonly Stopwatch stopwatch = new();

        public static void MeasurePerformance(Action method, int executionCount, string label)
        {
            stopwatch.Restart();

            for(int i = 0; i < executionCount; i++)
            {
                method();
            }

            stopwatch.Stop();

            Console.WriteLine($"[{label}]: {stopwatch.ElapsedMilliseconds.ToString("f2")} ms");
        }
    }
}
