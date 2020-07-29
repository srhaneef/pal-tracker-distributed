using System.Collections.Generic;

namespace Accounts.Data
{
    public interface IAccountDataGateway
    {
        AccountRecord Create(long ownerId, string name);

        List<AccountRecord> FindBy(long ownerId);
    }
}