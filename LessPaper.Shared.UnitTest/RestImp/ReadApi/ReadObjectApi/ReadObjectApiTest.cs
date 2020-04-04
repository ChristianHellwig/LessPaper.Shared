using Moq;
using RestSharp;
using Xunit;
using System;
using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Implemenations.General;
using Newtonsoft.Json;
using RestSharp.Serializers.Utf8Json;

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
        public async void GetMetadataTest()
        {
            IMetadata metadata = new Metadata {
                ObjectId = "1",
                ObjectName = "Name",
                SizeInBytes = 1,
                LatestChangeDate= new DateTime(2008, 5, 1, 8, 30, 52),
                LatestViewDate= new DateTime(2009, 5, 1, 8, 30, 52) };
            String test = new Utf8JsonSerializer().Serialize(metadata);
            


            IRestClient client = new RestSharp.RestClient(baseUrl);
            client.UseUtf8Json();

            ReadObjectApi readObjectApi = new ReadObjectApi(client);
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