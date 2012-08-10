(function() {

  window.EventsViewModel = (function() {

    EventsViewModel.name = 'EventsViewModel';

    function EventsViewModel() {
      var _this = this;
      this.events = ko.observableArray();
      this.organizerUrl = ko.observable('http://www.eventbrite.com/org/1699161450');
      $.getJSON('../api/events', function(data) {
        var e, es;
        es = (function() {
          var _i, _len, _results;
          _results = [];
          for (_i = 0, _len = data.length; _i < _len; _i++) {
            e = data[_i];
            if (Date.parse(e.Date).compareTo(Date.today()) < 0) {
              _results.push({
                Title: e.Title,
                Date: Date.parse(e.Date).toString('MMM dd'),
                Url: "http://www.eventbrite.ca/event/" + e.Id,
                Address: e.Address
              });
            }
          }
          return _results;
        })();
        return _this.events(es.slice(0, 3));
      });
    }

    return EventsViewModel;

  })();

}).call(this);
