using LessPaper.Shared.Interfaces.General;

namespace LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi
{
    public interface ISearchResponse
    {
        /// <summary>
        /// Search query
        /// </summary>
        string SearchQuery { get; }
        /// <summary>
        /// Found files
        /// </summary>
        IFileMetadata[] Files { get; }

        /// <summary>
        /// Found directories
        /// </summary>
        IMinimalDirectoryMetadata[] Directories { get; }
    }
}
