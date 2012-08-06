class window.NewsViewModel

	constructor: (limit = -1) ->
		@news = ko.observableArray()
		$.getJSON '../api/news', (data) => @news(data[0..(if limit == -1 then -1 else limit - 1)])

