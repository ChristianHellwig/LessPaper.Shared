using System;
using System.IO;
using System.Threading.Tasks;
using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.ReadApi.ObjectApi;

namespace LessPaper.Shared.Interfaces.WriteApi.ObjectApi
{
    public interface IFileApi
    {
        /// <summary>
        /// Upload new file
        /// </summary>
        /// <param name="file">File</param>
        /// <param name="plaintextKey">Plaintext key used for encrypting the key</param>
        /// <param name="encryptedKey">Encrypted key used for saving in database</param>
        /// <param name="documentLanguage">Language of the file or all files in the directory</param>
        /// <returns>Upload Metadata</returns>
        /// <exception cref="InvalidOperationException">Throws if service not available</exception>
        Task<IUploadMetadata> UploadFile(Stream file, string plaintextKey,
            string encryptedKey, string documentLanguage);

        /// <summary>
        /// Add File as new Version
        /// </summary>
        /// <param name="directoryId"></param>
        /// <param name="file"></param>
        /// <param name="plaintextKey"></param>
        /// <param name="encryptedKey"></param>
        /// <param name="documentLanguage"></param>
        /// <returns>Upload Metadata</returns>
        /// <exception cref="InvalidOperationException">Throws if service not available</exception>
        Task<IUploadMetadata> UploadFile(string directoryId, Stream file, string plaintextKey,
            string encryptedKey, string documentLanguage);

        /// <summary>
        /// Create Directory
        /// </summary>
        /// <param name="directoryId">Id of parent direcory</param>
        /// <param name="subDirectoryName">Name of new Directory</param>
        /// <returns>Directory Metadata</returns>
        /// <exception cref="InvalidOperationException">Throws if service not available</exception>
        Task<IDirectoryMetadata> CreateDirectory(string directoryId, string subDirectoryName);

        /// <summary>
        /// Update Metadata of file or directory 
        /// </summary>
        /// <param name="objectId">Object ID</param>
        /// <param name="metadataUpdate"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Throws if service not available</exception>
        Task<bool> UpdateMetadata(string objectId, IMetadataUpdate metadataUpdate);

        /// <summary>
        /// Flags Object as deleted
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns>Return true when file is deleted</returns>
        /// <exception cref="InvalidOperationException">Throws if service not available</exception>
        Task<bool> DeleteObject(string objectId);
    }
}
