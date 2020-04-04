using LessPaper.Shared.Interfaces.General;
using System;

namespace LessPaper.Shared.Implemenations.WriteApi
{
    class MinimalDirectoryMetadata: IMinimalDirectoryMetadata
    {
        readonly IMetadata _iMetadata;

        public MinimalDirectoryMetadata(IMetadata iMetadata, uint NumberOfChilds)
        {
            _iMetadata = iMetadata;
            this.NumberOfChilds = NumberOfChilds;
        }

        public uint NumberOfChilds { get; }

        public string ObjectName => _iMetadata.ObjectName;

        public string ObjectId => _iMetadata.ObjectId;

        public uint SizeInBytes => _iMetadata.SizeInBytes;

        public DateTime LatestChangeDate => _iMetadata.LatestChangeDate;

        public DateTime LatestViewDate => _iMetadata.LatestViewDate;
    }
}
