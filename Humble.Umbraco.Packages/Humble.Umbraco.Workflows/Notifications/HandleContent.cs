using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
namespace Humble.Umbraco.Workflows;

public class HandleContent : 
	INotificationHandler<ContentSavingNotification>,
	INotificationHandler<ContentSavedNotification>,
	INotificationHandler<ContentPublishingNotification>,
	INotificationHandler<ContentPublishedNotification>,
	INotificationHandler<ContentUnpublishingNotification>,
	INotificationHandler<ContentUnpublishedNotification>,
	INotificationHandler<ContentCopyingNotification>,
	INotificationHandler<ContentCopiedNotification>,
	INotificationHandler<ContentMovingNotification>,
	INotificationHandler<ContentMovedNotification>,
	INotificationHandler<ContentMovingToRecycleBinNotification>,
	INotificationHandler<ContentMovedToRecycleBinNotification>,
	INotificationHandler<ContentDeletingNotification>,
	INotificationHandler<ContentDeletedNotification>,
	INotificationHandler<ContentDeletingVersionsNotification>,
	INotificationHandler<ContentDeletedVersionsNotification>,
	INotificationHandler<ContentRollingBackNotification>,
	INotificationHandler<ContentRolledBackNotification>,
	INotificationHandler<ContentSendingToPublishNotification>,
	INotificationHandler<ContentSentToPublishNotification>,
	INotificationHandler<ContentEmptyingRecycleBinNotification>,
	INotificationHandler<ContentEmptiedRecycleBinNotification>,
	INotificationHandler<ContentSavedBlueprintNotification>,
	INotificationHandler<ContentDeletedBlueprintNotification>
{

	public void Handle(ContentSavingNotification notification) {
	}
	public void Handle(ContentSavedNotification notification) {
	}
	public void Handle(ContentPublishingNotification notification) {
	}
	public void Handle(ContentPublishedNotification notification) {
	}
	public void Handle(ContentUnpublishingNotification notification) {
	}
	public void Handle(ContentUnpublishedNotification notification) {
	}
	public void Handle(ContentCopyingNotification notification) {
	}
	public void Handle(ContentCopiedNotification notification) {
	}
	public void Handle(ContentMovingNotification notification) {
	}
	public void Handle(ContentMovedNotification notification) {
	}
	public void Handle(ContentMovingToRecycleBinNotification notification) {
	}
	public void Handle(ContentMovedToRecycleBinNotification notification) {
	}
	public void Handle(ContentDeletingNotification notification) {
	}
	public void Handle(ContentDeletedNotification notification) {
	}
	public void Handle(ContentDeletingVersionsNotification notification) {
	}
	public void Handle(ContentDeletedVersionsNotification notification) {
	}
	public void Handle(ContentRollingBackNotification notification) {
	}
	public void Handle(ContentRolledBackNotification notification) {
	}
	public void Handle(ContentSendingToPublishNotification notification) {
	}
	public void Handle(ContentSentToPublishNotification notification) {
	}
	public void Handle(ContentEmptyingRecycleBinNotification notification) {
	}
	public void Handle(ContentEmptiedRecycleBinNotification notification) {
	}
	public void Handle(ContentSavedBlueprintNotification notification) {
	}
	public void Handle(ContentDeletedBlueprintNotification notification) {
	}
}