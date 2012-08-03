using System.Collections.Generic;
using System.Linq;
using DotNetUserGroup.Website.Models;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace DotNetUserGroup.Website.Tests.Models.IdeaScaleRepo
{
    [Specification]
    public class When_getting_all_topics : IdeaScaleRepositorySpecification
    {
        private IEnumerable<FutureTopicInfo> _actual;

        protected override void WhenIRun()
        {
            this._actual = this.Sut.All();
        }

        [It]
        public void Should_have_all_the_ideas()
        {
            this._actual.Should().Not.Be.Empty();
            this._actual.Count().Should().Be.GreaterThanOrEqualTo(3);
        }
    }
}