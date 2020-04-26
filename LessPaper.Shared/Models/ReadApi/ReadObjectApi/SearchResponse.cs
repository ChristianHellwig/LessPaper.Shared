using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi;

namespace LessPaper.Shared.Models.ReadApi.ReadObjectApi
{
    public class SearchResponse : ISearchResponse
    {
        public string SearchQuery { get; set; }

        public IFileMetadata[] Files { get; set; }

        public IMinimalDirectoryMetadata[] Directories { get; set; }
    }
}
