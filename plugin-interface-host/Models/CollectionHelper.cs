// plugin-interface-host
// CollectionHelper.cs
//  
// Created by Ryan Wilson.
// Copyright (c) 2010-2012, Ryan Wilson. All rights reserved.

using System.Collections;
using System.Linq;

namespace plugin_interface_host.Models
{
    public class CollectionHelper : CollectionBase
    {
        /// <summary>
        ///   add to collection
        /// </summary>
        /// <param name="plugin"> </param>
        public void Add(PluginInstance plugin)
        {
            List.Add(plugin);
        }

        /// <summary>
        ///   remove from collection
        /// </summary>
        /// <param name="plugin"> </param>
        public void Remove(PluginInstance plugin)
        {
            List.Remove(plugin);
        }

        /// <summary>
        ///   find plugin by name
        /// </summary>
        /// <param name="plugin"> </param>
        /// <returns> </returns>
        public PluginInstance Find(string plugin)
        {
            return List.Cast<PluginInstance>().FirstOrDefault(p => (p.Instance.Name.Equals(plugin)) || p.AssemblyPath.Equals(plugin));
        }
    }
}