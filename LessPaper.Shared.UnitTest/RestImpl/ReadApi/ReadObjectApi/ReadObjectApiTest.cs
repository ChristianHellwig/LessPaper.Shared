using System.IO;
using System.Net;
using System.Threading.Tasks;
using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi;
using LessPaper.Shared.Models.General;
using LessPaper.Shared.Models.ReadApi.ReadObjectApi;
using Moq;
using RestSharp;
using Xunit;

#pragma warning disable 618

namespace LessPaper.Shared.UnitTest.RestImpl.ReadApi.ReadObjectApi
{
    public class ReadObjectApiTests
    {
        [Fact]
        public async Task GetMetadataTest()
        {

            string objectID = "1";
            uint revisionNumber = 2;

            var restClient = new Mock<IRestClient>();
            restClient.Setup(client => client.ExecuteTaskAsync<Metadata>(
                    It.IsAny<IRestRequest>(),
                    It.IsAny<Method>())
                )
                .ReturnsAsync(
                () => new RestResponse<Metadata>
                    {
                        StatusCode = HttpStatusCode.Accepted,
                        Data = new Metadata
                        {
                            ObjectId = objectID
                        }
                    }
            );

            Models.ReadApi.ReadObjectApi.ReadObjectApi readObjectApi = new Models.ReadApi.ReadObjectApi.ReadObjectApi {RestClient = restClient.Object};
            IMetadata metadataResponse = await readObjectApi.GetMetadata("1", objectID, revisionNumber);

            Assert.Equal(objectID, metadataResponse.ObjectId);
        }

        [Fact]
        public async Task GetObjectTest()
        {
            byte[] objectBytes = { 255 };
            Stream objectStream = new MemoryStream(objectBytes);

            var restClient = new Mock<IRestClient>();
            restClient.Setup(client => client.DownloadData(
                It.IsAny<IRestRequest>())
            ).Returns(objectBytes);

            Models.ReadApi.ReadObjectApi.ReadObjectApi readObjectApi = new Models.ReadApi.ReadObjectApi.ReadObjectApi { RestClient = restClient.Object };
            Stream objectResponse = new MemoryStream(); 

            var noError = await readObjectApi.GetObject("1", objectResponse,"1", 2);

            Assert.True(noError);
            Assert.True(objectStream.ToString().Equals(objectResponse.ToString()));
        }

        [Fact]
        public async Task SearchTest()
        {

            string directoryId = "directoryId";
            string searchQuery = "searchQuery";
            uint count = 1;
            uint page = 2;

            var restClient = new Mock<IRestClient>();
            restClient.Setup(client => client.ExecuteGetTaskAsync<SearchResponse>(
                    It.IsAny<IRestRequest>())
                )
                .ReturnsAsync(
                    () => new RestResponse<SearchResponse>
                    {
                        StatusCode = HttpStatusCode.Accepted,
                        Data = new SearchResponse
                        {
                            SearchQuery = searchQuery
                        }
                    });

            Models.ReadApi.ReadObjectApi.ReadObjectApi readObjectApi = new Models.ReadApi.ReadObjectApi.ReadObjectApi { RestClient = restClient.Object };
            var metadataResponse = await readObjectApi.Search("1", directoryId, searchQuery, count, page);

            Assert.Equal(searchQuery, metadataResponse.SearchQuery);
        }
    }
}