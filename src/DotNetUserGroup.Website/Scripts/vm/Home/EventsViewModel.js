(function() {
  var EventsViewModel;

  EventsViewModel = (function() {

    EventsViewModel.name = 'EventsViewModel';

    function EventsViewModel() {
      var _this = this;
      this.events = ko.observableArray();
      this.nextEvent = ko.observable();
      this.organizerUrl = ko.observable('http://www.eventbrite.com/org/1699161450');
      $.getJSON('../api/events', function(data) {
        var e, es;
        es = (function() {
          var _i, _len, _ref, _results;
          _ref = data.slice(0, 3);
          _results = [];
          for (_i = 0, _len = _ref.length; _i < _len; _i++) {
            e = _ref[_i];
            _results.push({
              Title: e.Title,
              Date: this.parseDate(e.Date),
              Url: "http://www.eventbrite.ca/event/" + e.Id,
              Address: e.Address
            });
          }
          return _results;
        }).call(_this);
        return _this.events(es);
      });
    }

    EventsViewModel.prototype.parseDate = function(d) {
      var str;
      str = new Date(Date.parse(d)).toString();
      return str.split(' ').slice(1, 3).join(' ');
    };

    return EventsViewModel;

  })();

  $(function() {
    return ko.applyBindings(new EventsViewModel(), document.getElementById('events'));
  });

}).call(this);
