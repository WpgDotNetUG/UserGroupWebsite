(function() {
  var __bind = function(fn, me){ return function(){ return fn.apply(me, arguments); }; };

  window.UserGroupEvent = (function() {

    function UserGroupEvent(event) {
      this.isCompleted = __bind(this.isCompleted, this);

      this.isDraft = __bind(this.isDraft, this);

      this.isLive = __bind(this.isLive, this);

      var _ref,
        _this = this;
      this.date = ko.observable(event.Date && Date.parse(event.Date));
      this.fDate = ko.computed(function() {
        return _this.formatDate(_this.date());
      });
      this.venue = ko.observable(event.Venue);
      this.address = ko.observable(event.Address);
      this.time = ko.observable(this.formatTime(event));
      this.status = ko.observable(event.Status);
      this.url = ko.observable("http://www.eventbrite.ca/event/" + event.Id);
      this.title = ko.observable(event.Title);
      this.description = ko.observable(((_ref = event.Description) != null ? _ref.split('\n').slice(0, 1).join('\n') : void 0) + "...");
    }

    UserGroupEvent.prototype.isLive = function() {
      return this.status() === 'Live';
    };

    UserGroupEvent.prototype.isDraft = function() {
      return this.status() === 'Draft';
    };

    UserGroupEvent.prototype.isCompleted = function() {
      return this.status() === 'Completed';
    };

    UserGroupEvent.prototype.formatDate = function(d) {
      return d != null ? d.toString('dddd, MMMM dd, yyyy') : void 0;
    };

    UserGroupEvent.prototype.formatTime = function(e) {
      var end, start;
      if (!e.EndDate) {
        return;
      }
      start = Date.parse(e.Date).toString('HH:mm');
      end = Date.parse(e.EndDate).toString('HH:mm');
      return "" + start + " to " + end;
    };

    UserGroupEvent.findAll = function(options) {
      return $.ajax({
        type: 'GET',
        url: '../api/events',
        success: function(data) {
          var e;
          return options.success((function() {
            var _i, _len, _results;
            _results = [];
            for (_i = 0, _len = data.length; _i < _len; _i++) {
              e = data[_i];
              _results.push(new UserGroupEvent(e));
            }
            return _results;
          })());
        },
        error: options.error,
        complete: options.complete
      });
    };

    UserGroupEvent.Empty = function() {
      return new UserGroupEvent({
        Date: null,
        Venue: null,
        Title: null,
        Status: null,
        EndDate: null
      });
    };

    return UserGroupEvent;

  })();

}).call(this);
