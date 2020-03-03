
# Description
Microsoft's powerfull ASP.NET Core configuration extensions are also available for .Net 4.7 projects.  
To make use of it for .Net 4.x in conjuction with the old `App.config`/`Web.config` sources you need a custom provider like this project.

[(microsoft docs)](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1)


# Usage

## NuGet Installation

From Visual Studio's Package Manager Console:
```powershell
PM> Install-Package Lz.Microsoft.Configuration.LegacyProvider
```

## In code

```c#
IConfigurationBuilder configBuilder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
	.SetBasePath(Directory.GetCurrentDirectory())
	// ...
	// With defaults section separators (.,-):
	.AddLegacyConfig()
	// Or with custom section separators:
	.AddLegacyConfig((new string[] {"."})
	// ...
	//.AddCommandLine(args)
;
IConfigurationRoot config = configBuilder.Build();
var appSettings = config.Get<MySettings>();
```

# Benefits
The benefits of using `Microsoft.Extensions.Configuration` over the old `System.Configuration.ConfigurationManager` are:
- Configuration binding to typed classes.
- Adds support for multiple configuration sources with 1 line of code (CommandLine, Json, Xml, Ini, EnvironmentVariables, User-Secrets tool, Azure, etc).
- Easily customizable configuration sources.
- Progressive migration from dotNet 4.X to Core.


> Thanks to Ben Foster for [his original post](https://benfoster.io/blog/net-core-configuration-legacy-projects).