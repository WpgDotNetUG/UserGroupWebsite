class window.UserGroupEvent

    constructor: (event) ->
        @date    = ko.observable @formatDate(event.Date)
        @venue   = ko.observable event.Venue
        @address = ko.observable event.Address
        @time    = ko.observable @formatTime(event)
        @url     = ko.observable "http://www.eventbrite.ca/event/#{event.Id}"
        @title   = ko.observable event.Title
        @description = ko.observable event.Description?.split('\n')[0..0].join('\n') + "..."

    formatDate: (d) -> d && Date.parse(d).toString('dddd, MMMM dd, yyyy')

    formatTime: (e) -> 
        return unless e.EndDate
        start = Date.parse(e.Date).toString('HH:mm')
        end   = Date.parse(e.EndDate).toString('HH:mm')
        "#{start} to #{end}"

    @findAll: (options) ->
        $.ajax
            type: 'GET'
            url: '../api/events'
            success: options.success
            error: options.error
            complete: options.complete

    @Empty: ->
        new UserGroupEvent
            Date: null
            Venue: null
            Title: null
            Status: null
            EndDate: null
