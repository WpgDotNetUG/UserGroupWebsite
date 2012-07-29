(function() {
  var TopicsViewModel;

  TopicsViewModel = (function() {

    TopicsViewModel.name = 'TopicsViewModel';

    function TopicsViewModel() {
      this.topics = ko.observableArray();
      $.getJSON('../api/topics', this.topics);
    }

    return TopicsViewModel;

  })();

  $(function() {
    return ko.applyBindings(new TopicsViewModel(), document.getElementById('topics'));
  });

}).call(this);
