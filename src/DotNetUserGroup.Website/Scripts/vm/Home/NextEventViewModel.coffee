class window.NextEventViewModel

	constructor: ->
		@title = ko.observable()
		@date = ko.observable()
		@url = ko.observable()
		@description = ko.observable()
		@eventPending = ko.observable(true)
		@loading = ko.observable(true)

		$.getJSON '../api/events', (data) =>
			@loading(false)
			events = (e for e in data when @hasNotHappened(e))
			if events.length
				event = events[0]
				@eventPending(false)
				@date @formatDate(event)
				@url "http://www.eventbrite.ca/event/#{event.Id}"
				@description event.Description
				@title event.Title

	hasNotHappened: (e) ->
		Date.parse(e.Date).compareTo(Date.today()) > 0

	formatDate: (e) ->
		Date.parse(e.Date).toString('MMM dd')