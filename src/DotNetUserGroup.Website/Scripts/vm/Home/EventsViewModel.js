(function() {
  var __bind = function(fn, me){ return function(){ return fn.apply(me, arguments); }; };

  window.EventsViewModel = (function() {
    function EventsViewModel() {
      this.mapEvent = __bind(this.mapEvent, this);
      this.processResult = __bind(this.processResult, this);      this.events = ko.observableArray();
      this.organizerUrl = ko.observable('http://www.eventbrite.com/org/1699161450');
      $.getJSON('../api/events', this.processResult);
    }

    EventsViewModel.prototype.processResult = function(data) {
      var e, es;

      es = (function() {
        var _i, _len, _results;

        _results = [];
        for (_i = 0, _len = data.length; _i < _len; _i++) {
          e = data[_i];
          if (Date.parse(e.Date).compareTo(Date.today()) < 0) {
            _results.push(this.mapEvent(e));
          }
        }
        return _results;
      }).call(this);
      return this.events(es.slice(0, 3));
    };

    EventsViewModel.prototype.mapEvent = function(e) {
      var result;

      return result = {
        Title: e.Title,
        Date: Date.parse(e.Date).toString('MMM dd'),
        Url: "http://www.eventbrite.ca/event/" + e.Id,
        Address: e.Address
      };
    };

    return EventsViewModel;

  })();

}).call(this);
