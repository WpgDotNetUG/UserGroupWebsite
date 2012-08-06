class window.TopicsViewModel

	constructor: ->
		@topics = ko.observableArray()
		$.getJSON '../api/topics', (data) => @topics(data[0..2])

