(function() {
  window.UserGroupEvent = (function() {
    function UserGroupEvent(event) {
      var _ref;

      this.date = ko.observable(this.formatDate(event.Date));
      this.venue = ko.observable(event.Venue);
      this.address = ko.observable(event.Address);
      this.time = ko.observable(this.formatTime(event.Date));
      this.url = ko.observable("http://www.eventbrite.ca/event/" + event.Id);
      this.title = ko.observable(event.Title);
      this.description = ko.observable(((_ref = event.Description) != null ? _ref.split('\n').slice(0, 1).join('\n') : void 0) + "...");
    }

    UserGroupEvent.prototype.formatDate = function(d) {
      return d && Date.parse(d).toString('dddd, MMMM dd, yyyy');
    };

    UserGroupEvent.prototype.formatTime = function(d) {
      return d && Date.parse(d).toString('HH:mm');
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
