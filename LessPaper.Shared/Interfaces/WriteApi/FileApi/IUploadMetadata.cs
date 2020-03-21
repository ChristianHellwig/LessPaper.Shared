using LessPaper.Shared.Interfaces.General;
using LessPaper.Shared.Interfaces.ReadApi.ObjectApi;

namespace LessPaper.Shared.Interfaces.WriteApi.FileApi
{
    public interface IUploadMetadata: IMetadata
    {
        /// <summary>
        /// Unique id set on uploading file
        /// </summary>
        uint QuickNumber { get;  }
    }
}
