using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.WriteApi.WriteObjectApi;
using System;

namespace LessPaper.Shared.Implemenations.WriteApi
{
    class UploadMetadata : IUploadMetadata
    {
        private readonly IMetadata _metadata;

        public UploadMetadata(
            IMetadata metadata, 
            uint quickNumber)
        {
            _metadata = metadata;
            this.QuickNumber = quickNumber;
        }

        public uint QuickNumber { get; }

        public string ObjectName => _metadata.ObjectName;

        public string ObjectId => _metadata.ObjectId;

        public uint SizeInBytes => _metadata.SizeInBytes;

        public DateTime LatestChangeDate => _metadata.LatestChangeDate;

        public DateTime LatestViewDate => _metadata.LatestViewDate;
    }
}
