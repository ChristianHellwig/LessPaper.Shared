using System;
using System.Threading.Tasks;
using LessPaper.Shared.Enums;
using LessPaper.Shared.Interfaces.GuardApi;
using LessPaper.Shared.Interfaces.GuardApi.Response;
using LessPaper.Shared.Interfaces.WriteApi.WriteObjectApi;
using RestSharp;

namespace LessPaper.Shared.Models.GuardApi
{
    class GuardApi : IGuardApi
    {
        private const string ObjectApiPath = "/v1";
        public IRestClient RestClient { get; set; }
        public async Task<bool> AddDirectory(string parentDirectoryId, string directoryName, string newDirectoryId)
        {
            // Request with to source
            IRestRequest request = new RestRequest(ObjectApiPath + "/directories/{parentDirectoryId}");
            request.AddParameter("parentDirectoryId", parentDirectoryId, ParameterType.UrlSegment);

            // Add query parameters
            request.AddParameter("directoryName", directoryName, ParameterType.GetOrPost);
            request.AddParameter("newDirectoryId", newDirectoryId, ParameterType.GetOrPost);

            return await RestClient.PostAsync<bool>(request);
        }

        public async Task<int> AddFile(string directoryId, string fileId, int fileSize, string encryptedKey,
            DocumentLanguage documentLanguage, ExtensionType fileExtension)
        {
            // Request with to source
            IRestRequest request = new RestRequest(ObjectApiPath + "/files/{directoryId}");
            request.AddParameter("directoryId", directoryId, ParameterType.UrlSegment);

            // Add query parameters
            request.AddParameter("fileId", fileId, ParameterType.GetOrPost);
            request.AddParameter("fileSize", fileSize, ParameterType.GetOrPost);
            request.AddParameter("encryptedKey", encryptedKey, ParameterType.GetOrPost);
            request.AddParameter("documentLanguage", documentLanguage, ParameterType.GetOrPost);
            request.AddParameter("fileExtension", fileExtension, ParameterType.GetOrPost);

            return await RestClient.PostAsync<int>(request);
        }

        public async Task<bool> DeleteObject(string objectId)
        {
            // Request with to source
            IRestRequest request = new RestRequest(ObjectApiPath + "/objects/{objectId}");
            request.AddParameter("objectId", objectId, ParameterType.UrlSegment);
            return await RestClient.DeleteAsync<bool>(request);
        }

        public Task<IPermissionResponse> GetObjectsPermissions(string userId, string[] objectIds)
        {
            throw new NotImplementedException();
        }

        public Task<ICredentialsResponse> GetUserCredentials(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterNewUser(string email, string passwordHash, string salt, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateObjectMetadata(string objectId, IMetadataUpdate updatedMetadata)
        {
            throw new NotImplementedException();
        }
    }
}
