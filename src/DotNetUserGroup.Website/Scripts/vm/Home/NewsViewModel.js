(function() {
  var NewsViewModel;

  NewsViewModel = (function() {

    NewsViewModel.name = 'NewsViewModel';

    function NewsViewModel() {
      var _this = this;
      this.news = ko.observableArray();
      $.getJSON('../api/news', function(data) {
        return _this.news(data.slice(0, 3));
      });
    }

    return NewsViewModel;

  })();

  $(function() {
    return ko.applyBindings(new NewsViewModel(), document.getElementById('news'));
  });

}).call(this);
