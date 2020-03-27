using LessPaper.Shared.Enums;
using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.WriteApi.WriteObjectApi;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LessPaper.Shared.Implemenations.WriteApi
{
    class WriteObjectApi : IWriteObjectApi
    {

        public Task<IDirectoryMetadata> CreateDirectory(string directoryId, string subDirectoryName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteObject(string objectId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMetadata(string objectId, IMetadataUpdate metadataUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<IUploadMetadata> UploadFile(string directoryId, Stream file, string plaintextKey, string encryptedKey, DocumentLanguage documentLanguage, ExtensionType fileExtension)
        {
            throw new NotImplementedException();
        }
    }
}
