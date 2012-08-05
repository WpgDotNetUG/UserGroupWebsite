using System.Collections.Generic;
using System.Linq;
using DotNetUserGroup.Website.Models;
using DotNetUserGroup.Website.Tests.Models.EventBriteRepo;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace DotNetUserGroup.Website.Tests.Models
{
    [Specification]
    public class When_getting_events_from_eventbrite : EventBriteRepositorySpecification
    {
        private IEnumerable<UserGroupEvent> _actual;

        protected override void WhenIRun()
        {
            this._actual = this.Sut.All();
        }

        [It]
        public void Should_have_the_events_from_the_site()
        {
            this._actual.Should().Not.Be.Empty();
            this._actual.Count().Should().Be.GreaterThanOrEqualTo(5);
        }
    }
}