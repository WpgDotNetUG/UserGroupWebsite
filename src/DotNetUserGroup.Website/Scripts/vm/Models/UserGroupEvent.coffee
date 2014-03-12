class window.UserGroupEvent

    constructor: (event) ->
        @date    = ko.observable event.Date && Date.parse(event.Date)
        @fDate   = ko.computed => @formatDate(@date())
        @venue   = ko.observable event.Venue
        @address = ko.observable event.Address
        @time    = ko.observable @formatTime(event)
        @status  = ko.observable event.Status
        @url     = ko.observable "http://www.eventbrite.ca/event/#{event.Id}"
        @title   = ko.observable event.Title
        @description = ko.observable event.Description?.split('\n')[0..0].join('\n') + "..."

    isLive: => @status() == 'Live'
    
    isDraft: => @status() == 'Draft'
    
    isCompleted: => @status() == 'Completed'
      
    formatDate: (d) -> d?.toString('dddd, MMMM dd, yyyy')

    formatTime: (e) -> 
        return unless e.EndDate
        start = Date.parse(e.Date).toString('HH:mm')
        end   = Date.parse(e.EndDate).toString('HH:mm')
        "#{start} to #{end}"

    @findAll: (options) ->
        $.ajax
            type: 'GET'
            url: '../api/events'
            success: (data) -> options.success(new UserGroupEvent(e) for e in data)
            error: options.error
            complete: options.complete

    @Empty: ->
        new UserGroupEvent
            Date: null
            Venue: null
            Title: null
            Status: null
            EndDate: null
