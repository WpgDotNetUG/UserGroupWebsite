(function() {
  var __bind = function(fn, me){ return function(){ return fn.apply(me, arguments); }; };

  window.FutureTopicsViewModel = (function() {

    function FutureTopicsViewModel() {
      this.loadTopics = __bind(this.loadTopics, this);

      var _this = this;
      this.topics = ko.observableArray();
      this.loading = ko.observable(true);
      FutureTopic.findAll({
        success: this.loadTopics,
        complete: function() {
          return _this.loading(false);
        }
      });
    }

    FutureTopicsViewModel.prototype.loadTopics = function(topics) {
      return this.topics(topics.slice(0, 5));
    };

    return FutureTopicsViewModel;

  })();

}).call(this);
