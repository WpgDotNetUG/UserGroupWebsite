class window.FutureTopicsViewModel

	constructor: ->
		@topics = ko.observableArray()
		
		FutureTopic.findAll
          success: @loadTopics
          complete: => @loading false
		
	loadTopics: (topics) =>
	    @topics(topics[0..4])
