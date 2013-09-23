class window.FutureTopicsViewModel

	constructor: ->
		@topics = ko.observableArray()
		$.getJSON '../api/topics', (data) => @topics(data[0..4])
