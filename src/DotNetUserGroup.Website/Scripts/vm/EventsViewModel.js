(function() {
  var EventsViewModel;

  EventsViewModel = (function() {

    EventsViewModel.name = 'EventsViewModel';

    function EventsViewModel() {
      this.events = ko.observableArray();
      $.getJSON('../api/events', this.events);
    }

    return EventsViewModel;

  })();

  $(function() {
    return ko.applyBindings(new EventsViewModel());
  });

}).call(this);
