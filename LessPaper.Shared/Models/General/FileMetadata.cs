using System;
using System.Collections.Generic;
using LessPaper.Shared.Enums;
using LessPaper.Shared.Interfaces.General;

namespace LessPaper.Shared.Models.General
{

    class FileMetadata : Metadata, IFileMetadata
    {
        public uint QuickNumber { get; set; }

        public ExtensionType Extension { get; set; }

        public DateTime UploadDate { get; set; }

        public string EncryptionKey { get; set; }

        public uint RevisionNumber { get; set; }

        public string Hash { get; set; }

         public string ThumbnailId { get; set; }

        public uint[] Revisions { get; set; }

        public string[] ParentDirectoryIds { get; set; }

        public ITag[] Tags { get; set; }

        public DocumentLanguage Language { get; set; }
    }
}
