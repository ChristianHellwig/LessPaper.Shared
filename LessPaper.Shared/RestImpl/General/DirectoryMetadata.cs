using System;
using LessPaper.Shared.Interfaces.General;

namespace LessPaper.Shared.RestImpl.General
{
    public class DirectoryMetadata : IDirectoryMetadata
    {

        public IMinimalDirectoryMetadata MinimalDirectoryMetadata { get; set; }

        public IFileMetadata[] FileChilds { get; set; }

        public IMinimalDirectoryMetadata[] DirectoryChilds { get; set; }

        public uint NumberOfChilds => MinimalDirectoryMetadata.NumberOfChilds;

        public string ObjectName => MinimalDirectoryMetadata.ObjectName;

        public string ObjectId => MinimalDirectoryMetadata.ObjectId;

        public uint SizeInBytes => MinimalDirectoryMetadata.SizeInBytes;

        public DateTime LatestChangeDate => MinimalDirectoryMetadata.LatestChangeDate;

        public DateTime LatestViewDate => MinimalDirectoryMetadata.LatestViewDate;
    }
}
