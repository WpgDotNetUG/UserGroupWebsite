class window.NextEventViewModel

    constructor: ->
        @event = ko.observable UserGroupEvent.Empty()
        @eventPending = ko.observable(true)
        @loading = ko.observable(true)

        UserGroupEvent.findAll
          success: @processResult
          complete: => @loading false

    processResult:(data, status, jqXHR) =>
        events = (e for e in data when @hasNotHappened(e))
        if events.length
            @event = new UserGroupEvent(events[0])
            @eventPending(false)
                 
    hasNotHappened: (e) -> Date.parse(e.Date).compareTo(Date.today()) > 0

