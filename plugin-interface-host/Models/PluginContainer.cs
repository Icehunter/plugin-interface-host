// plugin-interface-host
// PluginContainer.cs
//  
// Created by Ryan Wilson.
// Copyright (c) 2010-2012, Ryan Wilson. All rights reserved.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using IPluginInterface;
using NLog;

namespace plugin_interface_host.Models
{
    public class PluginContainer : Interface.IPluginHost
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly CollectionHelper _plugins = new CollectionHelper();

        /// <summary>
        ///   collection of loaded plugins
        /// </summary>
        public CollectionHelper Loaded
        {
            get { return _plugins; }
        }

        /// <summary>
        ///   load all plugins in path
        /// </summary>
        /// <param name="path"> </param>
        public void LoadPlugins(string path = "")
        {
            //setup default path if none provided
            path = (path == "") ? AppDomain.CurrentDomain.BaseDirectory : path;

            //clear the collection
            _plugins.Clear();

            //get list of files in directory
            var files = Directory.GetFiles(path);

            //iterate through file list adding all valid plugins
            foreach (var f in from f in files let file = new FileInfo(f) where file.Extension.ToLower().Equals(".dll") select f)
            {
                VerifyPlugin(f);
            }
        }

        /// <summary>
        ///   Close and clean all programs that are loaded
        /// </summary>
        public void UnloadPlugins()
        {
            foreach (PluginInstance p in _plugins)
            {
                if (p.Instance != null)
                {
                    //call plugin's built-in dispose
                    p.Instance.Dispose();
                }
                p.Instance = null;
            }

            //clear our collection after plugins dispose themselves
            _plugins.Clear();
        }

        /// <summary>
        ///   Verify plugin interface and add to our main assembly
        /// </summary>
        /// <param name="fileName"> </param>
        private void VerifyPlugin(string fileName)
        {
            try
            {
                //load plugin to assembly
                var pAssembly = Assembly.LoadFile(fileName);

                //get assembly type
                var pType = pAssembly.GetType(pAssembly.GetName().Name + ".Plugin");

                //check if plugin implements IPlugin interface
                var implementsIPlugin = typeof (Interface.IPlugin).IsAssignableFrom(pType);
                if (implementsIPlugin)
                {
                    //create a new plugin and initialize
                    var plugin = new PluginInstance {AssemblyPath = fileName, Instance = (Interface.IPlugin) Activator.CreateInstance(pType)};

                    //assign plugin host so it can access our main assembly
                    plugin.Instance.Host = this;
                    plugin.Instance.Initialize();

                    //add plugin to the collection
                    _plugins.Add(plugin);

                    //cleanup
                    plugin = null;
                }
                //cleanup
                pAssembly = null;
            }
            catch (Exception ex)
            {
                Logger.Trace(ex.Message);
            }
        }
    }
}