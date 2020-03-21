using System;
using System.Collections.Generic;
using System.Text;
using LessPaper.Shared.Interfaces.General;

namespace LessPaper.Shared.Interfaces.ReadApi.ObjectApi
{
    public interface ISearchResponse
    {
        /// <summary>
        /// Search query
        /// </summary>
        string SearchQuery { get; }
        /// <summary>
        /// Found files
        /// </summary>
        IFileMetadata[] Files { get; }

        /// <summary>
        /// Found directories
        /// </summary>
        IMinimalDirectoryMetadata[] Directories { get; }
    }
}
