using System;
using System.Collections.Generic;
using System.Text;

namespace LessPaper.Shared.Enums
{
    [Flags]
    public enum Permission
    {
        Read = 1,
        Write = 2,

        ReadPermissions = 4,
        WritePermissions = 8,
    }
}
