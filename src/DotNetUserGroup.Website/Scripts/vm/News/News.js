(function() {

  $(function() {
    return ko.applyBindings(new NewsViewModel(), document.getElementById('news'));
  });

}).call(this);
