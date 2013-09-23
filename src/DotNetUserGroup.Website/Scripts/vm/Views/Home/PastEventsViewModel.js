(function() {
  var __bind = function(fn, me){ return function(){ return fn.apply(me, arguments); }; };

  window.PastEventsViewModel = (function() {

    function PastEventsViewModel() {
      this.isInThePast = __bind(this.isInThePast, this);

      this.loadPastEvents = __bind(this.loadPastEvents, this);
      this.events = ko.observableArray();
      this.organizerUrl = ko.observable('http://www.eventbrite.com/org/1699161450');
      UserGroupEvent.findAll({
        success: this.loadPastEvents
      });
    }

    PastEventsViewModel.prototype.loadPastEvents = function(events) {
      var e, es;
      es = (function() {
        var _i, _len, _results;
        _results = [];
        for (_i = 0, _len = events.length; _i < _len; _i++) {
          e = events[_i];
          if (this.isInThePast(e)) {
            _results.push(e);
          }
        }
        return _results;
      }).call(this);
      return this.events(es.slice(0, 3));
    };

    PastEventsViewModel.prototype.isInThePast = function(e) {
      var _ref;
      return ((_ref = e.date()) != null ? _ref.compareTo(Date.today()) : void 0) < 0;
    };

    return PastEventsViewModel;

  })();

}).call(this);
