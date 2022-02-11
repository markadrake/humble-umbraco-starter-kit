/*
 * Upgrade and replace Umbraco v9's implementation of ImageSharp.Web to 2.0.
 * 
 * Ref: https://our.umbraco.com/Documentation/Implementation/Composing/
 */
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SixLabors.ImageSharp.Web.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Web.Common;

namespace Humble.Umbraco.ImageSharp2
{
	public class Composer : IComposer
	{
		public void Compose(IUmbracoBuilder builder)
		{
			builder.Services.AddImageSharp();
			builder.Services.AddTransient<IStartupFilter, StartupFilter>();
		}
	}
}
