using System;
using System.Runtime.InteropServices;

// ReSharper disable IdentifierTypo

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming

namespace Win32Api;

[StructLayout(LayoutKind.Sequential)]
public struct TITLEBARINFO {
    public const int CCHILDREN_TITLEBAR = 5;

    public int cbSize;
    public RECT rcTitleBar;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = CCHILDREN_TITLEBAR + 1)]
    public uint[] rgstate;
}

public static class TitleBarElement {
    public const int
        TitleBar = 0,
        MinimizeButton = 2,
        MaximizeButton = 3,
        HelpButton = 4,
        CloseButton = 5;
}

[Flags]
public enum RGState {
    /// <summary>
    ///     The element can accept the focus.
    /// </summary>
    STATE_SYSTEM_FOCUSABLE = 0x00100000,

    /// <summary>
    ///     The element is invisible.
    /// </summary>
    STATE_SYSTEM_INVISIBLE = 0x00008000,

    /// <summary>
    ///     The element has no visible representation.
    /// </summary>
    STATE_SYSTEM_OFFSCREEN = 0x00010000,

    /// <summary>
    ///     The element is unavailable.
    /// </summary>
    STATE_SYSTEM_UNAVAILABLE = 0x00000001,

    /// <summary>
    ///     The element is in the pressed state.
    /// </summary>
    STATE_SYSTEM_PRESSED = 0x00000008
}
