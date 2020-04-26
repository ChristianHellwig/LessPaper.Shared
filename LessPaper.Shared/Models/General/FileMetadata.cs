using System;
using LessPaper.Shared.Enums;
using LessPaper.Shared.Interfaces.General;

namespace LessPaper.Shared.Models.General
{

    class FileMetadata : IFileMetadata
    {
        internal IMetadata Metadata { get; set; }

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

        public string ObjectName => Metadata.ObjectName;

        public string ObjectId => Metadata.ObjectId;

        public uint SizeInBytes => Metadata.SizeInBytes;

        public DateTime LatestChangeDate => Metadata.LatestChangeDate;

        public DateTime LatestViewDate => Metadata.LatestViewDate;

        public DocumentLanguage Language { get; set; }
    }
}
