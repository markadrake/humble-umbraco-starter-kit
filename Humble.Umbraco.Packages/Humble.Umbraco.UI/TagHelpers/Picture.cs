using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Umbraco.Extensions;

namespace Humble.Umbraco.UI.TagHelpers
{
	/// <summary>
	/// The Picture Tag Helper assists us with building the HTML for a <PICTURE> element.
	/// </summary>
	public class Picture : TagHelper
	{
		[Description("(Required) The configuration for the PICTURE element.")]
		public Models.Picture Config { get; set; }
		[Description("(Optional) How many tabs to insert before each SOURCE element. Helps keep formatting pretty.")]
		public int Tabs { get; set; } = 1;

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			// Exit: no configuration provided
			if (Config == null || !Config.Sources.Any())
			{
				output.SuppressOutput();
				return;
			}

			// Force close tag
			output.TagMode = TagMode.StartTagAndEndTag;

			// Start by setting the PICTURE tag
			output.TagName = "picture";

			// Build SOURCE elements for each media query requested
			string sourceElements = "";
			foreach (var source in Config.Sources)
			{
				sourceElements += BuildSourceElement(source);
			}

			// Build IMG element
			sourceElements += BuildImageElement();

			// Append all SOURCE elements for this PICTURE
			output.PreContent.SetHtmlContent(sourceElements);
		}

		/// <summary>
		/// Helps us build the HTML string for a <SOURCE> element.
		/// </summary>
		/// <param name="Model"></param>
		/// <returns></returns>
		private string BuildSourceElement (Models.PictureSource Model)
		{
			// Override default if provided
			var imageFormats = string.IsNullOrEmpty(Model.ImageFormats) ?
				Config.DefaultImageFormats.ToLower().Split(' ') :
				Model.ImageFormats.ToLower().Split(' ');

			// Override default if provided
			var imageSrc = Model.Media != null ? 
				Model.Media.Url() :
				Config.DefaultMedia.Url();

			// Build a SOURCE element for each format requested
			var sourceElement = "";
			foreach (var imageFormat in imageFormats)
			{
				sourceElement += Environment.NewLine;
				foreach(var i in Enumerable.Range(0, Tabs))
				{
					sourceElement += "\t";
				}
				sourceElement += $"<source media=\"{Model.CssMediaQuery}\"";
				sourceElement += Environment.NewLine;
				foreach (var i in Enumerable.Range(0, Tabs+1))
				{
					sourceElement += "\t";
				}
				sourceElement += $"type=\"image/{imageFormat}\"";
				sourceElement += Environment.NewLine;
				foreach (var i in Enumerable.Range(0, Tabs + 1))
				{
					sourceElement += "\t";
				}
				sourceElement += $"srcset=\"{imageSrc}?format={imageFormat}\">";
			}

			// Return HTML for all SOURCE elements
			return sourceElement;
		}

		/// <summary>
		/// Helps us build the HTML string for a <IMG> element.
		/// </summary>
		/// <returns></returns>
		private string BuildImageElement()
		{

			var width = Config.DefaultMedia.Value("umbracoWidth");
			var height = Config.DefaultMedia.Value("umbracoHeight");

			// Build default IMG element
			var imageElement = "";

			imageElement += Environment.NewLine;
			foreach (var i in Enumerable.Range(0, Tabs))
			{
				imageElement += "\t";
			}
			imageElement += $"<img src=\"{Config.DefaultMedia.Url()}\" alt=\"{Config.ImageAlt}\" width=\"{width}\" height=\"{height}\">";
			imageElement += Environment.NewLine;
			foreach (var i in Enumerable.Range(0, Tabs - 1))
			{
				imageElement += "\t";
			}

			return imageElement;
		}
	}

}
