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
                result.Add(new UserGroupEvent
                               {
                                   Title = e.@event.title,
                                   Date = DateTime.Parse(e.@event.start_date)
                               });
            }

            return result;
        }
    }
}