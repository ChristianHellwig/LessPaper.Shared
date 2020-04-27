using System;
using LessPaper.Shared.Enums;
using LessPaper.Shared.Helper;
using LessPaper.Shared.Interfaces.WriteApi;
using LessPaper.Shared.Models.WriteApi;
using Xunit;

namespace LessPaper.Shared.IntegrationTest
{
    public class WriteObjectApiTest
    {
        private readonly IWriteApi writeApi;

        public WriteObjectApiTest()
        {
            writeApi = new WriteApi(new WriteApiSettings("https://localhost:44310/"));
        }


        [Fact]
        public async void CreateDirectoryTest()
        {
            var directoryMetadata = await writeApi.ObjectApi.CreateDirectory(IdGenerator.NewId(IdType.User),
                IdGenerator.NewId(IdType.Directory),
                "TestTest");
        }

        [Fact]
        public async void DeleteObjectTest()
        {
            var success = await writeApi.ObjectApi.DeleteObject(IdGenerator.NewId(IdType.User),
                IdGenerator.NewId(IdType.Directory),1);
        }
    }
}
