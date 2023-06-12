using Arm64.Performance;

Console.WriteLine($"Processor architecture: " +
    $"{Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE")}");

const int trialCount = 5;

for ( int i = 0; i < trialCount; i++ )
{
    Console.WriteLine($"Trial no: {i + 1} / {trialCount}");

    PerformanceHelper.MeasurePerformance(PerformanceTests.ListSorting, executionCount: 500, "List sorting");

    PerformanceHelper.MeasurePerformance(PerformanceTests.SquareMatrixMultiplication, executionCount: 5, "Matrix multiplication");

    PerformanceHelper.MeasurePerformance(PerformanceTests.StringOperations, executionCount: 500000, "String operations");
}