﻿using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Notifications;

namespace Humble.Umbraco.Cloudflare.Umbraco.Notifications;

internal class MediaSaved : INotificationAsyncHandler<MediaSavedNotification>
{

	private readonly MediaFileManager _mediaFileManager;

	/// <summary>
	/// Find the correct implementation for IFileSystem via MediaFileManager.
	/// </summary>
	/// <param name="mediaFileManager"></param>
	public MediaSaved(MediaFileManager mediaFileManager)
	{
		_mediaFileManager = mediaFileManager;
	}

	/// <summary>
	/// Called each time media is saved in the backoffice.
	/// </summary>
	/// <param name="notification"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public Task HandleAsync(MediaSavedNotification notification, CancellationToken cancellationToken)
	{
		foreach (var node in notification.SavedEntities)
		{
			using (Stream stream = _mediaFileManager.GetFile(node, out string mediaFilePath))
			{
				// Should have access to the stream for your image now.
			}
		}

		return Task.CompletedTask;
	}

}