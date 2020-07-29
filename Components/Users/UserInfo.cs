namespace Users
{
    public struct UserInfo
    {
        public long Id { get; set; }
        public string Name { get; set;  }
        public string Info { get; set;  }

        public UserInfo(long id, string name, string info)
        {
            Id = id;
            Name = name;
            Info = info;
        }
    }
}