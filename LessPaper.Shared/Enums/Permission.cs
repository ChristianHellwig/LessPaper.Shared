using System;
using System.Collections.Generic;
using System.Text;

namespace LessPaper.Shared.Enums
{
    [Flags]
    public enum Permission
    {
        ReadDirectory = 1,
        WriteDirectory = 2,
        ReadFile = 4,
        WriteFile = 8,
    }
}
