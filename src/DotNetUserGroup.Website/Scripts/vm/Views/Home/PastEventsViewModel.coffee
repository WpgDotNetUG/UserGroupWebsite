class window.PastEventsViewModel

    constructor: ->
      @events = ko.observableArray()
      @organizerUrl = ko.observable('http://www.eventbrite.com/org/1699161450')
      UserGroupEvent.findAll(success: @loadPastEvents)

    loadPastEvents: (events) =>
      completed = (e for e in events when e.isCompleted())
      @events completed[0..2]

 
                 