﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DotNetUserGroup.Website.Models;

namespace DotNetUserGroup.Website.Controllers
{
    public class EventsController : ApiController
    {
        private readonly IEventRepository _repository;

        public EventsController(IEventRepository repository)
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