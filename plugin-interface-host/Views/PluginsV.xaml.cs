// plugin-interface-host
// PluginsV.xaml.cs
//  
// Created by Ryan Wilson.
// Copyright (c) 2010-2012, Ryan Wilson. All rights reserved.

namespace plugin_interface_host.Views
{
    /// <summary>
    ///   Interaction logic for PluginsV.xaml
    /// </summary>
    public partial class PluginsV
    {
        public static PluginsV View;

        public PluginsV()
        {
            InitializeComponent();
            // Insert code required on object creation below this point.
            View = this;
        }
    }
}