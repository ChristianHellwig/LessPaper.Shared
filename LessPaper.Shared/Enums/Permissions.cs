using System;
using System.Collections.Generic;
using System.Text;

namespace LessPaper.Shared.Enums
{
    [Flags]
    public enum Permissions
    {
        ReadDirectory,
        WriteDirectory,
        ReadFile,
        WriteFile
    }
}
