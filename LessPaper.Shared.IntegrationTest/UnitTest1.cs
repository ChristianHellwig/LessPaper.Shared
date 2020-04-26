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
        [Fact]
        public async void CreateDirectory()
        {
            IWriteApi writeApi = new WriteApi(new WriteApiSettings("https://localhost:44310/"));
            var directoryMetadata = await writeApi.ObjectApi.CreateDirectory(IdGenerator.NewId(IdType.Directory), "TestTest");
        }
    }
}
