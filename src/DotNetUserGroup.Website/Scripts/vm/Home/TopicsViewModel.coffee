class TopicsViewModel

	constructor: ->
		@topics = ko.observableArray()
		$.getJSON '../api/topics', (data) => @topics(data[0..2])


$ ->
	ko.applyBindings(new TopicsViewModel(), document.getElementById('topics'))