using System;
using System.Collections.Generic;
using System.Linq;
using DotNetUserGroup.Website.Models;
using MavenThought.Commons.Testing;
using Rhino.Mocks;
using SharpTestsEx;

namespace DotNetUserGroup.Website.Tests.Controllers.Events
{
    public class When_get_is_called : EventsControllerSpecification
    {
        private IEnumerable<UserGroupEvent> _expectedEvents;
        private IEnumerable<UserGroupEvent> _actual;

        protected override void GivenThat()
        {
            base.GivenThat();

            this._expectedEvents = Given_I_have_some_past_events();

            Dep<IRepository<UserGroupEvent>>().Stub(r => r.All()).Return(this._expectedEvents);
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
                .SameSequenceAs(this._expectedEvents.OrderByDescending(e => e.Date).Select(e => e.Id));
        }

        private static IEnumerable<UserGroupEvent> Given_I_have_some_past_events()
        {
            return Enumerable
                .Range(1, 10)
                .Select(i => new UserGroupEvent
                                 {
                                     Title = "The event is " + i,
                                     Date = DateTime.Now.AddDays(i),
                                     Address = "Crazy Presenter " + i,
                                     Id = i
                                 });
        }
    }
}