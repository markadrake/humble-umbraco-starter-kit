using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace Humble.Umbraco.Workflows;

public class Composer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
		/*
			Content Notifications
			https://our.umbraco.com/documentation/Reference/Notifications/ContentService-Notifications/
		*/
        builder.AddNotificationHandler<ContentSavingNotification, HandleContent>();
        builder.AddNotificationHandler<ContentSavedNotification, HandleContent>();
        builder.AddNotificationHandler<ContentPublishingNotification, HandleContent>();
        builder.AddNotificationHandler<ContentPublishedNotification, HandleContent>();
        builder.AddNotificationHandler<ContentUnpublishingNotification, HandleContent>();
        builder.AddNotificationHandler<ContentUnpublishedNotification, HandleContent>();
        builder.AddNotificationHandler<ContentCopyingNotification, HandleContent>();
        builder.AddNotificationHandler<ContentCopiedNotification, HandleContent>();
        builder.AddNotificationHandler<ContentMovingNotification, HandleContent>();
        builder.AddNotificationHandler<ContentMovedNotification, HandleContent>();
        builder.AddNotificationHandler<ContentMovingToRecycleBinNotification, HandleContent>();
        builder.AddNotificationHandler<ContentMovedToRecycleBinNotification, HandleContent>();
        builder.AddNotificationHandler<ContentDeletingNotification, HandleContent>();
        builder.AddNotificationHandler<ContentDeletedNotification, HandleContent>();
        builder.AddNotificationHandler<ContentDeletingVersionsNotification, HandleContent>();
        builder.AddNotificationHandler<ContentDeletedVersionsNotification, HandleContent>();
        builder.AddNotificationHandler<ContentRollingBackNotification, HandleContent>();
        builder.AddNotificationHandler<ContentRolledBackNotification, HandleContent>();
        builder.AddNotificationHandler<ContentSendingToPublishNotification, HandleContent>();
        builder.AddNotificationHandler<ContentSentToPublishNotification, HandleContent>();
        builder.AddNotificationHandler<ContentEmptyingRecycleBinNotification, HandleContent>();
        builder.AddNotificationHandler<ContentEmptiedRecycleBinNotification, HandleContent>();
        builder.AddNotificationHandler<ContentSavedBlueprintNotification, HandleContent>();
        builder.AddNotificationHandler<ContentDeletedBlueprintNotification, HandleContent>();
		/*
			Media Notifications
			https://our.umbraco.com/documentation/Reference/Notifications/MediaService-Notifications/
		*/
		builder.AddNotificationHandler<MediaSavingNotification, HandleMedia>();
		builder.AddNotificationHandler<MediaSavedNotification, HandleMedia>();
		builder.AddNotificationHandler<MediaMovingNotification, HandleMedia>();
		builder.AddNotificationHandler<MediaMovedNotification, HandleMedia>();
		builder.AddNotificationHandler<MediaMovingToRecycleBinNotification, HandleMedia>();
		builder.AddNotificationHandler<MediaMovedToRecycleBinNotification, HandleMedia>();
		builder.AddNotificationHandler<MediaDeletingNotification, HandleMedia>();
		builder.AddNotificationHandler<MediaDeletedNotification, HandleMedia>();
		builder.AddNotificationHandler<MediaDeletingVersionsNotification, HandleMedia>();
		builder.AddNotificationHandler<MediaDeletedVersionsNotification, HandleMedia>();
    }
}