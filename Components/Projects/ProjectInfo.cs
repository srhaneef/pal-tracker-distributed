namespace Projects
{
    public struct ProjectInfo
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Info { get; set; }


        public ProjectInfo(long id, long accountId, string name, bool active, string info)
        {
            Id = id;
            AccountId = accountId;
            Name = name;
            Active = active;
            Info = info;
        }
    }
}