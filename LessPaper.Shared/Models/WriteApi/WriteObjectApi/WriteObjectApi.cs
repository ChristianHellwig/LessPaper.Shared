using System.IO;
using System.Threading.Tasks;
using LessPaper.Shared.Enums;
using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.WriteApi;
using LessPaper.Shared.Interfaces.WriteApi.WriteObjectApi;
using LessPaper.Shared.Models.General;
using RestSharp;

namespace LessPaper.Shared.Models.WriteApi.WriteObjectApi
{
    public class WriteObjectApi : IWriteObjectApi
    {
        public WriteObjectApi(IRestClient restClient)
        {
            RestClient = restClient;
            RestClient.FailOnDeserializationError = true;
            RestClient.ThrowOnDeserializationError = true;
            RestClient.ThrowOnAnyError = true;
        }
        private const string ObjectApiPath = "v1/objects";
        public IRestClient RestClient { get; set; }

        public async Task<IDirectoryMetadata> CreateDirectory(string userId, string directoryId, string subDirectoryName)
        {
            IRestRequest request = new RestRequest(ObjectApiPath + "/directories/{directory_id}")
                .AddDirectoryId(directoryId)
                .AddUserId(userId)
                .AddSubDirecotryName(subDirectoryName);

            return await RestClient.PostAsync<DirectoryMetadata>(request);
        }

        public async Task<bool> DeleteObject(string userId, string objectId, uint? revisionNr)
        {
            IRestRequest request = new RestRequest(ObjectApiPath + "/{objectId}")
                .AddUserId(userId)
                .AddObjectId(objectId).AddRevisionNr(revisionNr);

            return await RestClient.DeleteAsync<bool>(request);

        }

        public async Task<bool> UpdateMetadata(string userId, string objectId, IMetadataUpdate metadataUpdate)
        {
            IRestRequest request = new RestRequest(ObjectApiPath + "/{objectId}");
            request.AddParameter("objectId", objectId, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(metadataUpdate);
            return await RestClient.PatchAsync<bool>(request);
        }

        public async Task<IUploadMetadata> UploadFile(string userId, string objectId, Stream file, string plaintextKey,
            string encryptedKey, DocumentLanguage documentLanguage, string fileName, ExtensionType fileExtension)
        {

            IRestRequest request = new RestRequest(ObjectApiPath + "/files/{objectId}");
            request.AddParameter("objectId", objectId, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;

            // Add query parameters
            request.AddParameter("PlaintextKey", plaintextKey, ParameterType.GetOrPost);
            request.AddParameter("EncryptedKey", encryptedKey, ParameterType.GetOrPost);
            request.AddParameter("DocumentLanguage", documentLanguage, ParameterType.GetOrPost);
            request.AddParameter("FileExtension", fileExtension, ParameterType.GetOrPost);


            void FileAction(Stream stream) => stream.CopyToAsync(file);
            request.AddFile(fileName, FileAction , fileName, file.Length, null);
            return await RestClient.PostAsync<UploadMetadata>(request);
        }

    }
}
