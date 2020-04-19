using LessPaper.Shared.Interfaces.GuardApi.Response;

namespace LessPaper.Shared.RestImpl.GuardApi.WriteObjectApi
{
    class CredentialsResponse : ICredentialsResponse
    {

        public string PasswordHash { get; set; }

        public string Salt { get; set; }
    }
}
