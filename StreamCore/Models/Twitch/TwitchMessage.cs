﻿using StreamCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StreamCore.Models.Twitch
{
    public class TwitchMessage : IChatMessage
    {
        /// <summary>
        /// The actual message, if one exists for the current message Type.
        /// </summary>
        public string Message { get; internal set; }

        /// <summary>
        /// Whether or not the message is an action (/me) message
        /// </summary>
        public bool IsActionMessage { get; internal set; }

        /// <summary>
        /// The IRC message type for this TwitchMessage
        /// </summary>
        public string Type { get; internal set; }

        /// <summary>
        /// A reference to the TwitchUser that send this message
        /// </summary>
        public IChatUser Sender { get; internal set; }

        /// <summary>
        /// A reference to the TwitchChannel that this message was received in
        /// </summary>
        public IChatChannel Channel { get; internal set; }

        /// <summary>
        /// Info about any emotes that are in this message
        /// </summary>
        public IChatEmote[] Emotes { get; internal set; }

        /// <summary>
        /// Any metadata fields associated with the current TwitchMessage, such as user color, channel info, etc.
        /// </summary>
        public ReadOnlyDictionary<string, string> Metadata { get; internal set; }
    }
}
