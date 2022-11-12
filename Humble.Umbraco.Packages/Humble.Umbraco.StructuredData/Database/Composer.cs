using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;
namespace Humble.Umbraco.StructuredData.Database;

public class ExampleComposer : IComposer
{
	public void Compose(IUmbracoBuilder builder)
	{
		builder.AddNotificationHandler<UmbracoApplicationStartingNotification, RunMigrations>();
	}
}
