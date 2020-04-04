using LessPaper.Shared.Enums;
using LessPaper.Shared.Interfaces.GuardApi.Response;

namespace LessPaper.Shared.Implemenations.GuardApi.WriteObjectApi
{
    class PermissionResponse : IPermissionResponse
    {
        public PermissionResponse(string objectId, Permissions permission)
        {
            this.ObjectId = objectId;
            this.Permission = permission;
        }

        public string ObjectId { get; }

        public Permissions Permission { get; }
    }
}
