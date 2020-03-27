using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi;
using System;
using System.IO;
using System.Threading.Tasks;


namespace LessPaper.Shared.Implemenations.ReadApi
{
    class ReadObjectApi : IReadObjectApi
    {
        private const string ObjectApiPath = "/objects";


        public ReadObjectApi()
        {

        }

        public async Task<IMetadata> GetMetadata(string objectId, uint? revisionNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetObject(string objectId, uint? revisionNumber)
        {
            throw new NotImplementedException();
        }

        public Task<ISearchResponse> Search(string directoryId, string searchQuery, uint count, uint page)
        {
            throw new NotImplementedException();
        }
    }
}
