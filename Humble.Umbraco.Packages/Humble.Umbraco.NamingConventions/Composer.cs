using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace Humble.Umbraco.NamingConventions;

public class DontShoutComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddNotificationHandler<ContentTypeSavingNotification, ContentTypeSavingHandler>();
		// Testing
		builder.AddNotificationHandler<DataTypeSavingNotification, DataTypeSavingHandler>();
    }
	
}