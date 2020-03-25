using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi;

namespace LessPaper.Shared.Implemenations.ReadApi
{
    class SearchResponse : ISearchResponse
    {
        public SearchResponse(string searchQuery, IFileMetadata[] files, IMinimalDirectoryMetadata[] directories)
        {
            this.SearchQuery = searchQuery;
            this.Files = files;
            this.Directories = directories;
        }

        public string SearchQuery { get; }

        public IFileMetadata[] Files { get; }

        public IMinimalDirectoryMetadata[] Directories { get; }
    }
}
