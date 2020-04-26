using System;
using LessPaper.Shared.Interfaces.General;

namespace LessPaper.Shared.Models.General
{
    public class MinimalDirectoryMetadata: IMinimalDirectoryMetadata
    {
        public IMetadata Metadata { get; set; }

        public uint NumberOfChilds { get; set; }

        public string ObjectName => Metadata.ObjectName;

        public string ObjectId => Metadata.ObjectId;

        public uint SizeInBytes => Metadata.SizeInBytes;

        public DateTime LatestChangeDate => Metadata.LatestChangeDate;

        public DateTime LatestViewDate => Metadata.LatestViewDate;
    }
}
