using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DotNetUserGroup.Website.Models;

namespace DotNetUserGroup.Website.Controllers
{
    public class EventsController : ApiController
    {
        private readonly IRepository<UserGroupEvent> _repository;

        public EventsController(IRepository<UserGroupEvent> repository)
        {
            _repository = repository;
        }

        // GET api/events
        public IEnumerable<UserGroupEvent> Get()
        {
            return this
                ._repository
                .All()
                .OrderByDescending(e => e.Date);
        }
    }
}