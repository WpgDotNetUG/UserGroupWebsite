class window.PastEventsViewModel

    constructor: ->
        @events = ko.observableArray()
        @organizerUrl = ko.observable('http://www.eventbrite.com/org/1699161450')
        UserGroupEvent.findAll
          success: @loadPastEvents

    loadPastEvents: (events) =>
        es = (e for e in events when @isInThePast(e))
        @events(es[0..2])

    isInThePast: (e) => e.date()?.compareTo(Date.today()) < 0
 
                 