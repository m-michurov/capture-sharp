using System;
using System.Drawing;
using System.Drawing.Imaging;
using Win32Api;

namespace CaptureSharp.Core;

public static class WindowCapture {
    public static Bitmap? Capture(IntPtr handle) {
        var success = NativeMethods.GetWindowRect(handle, out var rect);

        if (false == success) {
            return null;
        }

        var hdcSrc = NativeMethods.GetDCEx(
            handle,
            IntPtr.Zero,
            DeviceContextValues.Window | DeviceContextValues.Cache | DeviceContextValues.LockWindowUpdate
        );

        if (IntPtr.Zero == hdcSrc) {
            return null;
        }

        var hdcDest = NativeMethods.CreateCompatibleDC(hdcSrc);

        if (IntPtr.Zero == hdcDest) {
            return null;
        }

        var (width, height) = (rect.Right - rect.Left, rect.Bottom - rect.Top);
        var hBitmap = NativeMethods.CreateCompatibleBitmap(hdcSrc, width, height);

        if (IntPtr.Zero == hBitmap) {
            NativeMethods.DeleteDC(hdcDest);
            return null;
        }

        var hOld = NativeMethods.SelectObject(hdcDest, hBitmap);

        if (IntPtr.Zero == hOld) {
            NativeMethods.DeleteDC(hdcDest);
            NativeMethods.DeleteObject(hBitmap);
            return null;
        }

        success = NativeMethods.BitBlt(
            hdcDest,
            nXDest: 0,
            nYDest: 0,
            width,
            height,
            hdcSrc,
            nXSrc: 0,
            nYSrc: 0,
            RasterOperationCode.SRCCOPY
        );

        if (false == success) {
            NativeMethods.DeleteDC(hdcDest);
            NativeMethods.DeleteObject(hBitmap);
            return null;
        }

        NativeMethods.SelectObject(hdcDest, hOld);
        NativeMethods.DeleteDC(hdcDest);
        NativeMethods.ReleaseDC(handle, hdcSrc);

        using var bitmap = Image.FromHbitmap(hBitmap);
        NativeMethods.DeleteObject(hBitmap);

        var result = bitmap.Clone(
            Rectangle.FromLTRB(left: 0, top: 0, right: bitmap.Width, bottom: bitmap.Height),
            PixelFormat.Format32bppArgb
        );

        return result;
    }
}
