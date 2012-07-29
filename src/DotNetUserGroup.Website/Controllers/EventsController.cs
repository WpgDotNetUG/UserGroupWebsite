using System.Collections.Generic;
using System.Web.Http;

namespace DotNetUserGroup.Website.Controllers
{
    public struct EventInfo
    {
        public string Title { get; set; }
        public string Date { get; set; }
    }

    public class EventsController : ApiController
    {
        
        // GET api/events
        public IEnumerable<EventInfo> Get()
        {
            const string appKey = "D2ZDCBPDNEWMO7I3OC";
            const int organizerId = 1687350;

            var context = new EventbriteNET.EventbriteContext(appKey);

            var user = context.GetOrganizer(organizerId);

            // var events = user.Events;
            // var values = events.Values.ToList();

            var events = new[]
                             {
                                 new EventInfo
                                     {
                                         Title = "Advanced IoC with Castle Windsor with Amir Barylko",
                                         Date = "Nov 29th 2011"
                                     },
                                 new EventInfo
                                     {Title = "ASP.NET MVC vs Ruby on Rails SMACKDOWN!", 
                                         Date = "Jan 25th 2012"},
                                 new EventInfo {Title = "Azure and the Web", 
                                     Date = "Mar 31st 2012"},
                                 new EventInfo
                                     {Title = "Open Source Software Libraries and tools", 
                                         Date = "May 24th 2012"},
                                 new EventInfo
                                     {Title = "Nuget package and dependencies manager", 
                                         Date = "Jun 26th 2012"}
                             };


            return events;
        }
    }
}