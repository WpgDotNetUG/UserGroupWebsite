class NewsViewModel

	constructor: ->
		@news = ko.observableArray()
		$.getJSON '../api/news', (data) => @news(data[0..2])

$ ->
	ko.applyBindings(new NewsViewModel(), document.getElementById('news'))