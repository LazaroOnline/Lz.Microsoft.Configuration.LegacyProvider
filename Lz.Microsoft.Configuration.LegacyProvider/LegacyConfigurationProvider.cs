using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace Lz.Microsoft.Configuration.LegacyProvider
{
    /// <summary>
    /// Configuration provider for IConfigurationBuilder that adds the config from the old web.config/app.config legacy configurations.
    /// </summary>
    public class LegacyConfigurationProvider : ConfigurationProvider, IConfigurationSource
    {
        private IEnumerable<string> _sectionDelimiters = new String[] { ".", ",", "-"};

        /// <summary>
        /// Configuration provider for IConfigurationBuilder that adds the config from the old web.config/app.config legacy configurations.
        /// </summary>
        /// <param name="sectionDelimiters">Specify what characters will be treated as section delimiters, by default it uses : . , - </param>
        public LegacyConfigurationProvider(IEnumerable<string> sectionDelimiters = null)
        {
            if (sectionDelimiters != null)
            {
                this._sectionDelimiters = sectionDelimiters;
            }
        }

        public override void Load()
        {
            foreach (ConnectionStringSettings connectionString in ConfigurationManager.ConnectionStrings)
            {
                Data.Add($"ConnectionStrings:{connectionString.Name}", connectionString.ConnectionString);
            }

            foreach (var settingKey in ConfigurationManager.AppSettings.AllKeys)
            {
                var settingKeyWithDelimiters = Regex.Replace(settingKey, "[" + Regex.Escape(String.Join("", _sectionDelimiters)) + "]", ":");
                Data.Add(settingKeyWithDelimiters, ConfigurationManager.AppSettings[settingKey]);
            }
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return this;
        }
    }
}
