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
            var tokens = Path.GetFileNameWithoutExtension(fileName).Split('-');

            var date = DateTime.Parse(String.Join("-", tokens.Take(3).ToArray()));

            var parsedData = ParseNewsArticle(new StreamReader(fileName));

            return new NewsArticle
                       {
                           Title = parsedData.Item1["title"],
                           Date = date,
                           Body = new Markdown().Transform(parsedData.Item2)
                       };
        }


        private static Tuple<IDictionary<string, string>, string> ParseNewsArticle(TextReader reader)
        {
            var metadata = ReadMetaData(reader, "---");

            var markdown = reader.ReadToEnd();

            return Tuple.Create(metadata, markdown);
        }

        private static IDictionary<string, string> ReadMetaData(TextReader reader, string separator)
        {
            reader.ReadLinesUntil(separator);

            return ParseMetadata(reader.ReadLinesUntil(separator));
        }

        private static IDictionary<string, string> ParseMetadata(IEnumerable<string> lines)
        {
            return lines.Aggregate(new Dictionary<string, string>(),
                                   (map, line) =>
                                       {
                                           var tokens = line.Split(':');
                                           map[tokens[0].Trim()] = tokens[1].Trim();
                                           return map;
                                       });
        }
    }

    static class Helper
    {
        public static IEnumerable<string> ReadLinesUntil(this TextReader reader, string separator)
        {
            var result = new List<string>();

            string line;

            while ((line = reader.ReadLine()) != separator)
            {
                result.Add(line);
            }

            return result;
        } 
    }
}