using System;
using System.Text;
using NUglify.Helpers;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Entities;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace Humble.Umbraco.NamingConventions;

public class ContentTypeSavingHandler : INotificationHandler<ContentTypeSavingNotification>
{
	private IContentTypeService _contentTypeService;

	public ContentTypeSavingHandler(IContentTypeService contentTypeService)
	{
		_contentTypeService = contentTypeService;
	}

	public void Handle(ContentTypeSavingNotification notification)
	{
		notification.SavedEntities.ForEach(entity =>
		{
			var alias = BuildAlias(entity);
			entity.Alias = alias;
		});
	}

	public string BuildAlias(IUmbracoEntity entity, string alias = "")
	{

		// Exit: no entity to work with, return the alias
		if (entity == null)
		{
			return alias;
		}

		// Prepend the current entity's alias
		var thisAlias = ToPascalCase(entity.Name);
		if(alias.IndexOf(thisAlias) != 0)
			alias = alias == "" ? thisAlias : $"{thisAlias}_{alias}";

		// Exit: no parent entity to continue work with, return the alias
		if (entity == null || entity.ParentId <= 0)
		{
			return alias;
		}

		// Move to the next entity
		var parentId = entity.ParentId;

		// Is it a content type?
		var parentContentType = _contentTypeService.Get(parentId);
		if (parentContentType != null)
			return BuildAlias(parentContentType, alias);

		// Is it a content type folder?
		var parentContainer = _contentTypeService.GetContainer(parentId);
		if (parentContainer != null)
			return BuildAlias(parentContainer, alias);

		// Exit
		return alias;
	}

	private static string ToPascalCase(string input)
	{
		string[] words = input.Split(new char[] { ' ', '-', '_', '.' }, StringSplitOptions.RemoveEmptyEntries);
		StringBuilder resultBuilder = new StringBuilder();

		foreach (string word in words)
		{
			string capitalized = char.ToUpper(word[0]) + word.Substring(1);
			resultBuilder.Append(capitalized);
		}

		return resultBuilder.ToString();
	}

}

public class DataTypeSavingHandler : INotificationHandler<DataTypeSavingNotification>
{
		private IContentTypeService _contentTypeService;

	public DataTypeSavingHandler(IContentTypeService contentTypeService)
	{
		_contentTypeService = contentTypeService;
	}

	public void Handle(DataTypeSavingNotification notification)
	{
		notification.SavedEntities.ForEach(entity =>
		{
			// Only for Block Lists
			if(entity.EditorAlias == Constants.PropertyEditors.Aliases.BlockList) {
				
				// Ignore block list data types that don't mention 'Humble' in their name.
				if (!entity.Name.InvariantContains("humble"))
				{
					return;
				}
				
				// Set custom view, custom stylesheet, and thumbnail value for every block editor in the configuration.
				var config = (BlockListConfiguration) entity.Configuration;

				config.Blocks.ForEach(block => {
					var contentType = _contentTypeService.Get(block.ContentElementTypeKey);	

					block.View = "~/App_Plugins/Humble.Umbraco.RazorBlockPreview/BlockPreview.html";
					block.Thumbnail = $"~/assets/media/{contentType.Name}.jpg";
					block.Stylesheet = "~/assets/block.min.css";
				});
			}
		});

	}
}