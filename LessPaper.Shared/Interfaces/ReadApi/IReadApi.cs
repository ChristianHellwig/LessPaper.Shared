using LessPaper.Shared.Interfaces.ReadApi.ObjectApi;

namespace LessPaper.Shared.Interfaces.ReadApi
{
    public interface IReadApi
    {
        IObjectApi ObjectApi { get; }
    }
}
