using System;
using System.Collections.Generic;
using System.Web.Configuration;
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

            var query = new
                            {
                                app_key = WebConfigurationManager.AppSettings["EB_APP_KEY"], 
                                user_key = WebConfigurationManager.AppSettings["EB_USER_KEY"]
                            };

            var response = http.Get(url, query);

            var eventList = response.DynamicBody.events;

            var result = new List<UserGroupEvent>();

            foreach (var e in eventList)
            {
                var @event = e.@event;

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