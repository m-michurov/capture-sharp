using System;

// ReSharper disable InconsistentNaming

namespace Win32Api;

[Flags]
public enum GetAncestorFlags {
    /// <summary>
    ///     Retrieves the parent window. This does not include the owner, as it does with the GetParent function.
    /// </summary>
    GA_PARENT = 1,

    /// <summary>
    ///     Retrieves the root window by walking the chain of parent windows.
    /// </summary>
    GA_ROOT,

    /// <summary>
    ///     Retrieves the owned root window by walking the chain of parent and owner windows returned by GetParent.
    /// </summary>
    GA_ROOTOWNER
}
