class EventsViewModel

	constructor: ->
		@events = ko.observableArray()
		$.getJSON '../api/events', (data) => @events(data[0..2])

$ ->
	ko.applyBindings(new EventsViewModel(), document.getElementById('events'))