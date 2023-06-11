using Arm64.Performance;

Console.WriteLine($"Processor architecture: " +
    $"{Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE")}");

const int executionCount = 500;
const int trialCount = 5;

for ( int i = 0; i < trialCount; i++ )
{
    Console.WriteLine($"Trial no: {i + 1} / {trialCount}");

    PerformanceHelper.MeasurePerformance(PerformanceTests.ListSorting, executionCount, "List sorting");

    PerformanceHelper.MeasurePerformance(PerformanceTests.ListSorting, executionCount, "Matrix multiplication");

    PerformanceHelper.MeasurePerformance(PerformanceTests.StringOperations, executionCount*1000, "String operations");
}