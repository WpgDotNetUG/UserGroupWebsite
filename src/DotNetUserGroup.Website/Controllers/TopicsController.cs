using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DotNetUserGroup.Website.Models;

namespace DotNetUserGroup.Website.Controllers
{
    public class TopicsController : ApiController
    {
        private readonly IFutureTopicsRepository _repository;
        
        public TopicsController(IFutureTopicsRepository repository)
        {
            _repository = repository;
        }

        // GET api/topics
        public IEnumerable<FutureTopicInfo> Get()
        {
            return _repository.All().OrderByDescending(t => t.Votes);
        }
    }
}