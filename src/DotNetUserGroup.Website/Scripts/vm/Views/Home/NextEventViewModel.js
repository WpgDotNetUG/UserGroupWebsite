(function() {
  var __bind = function(fn, me){ return function(){ return fn.apply(me, arguments); }; };

  window.NextEventViewModel = (function() {

    function NextEventViewModel() {
      this.loadNextEvent = __bind(this.loadNextEvent, this);

      var _this = this;
      this.event = ko.observable(UserGroupEvent.Empty());
      this.loading = ko.observable(true);
      this.eventPending = ko.observable(true);
      UserGroupEvent.findAll({
        success: this.loadNextEvent,
        complete: function() {
          return _this.loading(false);
        }
      });
    }

    NextEventViewModel.prototype.loadNextEvent = function(events) {
      var e, liveEvents;
      liveEvents = (function() {
        var _i, _len, _results;
        _results = [];
        for (_i = 0, _len = events.length; _i < _len; _i++) {
          e = events[_i];
          if (e.isLive()) {
            _results.push(e);
          }
        }
        return _results;
      })();
      this.eventPending(liveEvents.length === 0);
      if (!this.eventPending()) {
        return this.event(liveEvents[liveEvents.length - 1]);
      }
    };

    return NextEventViewModel;

  })();

}).call(this);
