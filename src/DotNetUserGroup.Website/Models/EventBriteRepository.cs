using System;
using System.Collections.Generic;
using EasyHttp.Http;

namespace DotNetUserGroup.Website.Models
{
    public class EventBriteRepository : IEventRepository
    {
        public IEnumerable<UserGroupEvent> All()
        {
            var http = new HttpClient();
            http.Request.Accept = HttpContentTypes.ApplicationJson;
            const string url = "https://www.eventbrite.com/json/user_list_events";

            var response = http.Get(url, new
                                             {
                                                 app_key = "RMG5TWH6AW5DXBKIZQ",
                                                 user_key = "132216720823914661396"
                                             });

            var eventList = response.DynamicBody.events;

            var result = new List<UserGroupEvent>();

            foreach (var e in eventList)
            {
                dynamic @event = e.@event;

                result.Add(new UserGroupEvent
                               {
                                   Title = @event.title,
                                   Date = DateTime.Parse(@event.start_date),
                                   Id = @event.id,
                                   Address = @event.venue.address
                               });
            }

            return result;
        }
    }
}