using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi;
using System.IO;
using System.Threading.Tasks;
using RestSharp;
using LessPaper.Shared.Implemenations.General;
//using System.ServiceModel.Dispatcher.JsonQueryStringConverter;

namespace LessPaper.Shared.Implemenations.ReadApi
{

    public class ReadObjectApi : IReadObjectApi
    {
        private const string ObjectApiPath = "objects/";
        private readonly IRestClient _restClient;
        //private QueryStringConverter queryStringConverter;

        public ReadObjectApi(IRestClient restClient)
        {
            _restClient = restClient;
            //queryStringConverter = new QueryStringConverter();
        }

        public async Task<IMetadata> GetMetadata(string objectId, uint? revisionNumber)
        {
            IRestRequest request = GetIRestRequestAddObjectIdAddRevisionNumber(objectId, revisionNumber);
            Metadata responseDerived = await _restClient.HeadAsync<Metadata>(request);
            return responseDerived;
        }

        public async Task<Stream> GetObject(string objectId, uint? revisionNumber)
        {
            IRestRequest request = GetIRestRequestAddObjectIdAddRevisionNumber(objectId, revisionNumber);
            request.Method = Method.GET;

            byte[] objectBytes = _restClient.DownloadData(request);
            Stream objectStream = new MemoryStream(objectBytes);

            return objectStream;
        }

        private IRestRequest GetIRestRequestAddObjectIdAddRevisionNumber(string objectId, uint? revisionNumber)
        {
            string[] parameterObjectId = { "objectId" };
            IRestRequest request = new RestRequest(ObjectApiPath + "{" + parameterObjectId + "}");
            request.AddParameter(parameterObjectId[0], objectId);
            if (revisionNumber != default)
            {
                request.AddQueryParameter("RevisionNumber", revisionNumber.ToString());
            }
            return request;
        }

        public async Task<ISearchResponse> Search(string directoryId, string searchQuery, uint count, uint page)
        {
            IRestRequest request = new RestRequest(ObjectApiPath + "{" + "RirectoryId" + "}" + "/" + "search");
            request.AddParameter("RirectoryId", directoryId);

            request.AddQueryParameter("SearchQuery", searchQuery);
            request.AddQueryParameter("Count", count.ToString());
            request.AddQueryParameter("Page", page.ToString());

            ISearchResponse searchResponse = await _restClient.GetAsync<SearchResponse>(request);
            return searchResponse;
        }
    }
}
