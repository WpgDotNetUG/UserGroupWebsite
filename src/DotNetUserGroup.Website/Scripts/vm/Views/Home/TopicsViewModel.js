(function() {
  window.TopicsViewModel = (function() {
    function TopicsViewModel() {
      var _this = this;

      this.topics = ko.observableArray();
      $.getJSON('../api/topics', function(data) {
        return _this.topics(data.slice(0, 5));
      });
    }

    return TopicsViewModel;

  })();

}).call(this);
