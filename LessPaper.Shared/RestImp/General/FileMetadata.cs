using LessPaper.Shared.Enums;
using LessPaper.Shared.Interfaces.General;
using System;

namespace LessPaper.Shared.Implemenations.General
{

    class FileMetadata : IFileMetadata
    {
        internal IMetadata _metadata;

        public FileMetadata(IMetadata metadata)
        {
            _metadata = metadata;

        }

        public uint QuickNumber { get; }

        public ExtensionType Extension { get; }

        public DateTime UploadDate { get; }

        public string EncryptionKey { get; }

        public uint RevisionNumber { get; }

        public string Hash { get; }

         public string ThumbnailId { get; }

        public uint[] Revisions { get; }

        public string[] ParentDirectoryIds { get; }

        public ITag[] Tags { get; }

        public string ObjectName => _metadata.ObjectName;

        public string ObjectId => _metadata.ObjectId;

        public uint SizeInBytes => _metadata.SizeInBytes;

        public DateTime LatestChangeDate => _metadata.LatestChangeDate;

        public DateTime LatestViewDate => _metadata.LatestViewDate;

        public DocumentLanguage Language { get; }
    }
}
