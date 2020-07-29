using Users.Data;

namespace Accounts
{
    public interface IRegistrationService
    {
        UserRecord CreateUserWithAccount(string name);
    }
}