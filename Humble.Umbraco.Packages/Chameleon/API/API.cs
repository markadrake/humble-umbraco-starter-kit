using Microsoft.AspNetCore.Mvc;
using System;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.Controllers;

namespace Chameleon.Api {
	public class HumbleController : UmbracoApiController {
		public bool Test()
		{
			return true;
		}

		public JsonResult Content(Guid Key)
		{
			// Failure condition: key not provided, or incorrectly formatted
			if (Key.Equals(Guid.Empty)) {
				return Response(false, null);
			}

			// Failure condition: cannot find Umbraco content by key

			// TODO: Lookup content in Umbraco
			return new JsonResult(new { });
		}

		private JsonResult Response(bool Success, dynamic Data)
		{
			return new JsonResult(new { 
				Success,
				Data
			});
		}
	}
}