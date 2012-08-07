
$ ->
	ko.applyBindings(new NewsViewModel(), document.getElementById('news'))
	$('.collapse').collapse()