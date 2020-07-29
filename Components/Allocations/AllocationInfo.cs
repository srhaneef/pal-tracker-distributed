using System;

namespace Allocations
{
    public struct AllocationInfo
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long UserId { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }
        public string Info { get; set; }


        public AllocationInfo(long id, long projectId, long userId, DateTime firstDay, DateTime lastDay, string info)
        {
            Id = id;
            ProjectId = projectId;
            UserId = userId;
            FirstDay = firstDay;
            LastDay = lastDay;
            Info = info;
        }
    }
}