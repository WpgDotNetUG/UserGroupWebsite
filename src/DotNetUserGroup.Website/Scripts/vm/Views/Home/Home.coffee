
$ ->
  ko.applyBindings(new NextEventViewModel(), $('next-event')[0])
  ko.applyBindings(new EventsViewModel(), $('past-events')[0])
  ko.applyBindings(new TopicsViewModel(), $('future-topics')[0])
  # ko.applyBindings(new NewsViewModel(3), document.getElementById('news'))
