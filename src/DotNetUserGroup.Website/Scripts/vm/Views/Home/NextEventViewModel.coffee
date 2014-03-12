class window.NextEventViewModel

    constructor: ->
        @event = ko.observable UserGroupEvent.Empty()
        @topics = ko.observableArray()
        @loading = ko.observable true
        @eventPending = ko.observable true

        UserGroupEvent.findAll
          success: @loadNextEvent
          complete: => @loading false
          
        FutureTopic.findAll
          success: @loadTopics
          complete: => @loading false

    loadNextEvent: (events) =>
        liveEvents = (e for e in events when e.isLive())
        @eventPending liveEvents.length == 0
        @event liveEvents[liveEvents.length - 1] unless @eventPending()
        
    loadTopics: (topics) =>
      @topics(topics[0..7])
      $('.sy-list').slippry(adaptiveHeight: false)
                 

