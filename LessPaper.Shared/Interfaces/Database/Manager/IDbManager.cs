using System;
using System.Collections.Generic;
using System.Text;

namespace LessPaper.Shared.Interfaces.Database.Manager
{
    public interface IDbManager
    {
        /// <summary>
        /// Access to file related tasks
        /// </summary>
        IDbFileManager DbFileManager { get;  }

        /// <summary>
        /// Access to directory related tasks
        /// </summary>
        IDbDirectoryManager DbDirectoryManager { get; }

        /// <summary>
        /// Access to user related tasks
        /// </summary>
        IDbUserManager DbUserManager { get; }

        /// <summary>
        /// Access to search related tasks
        /// </summary>
        IDbSearchManager DbSearchManager { get;  }
    }
}
