using LessPaper.Shared.Interfaces.GuardApi.Response;

namespace LessPaper.Shared.Implemenations.GuardApi
{
    class CredentialsResponse : ICredentialsResponse
    {
        public CredentialsResponse(string passwordHash, string salt)
        {
            this.PasswordHash = passwordHash;
            this.Salt = salt;
        }

        public string PasswordHash { get; }

        public string Salt { get; }
    }
}
