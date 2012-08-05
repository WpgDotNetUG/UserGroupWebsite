using System.Collections.Generic;
using System.Web.Http;
using DotNetUserGroup.Website.Models;

namespace DotNetUserGroup.Website.Controllers
{
    public class NewsController : ApiController
    {
        private readonly IRepository<NewsArticle> _repository;

        public NewsController(IRepository<NewsArticle> repository)
        {
            _repository = repository;
        }

        // GET api/newsarticle
        public IEnumerable<NewsArticle> Get()
        {
            return this._repository.All();
        }
    }
}