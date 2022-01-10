using System.Collections.Generic;
using HumbleUmbraco.ContentNodeIcons.Database;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;

namespace HumbleUmbraco.ContentNodeIcons.Api
{
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
		// umbraco/api/contentnodeicons/geticon
		public Schema GetIcon([FromBody] int id)
		{
			return _contentNodeIconsService.GetIcon(id);
		}

		[HttpPost]
		// umbraco/api/contentnodeicons/saveicon
		public Schema SaveIcon(Schema config)
		{
			return _contentNodeIconsService.SaveIcon(config);
		}

		[HttpPost]
		// umbraco/api/contentnodeicons/removeicon
		public bool RemoveIcon([FromBody] int id)
		{
			return _contentNodeIconsService.RemoveIcon(id);
		}

	}
}