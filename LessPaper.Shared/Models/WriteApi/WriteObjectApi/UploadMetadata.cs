using System;
using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.WriteApi.WriteObjectApi;

namespace LessPaper.Shared.Models.WriteApi.WriteObjectApi
{
    public class UploadMetadata : IUploadMetadata
    {
        public IMetadata Metadata { get; set; }

        public uint QuickNumber { get; set; }

        public string ObjectName => Metadata.ObjectName;

        public string ObjectId => Metadata.ObjectId;

        public uint SizeInBytes => Metadata.SizeInBytes;

        public DateTime LatestChangeDate => Metadata.LatestChangeDate;

        public DateTime LatestViewDate => Metadata.LatestViewDate;
    }
}
