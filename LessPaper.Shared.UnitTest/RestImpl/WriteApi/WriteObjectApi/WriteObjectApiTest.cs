using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LessPaper.Shared.Enums;
using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi;
using LessPaper.Shared.Interfaces.WriteApi;
using LessPaper.Shared.Interfaces.WriteApi.WriteObjectApi;
using Moq;
using RestSharp;
using LessPaper.Shared.RestImpl.General;
using LessPaper.Shared.RestImpl.WriteApi.WriteObjectApi;
using Xunit;
#pragma warning disable 618

namespace LessPaper.Shared.UnitTest.RestImpl.WriteApi.WriteObjectApi
{
    public class WriteObjectApiTest
    {
        [Fact]
        public async Task CreateDirectory()
        {
            var restClient = new Mock<IRestClient>();
            restClient.Setup(client => client.ExecutePostTaskAsync<DirectoryMetadata>(
                It.IsAny<IRestRequest>())
            ).ReturnsAsync(() => new RestResponse<DirectoryMetadata>
                {
                    StatusCode = HttpStatusCode.Accepted,
                    Data = new DirectoryMetadata
                    {
                        MinimalDirectoryMetadata = new MinimalDirectoryMetadata()
                        {
                            Metadata = new Metadata()
                            {
                                ObjectId = "1"
                            }
                        }
                    }
            });
            IWriteObjectApi writeObjectApi = 
                new Shared.RestImpl.WriteApi.WriteObjectApi.WriteObjectApi { RestClient = restClient.Object};
            IDirectoryMetadata directoryMetadata = await writeObjectApi.CreateDirectory("1", "2");

            Assert.Equal(directoryMetadata.ObjectId,"1");
        }

        [Fact]
        public async Task DeleteObject()
        {
            var restClient = new Mock<IRestClient>();
            restClient.Setup(client => 
                client.ExecuteTaskAsync<bool>(
                It.IsAny<IRestRequest>(),
                It.IsAny<Method>()
                )
            ).ReturnsAsync(() => new RestResponse<bool>
            {
                StatusCode = HttpStatusCode.Accepted,
                Data = true
            });

            IWriteObjectApi writeObjectApi =
                new Shared.RestImpl.WriteApi.WriteObjectApi.WriteObjectApi { RestClient = restClient.Object };
            bool requestSuccsess = await writeObjectApi.DeleteObject("1");
            Assert.True(requestSuccsess);
        }

        [Fact]
        public async Task UpdateMetadata()
        {
            var restClient = new Mock<IRestClient>();
            restClient.Setup(client =>
                client.ExecuteTaskAsync<bool>(
                    It.IsAny<IRestRequest>(),
                    It.IsAny<Method>()
                )
            ).ReturnsAsync(() => new RestResponse<bool>
            {
                StatusCode = HttpStatusCode.Accepted,
                Data = true
            });


            IWriteObjectApi writeObjectApi =
                new Shared.RestImpl.WriteApi.WriteObjectApi.WriteObjectApi { RestClient = restClient.Object };

            IMetadataUpdate metadataUpdate = new MetadataUpdate
            {
                ObjectName = "2"
            };

            bool requestSuccsess = await writeObjectApi.UpdateMetadata("1", metadataUpdate);
            Assert.True(requestSuccsess);
        }

        [Fact]
        public async Task UploadFile()
        {
            var restClient = new Mock<IRestClient>();
            restClient.Setup(client =>
                client.ExecutePostTaskAsync<UploadMetadata>(
                    It.IsAny<IRestRequest>()
                )
            ).ReturnsAsync(() => new RestResponse<UploadMetadata>
            {
                StatusCode = HttpStatusCode.Accepted,
                Data = new UploadMetadata
                {
                    Metadata = new Metadata
                    {
                        ObjectId = "1"
                    }
                }
            });


            IWriteObjectApi writeObjectApi =
                new Shared.RestImpl.WriteApi.WriteObjectApi.WriteObjectApi { RestClient = restClient.Object };
            byte[] objectBytes = { 255 };
            Stream objectStream = new MemoryStream(objectBytes);
            IUploadMetadata uploadMetadata = await writeObjectApi.UploadFile("1", objectStream, "plaintextKey",
                "encryptedKey",DocumentLanguage.German,"fileName",ExtensionType.Docx);

            Assert.Equal("1", uploadMetadata.ObjectId);
        }

    }
}
