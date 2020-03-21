using LessPaper.Shared.Interfaces.WriteApi.FileApi;

namespace LessPaper.Shared.Interfaces.WriteApi
{
    public interface IWriteApi
    {
        /// <summary>
        /// Api for writing objects like files, directories or specific properties
        /// </summary>
        IFileApi FileApi { get; }
    }
}
