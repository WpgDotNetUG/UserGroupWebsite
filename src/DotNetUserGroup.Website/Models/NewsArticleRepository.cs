using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MarkdownSharp;

namespace DotNetUserGroup.Website.Models
{
    public class NewsArticleRepository : IRepository<NewsArticle>
    {
        private readonly string newsFolderPath;

        public NewsArticleRepository(string dirPath)
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
            return Directory.GetFiles(newsFolderPath, "*.markdown");
        }

        private static NewsArticle ReadNewsArticle(string fileName)
        {
            var fileData = File.ReadAllText(fileName);

            var tokens = Path.GetFileNameWithoutExtension(fileName).Split('-');

            var date = DateTime.Parse(String.Join("-", tokens.Take(3).ToArray())).ToString("MMM dd");

            return new NewsArticle
                       {
                           Title = tokens[3].Trim(),
                           Date = date,
                           Body = new Markdown().Transform(fileData)
                       };
        }
    }
}