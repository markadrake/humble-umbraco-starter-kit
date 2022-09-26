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
		throw new System.NotImplementedException();
	}
	public void Handle(ContentSavedNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentPublishingNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentPublishedNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentUnpublishingNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentUnpublishedNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentCopyingNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentCopiedNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentMovingNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentMovedNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentMovingToRecycleBinNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentMovedToRecycleBinNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentDeletingNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentDeletedNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentDeletingVersionsNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentDeletedVersionsNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentRollingBackNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentRolledBackNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentSendingToPublishNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentSentToPublishNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentEmptyingRecycleBinNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentEmptiedRecycleBinNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentSavedBlueprintNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(ContentDeletedBlueprintNotification notification) {
		throw new System.NotImplementedException();
	}
}