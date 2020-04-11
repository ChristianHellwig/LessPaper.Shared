using LessPaper.Shared.Interfaces.ReadApi;
using LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi;
using RestSharp;
using RestSharp.Serializers.Utf8Json;

namespace LessPaper.Shared.Implemenations.ReadApi
{
    class ReadApi : IReadApi
    {
        private const string baseUrl = "http://127.0.0.1:6666";
        private readonly IRestClient _restClient;
        public IReadObjectApi ObjectApi { get; }
        public ReadApi()
        {
            _restClient = new RestClient();
            _restClient.UseUtf8Json();
            ObjectApi = new ReadObjectApi(_restClient);
        }
    }
}
