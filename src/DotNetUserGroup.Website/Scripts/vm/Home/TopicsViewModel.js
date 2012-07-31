(function() {
  var TopicsViewModel;

  TopicsViewModel = (function() {

    TopicsViewModel.name = 'TopicsViewModel';

    function TopicsViewModel() {
      var _this = this;
      this.topics = ko.observableArray();
      $.getJSON('../api/topics', function(data) {
        return _this.topics(data.slice(0, 3));
      });
    }

    return TopicsViewModel;

  })();

  $(function() {
    return ko.applyBindings(new TopicsViewModel(), document.getElementById('topics'));
  });

}).call(this);
