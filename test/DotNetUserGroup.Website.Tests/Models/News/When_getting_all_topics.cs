using System.Collections.Generic;
using System.Linq;
using DotNetUserGroup.Website.Models;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace DotNetUserGroup.Website.Tests.Models.News
{
    [Specification]
    public class When_getting_all_news : NewsArticleRepositorySpecification
    {
        private IEnumerable<NewsArticle> _actual;

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
            this._actual.Should().Not.Be.Empty();
            this._actual.Count().Should().Be.GreaterThanOrEqualTo(3);
        }

        private void Given_I_have_some_news_stored()
        {

        }
    }
}