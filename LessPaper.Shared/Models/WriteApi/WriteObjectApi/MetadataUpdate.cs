using LessPaper.Shared.Interfaces.WriteApi.WriteObjectApi;

namespace LessPaper.Shared.Models.WriteApi.WriteObjectApi
{
    public class MetadataUpdate : IMetadataUpdate
    {

        public string ObjectName { get; set; }

        public string[] ParentDirectoryIds { get; set; }
    }
}
