// PluginSample
// PluginException.cs
//  
// Created by Ryan Wilson.
// Copyright (c) 2010-2012, Ryan Wilson. All rights reserved.

using System;

namespace PluginSample
{
    public class PluginException : Exception
    {
        public PluginException(string message) : base(message)
        {
        }
    }
}