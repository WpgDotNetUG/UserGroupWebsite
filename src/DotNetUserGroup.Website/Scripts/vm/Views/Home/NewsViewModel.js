(function() {
  var __bind = function(fn, me){ return function(){ return fn.apply(me, arguments); }; };

  window.NewsViewModel = (function() {
    function NewsViewModel(limit) {
      this.limit = limit != null ? limit : -1;
      this.createNewsItem = __bind(this.createNewsItem, this);
      this.loadNews = __bind(this.loadNews, this);
      this.news = ko.observableArray();
      this.title = ko.observable();
      $.getJSON('../api/news', this.loadNews);
    }

    NewsViewModel.prototype.loadNews = function(data) {
      var e, max, _ref;

      max = (this.limit === -1 ? -1 : this.limit - 1);
      this.news((function() {
        var _i, _len, _ref, _results;

        _ref = data.slice(0, +max + 1 || 9e9);
        _results = [];
        for (_i = 0, _len = _ref.length; _i < _len; _i++) {
          e = _ref[_i];
          _results.push(this.createNewsItem(e));
        }
        return _results;
      }).call(this));
      return this.title((_ref = this.news()[0]) != null ? _ref.Title : void 0);
    };

    NewsViewModel.prototype.createNewsItem = function(e) {
      var newsItem;

      return newsItem = {
        Title: e.Title,
        Date: this.parseDate(e.Date),
        Body: e.Body
      };
    };

    NewsViewModel.prototype.parseDate = function(d) {
      var str;

      str = new Date(Date.parse(d)).toString();
      return str.split(' ').slice(1, 3).join(' ');
    };

    return NewsViewModel;

  })();

}).call(this);
