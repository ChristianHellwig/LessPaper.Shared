using System.IO;
using System.Threading.Tasks;
using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi;
using LessPaper.Shared.Models.General;
using RestSharp;

//using System.ServiceModel.Dispatcher.JsonQueryStringConverter;

namespace LessPaper.Shared.Models.ReadApi.ReadObjectApi
{

    public class ReadObjectApi : IReadObjectApi
    {
        private const string ObjectApiPath = "v1/objects";
        public IRestClient RestClient { get; set; }

        public async Task<IMetadata> GetMetadata(string requestingUserId, string objectId, uint? revisionNumber)
        {
            IRestRequest request = GetIRestRequestAddObjectIdAddRevisionNumber(requestingUserId, objectId, revisionNumber);
            Metadata responseDerived = await RestClient.HeadAsync<Metadata>(request);
            return responseDerived;
        }

        public async Task<bool> GetObject(string requestingUserId, Stream responseStream, string objectId, uint? revisionNumber)
        {
            IRestRequest request = GetIRestRequestAddObjectIdAddRevisionNumber(requestingUserId, objectId, revisionNumber);
            request.Method = Method.GET;

            // Async upload ???

            request.ResponseWriter = async resStream =>
            {
                await resStream.CopyToAsync(responseStream);               
            };

            // byte[] objectBytes = 
            RestClient.DownloadData(request);

            return true;
        }


        private IRestRequest GetIRestRequestAddObjectIdAddRevisionNumber(string requestingUserId, string objectId, uint? revisionNumber = default)
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


        public async Task<ISearchResult> Search(string requestingUserId, string directoryId, string searchQuery, uint count, uint page)
        {
            // Request with to source
            IRestRequest request = new RestRequest(ObjectApiPath + "/{" + "DirectoryId" + "}" + "/" + "search");
            request.AddParameter("DirectoryId", directoryId, ParameterType.UrlSegment);

            // Add query parameters
            request.AddParameter("SearchQuery", searchQuery, ParameterType.GetOrPost);
            request.AddParameter("Count", count, ParameterType.GetOrPost);
            request.AddParameter("Page", page, ParameterType.GetOrPost);

            ISearchResult searchResponse = await RestClient.GetAsync<SearchResponse>(request);
            return searchResponse;
        }
    }
}
