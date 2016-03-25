/**
 * @fileoverview Youtube Channel Loader For Wordpress using the Youtube API and
 *   jQuery
 * @autor Jorge Vivas
 * @version 0.0.1
 * @requires jQuery 2.1.2 | Youtube API 2.1
 */

 /* global gapi */
(function() {

  var YTChannel = function() {
      this.initialize.apply(this, arguments);
    };

  // Make YTC available globally
  window.YTChannel = YTChannel;

  $.extend(YTChannel.prototype, {

    MAX_RESULTS: 10,

    /**
     * Builds the fetching feed url
     * @param {String} section
     * @return {String}
     */
    url: function() {
      var yt = 'https://www.googleapis.com/youtube/v3/search',
        options = '?order=date&part=snippet',
        channel = '&channelId=' + this.getChannel(),
        apiKey = '&key=' + this.getApiKey();

      // Set max results
      // @todo Make a helper to build the Query Params
      options += '&max-results=' + this.maxResults;

      return yt + options + channel + apiKey;
    },

    /**
     * Starts the app and pass the options
     * @param {Object} options
     * @param {String} options.channel
     */
    initialize: function(options) {
      options = options || {};

      var channel = options.channel || this.channel,
        apiKey = options.apiKey || this.apiKey;

      // Set channel from the options
      if (channel) {
        this.setChannel(channel);
      } else {
        throw 'Channel name is required';
      }

      if (apiKey) {
        this.setApiKey(apiKey);
      } else {
        throw 'Api Key must be set';
      }

      this.maxResults = options.maxResults || this.MAX_RESULTS;

      this.ui = {
        container: $('#ytc-channel'),
        author: $('.ytc-author'),
        lastVideo: $('.ytc-last-video'),
        suscribe: $('#ytc-suscribe')
      };
    },

    /**
     * Async Loading for the Youtube Major API
     */
    loadYoutubeSuscribe: function() {
      var po = document.createElement('script'),
        s = document.getElementsByTagName('script')[0];

      po.type = 'text/javascript';
      po.async = true;
      po.src = 'https://apis.google.com/js/platform.js?onload=YTChannelCallback';
      s.parentNode.insertBefore(po, s);
    },

    renderSuscribe: function() {
      var el = this.ui.suscribe[0],
        options = {
          channel: this.getChannel(),
          layout: 'full'
        };
      gapi.ytsubscribe.render(el, options);
    },

    /**
     * Sets the channel name on the app
     * @param {String} channel
     */
    setChannel: function(channel) {
      this._channel = channel;
    },

    /**
     * Gets the channel name
     * @return {String}
     */
    getChannel: function() {
      return this._channel;
    },

    /**
     * Sets the api key
     * @param {String} channel
     */
    setApiKey: function(apiKey) {
      this._apiKey = apiKey;
    },

    /**
     * Gets the api key
     * @return {String}
     */
    getApiKey: function() {
      return this._apiKey;
    },

    /**
     * XHR Request
     */
    fetchFeed: function() {
      var callback = this.show;
      $.getJSON(this.url(), callback.bind(this));
    },

    /**
     * Takes the data and shows it on the DOM
     * @param {Object} data. Response from the server
     */
    show: function(data) {
      var channelTitle = data.items[0].snippet.channelTitle,
        lastVideo = data.items[0];

      // Channel Title
      this.ui.author.text(channelTitle);

      // Set suscribe
      this.loadYoutubeSuscribe();

      // Set Last Video
      this._setLastVideo(lastVideo);
    },

    /**
     * Builds the last video view
     * @param {Object} data
     */
    _setLastVideo: function(data) {
      var container = this.ui.lastVideo.children('a'),
        title = container.children('h5'),
        img = container.children('img'),
        media = data.snippet.thumbnails.medium.url,
        link = 'http://youtube.com/watch?v=' + data.id.videoId;

      container.attr({
        'href': link,
        'target': '_blank'
      });
      title.text(data.snippet.title);
      img.attr('src', media);
    }
  });
}).call(this);