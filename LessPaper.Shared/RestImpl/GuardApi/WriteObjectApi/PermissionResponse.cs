using LessPaper.Shared.Enums;
using LessPaper.Shared.Interfaces.GuardApi.Response;

namespace LessPaper.Shared.RestImpl.GuardApi.WriteObjectApi
{
    class PermissionResponse : IPermissionResponse
    {

        public string ObjectId { get; set; }

        public Permissions Permission { get; set; }
    }
}
