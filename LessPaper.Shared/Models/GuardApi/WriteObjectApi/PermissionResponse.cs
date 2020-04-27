using LessPaper.Shared.Enums;
using LessPaper.Shared.Interfaces.GuardApi.Response;

namespace LessPaper.Shared.Models.GuardApi.WriteObjectApi
{
    class PermissionResponse : IPermissionResponse
    {

        public string ObjectId { get; set; }

        public Permission Permission { get; set; }
    }
}
