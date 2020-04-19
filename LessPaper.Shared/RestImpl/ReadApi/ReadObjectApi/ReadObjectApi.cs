using System.IO;
using System.Threading.Tasks;
using LessPaper.Shared.RestImpl.ReadApi;
using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi;
using LessPaper.Shared.RestImpl.General;
using RestSharp;

//using System.ServiceModel.Dispatcher.JsonQueryStringConverter;

namespace LessPaper.Shared.RestImpl.ReadApi.ReadObjectApi
{

    public class ReadObjectApi : IReadObjectApi
    {
        private const string ObjectApiPath = "v1/objects";
        public IRestClient RestClient { get; set; }

        public async Task<IMetadata> GetMetadata(string objectId, uint? revisionNumber = default)
        {
            IRestRequest request = GetIRestRequestAddObjectIdAddRevisionNumber(objectId, revisionNumber);
            Metadata responseDerived = await RestClient.HeadAsync<Metadata>(request);
            return responseDerived;
        }

        public async Task<bool> GetObject(Stream responseStream, string objectId, uint? revisionNumber)
        {
            IRestRequest request = GetIRestRequestAddObjectIdAddRevisionNumber(objectId, revisionNumber);
            request.Method = Method.GET;

            request.ResponseWriter = async resStream =>
            {
                await resStream.CopyToAsync(responseStream);               
            };

            // byte[] objectBytes = 
            RestClient.DownloadData(request);

            return true;
        }


        private IRestRequest GetIRestRequestAddObjectIdAddRevisionNumber(string objectId, uint? revisionNumber = default)
        {
            string[] parameterObjectId = { "objectId" };
            IRestRequest request = new RestRequest(ObjectApiPath + "/{" + parameterObjectId + "}");
            request.AddParameter(parameterObjectId[0], objectId, ParameterType.UrlSegment);
            // Add 
            if (revisionNumber != default)
            {
                request.AddParameter("RevisionNumber", revisionNumber, ParameterType.GetOrPost);
            }
            return request;
        }


        public async Task<ISearchResponse> Search(string directoryId, string searchQuery, uint count, uint page)
        {
            // Request with to source
            IRestRequest request = new RestRequest(ObjectApiPath + "/{" + "DirectoryId" + "}" + "/" + "search");
            request.AddParameter("DirectoryId", directoryId, ParameterType.UrlSegment);

            // Add query parameters
            request.AddParameter("SearchQuery", searchQuery, ParameterType.GetOrPost);
            request.AddParameter("Count", count, ParameterType.GetOrPost);
            request.AddParameter("Page", page, ParameterType.GetOrPost);

            ISearchResponse searchResponse = await RestClient.GetAsync<SearchResponse>(request);
            return searchResponse;
        }
    }
}
