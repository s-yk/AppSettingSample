using System;
using System.Configuration;

namespace AppSettingSample.Configs
{
    #region section
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
    #endregion

    #region elements

    #region plugin
    public class PluginElement : ConfigurationElement
    {
        [ConfigurationProperty("assemblyName")]
        public string AssemblyName
        {
            get
            {
                return base["assemblyName"] as string;
            }
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public ParamCollection Params
        {
            get
            {
                return base[""] as ParamCollection;
            }
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
    #endregion

    #region param
    public class ParamElement : ConfigurationElement
    {
        [ConfigurationProperty("name")]
        public string Name
        {
            get
            {
                return base["name"] as string;
            }
        }

        [ConfigurationProperty("value")]
        public string Value
        {
            get
            {
                return base["value"] as string;
            }
        }
    }

    [ConfigurationCollection(typeof(ParamElement), AddItemName = "param")]
    public class ParamCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ParamElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ParamElement)element).Name;
        }
    }
    #endregion

    #endregion
}
