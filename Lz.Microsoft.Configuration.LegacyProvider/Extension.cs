using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Configuration
{
	public static class Extension
	{
		/// <summary>
		///  Adds the XML web.config/app.config configuration provider to builder. Specifically "AppSettings" and "ConnectionStrings" sections only.
		/// </summary>
		/// <param name="builder">The Microsoft.Extensions.Configuration.IConfigurationBuilder to add to.</param>
		/// <param name="sectionDelimiters"></param>
		/// <returns>The Microsoft.Extensions.Configuration.IConfigurationBuilder.</returns>
		public static IConfigurationBuilder AddLegacyConfig(this IConfigurationBuilder builder, IEnumerable<string> sectionDelimiters = null)
		{
			return builder.Add(new LegacyConfigurationProvider(sectionDelimiters));
		}
	}
}
