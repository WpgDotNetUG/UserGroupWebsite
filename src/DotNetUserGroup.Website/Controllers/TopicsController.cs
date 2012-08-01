using System.Collections.Generic;
using System.Web.Http;
using DotNetUserGroup.Website.Models;

namespace DotNetUserGroup.Website.Controllers
{
    public class TopicsController : ApiController
    {
        
        // GET api/topics
        public IEnumerable<FutureTopicInfo> Get()
        {
            var topics = new[]
                             {
                                 new FutureTopicInfo {Topic = "Git", Votes = 14},
                                 new FutureTopicInfo {Topic = "A whole day MVC workshop", Votes = 12},
                                 new FutureTopicInfo {Topic = "Sass & Less & CSS Frameworks", Votes = 10},
                                 new FutureTopicInfo {Topic = "Using CI server", Votes = 7},
                                 new FutureTopicInfo {Topic = "Web API", Votes = 7},
                                 //new FutureTopicInfo {Topic = "CruiseConrol vs TeamCity", Votes = 6},
                                 //new FutureTopicInfo {Topic = "Cloud Computing", Votes = 5},
                                 //new FutureTopicInfo {Topic = "Using nHibernate", Votes = 5},
                                 //new FutureTopicInfo {Topic = "Coffeescript", Votes = 5},
                             };


            return topics;
        }
    }
}