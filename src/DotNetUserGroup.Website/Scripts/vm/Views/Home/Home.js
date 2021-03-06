﻿// Generated by IcedCoffeeScript 108.0.9
(function() {
  window.EventsViewModel = (function() {
    function EventsViewModel() {
      this.nextEvent = new NextEventViewModel();
      this.pastEvents = new PastEventsViewModel();
      this.futureTopics = new FutureTopicsViewModel();
    }

    return EventsViewModel;

  })();

  $(function() {
    return ko.applyBindings(new EventsViewModel(), $('#events')[0]);
  });

}).call(this);
