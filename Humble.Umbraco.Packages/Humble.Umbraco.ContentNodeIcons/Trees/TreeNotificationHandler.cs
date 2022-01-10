using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Actions;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Models.Trees;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Trees;
using Umbraco.Cms.Web.BackOffice.Trees;
using Umbraco.Extensions;
using Humble.Umbraco.ContentNodeIcons.Api;
using Umbraco.Cms.Core.Notifications;
using System.Linq;
using Umbraco.Cms.Web.Common.ModelBinders;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Humble.Umbraco.ContentNodeIcons.Trees
{
	public class TreeNotificationComposer : IComposer
	{
		public void Compose(IUmbracoBuilder builder) {
			builder.AddNotificationHandler<TreeNodesRenderingNotification, TreeNodesRenderingNotificationHandler>();
			builder.AddNotificationHandler<MenuRenderingNotification, MenuRenderingNotificationHandler>();
		}
	}

	// Hijack the rendering of each content node to customize the icon shown.
	public class TreeNodesRenderingNotificationHandler : INotificationHandler<TreeNodesRenderingNotification>
	{

		private readonly IContentNodeIconsService _contentNodeIconsService;

		public TreeNodesRenderingNotificationHandler(IContentNodeIconsService contentNodeIconsService)
		{
			_contentNodeIconsService = contentNodeIconsService;
		}

		public void Handle(TreeNodesRenderingNotification notification)
		{

			if (notification.TreeAlias.Equals(Constants.Trees.Content))
			{
				var customIcons = _contentNodeIconsService.GetIcons();

				foreach (TreeNode treeNode in notification.Nodes)
				{
					int nodeId = Convert.ToInt32(treeNode.Id);
					if (nodeId <= 0)
					{
						continue;
					}

					var node = customIcons.Where(x => x.ContentId.Equals(nodeId)).FirstOrDefault();
					if (node == null)
					{
						continue;
					}

					treeNode.Icon = $"{node.Icon} {node.IconColor}";
				}
			}
		}
	}

	// Provide a new context menu option.
	public class MenuRenderingNotificationHandler : INotificationHandler<MenuRenderingNotification>
	{

		private readonly IContentNodeIconsService _contentNodeIconsService;

		public MenuRenderingNotificationHandler(IContentNodeIconsService contentNodeIconsService)
		{
			_contentNodeIconsService = contentNodeIconsService;
		}

		public void Handle(MenuRenderingNotification notification)
		{

			// Only for the Content tree and never for the root content node.
			// -1 = Root
			// -20 = Recycle Bin
			if (notification.TreeAlias.Equals(Constants.Trees.Content) && 
				Int32.Parse(notification.NodeId) >= 1)
			{
				var indexPos = notification.Menu.Items.Count;

				// Set Icon
				var setMenuItem = new MenuItem("setIcon", "Set Icon");
				setMenuItem.AdditionalData.Add("actionView", "/app_plugins/Humble.Umbraco.ContentNodeIcons/set.html");
				setMenuItem.Icon = "favorite";
				setMenuItem.OpensDialog = true;
				notification.Menu.Items.Insert(indexPos, setMenuItem);

				// Remove Icon
				var unsetMenuItem = new MenuItem("unsetIcon", "Unset Icon");
				unsetMenuItem.AdditionalData.Add("actionView", "/app_plugins/Humble.Umbraco.ContentNodeIcons/unset.html");
				unsetMenuItem.Icon = "wrong";
				unsetMenuItem.OpensDialog = true;
				notification.Menu.Items.Insert(indexPos + 1, unsetMenuItem);
			}
		}
	}

}