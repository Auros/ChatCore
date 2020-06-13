﻿using ChatCore.SimpleJSON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ChatCore.Interfaces
{
    public interface IChatChannel
    {
        string Name { get; }
        string Id { get; }
        JSONObject ToJson();
    }
}
