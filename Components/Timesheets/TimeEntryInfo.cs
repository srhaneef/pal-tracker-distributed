using System;

namespace Timesheets
{
    public struct TimeEntryInfo
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long UserId { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public string Info { get; set; }


        public TimeEntryInfo(long id, long projectId, long userId, DateTime date, int hours, string info)
        {
            Id = id;
            ProjectId = projectId;
            UserId = userId;
            Date = date;
            Hours = hours;
            Info = info;
        }
    }
}