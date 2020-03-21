using System;
using System.Collections.Generic;
using System.Text;

namespace LessPaper.Shared.Interfaces.WriteApi.FileApi
{
    public interface IMetadataUpdate
    {
        /// <summary>
        /// Object Name
        /// </summary>
        string ObjectName { get; }
        /// <summary>
        /// List of parent directories
        /// </summary>
        string[] ParentDirectoryIds { get; }
    }
}
