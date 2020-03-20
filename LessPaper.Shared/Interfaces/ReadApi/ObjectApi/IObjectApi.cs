using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace LessPaper.Shared.Interfaces.ReadApi.ObjectApi
{
    public interface IObjectApi
    {
        /// <summary>
        /// Download file or directory
        /// </summary>
        /// <param name="objectId">Id of file or directory</param>
        /// <param name="revisionNumber">Version number. Newest file when not set</param>
        /// <returns>Binary file</returns>
        /// <exception cref="InvalidOperationException">Throws if service not available</exception>
        /// <exception cref="FileNotFoundException"></exception>
        Task<byte[]> GetObject(string objectId, uint? revisionNumber);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectId">Directory or file id</param>
        /// <param name="revisionNumber">Version number. Newest file when not set</param>
        /// <returns>Returns metadata of directory or file</returns>
        /// <exception cref="InvalidOperationException">Throws if service not available</exception>
        /// <exception cref="FileNotFoundException"></exception>
        Task<IMetadata> GetMetadata(string objectId, uint? revisionNumber);

        /// <summary>
        /// Search for files and directories
        /// </summary>
        /// <param name="directoryId">Search root directory</param>
        /// <param name="searchQuery">Search query</param>
        /// <param name="count">Limit of results</param>
        /// <param name="page">Result page</param>
        /// <returns>List of files and directories</returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<ISearchResponse> Search(string directoryId, string searchQuery, uint count, uint page);
    }
}
