// plugin-interface-host
// MainWindow.xaml.cs
//  
// Created by Ryan Wilson.
// Copyright (c) 2010-2012, Ryan Wilson. All rights reserved.

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using plugin_interface_host.Classes;
using plugin_interface_host.Models;
using plugin_interface_host.Properties;

namespace plugin_interface_host
{
    /// <summary>
    ///   Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static MainWindow View;

        public MainWindow()
        {
            InitializeComponent();
            // Insert code required on object creation below this point.
            View = this;
            Title = "plugin-interface-host : Current";
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var s = new Style();
            s.Setters.Add(new Setter(VisibilityProperty, Visibility.Collapsed));
            View.MainWindowTC.ItemContainerStyle = s;

            Entry.Instance.Plugins.LoadPlugins(Directory.GetCurrentDirectory() + @"\Plugins");
            foreach (PluginInstance v in Entry.Instance.Plugins.Loaded)
            {
                var groupbox = new GroupBox {Header = v.Instance.Name};
                var sp = new StackPanel {Name = Name = v.Instance.Name + "PI"};
                sp.Children.Add(new Label {Content = String.Format("Description: {0}", v.Instance.Description)});
                sp.Children.Add(new Label {Content = String.Format("Author: {0}", v.Instance.Author)});
                sp.Children.Add(new Label {Content = String.Format("Version: {0}", v.Instance.Version)});
                groupbox.Content = sp;
                PluginsView.Contents.Children.Add(groupbox);
            }
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            Settings.Default.Save();
        }

        private void MetroWindow_StateChanged(object sender, EventArgs e)
        {
        }
    }
}