using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Web.Common.Controllers;

namespace Humble.Umbraco.Controllers;

/*
 * Url: /umbraco/api/example/
 */
public class ExampleController : UmbracoApiController
{

	private readonly ITagQuery _tagQuery;

	public ExampleController(ITagQuery tagQuery)
	{
		_tagQuery = tagQuery;
	}

	/*
	 * Url: /umbraco/api/example/test
	 */
	public JsonResult Test()
	{
		return new JsonResult(true);
	}

	/*
	 * Url: /umbraco/api/example/bytag?tag=
	 */
	public JsonResult ByTag(string tag)
	{
		var content = _tagQuery.GetContentByTag(tag);
		return new JsonResult(content.Select(x => x.Name));
	}

}
