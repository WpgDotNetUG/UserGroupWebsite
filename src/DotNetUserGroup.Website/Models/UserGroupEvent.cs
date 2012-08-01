using System;

namespace DotNetUserGroup.Website.Models
{
    public struct UserGroupEvent
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Presenter { get; set; }
    }
}