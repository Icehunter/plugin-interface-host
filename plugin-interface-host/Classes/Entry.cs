// plugin-interface-host
// Entry.cs
//  
// Created by Ryan Wilson.
// Copyright (c) 2010-2012, Ryan Wilson. All rights reserved.

using plugin_interface_host.Models;

namespace plugin_interface_host.Classes
{
    public class Entry
    {
        private static Entry _instance;
        internal PluginContainer Plugins = new PluginContainer();

        /// <summary>
        /// </summary>
        public static Entry Instance
        {
            get { return _instance ?? (_instance = new Entry()); }
        }

        /// <summary>
        /// </summary>
        private Entry()
        {
        }
    }
}