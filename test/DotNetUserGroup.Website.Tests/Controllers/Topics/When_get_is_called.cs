using System.Collections.Generic;
using System.Linq;
using DotNetUserGroup.Website.Models;
using MavenThought.Commons.Testing;
using Rhino.Mocks;
using SharpTestsEx;

namespace DotNetUserGroup.Website.Tests.Controllers.Topics
{
    public class When_get_is_called : TopicsControllerSpecification
    {
        private IEnumerable<FutureTopicInfo> _expected;
        private IEnumerable<FutureTopicInfo> _actual;

        protected override void GivenThat()
        {
            base.GivenThat();

            this._expected = Given_I_have_some_topics();

            Dep<IRepository<FutureTopicInfo>>().Stub(r => r.All()).Return(this._expected);
        }

        protected override void WhenIRun()
        {
            _actual = this.Sut.Get();
        }

        [It]
        public void Should_return_all_the_events()
        {
            this._actual
                .Select(e => e.Id)
                .Should().Have
                .SameSequenceAs(this._expected.OrderByDescending(e => e.Votes).Select(e => e.Id));
        }

        private static IEnumerable<FutureTopicInfo> Given_I_have_some_topics()
        {
            return Enumerable
                .Range(1, 10)
                .Select(i => new FutureTopicInfo
                                 {
                                     Topic = "Topic #" + i,
                                     Votes = i,
                                     Id = i
                                 });
        }
    }
}