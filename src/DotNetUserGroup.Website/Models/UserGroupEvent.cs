using System;

namespace DotNetUserGroup.Website.Models
{
    public struct UserGroupEvent
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Venue { get; set; }
    }
}