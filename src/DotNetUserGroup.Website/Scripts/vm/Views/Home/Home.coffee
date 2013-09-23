
$ ->
  
  ko.applyBindings(new NextEventViewModel(), $('#next-event')[0])
  ko.applyBindings(new PastEventsViewModel(), $('#past-events')[0])
  ko.applyBindings(new FutureTopicsViewModel(), $('#future-topics')[0])
  # ko.applyBindings(new NewsViewModel(3), document.getElementById('news'))
