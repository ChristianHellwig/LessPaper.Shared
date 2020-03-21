using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LessPaper.Shared.Interfaces.GuardApi
{
    public interface IGuardApi
    {
        /// <summary>
        /// Register New User
        /// </summary>
        /// <param name="email"></param>
        /// <param name="passwordHash"></param>
        /// <param name="salt"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Throws if service not available</exception>
        Task<bool> RegisterNewUser(string email, string passwordHash, string salt, string userId);

        /// <summary>
        /// Get user credentials for comparison with given data.
        /// </summary>
        /// <param name="email">E-Mail address</param>
        /// <returns>Necessary credentials or null if user does not exist</returns>
        /// <exception cref="InvalidOperationException">Throws if service not available</exception>
        Task<ICredentialsResponse> GetUserCredentials(string email);
    }
}
