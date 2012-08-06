(function() {

  $(function() {
    ko.applyBindings(new EventsViewModel(), document.getElementById('events'));
    ko.applyBindings(new TopicsViewModel(), document.getElementById('topics'));
    return ko.applyBindings(new NewsViewModel(3), document.getElementById('news'));
  });

}).call(this);
