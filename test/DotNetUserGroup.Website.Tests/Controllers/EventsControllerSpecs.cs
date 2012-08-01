using System.Collections.Generic;
using System.Linq;
using DotNetUserGroup.Website.Models;
using MavenThought.Commons.Testing;
using NUnit.Framework;
using Rhino.Mocks;
using SharpTestsEx;

namespace DotNetUserGroup.Website.Tests.Controllers
{
    public class When_get_is_called : EventsControllerSpecification
    {
        private IEnumerable<EventInfo> _expectedEvents;
        private IEnumerable<EventInfo> _actual;

        protected override void GivenThat()
        {
            base.GivenThat();

            this._expectedEvents = Given_I_have_some_events_loaded();

            Dep<IEventRepository>().Stub(r => r.All()).Return(this._expectedEvents);
        }

        protected override void WhenIRun()
        {
            _actual = this.Sut.Get();
        }

        [It]
        public void Should_return_all_the_events()
        {
            this._actual.Should().Have.SameSequenceAs(this._expectedEvents);
        }

        private static IEnumerable<EventInfo> Given_I_have_some_events_loaded()
        {
            return Enumerable
                .Range(1, 10)
                .Select(i => new EventInfo
                                 {
                                     Title = "The event is " + i,
                                     Date = "March " + i
                                 });
        }
    }
}