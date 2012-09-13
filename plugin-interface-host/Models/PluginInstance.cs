// plugin-interface-host
// PluginInstance.cs
//  
// Created by Ryan Wilson.
// Copyright (c) 2010-2012, Ryan Wilson. All rights reserved.

using IPluginInterface;

namespace plugin_interface_host.Models
{
    public class PluginInstance
    {
        public PluginInstance()
        {
            AssemblyPath = "";
        }

        public Interface.IPlugin Instance { get; set; }
        public string AssemblyPath { get; set; }
    }
}