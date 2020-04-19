using LessPaper.Shared.Interfaces.ReadApi;
using LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi;
using RestSharp;

namespace LessPaper.Shared.RestImpl.ReadApi
{
    class ReadApi : IReadApi
    {
        public IReadObjectApi ObjectApi { get; set; }
    }
}
