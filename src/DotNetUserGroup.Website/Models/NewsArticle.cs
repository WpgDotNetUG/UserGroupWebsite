using System;

namespace DotNetUserGroup.Website.Models
{
    public struct NewsArticle
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
    }
}