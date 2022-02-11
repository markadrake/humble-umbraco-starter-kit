using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace Humble.Umbraco.Cloudflare.Umbraco.Notifications
{
	internal class Subscribe : IComposer
	{
		public void Compose(IUmbracoBuilder builder)
		{
			builder.AddNotificationAsyncHandler<ContentPublishedNotification, ContentPublished>();
			//builder.AddNotificationAsyncHandler<MediaSavedNotification, MediaSaved>();
		}
	}
}
