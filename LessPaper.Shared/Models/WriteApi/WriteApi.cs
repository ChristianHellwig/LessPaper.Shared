using LessPaper.Shared.Interfaces.WriteApi;
using LessPaper.Shared.Interfaces.WriteApi.WriteObjectApi;
using RestSharp;

namespace LessPaper.Shared.Models.WriteApi
{
    public class WriteApi: IWriteApi
    {
        public WriteApi(IWriteApiSettings writeApiSettings)
        {
            ObjectApi = new WriteObjectApi.WriteObjectApi(new RestClient(writeApiSettings.BaseUrl));
        }

        public IWriteObjectApi ObjectApi { get; set; }
    }
}
