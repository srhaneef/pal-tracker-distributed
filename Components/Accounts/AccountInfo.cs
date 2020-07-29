namespace Accounts
{
    public class AccountInfo
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

        public AccountInfo(long id, long ownerId, string name, string info)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
            Info = info;
        }
    }
}