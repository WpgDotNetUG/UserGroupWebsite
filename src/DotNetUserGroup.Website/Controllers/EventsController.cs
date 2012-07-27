using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EventbriteNET.Entities;

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
            const string apiKey = "132216720823914661396";
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
                                         Date = "2011-11-29 17:30:00"
                                     },
                                 new EventInfo
                                     {Title = "ASP.NET MVC vs Ruby on Rails SMACKDOWN!", Date = "2012-01-25 17:30:00"},
                                 new EventInfo {Title = "Azure and the Web", Date = "2012-03-31 09:00:00"},
                                 new EventInfo
                                     {Title = "Open Source Software Libraries and tools", Date = "2012-05-24 17:30:00"},
                                 new EventInfo
                                     {Title = "Nuget package and dependencies manager", Date = "2012-06-26 17:30:00"}
                             };


            return events;
        }
    }
}