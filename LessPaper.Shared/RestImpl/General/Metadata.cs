using System;
using LessPaper.Shared.Interfaces.General;

namespace LessPaper.Shared.RestImpl.General
{
    public class Metadata : IMetadata
    {
        public string ObjectName { get; set; }

        public string ObjectId { get; set; }

        public uint SizeInBytes { get; set; }

        public DateTime LatestChangeDate { get; set; }

        public DateTime LatestViewDate { get; set; }

    }
} 