using System.Collections.Generic;
using Humble.Umbraco.ContentNodeIcons.Database;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.Attributes;

namespace Humble.Umbraco.ContentNodeIcons.Api;

[PluginController("HumbleUmbraco")]
public class ContentNodeIconsController : UmbracoApiController
{

	private readonly IContentNodeIconsService _contentNodeIconsService;

	public ContentNodeIconsController(IContentNodeIconsService contentNodeIconsService)
	{
		_contentNodeIconsService = contentNodeIconsService;
	}

	[HttpGet]
	public List<Schema> GetIcons()
	{
		return _contentNodeIconsService.GetIcons();
	}

	[HttpPost]
	// umbraco/humbleUmbraco/contentNodeIcons/geticon
	public Schema GetIcon([FromBody] int id)
	{
		return _contentNodeIconsService.GetIcon(id);
	}

	[HttpPost]
	// umbraco/humbleUmbraco/contentNodeIcons/setIcon
	public Schema SetIcon(Schema config)
	{
		return _contentNodeIconsService.SaveIcon(config);
	}

	[HttpPost]
	// umbraco/humbleUmbraco/contentNodeIcons/unsetIcon
	public bool UnsetIcon([FromBody] int id)
	{
		return _contentNodeIconsService.RemoveIcon(id);
	}

}