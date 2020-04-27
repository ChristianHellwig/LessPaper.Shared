using System.IO;
using System.Net;
using System.Threading.Tasks;
using LessPaper.Shared.Enums;
using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.WriteApi.WriteObjectApi;
using LessPaper.Shared.Models.General;
using LessPaper.Shared.Models.WriteApi.WriteObjectApi;
using Moq;
using RestSharp;
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
                            ObjectId = "1"
                    }
            });
            var writeObjectApi = 
                new Models.WriteApi.WriteObjectApi.WriteObjectApi(restClient.Object);
            var directoryMetadata = await writeObjectApi.CreateDirectory("1", "1", "2");

            Assert.Equal("1", directoryMetadata.ObjectId);
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
                new Models.WriteApi.WriteObjectApi.WriteObjectApi(restClient.Object);
            var requestSuccsess = await writeObjectApi.DeleteObject("1", "1", 1);
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
                new Models.WriteApi.WriteObjectApi.WriteObjectApi( restClient.Object );

            IMetadataUpdate metadataUpdate = new MetadataUpdate
            {
                ObjectName = "2"
            };

            bool requestSuccsess = await writeObjectApi.UpdateMetadata("1", "1", metadataUpdate);
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
                    ObjectId = "1"
                }
            });


            IWriteObjectApi writeObjectApi =
                new Models.WriteApi.WriteObjectApi.WriteObjectApi (restClient.Object );
            byte[] objectBytes = { 255 };
            Stream objectStream = new MemoryStream(objectBytes);
            var uploadMetadata = await writeObjectApi.UploadFile("1","1",
                objectStream, "plaintextKey",
                "encryptedKey",DocumentLanguage.German,"fileName",ExtensionType.Docx);

            Assert.Equal("1", uploadMetadata.ObjectId);
        }

    }
}
