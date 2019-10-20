using System;
using System.Configuration;

namespace AppSettingSample.Configs
{
    public class PluginsSection : ConfigurationSection
    {
        public static PluginsSection GetSection()
        {
            return ConfigurationManager.GetSection("plugins") as PluginsSection;
        }

        [ConfigurationProperty("prePlugins")]
        public PluginCollection PrePlugins
        {
            get { return base["prePlugins"] as PluginCollection; }
        }

        [ConfigurationProperty("postPlugins")]
        public PluginCollection PostPlugins
        {
            get { return base["postPlugins"] as PluginCollection; }
        }
    }

    [ConfigurationCollection(typeof(PluginElement), AddItemName = "plugin")]
    public class PluginCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PluginElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PluginElement)element).AssemblyName;
        }
    }

    public class PluginElement : ConfigurationElement
    {
        [ConfigurationProperty("assemblyName")]
        public string AssemblyName {
            get
            {
                return base["assemblyName"] as string;
            }
            set
            {
                this["assemblyName"] = value;
            }
        }
    }
}
