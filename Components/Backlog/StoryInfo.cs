namespace Backlog
{
    public struct StoryInfo
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }


        public StoryInfo(long id, long projectId, string name, string info)
        {
            Id = id;
            ProjectId = projectId;
            Name = name;
            Info = info;
        }
    }
}