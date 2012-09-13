// plugin-interface-host
// MainWindowVM.cs
//  
// Created by Ryan Wilson.
// Copyright (c) 2010-2012, Ryan Wilson. All rights reserved.

using System.Windows.Input;
using plugin_interface_host.Classes.Commands;

namespace plugin_interface_host.ViewModels
{
    public class MainWindowVM
    {
        private static string _currentView = "status";
        public ICommand SwitchViewCommand { get; private set; }

        public MainWindowVM()
        {
            SwitchViewCommand = new DelegateCommand<string>(SwitchView);
        }

        #region GUI Functions

        /// <summary>
        /// </summary>
        /// <param name="t"> </param>
        public static void SwitchView(string t)
        {
            if (_currentView == t)
            {
                return;
            }
            switch (t)
            {
                case "status":
                    MainWindow.View.MainWindowTC.SelectedItem = MainWindow.View.MainWindowTC.FindName("StatusTI");
                    MainWindow.View.Title = "plugin-interface-host : Current";
                    break;
                case "plugins":
                    MainWindow.View.MainWindowTC.SelectedItem = MainWindow.View.MainWindowTC.FindName("PluginsTI");
                    MainWindow.View.Title = "plugin-interface-host : Loaded Plugins";
                    break;
                case "about":
                    MainWindow.View.MainWindowTC.SelectedItem = MainWindow.View.MainWindowTC.FindName("AboutTI");
                    MainWindow.View.Title = "plugin-interface-host : About";
                    break;
            }
            _currentView = t;
        }

        #endregion
    }
}