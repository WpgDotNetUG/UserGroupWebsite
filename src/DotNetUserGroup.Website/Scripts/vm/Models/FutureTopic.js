(function() {

  window.FutureTopic = (function() {

    function FutureTopic(topic) {
      this.title = ko.observable(topic.Topic);
      this.summary = ko.observable(topic.Summary);
      this.url = ko.observable(topic.Url);
    }

    FutureTopic.findAll = function(options) {
      return $.ajax({
        type: 'GET',
        url: '../api/topics',
        success: function(data) {
          var e;
          return options.success((function() {
            var _i, _len, _results;
            _results = [];
            for (_i = 0, _len = data.length; _i < _len; _i++) {
              e = data[_i];
              _results.push(new FutureTopic(e));
            }
            return _results;
          })());
        },
        error: options.error,
        complete: options.complete
      });
    };

    return FutureTopic;

  })();

}).call(this);
