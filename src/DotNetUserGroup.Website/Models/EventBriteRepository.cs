using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Configuration;
using EasyHttp.Http;

namespace DotNetUserGroup.Website.Models
{
    public class EventBriteRepository : IEventRepository
    {
        private const string url = "https://www.eventbrite.com/json/";

        public IEnumerable<UserGroupEvent> All()
        {
            var eventList = Request("/user_list_events", LoadConfiguration()).DynamicBody.events;

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

        private static HttpResponse Request(string method, object configuration)
        {
            var http = new HttpClient();

            http.Request.Accept = HttpContentTypes.ApplicationJson;

            var response = http.Get(url + "/" + method, configuration);

            return response;
        }

        private static object LoadConfiguration()
        {
            var section = WebConfigurationManager.AppSettings;

            var query = new
                            {
                                app_key = section["EB_APP_KEY"],
                                user_key = section["EB_USER_KEY"]
                            };

#if DEBUG
            query = new
            {
                app_key = Environment.GetEnvironmentVariable("EB_APP_KEY"),
                user_key = Environment.GetEnvironmentVariable("EB_USER_KEY")
            };
#endif

            return query;
        }
    }
}