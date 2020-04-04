using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi;
using System;
using System.IO;
using System.Threading.Tasks;
using RestSharp;
using LessPaper.Shared.Implemenations.General;
using RestSharp.Serializers.Utf8Json;

namespace LessPaper.Shared.Implemenations.ReadApi
{
    
    public class ReadObjectApi : IReadObjectApi
    {
        private const string ObjectApiPath = "/objects";
        private readonly IRestClient _restClient;
        public ReadObjectApi(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<IMetadata> GetMetadata(string objectId, uint? revisionNumber)
        {
            //RestClient restClient = new RestClient("");
            IRestRequest request = new RestRequest(ObjectApiPath);
            if (revisionNumber != default)
            {
                request.AddQueryParameter("RevisionNumber", revisionNumber.ToString());
            }
            request.AddJsonBody(revisionNumber);
            IMetadata response = await _restClient.GetAsync<Metadata>(request);
            return response;
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
