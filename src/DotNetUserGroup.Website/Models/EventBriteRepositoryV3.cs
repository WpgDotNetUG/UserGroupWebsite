using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using EasyHttp.Http;

namespace DotNetUserGroup.Website.Models
{
    public class EventBriteRepositoryV3 : IRepository<UserGroupEvent>
    {
        private const string Url = "https://www.eventbriteapi.com";

        public IEnumerable<UserGroupEvent> All()
        {
            IEnumerable<UserGroupEvent> result;

            var response = Request("v3/users/me/owned_events").DynamicBody;
            
            try
            {
                var events = (IEnumerable<dynamic>) response.events;

                result = events.Select(CreateEvent);
            }
            catch (Exception e)
            {
                new LogEvent("Exception connecting with EB " + e.Message).Raise();
                new LogEvent("Error from EB is  " + response.error.error_type + " -> " + response.error.error_message).Raise();
                
                throw new Exception("Error connecting to EventBrite");
            }

            return result;
        }

        private static UserGroupEvent CreateEvent(dynamic e)
        {
            var @event = e.@event;
            var venue = @event.venue;
            return new UserGroupEvent
            {
                Title = @event.title,
                Date = DateTime.Parse(@event.start_date),
                EndDate = DateTime.Parse(@event.end_date),
                Status = @event.status,
                Id = @event.id,
                Address = venue.address,
                Venue = venue.name,
                Description = @event.description
            };
        }

        private static HttpResponse Request(string method)
        {
            var http = new HttpClient();

            http.Request.Accept = HttpContentTypes.ApplicationJson;

            var response = http.Get(Url + "/" + method, new { token = GetConfig("EB_TOKEN") });

            return response;
        }

        private static string GetConfig(string key)
        {
            var section = WebConfigurationManager.AppSettings;

            var debugEnv = section["Environment"] != "Release";

            return debugEnv ? Environment.GetEnvironmentVariable(key) : section[key];
        }
    }
}