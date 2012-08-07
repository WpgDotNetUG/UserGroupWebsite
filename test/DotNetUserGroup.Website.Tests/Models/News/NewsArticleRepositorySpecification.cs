using System;
using System.IO;
using DotNetUserGroup.Website.Models;
using MavenThought.Commons.Testing;

namespace DotNetUserGroup.Website.Tests.Models.News
{
    public abstract class NewsArticleRepositorySpecification
        : AutoMockSpecificationWithNoContract<NewsArticleRepository>
    {
        protected string NewsFolder { get; set; }

        protected override void GivenThat()
        {
            base.GivenThat();

            this.NewsFolder = Path.Combine(Path.GetTempPath(), RandomFolderName());

            Directory.CreateDirectory(this.NewsFolder);
        }

        protected override NewsArticleRepository CreateSut()
        {
            return new NewsArticleRepository(this.NewsFolder);
        }

        private static string RandomFolderName()
        {
            return "NewsFolder_" + DateTime.Now.Millisecond;
        }
    }
}