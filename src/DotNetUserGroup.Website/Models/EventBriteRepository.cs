using System.Collections.Generic;

namespace DotNetUserGroup.Website.Models
{
    public class EventBriteRepository : IEventRepository
    {
        public IEnumerable<EventInfo> All()
        {
            var events = new[]
                             {
                                 new EventInfo
                                     {
                                         Title = "Advanced IoC with Castle Windsor with Amir Barylko",
                                         Date = "Nov 29"
                                     },
                                 new EventInfo
                                     {
                                         Title = "ASP.NET MVC vs Ruby on Rails SMACKDOWN!",
                                         Date = "Jan 25"
                                     },
                                 new EventInfo
                                     {
                                         Title = "Azure and the Web",
                                         Date = "Mar 31"
                                     },
                                 new EventInfo
                                     {
                                         Title = "Open Source Software Libraries and tools",
                                         Date = "May 24"
                                     },
                                 new EventInfo
                                     {
                                         Title = "Nuget package and dependencies manager",
                                         Date = "Jun 26"
                                     }
                             };
            return events;
        }
    }
}