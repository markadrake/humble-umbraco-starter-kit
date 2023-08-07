using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using J2N.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NPoco.RowMappers;
using NUglify.Helpers;
using StackExchange.Profiling.Internal;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Humble.Umbraco;

// URL: /umbraco/api/content/
public class ContentController : UmbracoApiController {

	private readonly UmbracoHelper _umbracoHelper;
	private readonly ITagQuery _tagQuery;
	// private readonly IUmbracoMapper _umbracoMapper;

	public ContentController(UmbracoHelper umbracoHelper, ITagQuery tagQuery /* IUmbracoMapper umbracoMapper */) {
		_umbracoHelper = umbracoHelper;
		_tagQuery = tagQuery;
		// _umbracoMapper = umbracoMapper;
	}

	// URL: /umbraco/api/content/test
	public JsonResult Test(string tag = "humble") {

		JsonSerializerOptions options = new JsonSerializerOptions() {
			ReferenceHandler = ReferenceHandler.Preserve,
			PropertyNameCaseInsensitive = true,
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};

		var content = _tagQuery.GetContentByTag(tag);
		var returnContent = new List<object>();

		foreach(var c in content) {
			var cType = c.ContentType.Alias;
			Console.WriteLine(cType);

			// var actualType = GetType($"Umbraco.Cms.Web.Common.{cType}");
		}
		return new JsonResult(returnContent, options);
	}
}