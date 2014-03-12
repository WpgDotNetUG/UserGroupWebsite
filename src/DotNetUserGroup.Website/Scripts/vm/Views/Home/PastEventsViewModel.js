(function() {
  var __bind = function(fn, me){ return function(){ return fn.apply(me, arguments); }; };

  window.PastEventsViewModel = (function() {

    function PastEventsViewModel() {
      this.loadPastEvents = __bind(this.loadPastEvents, this);
      this.events = ko.observableArray();
      this.organizerUrl = ko.observable('http://www.eventbrite.com/org/1699161450');
      UserGroupEvent.findAll({
        success: this.loadPastEvents
      });
    }

    PastEventsViewModel.prototype.loadPastEvents = function(events) {
      var completed, e;
      completed = (function() {
        var _i, _len, _results;
        _results = [];
        for (_i = 0, _len = events.length; _i < _len; _i++) {
          e = events[_i];
          if (e.isCompleted()) {
            _results.push(e);
          }
        }
        return _results;
      })();
      return this.events(completed.slice(0, 3));
    };

    return PastEventsViewModel;

  })();

}).call(this);
