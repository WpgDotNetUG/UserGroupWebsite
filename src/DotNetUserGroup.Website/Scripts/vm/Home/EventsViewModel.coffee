class EventsViewModel

	constructor: ->
		@events = ko.observableArray()
		@nextEvent = ko.observable()

		$.getJSON '../api/events', (data) =>
			es = ({
				Title: e.Title, 
				Date: @parseDate(e.Date)
				Url: "http://www.eventbrite.ca/event/#{e.Id}"
				Address: e.Address
				} for e in data[0..2])
			@events(es)

	parseDate: (d) ->
		str = new Date(Date.parse(d)).toString()
		str.split(' ')[1..2].join(' ')

$ ->
	ko.applyBindings(new EventsViewModel(), document.getElementById('events'))