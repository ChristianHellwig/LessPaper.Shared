using System;
using System.Collections.Generic;
using System.Text;
using LessPaper.Shared.Enums;

namespace LessPaper.Shared.Interfaces.General
{
    public interface IFilePermission
    {
        /// <summary>
        /// Encrypted Key
        /// </summary>
        string EncryptedKey { get; set; }

        /// <summary>
        /// Permission
        /// </summary>
        Permission Permission { get; set; }
    }
}
