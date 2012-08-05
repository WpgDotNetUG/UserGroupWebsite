using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotNetUserGroup.Website.Models;
using MarkdownSharp;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace DotNetUserGroup.Website.Tests.Models.News
{
    [Specification]
    public class When_getting_all_news : NewsArticleRepositorySpecification
    {
        private IEnumerable<NewsArticle> _actual;
        private IEnumerable<NewsArticle> _expected;

        protected override void GivenThat()
        {
            base.GivenThat();

            Given_I_have_some_news_stored();
        }

        protected override void WhenIRun()
        {
            this._actual = this.Sut.All();
        }

        [It]
        public void Should_have_all_the_news_parsed_from_the_folder()
        {
            this._actual
                .Should().Have
                .SameValuesAs(this._expected);
        }

        private void Given_I_have_some_news_stored()
        {
            this._expected = Enumerable
                .Range(1, 10)
                .Select(i =>
                            {
                                var data = new
                                               {
                                                   Title = "News Article " + i,
                                                   Date = DateTime.Now.AddDays(i),
                                                   Markdown = GenerateMarkdown(i)
                                               };

                                SaveFileWithMarkdown(data.Title, data.Date, data.Markdown);

                                return new NewsArticle
                                           {
                                               Title = data.Title,
                                               Date = data.Date.ToString("yyyy-MM-d"),
                                               Body = new Markdown().Transform(data.Markdown)
                                           };
                            });
        }

        private void SaveFileWithMarkdown(string title, DateTime date, string markdown)
        {
            var fileName = string.Format("{0}-{1}.markdown",
                                         date.ToString("yyyy-MM-d"),
                                         title);
            var path = Path.Combine(this.NewsFolder, fileName);
            var stream = File.Create(path);

            var writer = new StreamWriter(stream);

            writer.WriteLine("---");
            writer.WriteLine("title: {0}", title);
            writer.WriteLine("date: {0}", date.ToShortDateString());
            writer.WriteLine("---");
            writer.WriteLine(markdown);

            writer.Close();
        }

        private static string GenerateMarkdown(int i)
        {
            const string article = @"
**ASP.NET MVC** gives you a powerful, patterns-based way to build dynamic websites that enables a clean separation of concerns and that gives you full control over markup for enjoyable, agile development. 

MVC includes many features that enable:

* fast, TDD-friendly development for creating sophisticated applications
* use the latest web standards.

[Learn More About MVC](http://www.asp.net/mvc 'Learn more about MVC today!')";

            return "#The news number " + i + article;
        }
    }
}