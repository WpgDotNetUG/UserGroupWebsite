using System.Collections.Generic;
using System.Web.Http;

namespace DotNetUserGroup.Website.Controllers
{
    public class NewsController : ApiController
    {
        
        // GET api/events
        public IEnumerable<NewsInfo> Get()
        {
            var news = new[]
                             {
                                 new NewsInfo 
                                     {
                                         Title = "Ruby On Rails 101 free workshop",
                                         Date = "Jul 30"
                                     },
                                 new NewsInfo 
                                     {
                                         Title = "Winnipeg hosts Azurefest",
                                         Date = "May 19"
                                     },
                                 new NewsInfo 
                                     {
                                         Title = "Imaginet Interactive Launch Party",
                                         Date = "May 12"
                                     },
                                     
                                 new NewsInfo 
                                     {
                                         Title = "Free Windows Phone 7/IE9 Developer Bootcamp on April 5th",
                                         Date = "Apr 8"
                                     },
                                 new NewsInfo 
                                     {
                                         Title = "DevTeach gets a Taste of Winnipeg",
                                         Date = "Mar 15"
                                     },
                             };

            return news;
        }
    }
}