class TopicsViewModel

	constructor: ->
		@topics = ko.observableArray()
		$.getJSON('../api/topics', @topics)


$ ->
	ko.applyBindings(new TopicsViewModel(), document.getElementById('topics'))