(function() {

  $(function() {
    ko.applyBindings(new NextEventViewModel(), $('next-event')[0]);
    ko.applyBindings(new EventsViewModel(), $('past-events')[0]);
    return ko.applyBindings(new TopicsViewModel(), $('future-topics')[0]);
  });

}).call(this);
