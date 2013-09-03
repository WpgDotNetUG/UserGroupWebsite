class window.EventsViewModel

    constructor: ->
        @events = ko.observableArray()
        @organizerUrl = ko.observable('http://www.eventbrite.com/org/1699161450')

        $.getJSON '../api/events', @processResult

    processResult: (data) =>
        es = (@mapEvent(e) for e in data when Date.parse(e.Date).compareTo(Date.today()) < 0)
        @events(es[0..2])

    mapEvent: (e) =>
     result =
        Title: e.Title
        Date: Date.parse(e.Date).toString('MMM dd')
        Url: "http://www.eventbrite.ca/event/#{e.Id}"
        Address: e.Address
 
                 
