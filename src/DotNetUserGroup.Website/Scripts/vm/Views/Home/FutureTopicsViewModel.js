(function() {

  window.FutureTopicsViewModel = (function() {

    function FutureTopicsViewModel() {
      var _this = this;
      this.topics = ko.observableArray();
      $.getJSON('../api/topics', function(data) {
        return _this.topics(data.slice(0, 5));
      });
    }

    return FutureTopicsViewModel;

  })();

}).call(this);
