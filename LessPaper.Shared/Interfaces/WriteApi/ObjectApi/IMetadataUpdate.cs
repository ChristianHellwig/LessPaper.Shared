
namespace LessPaper.Shared.Interfaces.WriteApi.ObjectApi
{
    public interface IMetadataUpdate
    {
        /// <summary>
        /// Object Name
        /// </summary>
        string ObjectName { get; }
        /// <summary>
        /// List of parent directories
        /// </summary>
        string[] ParentDirectoryIds { get; }
    }
}
