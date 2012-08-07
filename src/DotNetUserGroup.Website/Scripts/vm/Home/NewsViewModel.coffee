class window.NewsViewModel

	constructor: (limit = -1) ->
		@news = ko.observableArray()
		$.getJSON '../api/news', (data) => 
			es = ({
				Title: e.Title 
				Date: @parseDate(e.Date)
				Body: e.Body
			} for e in data[0..(if limit == -1 then -1 else limit - 1)])
			@news(es)

	parseDate: (d) ->
		str = new Date(Date.parse(d)).toString()
		str.split(' ')[1..2].join(' ')
