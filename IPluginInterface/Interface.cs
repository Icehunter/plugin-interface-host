// IPluginInterface
// Interface.cs
//  
// Created by Ryan Wilson.
// Copyright (c) 2010-2012, Ryan Wilson. All rights reserved.

using System.Collections.Generic;

namespace IPluginInterface
{
    public static class Interface
    {
        /// <summary>
        /// </summary>
        public interface IPlugin
        {
            IPluginHost Host { get; set; }
            string Name { get; }
            string Description { get; }
            string Author { get; }
            string Version { get; }
            string Notice { get; }
            //Exception Trace { get; }
            void Initialize();
            void Dispose();
            void PeformCheck(IEnumerable<object> args, out bool result);
        }

        public interface IPluginHost
        {
        }
    }
}