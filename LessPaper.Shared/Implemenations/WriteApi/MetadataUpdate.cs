using LessPaper.Shared.Interfaces.WriteApi.WriteObjectApi;

namespace LessPaper.Shared.Implemenations.WriteApi
{
    class MetadataUpdate : IMetadataUpdate
    {
        public string ObjectName { get; set; }

        public string[] ParentDirectoryIds { get; set; }
    }
}
