(function() {
  var __bind = function(fn, me){ return function(){ return fn.apply(me, arguments); }; };

  window.NextEventViewModel = (function() {

    function NextEventViewModel() {
      this.loadTopics = __bind(this.loadTopics, this);

      this.loadNextEvent = __bind(this.loadNextEvent, this);

      var _this = this;
      this.event = ko.observable(UserGroupEvent.Empty());
      this.eventPending = ko.observable(true);
      this.loading = ko.observable(true);
      this.topics = ko.observableArray();
      UserGroupEvent.findAll({
        success: this.loadNextEvent,
        complete: function() {
          return _this.loading(false);
        }
      });
      FutureTopic.findAll({
        success: this.loadTopics,
        complete: function() {
          return _this.loading(false);
        }
      });
    }

    NextEventViewModel.prototype.loadNextEvent = function(events) {
      var e, nextEvents;
      nextEvents = (function() {
        var _i, _len, _results;
        _results = [];
        for (_i = 0, _len = events.length; _i < _len; _i++) {
          e = events[_i];
          if (this.hasNotHappened(e)) {
            _results.push(e);
          }
        }
        return _results;
      }).call(this);
      this.eventPending(nextEvents.length === 0);
      if (!this.eventPending()) {
        return this.event(nextEvents[0]);
      }
    };

    NextEventViewModel.prototype.loadTopics = function(topics) {
      return this.topics(topics.slice(0, 4));
    };

    NextEventViewModel.prototype.hasNotHappened = function(e) {
      var _ref;
      return ((_ref = e.date()) != null ? _ref.compareTo(Date.today()) : void 0) > 0;
    };

    return NextEventViewModel;

  })();

}).call(this);
