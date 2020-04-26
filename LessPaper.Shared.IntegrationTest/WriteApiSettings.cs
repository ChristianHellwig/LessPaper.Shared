using LessPaper.Shared.Interfaces.WriteApi;

namespace LessPaper.Shared.IntegrationTest
{
    public class WriteApiSettings: IWriteApiSettings
    {
        public WriteApiSettings(string baseUrl)
        {
            BaseUrl = baseUrl;
        }
        public string BaseUrl { get; }
    }
}