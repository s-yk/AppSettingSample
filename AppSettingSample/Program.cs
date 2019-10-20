using AppSettingSample.Configs;
using System;

namespace AppSettingSample
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var pluginsSection = PluginsSection.GetSection();

            var pre = pluginsSection.PrePlugins;
            showPlugin(pre);

            var post = pluginsSection.PostPlugins;
            showPlugin(post);

            Console.ReadLine();
            Environment.Exit(0);
        }

        private static void showPlugin(PluginCollection cec)
        {
            foreach(var ce in cec)
            {
                var pe = ce as PluginElement;
                Console.WriteLine("=============================");
                Console.WriteLine($"plugin: {pe.AssemblyName}");
                showParam(pe.Params);
            }
        }

        private static void showParam(ParamCollection pac)
        {
            foreach(var pa in pac)
            {
                var param = pa as ParamElement;
                Console.WriteLine($"param name:{param.Name}, value:{param.Value}");
            }
        }
    }
}
