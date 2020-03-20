using System;
using System.Collections.Generic;
using System.Text;

namespace LessPaper.Shared.Interfaces.GuardApi
{
    public interface ICredentialsResponse
    {
        string PasswordHash { get; }
        string Salt { get; }
    }
}
