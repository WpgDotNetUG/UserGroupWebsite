# CoffeeScript
class window.FutureTopic

    constructor: (topic) ->
        @title = ko.observable topic.Topic
        @summary = ko.observable topic.Summary
        @url = ko.observable topic.Url
        
    @findAll: (options) ->
        $.ajax
            type: 'GET'
            url: '../api/topics'
            success: (data) -> options.success(new FutureTopic(e) for e in data)
            error: options.error
            complete: options.complete 