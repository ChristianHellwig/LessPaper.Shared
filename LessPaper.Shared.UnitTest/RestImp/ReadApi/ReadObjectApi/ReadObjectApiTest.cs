using Moq;
using RestSharp;
using Xunit;
using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Implemenations.General;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace LessPaper.Shared.Implemenations.ReadApi.UnitTests
{
    public class ReadObjectApiTests
    {

        [Fact]
        public void ReadObjectApiTest()
        {
            Assert.True(true);
        }

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
                            ObjectId = "1"
                        }
                    }
            );

            ReadObjectApi readObjectApi = new ReadObjectApi(restClient.Object);
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

            ReadObjectApi readObjectApi = new ReadObjectApi(restClient.Object);
            Stream objectResponse = await readObjectApi.GetObject("1", 2);

            Assert.True(objectStream.ToString().Equals(objectResponse.ToString()));
        }

        [Fact]
        public void SearchTest()
        {
            Assert.True(true);
        }
    }
}