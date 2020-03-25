using LessPaper.Shared.Interfaces.WriteApi.WriteObjectApi;

namespace LessPaper.Shared.Implemenations.WriteApi
{
    class MetadataUpdate : IMetadataUpdate
    {
        public MetadataUpdate(string objectName, string[] parentDirectoryIds)
        {
            this.ObjectName = objectName;
            this.ParentDirectoryIds = parentDirectoryIds;
        }

        public string ObjectName { get;  }

        public string[] ParentDirectoryIds { get;  }
    }
}
