using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using EasyHttp.Http;

namespace DotNetUserGroup.Website.Models
{
    public class IdeaScaleRepository : IFutureTopicsRepository
    {
        private const string URL = "https://wpgdotnet.ideascale.com/a/rest/v1/";

        private const string CAMPAIGN_URL = URL + "campaigns/33031/";

        private const string API_TOKEN_KEY = "IDEASCALE_API_TOKEN";

        public IEnumerable<FutureTopicInfo> All()
        {
            var topics = (dynamic[]) Request("ideas").DynamicBody;

            return topics.Select(e => new FutureTopicInfo
                               {
                                   Topic = e.title,
                                   Votes = e.voteCount
                               });
        }

        private static HttpResponse Request(string method)
        {
            var http = new HttpClient();

            http.Request.Accept = HttpContentTypes.ApplicationJson;
            
            http.Request.AddExtraHeader("api_token", GetApiToken());

            return http.Get(CAMPAIGN_URL + method);
        }

        private static string GetApiToken()
        {
            return WebConfigurationManager.AppSettings[API_TOKEN_KEY]
                   ?? Environment.GetEnvironmentVariable(API_TOKEN_KEY);
        }
    }
}