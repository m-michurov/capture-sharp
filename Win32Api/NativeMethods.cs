using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable InconsistentNaming

namespace Win32Api;

public static class NativeMethods {
    public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    /// <summary>
    /// </summary>
    /// <param name="lpEnumFunc"></param>
    /// <param name="lParam"></param>
    /// <returns>
    ///     If the function succeeds, the return value is nonzero.
    ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
    ///     If EnumWindowsProc returns zero, the return value is also zero. In this case,
    ///     the callback function should call SetLastError to obtain a meaningful error code to be returned
    ///     to the caller of EnumWindows.
    /// </returns>
    [DllImport(dllName: "user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    /// <summary>
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="lpString"></param>
    /// <param name="nMaxCount"></param>
    /// <returns>
    ///     If the function succeeds, the return value is the length, in characters, of the copied string,
    ///     not including the terminating null character. If the window has no title bar or text,
    ///     if the title bar is empty, or if the window or control handle is invalid, the return value is zero.
    ///     To get extended error information, call GetLastError.
    ///     This function cannot retrieve the text of an edit control in another application.
    /// </returns>
    [DllImport(dllName: "user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    /// <summary>
    /// </summary>
    /// <param name="hWnd"></param>
    /// <returns>
    ///     If the specified window, its parent window, its parent's parent window, and so forth,
    ///     have the WS_VISIBLE style, the return value is nonzero. Otherwise, the return value is zero.
    ///     Because the return value specifies whether the window has the WS_VISIBLE style, it may
    ///     be nonzero even if the window is totally obscured by other windows.
    /// </returns>
    [DllImport(dllName: "user32.dll")]
    public static extern bool IsWindowVisible(IntPtr hWnd);

    /// <summary>
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="lpdwProcessId"></param>
    /// <returns>
    ///     The return value is the identifier of the thread that created the window.
    /// </returns>
    [DllImport(dllName: "user32.dll", SetLastError = true)]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    /// <summary>
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="dwAttribute"></param>
    /// <param name="pvAttribute"></param>
    /// <param name="cbAttribute"></param>
    /// <returns>
    ///     If the function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.
    /// </returns>
    [DllImport(dllName: "dwmapi.dll")]
    public static extern int DwmGetWindowAttribute(
        IntPtr hWnd,
        DWMWINDOWATTRIBUTE dwAttribute,
        out RECT pvAttribute,
        int cbAttribute
    );

    /// <summary>
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="dwAttribute"></param>
    /// <param name="pvAttribute"></param>
    /// <param name="cbAttribute"></param>
    /// <returns>
    ///     If the function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.
    /// </returns>
    [DllImport(dllName: "dwmapi.dll")]
    public static extern int DwmGetWindowAttribute(
        IntPtr hWnd,
        DWMWINDOWATTRIBUTE dwAttribute,
        out int pvAttribute,
        int cbAttribute
    );

    [DllImport(dllName: "user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsIconic(IntPtr hWnd);

    [DllImport(dllName: "user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommand nCmdShow);

    /// <summary>
    ///     Retrieves the handle to the ancestor of the specified window.
    /// </summary>
    /// <param name="hWnd">
    ///     A handle to the window whose ancestor is to be retrieved.
    ///     If this parameter is the desktop window, the function returns NULL.
    /// </param>
    /// <param name="flags">
    ///     The ancestor to be retrieved.
    /// </param>
    /// <returns>
    ///     The return value is the handle to the ancestor window.
    /// </returns>
    [DllImport(dllName: "user32.dll", ExactSpelling = true)]
    public static extern IntPtr GetAncestor(IntPtr hWnd, GetAncestorFlags flags);

    /// <summary>
    ///     Determines which pop-up window owned by the specified window was most recently active.
    /// </summary>
    /// <param name="hWnd"></param>
    /// <returns>
    ///     The return value identifies the most recently active pop-up window. The return value is the same as the hWnd
    ///     parameter, if any of the following conditions are met:
    ///     The window identified by hWnd was most recently active.
    ///     The window identified by hWnd does not own any pop-up windows.
    ///     The window identifies by hWnd is not a top-level window, or it is owned by another window.
    /// </returns>
    [DllImport(dllName: "user32.dll")]
    public static extern IntPtr GetLastActivePopup(IntPtr hWnd);

    /// <summary>
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="pti"></param>
    /// <returns>
    ///     If the function succeeds, the return value is nonzero.
    ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
    /// </returns>
    [DllImport(dllName: "user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetTitleBarInfo(IntPtr hWnd, ref TITLEBARINFO pti);

    [DllImport(dllName: "user32.dll", SetLastError = true)]
    public static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

    /// <summary>
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="hrgnClip"></param>
    /// <param name="flags"></param>
    /// <returns>
    ///     If the function succeeds, the return value is the handle to the DC for the specified window.
    ///     If the function fails, the return value is NULL.
    ///     An invalid value for the hWnd parameter will cause the function to fail.
    /// </returns>
    [DllImport(dllName: "user32.dll")]
    public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, DeviceContextValues flags);

    /// <summary>
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="lpRect"></param>
    /// <returns>
    ///     If the function succeeds, the return value is nonzero.
    ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
    /// </returns>
    [DllImport(dllName: "user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [DllImport(dllName: "user32.dll")]
    public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

    /// <summary>
    /// </summary>
    /// <param name="hdc"></param>
    /// <param name="nXDest"></param>
    /// <param name="nYDest"></param>
    /// <param name="nWidth"></param>
    /// <param name="nHeight"></param>
    /// <param name="hdcSrc"></param>
    /// <param name="nXSrc"></param>
    /// <param name="nYSrc"></param>
    /// <param name="dwRop"></param>
    /// <returns>
    ///     If the function succeeds, the return value is nonzero.
    ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
    /// </returns>
    [DllImport(dllName: "gdi32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool BitBlt(
        IntPtr hdc,
        int nXDest,
        int nYDest,
        int nWidth,
        int nHeight,
        IntPtr hdcSrc,
        int nXSrc,
        int nYSrc,
        RasterOperationCode dwRop
    );

    /// <summary>
    /// </summary>
    /// <param name="hdc"></param>
    /// <returns>
    ///     If the function succeeds, the return value is the handle to a memory DC.
    ///     If the function fails, the return value is NULL.
    /// </returns>
    [DllImport(dllName: "gdi32.dll", SetLastError = true)]
    public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

    /// <summary>
    /// </summary>
    /// <param name="hdc"></param>
    /// <param name="nWidth"></param>
    /// <param name="nHeight"></param>
    /// <returns>
    ///     If the function succeeds, the return value is a handle to the compatible bitmap (DDB).
    ///     If the function fails, the return value is NULL.
    /// </returns>
    [DllImport(dllName: "gdi32.dll")]
    public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

    /// <summary>
    ///     The SelectObject function selects an object into the specified device context (DC).
    ///     The new object replaces the previous object of the same type.
    /// </summary>
    /// <param name="hdc"></param>
    /// <param name="hgdiobj"></param>
    /// <returns>
    ///     If the selected object is not a region and the function succeeds, the return value is
    ///     a handle to the object being replaced. If the selected object is a region and the function
    ///     succeeds, the return value is one of the following values.
    ///     SIMPLEREGION - Region consists of a single rectangle.
    ///     COMPLEXREGION - Region consists of more than one rectangle.
    ///     NULLREGION - Region is empty.
    ///     If an error occurs and the selected object is not a region, the return value is NULL.
    ///     Otherwise, it is HGDI_ERROR.
    /// </returns>
    [DllImport(dllName: "gdi32.dll")]
    public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

    [DllImport(dllName: "gdi32.dll")]
    public static extern bool DeleteDC(IntPtr hdc);

    [DllImport(dllName: "gdi32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool DeleteObject(IntPtr hObject);
}
