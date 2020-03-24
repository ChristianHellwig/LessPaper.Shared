using LessPaper.Shared.Interfaces.General;
using System;

namespace LessPaper.Shared.Implemenations.General
{
    class Metadata : IMetadata
    {
        public string ObjectName { get;  }

        public string ObjectId { get;  }

        public uint SizeInBytes { get;  }


        public DateTime LatestChangeDate { get;  }

        public DateTime LatestViewDate { get;  }

        public Metadata(
            string objectId,
            string objectName,
            uint sizeInBytes,
            DateTime latestChangeDate,
            DateTime latestViewDate)
        {
            this.ObjectId = objectId;
            this.ObjectName = objectName;
            this.SizeInBytes = sizeInBytes;
            this.LatestChangeDate = latestChangeDate;
            this.LatestViewDate = latestViewDate;
        }
    }
} 