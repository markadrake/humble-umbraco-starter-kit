/*
 * Upgrade and replace Umbraco v9's implementation of ImageSharp.Web to 2.0.
 * 
 * Ref: https://our.umbraco.com/Documentation/Implementation/Composing/
 */
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Web.Common;

namespace Humble.Umbraco.ImageSharp2
{
	internal class Composer : IComposer
	{
		public void Compose(IUmbracoBuilder builder)
		{
			//builder.AddUmbracoImageSharp2();
		}
	}
}
