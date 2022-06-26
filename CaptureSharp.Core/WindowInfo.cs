using System;

namespace CaptureSharp.Core;

public readonly struct WindowInfo {
    public readonly IntPtr Handle;
    public readonly string Title;
    public readonly string ProcessName;

    public WindowInfo(IntPtr handle, string title, string processName) {
        Handle = handle;
        Title = title;
        ProcessName = processName;
    }

    public void Deconstruct(
        out IntPtr handle,
        out string title,
        out string processName
    ) {
        handle = Handle;
        title = Title;
        processName = ProcessName;
    }
}
