using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
namespace Humble.Umbraco.Workflows;

public class HandleMedia : 
	INotificationHandler<MediaSavingNotification>,
	INotificationHandler<MediaSavedNotification>,
	INotificationHandler<MediaMovingNotification>,
	INotificationHandler<MediaMovedNotification>,
	INotificationHandler<MediaMovingToRecycleBinNotification>,
	INotificationHandler<MediaMovedToRecycleBinNotification>,
	INotificationHandler<MediaDeletingNotification>,
	INotificationHandler<MediaDeletedNotification>,
	INotificationHandler<MediaDeletingVersionsNotification>,
	INotificationHandler<MediaDeletedVersionsNotification>
{
	public void Handle(MediaSavingNotification notification) {
	}
	public void Handle(MediaSavedNotification notification) {
	}
	public void Handle(MediaMovingNotification notification) {
	}
	public void Handle(MediaMovedNotification notification) {
	}
	public void Handle(MediaMovingToRecycleBinNotification notification) {
	}
	public void Handle(MediaMovedToRecycleBinNotification notification) {
	}
	public void Handle(MediaDeletingNotification notification) {
	}
	public void Handle(MediaDeletedNotification notification) {
	}
	public void Handle(MediaDeletingVersionsNotification notification) {
	}
	public void Handle(MediaDeletedVersionsNotification notification) {
	}
}