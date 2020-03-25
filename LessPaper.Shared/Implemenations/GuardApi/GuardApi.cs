using LessPaper.Shared.Interfaces.GuardApi;
using System;
using System.Threading.Tasks;

namespace LessPaper.Shared.Implemenations.GuardApi
{
    class GuardApi : IGuardApi
    {
        public Task<ICredentialsResponse> GetUserCredentials(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterNewUser(string email, string passwordHash, string salt, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
