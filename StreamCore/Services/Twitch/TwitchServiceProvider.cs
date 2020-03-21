﻿using Microsoft.Extensions.Logging;
using StreamCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamCore.Services.Twitch
{
    public class TwitchServiceProvider : IStreamingServiceProvider, IDisposable
    {

        public event Action<IChatMessage> OnMessageReceived;

        public TwitchServiceProvider(ILogger<TwitchServiceProvider> logger, TwitchService twitchService, IWebSocketService websocketService)
        {
            _logger = logger;
            _twitchService = twitchService;
            _websocketService = websocketService;
        }

        private ILogger _logger;
        private TwitchService _twitchService;
        private IWebSocketService _websocketService;

        public bool IsRunning { get; private set; } = false;

        public void Start()
        {
            if (IsRunning)
            {
                return;
            }
            IsRunning = true;
            _websocketService.OnOpen += _websocketService_OnOpen; ;
            _websocketService.OnClose += _websocketService_OnClose; ;
            _websocketService.Connect("wss://irc-ws.chat.twitch.tv:443");
            _logger.LogInformation("Started");
        }

        private void _websocketService_OnClose()
        {
            _logger.LogInformation("Twitch connection closed");
        }

        private void _websocketService_OnOpen()
        {
            _logger.LogInformation("Twitch connection opened");
            _websocketService.SendMessage("CAP REQ :twitch.tv/tags twitch.tv/commands twitch.tv/membership");
        }

        public void Stop()
        {
            if (!IsRunning)
            {
                return;
            }
            IsRunning = false;
            _websocketService.Disconnect();
            _logger.LogInformation("Stopped");
        }

        public void Dispose()
        {
            if(IsRunning)
            {
                Stop();
            }
            _logger.LogInformation("Disposed");
        }

        public IStreamingService GetService()
        {
            return _twitchService;
        }
    }
}
