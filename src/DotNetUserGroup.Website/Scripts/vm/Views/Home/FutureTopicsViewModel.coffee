class window.FutureTopicsViewModel

	constructor: ->
		@topics = ko.observableArray()
		@loading = ko.observable true
		
		FutureTopic.findAll
          success: @loadTopics
          done: => @loading false
		
	loadTopics: (topics) =>
	  @topics topics[0..4]
