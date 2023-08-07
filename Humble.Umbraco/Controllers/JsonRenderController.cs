using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.ActionsResults;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.Filters;
using Umbraco.Extensions;

namespace Humble.Umbraco.Controllers
{
	public class JsonRenderController : RenderController
	{

		public JsonRenderController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor)
			: base(logger, compositeViewEngine, umbracoContextAccessor)
		{

		}

		public override IActionResult Index() {

			if(IsJsonRequest())
			{
				var o = new JsonResponse(new ContentModel(CurrentPage));
				return Json(o);

				//var myObj = new JsonResponse(new ContentModel(CurrentPage));
				//return new OkObjectResult(myObj);

				//return Json(CurrentPage, new JsonSerializerOptions
				//{
				//	ReferenceHandler = ReferenceHandler.Preserve
				//});

			}

			return CurrentTemplate(new ContentModel(CurrentPage));

		}

		private bool IsJsonRequest()
		{
			// Exit: no request found
			if (Request == null) return false;

			// Attempt to get the requested mime type
			Request.Headers.TryGetValue("Accept", out var accepts);
			
			// Exit: no value for accepts found in request headers
			if (string.IsNullOrEmpty(accepts)) return false;

			// Value(s) we are searching for
			string[] mimes = new string[]
			{
				"application/json"
			};

			// Did we find any acceptable mime values?
			return mimes.Any(m => m.Equals(accepts, StringComparison.OrdinalIgnoreCase));

		}

	}
}