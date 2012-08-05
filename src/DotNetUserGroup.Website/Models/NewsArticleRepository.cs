using System.Collections.Generic;
using System.Linq;

namespace DotNetUserGroup.Website.Models
{
    public class NewsArticleRepository : IRepository<NewsArticle>
    {
        private readonly string newsFolderPath;

        public NewsArticleRepository(string dirPath = "Content/News")
        {
            newsFolderPath = dirPath;
        }

        public IEnumerable<NewsArticle> All()
        {
            return GetFileNames()
                .OrderByDescending(i => i)
                .Select(ReadNewsArticle);
        }

        private IEnumerable<string> GetFileNames()
        {
            return System.IO.Directory.GetFiles(newsFolderPath, "*.markdown");
        }

        private static NewsArticle ReadNewsArticle(string fileName)
        {

            var fileData = System.IO.File.ReadAllText(fileName);

            return new NewsArticle
                       {

                       };
        }
    }
}