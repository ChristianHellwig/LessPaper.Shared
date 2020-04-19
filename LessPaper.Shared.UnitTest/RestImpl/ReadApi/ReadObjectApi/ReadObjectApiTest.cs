using System.IO;
using System.Net;
using System.Threading.Tasks;
using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi;
using LessPaper.Shared.RestImpl.General;
using LessPaper.Shared.RestImpl.ReadApi.ReadObjectApi;
using Moq;
using RestSharp;
using Xunit;

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

            Shared.RestImpl.ReadApi.ReadObjectApi.ReadObjectApi readObjectApi = new Shared.RestImpl.ReadApi.ReadObjectApi.ReadObjectApi {RestClient = restClient.Object};
            IMetadata metadataResponse = await readObjectApi.GetMetadata(objectID, revisionNumber);

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

            Shared.RestImpl.ReadApi.ReadObjectApi.ReadObjectApi readObjectApi = new Shared.RestImpl.ReadApi.ReadObjectApi.ReadObjectApi { RestClient = restClient.Object };
            Stream objectResponse = new MemoryStream(); 

            bool noError = await readObjectApi.GetObject(objectResponse,"1", 2);

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

            Shared.RestImpl.ReadApi.ReadObjectApi.ReadObjectApi readObjectApi = new Shared.RestImpl.ReadApi.ReadObjectApi.ReadObjectApi { RestClient = restClient.Object };
            ISearchResponse metadataResponse = await readObjectApi.Search(directoryId, searchQuery, count, page);

            Assert.Equal(searchQuery, metadataResponse.SearchQuery);
        }
    }
}