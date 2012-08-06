(function() {

  window.NewsViewModel = (function() {

    NewsViewModel.name = 'NewsViewModel';

    function NewsViewModel(limit) {
      var _this = this;
      if (limit == null) {
        limit = -1;
      }
      this.news = ko.observableArray();
      $.getJSON('../api/news', function(data) {
        return _this.news(data.slice(0, (limit === -1 ? -1 : limit - 1) + 1 || 9e9));
      });
    }

    return NewsViewModel;

  })();

}).call(this);
