namespace Win32Api;

// ReSharper disable IdentifierTypo

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
public enum ExtendedWindowStyles : long {
    /// <summary>
    ///     The window is intended to be used as a floating toolbar.
    ///     A tool window has a title bar that is shorter than a normal title bar, and
    ///     the window title is drawn using a smaller font. A tool window does not appear
    ///     in the taskbar or in the dialog that appears when the user presses ALT+TAB.
    ///     If a tool window has a system menu, its icon is not displayed on the title bar.
    ///     However, you can display the system menu by right-clicking or by typing ALT+SPACE.
    /// </summary>
    WS_EX_TOOLWINDOW = 0x00000080L
}
