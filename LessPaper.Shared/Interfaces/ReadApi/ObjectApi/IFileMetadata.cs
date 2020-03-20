using System;
using LessPaper.Shared.Enums;

namespace LessPaper.Shared.Interfaces.ReadApi.ObjectApi
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
        /// Upload date
        /// </summary>
        DateTime UploadDate { get; }

        /// <summary>
        /// Encrypted file encryption key
        /// </summary>
        string EncryptionKey { get; }

        /// <summary>
        /// Current version of file
        /// </summary>
        uint RevisionNumber { get;  }

        /// <summary>
        /// File hash
        /// </summary>
        string Hash { get;  }

        /// <summary>
        /// Thumbnail id
        /// </summary>
        string ThumbnailId { get;  }

        /// <summary>
        /// Revision numbers of files with the same object id
        /// </summary>
        uint[] Revisions { get; }

        /// <summary>
        /// List of directories containing the current file
        /// </summary>
        string[] ParentDirectoryIds { get; }

        /// <summary>
        /// List of tags linked to the current file
        /// </summary>
        ITag[] Tags { get;  }
    }
}
