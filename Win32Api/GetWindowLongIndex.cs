﻿namespace Win32Api;

// ReSharper disable IdentifierTypo

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable InconsistentNaming
public enum GetWindowLongIndex {
    /// <summary>
    ///     Retrieves the extended window styles.
    /// </summary>
    GWL_EXSTYLE = -20,

    /// <summary>
    ///     Retrieves a handle to the application instance.
    /// </summary>
    GWL_HINSTANCE = -6,

    /// <summary>
    ///     Retrieves a handle to the parent window, if any.
    /// </summary>
    GWL_HWNDPARENT = -8,

    /// <summary>
    ///     Retrieves the identifier of the window.
    /// </summary>
    GWL_ID = -12,

    /// <summary>
    ///     Retrieves the window styles.
    /// </summary>
    GWL_STYLE = -16,

    /// <summary>
    ///     Retrieves the user data associated with the window.
    ///     This data is intended for use by the application that created the window. Its value is initially zero.
    /// </summary>
    GWL_USERDATA = -21,

    /// <summary>
    ///     Retrieves the address of the window procedure, or a handle representing
    ///     the address of the window procedure. You must use the CallWindowProc function
    ///     to call the window procedure.
    /// </summary>
    GWL_WNDPROC = -4
}
