class window.NewsViewModel

    constructor: (@limit = -1) ->
        @news = ko.observableArray()
        @title = ko.observable()
        $.getJSON '../api/news', @loadNews

    loadNews: (data) => 
        max = (if @limit == -1 then -1 else @limit - 1)
        @news(@createNewsItem(e) for e in data[0..max])
        @title @news()[0]?.Title

    createNewsItem: (e) =>
        newsItem =
            Title: e.Title 
            Date: @parseDate(e.Date)
            Body: e.Body
        
    parseDate: (d) ->
        str = new Date(Date.parse(d)).toString()
        str.split(' ')[1..2].join(' ')
