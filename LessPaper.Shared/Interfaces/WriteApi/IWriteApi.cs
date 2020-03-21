using LessPaper.Shared.Interfaces.WriteApi.FileApi;

namespace LessPaper.Shared.Interfaces.WriteApi
{
    public interface IWriteApi
    {
        IFileApi FileApi { get; }
    }
}
