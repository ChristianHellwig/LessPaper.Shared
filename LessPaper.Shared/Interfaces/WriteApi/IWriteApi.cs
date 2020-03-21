using LessPaper.Shared.Interfaces.ReadApi.ObjectApi;
using LessPaper.Shared.Interfaces.WriteApi.ObjectApi;

namespace LessPaper.Shared.Interfaces.WriteApi
{
    public interface IWriteApi
    {
        /// <summary>
        /// Api for writing objects like files, directories or specific properties
        /// </summary>
        IObjectApi ObjectApi { get; }
    }
}
