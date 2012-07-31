(function() {
  var EventsViewModel;

  EventsViewModel = (function() {

    EventsViewModel.name = 'EventsViewModel';

    function EventsViewModel() {
      var _this = this;
      this.events = ko.observableArray();
      $.getJSON('../api/events', function(data) {
        return _this.events(data.slice(0, 3));
      });
    }

    return EventsViewModel;

  })();

  $(function() {
    return ko.applyBindings(new EventsViewModel(), document.getElementById('events'));
  });

}).call(this);
