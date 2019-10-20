using System;
using System.Configuration;
using AppSettingSample.Configs;

namespace AppSettingSample
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var pluginsSection = PluginsSection.GetSection();

            var pre = pluginsSection.PrePlugins;
            show(pre);

            var post = pluginsSection.PostPlugins;
            show(post);
        }

        private static void show(PluginCollection cec)
        {
            foreach(var ce in cec)
            {
                var pe = ce as PluginElement;
                Console.WriteLine(pe.AssemblyName);
            }
        }
    }
}
