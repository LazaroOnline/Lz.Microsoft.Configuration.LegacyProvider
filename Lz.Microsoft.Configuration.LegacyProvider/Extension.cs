using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Lz.Microsoft.Configuration.LegacyProvider
{
	public static class Extension
	{
		//
		// Summary:
		//     Adds the XML web.config/app.config configuration provider to builder. Specifically "AppSettings" and "ConnectionStrings" sections only.
		//
		// Parameters:
		//   builder:
		//     The Microsoft.Extensions.Configuration.IConfigurationBuilder to add to.
		//
		// Returns:
		//     The Microsoft.Extensions.Configuration.IConfigurationBuilder.
		public static IConfigurationBuilder AddLegacyConfig(this IConfigurationBuilder builder, IEnumerable<string> sectionDelimiters = null)
		{
			return builder.Add(new LegacyConfigurationProvider(sectionDelimiters));
		}

		/*
		public static IConfigurationBuilder AddAppConfig(this IConfigurationBuilder builder, IEnumerable<string> sectionDelimiters = null)
		{
			return builder.Add(new LegacyConfigurationProvider(sectionDelimiters));
		}

		public static IConfigurationBuilder AddWebConfig(this IConfigurationBuilder builder, IEnumerable<string> sectionDelimiters = null)
		{
			return builder.Add(new LegacyConfigurationProvider(sectionDelimiters));
		}
		*/

	}
}
