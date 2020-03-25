using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LessPaper.Shared.Implemenations.ReadApi
{
    class ReadObjectApi : IReadObjectApi
    {
        public ReadObjectApi()
        {
        }

        public Task<IMetadata> GetMetadata(string objectId, uint? revisionNumber)
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
