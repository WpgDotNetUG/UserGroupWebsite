class window.UserGroupEvent

    constructor: (event) ->
        @date    = ko.observable @formatDate(event.Date)
        @venue   = ko.observable event.Venue
        @address = ko.observable event.Address
        @time    = ko.observable @formatTime(event.Date)
        @url     = ko.observable "http://www.eventbrite.ca/event/#{event.Id}"
        @title   = ko.observable event.Title
        @description = ko.observable event.Description?.split('\n')[0..0].join('\n') + "..."

    formatDate: (d) -> d && Date.parse(d).toString('dddd, MMMM dd, yyyy')
    formatTime: (d) -> d && Date.parse(d).toString('HH:mm')

    @Empty: ->
        new UserGroupEvent
            Date: null
            Venue: null
            Title: null
            Status: null
            EndDate: null
