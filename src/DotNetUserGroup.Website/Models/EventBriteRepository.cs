using System;
using System.Collections.Generic;
using System.Web.Configuration;
using EasyHttp.Http;

namespace DotNetUserGroup.Website.Models
{
    public class EventBriteRepository : IRepository<UserGroupEvent>
    {
        private const string Url = "https://www.eventbrite.com/json/";

        public IEnumerable<UserGroupEvent> All()
        {
            var result = new List<UserGroupEvent>();

            var response = Request("user_list_events", LoadConfiguration()).DynamicBody;

            try
            {
                foreach (var e in response.events)
                {
                    var @event = e.@event;

                    result.Add(new UserGroupEvent
                    {
                        Title = @event.title,
                        Date = DateTime.Parse(@event.start_date),
                        Id = @event.id,
                        Address = @event.venue.address,
                        Description = @event.description
                    });
                }

            }
            catch (Exception e)
            {
                new LogEvent("Exception connecting with EB " + e.Message).Raise();
                new LogEvent("Error from EB is  " + response.error.error_type + " -> " + response.error.error_message).Raise();
                
                throw new Exception("Error connecting to EventBrite");
            }

            return result;
        }

        private static HttpResponse Request(string method, object configuration)
        {
            var http = new HttpClient();

            http.Request.Accept = HttpContentTypes.ApplicationJson;

            var response = http.Get(Url + "/" + method, configuration);

            return response;
        }

        private static object LoadConfiguration()
        {
            var config = new
            {
                app_key = GetConfig("EB_APP_KEY"),
                user_key = GetConfig("EB_USER_KEY")
            };

            return config;
        }

        private static string GetConfig(string key)
        {
            var section = WebConfigurationManager.AppSettings;

            var debugEnv = section["Environment"] != "Release";

            return debugEnv ? Environment.GetEnvironmentVariable(key) : section[key];
        }
    }
}