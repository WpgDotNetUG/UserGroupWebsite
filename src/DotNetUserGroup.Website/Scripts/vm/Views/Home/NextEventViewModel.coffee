class window.NextEventViewModel

    constructor: ->
        @event = ko.observable UserGroupEvent.Empty()
        @loading = ko.observable true
        @eventPending = ko.observable true

        UserGroupEvent.findAll
          success: @loadNextEvent
          complete: => @loading false

    loadNextEvent: (events) =>
        liveEvents = (e for e in events when e.isLive())
        @eventPending liveEvents.length == 0
        @event liveEvents[liveEvents.length - 1] unless @eventPending()
            

