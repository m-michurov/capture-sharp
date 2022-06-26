using System;
using BenchmarkDotNet.Attributes;
using CaptureSharp.Core;

namespace WindowCapture.Benchmarks;

// ReSharper disable once ClassCanBeSealed.Global
public class CaptureBenchmark {
    private const string Process = "rider64";
    private IntPtr handle = IntPtr.Zero;

    [GlobalSetup]
    public void Setup() {
        var windowFound = WindowCaptureUtility.TryFindCapturableWindow(
            (_, processName) => processName.ToLower()
                .Contains(Process.ToLower()),
            out handle
        );

        if (false == windowFound) {
            throw new Exception(message: "Window not found");
        }
    }

    [Benchmark]
    public void CaptureWindow() {
        using var image = CaptureSharp.Core.WindowCapture.Capture(handle);
    }
}
