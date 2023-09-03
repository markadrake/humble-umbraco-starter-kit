using System.Collections.Generic;
using System.ComponentModel;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Humble.Umbraco.UI.TagHelpers.Models;

public class Picture
{
	[Description("(Required) ")]
	public IPublishedContent DefaultMedia { get; set; }
	[Description("(Recommended) ")]
	public string ImageAlt { get; set; }
	[Description("(Recommended) ")]
	public string DefaultImageFormats { get; set; }
	[Description("(Recommended) ")]
	public string DefaultImageCropAlias { get; set; }
	[Description("(Required) ")]
	public IEnumerable<PictureSource> Sources { get; set; }
}

public class PictureSource
{
	[Description("(Required) Provide a valid CSS media query.")]
	public string CssMediaQuery { get; set; }
	[Description("(Optional Override) Provide the media file from Umbraco.")]
	public IPublishedContent Media { get; set; }
	[Description("(Optional Override) Provide a list of image formats to use, space-separated, without `.` periods.")]
	public string ImageFormats { get; set; }
	[Description("(Optional Override) Provide the alias of an image crop you want to apply.")]
	public string ImageCropAlias { get; set; }
}