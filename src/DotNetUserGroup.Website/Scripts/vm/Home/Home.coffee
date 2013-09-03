
$ ->
  ko.applyBindings(new NextEventViewModel(), document.getElementById('next-event'))
  ko.applyBindings(new EventsViewModel(), document.getElementById('past-events'))
  ko.applyBindings(new TopicsViewModel(), document.getElementById('future-topics'))
  # ko.applyBindings(new NewsViewModel(3), document.getElementById('news'))