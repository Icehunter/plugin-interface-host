﻿// plugin-interface-host
// StatusVM.cs
//  
// Created by Ryan Wilson.
// Copyright (c) 2010-2012, Ryan Wilson. All rights reserved.

using System;
using System.Windows.Input;
using plugin_interface_host.Classes.Commands;

namespace plugin_interface_host.ViewModels
{
    public class StatusVM
    {
        public ICommand SomeCommand { get; private set; }

        public StatusVM()
        {
            SomeCommand = new DelegateCommand(SomeFunction);
        }

        #region GUI Functions

        private static void SomeFunction()
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        #endregion
    }
}