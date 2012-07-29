class EventsViewModel

	constructor: ->
		@events = ko.observableArray()
		$.getJSON('../api/events', @events)


$ ->
	ko.applyBindings(new EventsViewModel(), document.getElementById('events'))