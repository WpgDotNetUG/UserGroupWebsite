(function() {
  $(function() {
    ko.applyBindings(new NextEventViewModel(), document.getElementById('next-event'));
    return ko.applyBindings(new EventsViewModel(), document.getElementById('past-events'));
  });

}).call(this);
