(function() {
  var __bind = function(fn, me){ return function(){ return fn.apply(me, arguments); }; };

  window.NextEventViewModel = (function() {

    function NextEventViewModel() {
      this.processResult = __bind(this.processResult, this);

      var _this = this;
      this.event = ko.observable(UserGroupEvent.Empty());
      this.eventPending = ko.observable(true);
      this.loading = ko.observable(true);
      UserGroupEvent.findAll({
        success: this.processResult,
        complete: function() {
          return _this.loading(false);
        }
      });
    }

    NextEventViewModel.prototype.processResult = function(data, status, jqXHR) {
      var e, events;
      events = (function() {
        var _i, _len, _results;
        _results = [];
        for (_i = 0, _len = data.length; _i < _len; _i++) {
          e = data[_i];
          if (this.hasNotHappened(e)) {
            _results.push(e);
          }
        }
        return _results;
      }).call(this);
      if (events.length) {
        this.event = new UserGroupEvent(events[0]);
        return this.eventPending(false);
      }
    };

    NextEventViewModel.prototype.hasNotHappened = function(e) {
      return Date.parse(e.Date).compareTo(Date.today()) > 0;
    };

    return NextEventViewModel;

  })();

}).call(this);
