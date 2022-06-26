using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Win32Api;

namespace CaptureSharp.Core;

public static class WindowCaptureUtility {
    public delegate bool WindowSelector(string title, string processName);

    private const bool ContinueEnumeration = true;
    private const bool StopEnumeration = false;

    private const int TitleBufferCapacity = 1024;

    public static bool IsWindowMinimized(IntPtr handle) => NativeMethods.IsIconic(handle);

    public static void RestoreWindow(IntPtr handle) => NativeMethods.ShowWindow(handle, ShowWindowCommand.SW_RESTORE);

    /// <summary>
    ///     Check if a window can be captured (visible, top level e.t.c.)
    ///     https://stackoverflow.com/a/7292674/17654649
    ///     https://stackoverflow.com/a/33577647/17654649
    /// </summary>
    /// <param name="handle"></param>
    /// <returns></returns>
    public static bool IsWindowCapturable(IntPtr handle) {
        if (false == NativeMethods.IsWindowVisible(handle)) {
            return false;
        }

        var result = NativeMethods.DwmGetWindowAttribute(
            handle,
            DWMWINDOWATTRIBUTE.DWMWA_CLOAKED,
            out int cloaked,
            Marshal.SizeOf<int>()
        );

        if ((int)HRESULT.S_OK != result) {
            return false;
        }

        if (0 != cloaked) {
            return false;
        }

        var parent = NativeMethods.GetAncestor(handle, GetAncestorFlags.GA_ROOTOWNER);

        var current = IntPtr.Zero;

        while (parent != current) {
            current = parent;
            parent = NativeMethods.GetLastActivePopup(current);

            if (NativeMethods.IsWindowVisible(parent)) {
                break;
            }
        }

        if (current != handle) {
            return false;
        }

        var titleBarInfo = new TITLEBARINFO { cbSize = Marshal.SizeOf<TITLEBARINFO>() };

        if (false == NativeMethods.GetTitleBarInfo(handle, ref titleBarInfo)) {
            return false;
        }

        var titleBarState = (RGState)titleBarInfo.rgstate[TitleBarElement.TitleBar];

        if (titleBarState.HasFlag(RGState.STATE_SYSTEM_INVISIBLE)) {
            return false;
        }

        var style = (ExtendedWindowStyles)NativeMethods.GetWindowLong(handle, (int)GetWindowLongIndex.GWL_EXSTYLE);

        return false == style.HasFlag(ExtendedWindowStyles.WS_EX_TOOLWINDOW);

    }

    public static bool TryFindCapturableWindow(WindowSelector selector, out IntPtr handle) {
        var selectedHandle = IntPtr.Zero;

        bool EnumWindowsCallback(IntPtr hWnd, IntPtr _) {
            if (false == IsWindowCapturable(hWnd)) {
                return ContinueEnumeration;
            }

            var (title, processName) = GetWindowTitleAndProcessName(hWnd);

            if (string.IsNullOrWhiteSpace(title)) {
                return ContinueEnumeration;
            }

            if (false == selector(title, processName)) {
                return ContinueEnumeration;
            }

            selectedHandle = hWnd;
            return StopEnumeration;
        }

        NativeMethods.EnumWindows(lParam: IntPtr.Zero, lpEnumFunc: EnumWindowsCallback);

        handle = selectedHandle;

        return IntPtr.Zero != handle;
    }

    public static IList<WindowInfo> ListCapturableWindows() {
        var windows = new List<WindowInfo>();

        bool EnumWindowsCallback(IntPtr handle, IntPtr _) {
            if (false == IsWindowCapturable(handle)) {
                return ContinueEnumeration;
            }

            var (title, processName) = GetWindowTitleAndProcessName(handle);

            if (string.IsNullOrWhiteSpace(title)) {
                return ContinueEnumeration;
            }

            windows.Add(new WindowInfo(handle, title, processName));

            return ContinueEnumeration;
        }

        NativeMethods.EnumWindows(lParam: IntPtr.Zero, lpEnumFunc: EnumWindowsCallback);

        return windows;
    }

    private static (string title, string processName) GetWindowTitleAndProcessName(IntPtr handle) {
        var titleBuffer = new StringBuilder(TitleBufferCapacity);
        NativeMethods.GetWindowText(handle, titleBuffer, titleBuffer.Capacity);

        NativeMethods.GetWindowThreadProcessId(handle, out var processId);
        var process = Process.GetProcessById((int)processId);

        var title = titleBuffer.ToString();
        var processName = process.ProcessName;

        return (title, processName);
    }
}
