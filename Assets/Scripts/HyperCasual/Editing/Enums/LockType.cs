using System;

namespace HyperCasual.Editing.Enums
{
    /// <summary>
    /// Enumerates the different types of transform locks available.
    /// </summary>
    [Flags]
    public enum LockType
    {
        None = 0,
        Position = 1 << 0,
        Rotation = 1 << 1,
        Scale = 1 << 2,

        All = Position|Rotation|Scale
    }
}
