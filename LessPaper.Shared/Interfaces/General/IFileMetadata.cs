using System;
using System.Collections.Generic;
using LessPaper.Shared.Enums;

namespace LessPaper.Shared.Interfaces.General
{
    public interface IFileMetadata : IMetadata
    {
        /// <summary>
        /// Unique id set on uploading file
        /// </summary>
        uint QuickNumber { get; }

        /// <summary>
        /// File extension
        /// </summary>
        ExtensionType Extension { get; }
        
        /// <summary>
        /// Thumbnail id
        /// </summary>
        string ThumbnailId { get;  }

        /// <summary>
        /// Revision numbers of files with the same object id
        /// </summary>
        IFileRevision[] Revisions { get; }

        /// <summary>
        /// List of directories containing the current file
        /// </summary>
        string[] ParentDirectoryIds { get; }

        /// <summary>
        /// List of tags linked to the current file
        /// </summary>
        ITag[] Tags { get;  }

        /// <summary>
        /// Language of the document
        /// </summary>
        DocumentLanguage Language { get;  }
        
        /// <summary>
        /// Permissions
        /// 
        /// Key: UserId
        /// Value: File Permissions (Flags)
        /// </summary>
        Dictionary<string, IFilePermission> Permissions { get; }
    }
}
