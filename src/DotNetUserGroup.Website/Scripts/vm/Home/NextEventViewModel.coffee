class window.NextEventViewModel

	constructor: ->
		@title = ko.observable()
		@date = ko.observable()
		@url = ko.observable()
		@description = ko.observable()

		$.getJSON '../api/events', (data) =>
			event = (e for e in data when @hasNotHappened(e))[0]
			@date @formatDate(event)
			@url "http://www.eventbrite.ca/event/#{event.Id}"
			@description event.Description
			@title event.Title

	hasNotHappened: (e) ->
		Date.parse(e.Date).compareTo(Date.today()) > 0

	formatDate: (e) ->
		Date.parse(e.Date).toString('MMM dd')