using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LessPaper.Shared.Enums;
using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.GuardApi.Response;

namespace LessPaper.Shared.Interfaces.Database.Manager
{
    public interface IDbFileManager
    {
        /// <summary>
        /// Delete a file entry
        /// </summary>
        /// <param name="requestingUserId">Id of the requesting user</param>
        /// <param name="fileId">Id of the file</param>
        /// <returns></returns>
        Task<bool> DeleteFile(string requestingUserId, string fileId);

        /// <summary>
        /// Retrieve permissions of a user on one or more files
        /// </summary>
        /// <param name="requestingUserId">Id of the requesting user</param>
        /// <param name="userId">Id of the user</param>
        /// <param name="objectIds">Object ids</param>
        /// <returns></returns>
        Task<IPermissionResponse> GetFilePermissions(string requestingUserId, string userId, string[] objectIds);

        /// <summary>
        /// Add a new file entry into a directory
        /// </summary>
        /// <param name="requestingUserId">Id of the requesting user</param>
        /// <param name="directoryId">Id of the directory</param>
        /// <param name="fileId">New id of the file</param>
        /// <param name="fileSize">File size in bytes</param>
        /// <param name="encryptedKey">Encrypted key</param>
        /// <param name="documentLanguage">Document language</param>
        /// <param name="fileExtension">File extension</param>
        /// <returns></returns>
        Task<int> InsertFile(
            string requestingUserId,
            string directoryId,
            string fileId,
            int fileSize,
            string encryptedKey,
            DocumentLanguage documentLanguage,
            ExtensionType fileExtension);
        

        /// <summary>
        /// Retrieve metadata of an object
        /// </summary>
        /// <param name="requestingUserId">Id of the requesting user</param>
        /// <param name="objectId">Directory or file id</param>
        /// <param name="revisionNumber">Version number. Newest file when not set</param>
        /// <returns>Returns metadata of directory or file</returns>
        /// <exception cref="InvalidOperationException">Throws if service not available</exception>
        /// <exception cref="FileNotFoundException"></exception>
        Task<IFileMetadata> GetFileMetadata(string requestingUserId, string objectId, uint? revisionNumber);
    }
}
