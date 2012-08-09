(function() {

  window.NextEventViewModel = (function() {

    NextEventViewModel.name = 'NextEventViewModel';

    function NextEventViewModel() {
      var _this = this;
      this.title = ko.observable();
      this.date = ko.observable();
      this.url = ko.observable();
      this.description = ko.observable();
      $.getJSON('../api/events', function(data) {
        var e, event;
        event = ((function() {
          var _i, _len, _results;
          _results = [];
          for (_i = 0, _len = data.length; _i < _len; _i++) {
            e = data[_i];
            if (this.hasNotHappened(e)) {
              _results.push(e);
            }
          }
          return _results;
        }).call(_this))[0];
        _this.date(_this.formatDate(event));
        _this.url("http://www.eventbrite.ca/event/" + event.Id);
        _this.description(event.Description);
        return _this.title(event.Title);
      });
    }

    NextEventViewModel.prototype.hasNotHappened = function(e) {
      return Date.parse(e.Date).compareTo(Date.today()) > 0;
    };

    NextEventViewModel.prototype.formatDate = function(e) {
      return Date.parse(e.Date).toString('MMM dd');
    };

    return NextEventViewModel;

  })();

}).call(this);
