(function() {
  $(function() {
    ko.applyBindings(new NextEventViewModel(), document.getElementById('next-event'));
    ko.applyBindings(new EventsViewModel(), document.getElementById('past-events'));
    return ko.applyBindings(new TopicsViewModel(), document.getElementById('future-topics'));
  });

}).call(this);
