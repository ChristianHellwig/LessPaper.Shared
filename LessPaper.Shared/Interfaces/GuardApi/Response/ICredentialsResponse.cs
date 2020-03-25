namespace LessPaper.Shared.Interfaces.GuardApi.Response
{
    public interface ICredentialsResponse
    {
        string PasswordHash { get; }
        string Salt { get; }
    }
}
