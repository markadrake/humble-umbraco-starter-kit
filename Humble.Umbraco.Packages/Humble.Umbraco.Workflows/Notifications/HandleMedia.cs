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
		throw new System.NotImplementedException();
	}
	public void Handle(MediaSavedNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(MediaMovingNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(MediaMovedNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(MediaMovingToRecycleBinNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(MediaMovedToRecycleBinNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(MediaDeletingNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(MediaDeletedNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(MediaDeletingVersionsNotification notification) {
		throw new System.NotImplementedException();
	}
	public void Handle(MediaDeletedVersionsNotification notification) {
		throw new System.NotImplementedException();
	}
}