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
        var e, es;
        es = (function() {
          var _i, _len, _ref, _results;
          _ref = data.slice(0, (limit === -1 ? -1 : limit - 1) + 1 || 9e9);
          _results = [];
          for (_i = 0, _len = _ref.length; _i < _len; _i++) {
            e = _ref[_i];
            _results.push({
              Title: e.Title,
              Date: this.parseDate(e.Date),
              Body: e.Body
            });
          }
          return _results;
        }).call(_this);
        return _this.news(es);
      });
    }

    NewsViewModel.prototype.parseDate = function(d) {
      var str;
      str = new Date(Date.parse(d)).toString();
      return str.split(' ').slice(1, 3).join(' ');
    };

    return NewsViewModel;

  })();

}).call(this);
