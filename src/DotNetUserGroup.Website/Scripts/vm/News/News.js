(function() {

  $(function() {
    ko.applyBindings(new NewsViewModel(), document.getElementById('news'));
    return $('.collapse').collapse();
  });

}).call(this);
