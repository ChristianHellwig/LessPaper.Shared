using Moq;
using RestSharp;
using Xunit;
using System;
using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Implemenations.General;
using RestSharp.Serializers.Utf8Json;
using System.Threading.Tasks;
using System.Net.Http;
using Moq.Protected;
using System.Threading;
using System.Net;
using System.Collections.Generic;

namespace LessPaper.Shared.Implemenations.ReadApi.UnitTests
{
    public class ReadObjectApiTests
    {
        public readonly string baseUrl = "https://d059abfe-68b3-4e09-afbf-48b6e1b70ef5.mock.pstmn.io";

        [Fact]
        public void ReadObjectApiTest()
        {
            Assert.True(true);
        }

        [Fact]
        public async Task GetMetadataTest()
        {

            Metadata metadata = new Metadata
            {
                ObjectId = "1",
                ObjectName = "Name",
                SizeInBytes = 1,
                LatestChangeDate = new DateTime(2008, 5, 1, 8, 30, 52),
                LatestViewDate = new DateTime(2009, 5, 1, 8, 30, 52)
            };

            String metadataJson = new Utf8JsonSerializer().Serialize(metadata);

            //Task<IMetadata> metadataTask = new Task<IMetadata>(metadata);
            var restClient = new Mock<IRestClient>();
            //restClient.SetupSet(x => x.BaseUrl = "https://api.careerbuilder.com/v1/categories");

            restClient.Setup(x => x.ExecuteAsync<Metadata>(
                It.IsAny<IRestRequest>(), 
                It.IsAny<Action<IRestResponse<Metadata>, RestRequestAsyncHandle>>(),
                It.IsAny<Method>()
                )).Callback<IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>>((request, callback) =>
                {
                    callback(new RestResponse { StatusCode = HttpStatusCode.OK, Content = metadataJson}, null);
                });



            //IRestClient client = new RestSharp.RestClient(baseUrl);
            //client.UseUtf8Json();

            ReadObjectApi readObjectApi = new ReadObjectApi(restClient.Object);
            IMetadata metadataResponse = await readObjectApi.GetMetadata("1",1);

            Assert.Equal("1", metadataResponse.ObjectId);
        }

        [Fact]
        public void GetObjectTest()
        {
            Assert.True(true);
        }

        [Fact]
        public void SearchTest()
        {
            Assert.True(true);
        }
    }
}