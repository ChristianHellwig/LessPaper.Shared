using LessPaper.Shared.Interfaces.General;
using System;

namespace LessPaper.Shared.Implemenations.General
{
    class DirectoryMetadata : IDirectoryMetadata
    {

        internal IMinimalDirectoryMetadata _minimalDirectoryMetadata;
        public DirectoryMetadata(IMinimalDirectoryMetadata minimalDirectoryMetadata, IMinimalDirectoryMetadata[] DirectoryChilds, IFileMetadata[] FileChilds)
        {
            this._minimalDirectoryMetadata = minimalDirectoryMetadata;
            this.DirectoryChilds = DirectoryChilds;
            this.FileChilds = FileChilds;
        }

        public IFileMetadata[] FileChilds { get; }

        public IMinimalDirectoryMetadata[] DirectoryChilds { get; }

        public uint NumberOfChilds => _minimalDirectoryMetadata.NumberOfChilds;

        public string ObjectName => _minimalDirectoryMetadata.ObjectName;

        public string ObjectId => _minimalDirectoryMetadata.ObjectId;

        public uint SizeInBytes => _minimalDirectoryMetadata.SizeInBytes;

        public DateTime LatestChangeDate => _minimalDirectoryMetadata.LatestChangeDate;

        public DateTime LatestViewDate => _minimalDirectoryMetadata.LatestViewDate;
    }
}
