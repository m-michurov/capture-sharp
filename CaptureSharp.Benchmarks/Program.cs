using BenchmarkDotNet.Running;

namespace WindowCapture.Benchmarks;

internal static class Program {
    public static void Main() => BenchmarkRunner.Run<CaptureBenchmark>();
}
