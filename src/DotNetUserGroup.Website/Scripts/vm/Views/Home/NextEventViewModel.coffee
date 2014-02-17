class window.NextEventViewModel

    constructor: ->
        @event = ko.observable UserGroupEvent.Empty()
        @eventPending = ko.observable(true)
        @loading = ko.observable(true)
        @topics = ko.observableArray()

        UserGroupEvent.findAll
          success: @loadNextEvent
          complete: => @loading false
          
        FutureTopic.findAll
          success: @loadTopics
          complete: => @loading false

    loadNextEvent: (events) =>
        nextEvents = (e for e in events when @hasNotHappened(e))
        @eventPending(nextEvents.length == 0)
        @event nextEvents[0] unless @eventPending()
        
    loadTopics: (topics) =>
        @topics(topics[0..3])
                 
    hasNotHappened: (e) -> e.date()?.compareTo(Date.today()) > 0

