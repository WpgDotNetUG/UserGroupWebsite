using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Management;
using EasyHttp.Http;

namespace DotNetUserGroup.Website.Models
{
    public class EventBriteRepository : IEventRepository
    {
        private const string url = "https://www.eventbrite.com/json/";

        public IEnumerable<UserGroupEvent> All()
        {
            var result = new List<UserGroupEvent>();

            try
            {
                var eventList = Request("user_list_events", LoadConfiguration()).DynamicBody.events;

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

            }
            catch (Exception e)
            {
                new LogEvent("Exception with EB " + e.Message).Raise();
                
                result.Add(new UserGroupEvent
                               {
                                   Date = DateTime.Now,
                                   Title = "Error reading from EB"
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
            return new
                       {
                           app_key = GetConfig("EB_APP_KEY"),
                           user_key = GetConfig("EB_USER_KEY")
                       };

        }

        private static string GetConfig(string key)
        {
            var section = WebConfigurationManager.AppSettings;

            var debugEnv = section["Environment"] != "Release";

            var value = debugEnv ? Environment.GetEnvironmentVariable(key) : section[key];

            new LogEvent("Reading Enivornment " + key + " and obtaind " + value).Raise();

            return value;
        }
    }

    public class LogEvent : WebRequestErrorEvent
    {
        public LogEvent(string message)
            : base(null, null, 100001, new Exception(message))
        {
        }
    }
}