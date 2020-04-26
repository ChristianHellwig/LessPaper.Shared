using LessPaper.Shared.Interfaces.ReadApi;
using LessPaper.Shared.Interfaces.ReadApi.ReadObjectApi;

namespace LessPaper.Shared.Models.ReadApi
{
    class ReadApi : IReadApi
    {
        public IReadObjectApi ObjectApi { get; set; }
    }
}
