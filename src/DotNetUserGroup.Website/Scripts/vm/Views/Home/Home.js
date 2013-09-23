(function() {

  $(function() {
    ko.applyBindings(new NextEventViewModel(), $('#next-event')[0]);
    ko.applyBindings(new PastEventsViewModel(), $('#past-events')[0]);
    return ko.applyBindings(new FutureTopicsViewModel(), $('#future-topics')[0]);
  });

}).call(this);
