// PluginSample
// Plugin.cs
//  
// Created by Ryan Wilson.
// Copyright (c) 2010-2012, Ryan Wilson. All rights reserved.

using System;
using System.Collections.Generic;
using System.Reflection;
using IPluginInterface;

namespace PluginSample
{
    public class Plugin : Interface.IPlugin
    {
        #region Implementation of IPlugin

        public Interface.IPluginHost Host { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string Author { get; private set; }

        public string Version { get; private set; }

        public string Notice { get; private set; }

        //public Exception Trace { get; private set; }

        /// <summary>
        ///   initialize plugin data
        /// </summary>
        public void Initialize()
        {
            Name = "Sample";
            Description = "Sample Plugin";
            Author = "Author";
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Notice = "";
        }

        /// <summary>
        ///   dipose anything needed here
        /// </summary>
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        ///   status check; returns true/false and status message
        ///   on error returns Exception Trace
        /// </summary>
        /// <param name="args"> </param>
        /// <param name="result"> </param>
        public void PeformCheck(IEnumerable<object> args, out bool result)
        {
            var success = false;
            try
            {
                //do your stuff here

                //assign success only if code passes
                success = true;

                //setup success return variables
                switch (success)
                {
                    case true:
                        Notice = "Success";
                        break;
                    case false:
                        //throw your own error
                        throw new PluginException("why it failed");
                }
                result = success;
                return;
            }
            catch (PluginException ex)
            {
                //setup non-critical error return variables
                Notice = ex.Message;
                //Trace = ex;
            }
            catch (Exception ex)
            {
                //setup critical error return variables
                Notice = ex.Message;
                //Trace = ex;
            }
            result = false;
        }

        #endregion
    }
}