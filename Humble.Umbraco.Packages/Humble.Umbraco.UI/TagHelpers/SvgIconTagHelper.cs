using HtmlAgilityPack;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Umbraco.Cms.Core.Extensions;
using Umbraco.Cms.Core.Services;

namespace Humble.Umbraco.UI.TagHelpers;

/// <summary>
/// Tag helper for rendering SVG icons.
/// </summary>
[HtmlTargetElement("humble-icon", TagStructure = TagStructure.NormalOrSelfClosing)]
public class SvgIconTagHelper : TagHelper
{
    private readonly IIconService _iconService;
    private readonly IMemoryCache _cache;
    private readonly IUrlHelperFactory _urlHelperFactory;
    private readonly IWebHostEnvironment _environment;

    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; } = default!;
    
    /// <summary>
    /// The name of the icon. This will load SVG contents from the Umbraco backoffice.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The path of the icon. This will load SVG contents from the file system.
    /// </summary>
    public string Path { get; set; }

    public SvgIconTagHelper (IIconService iconService, IMemoryCache memoryCache, IUrlHelperFactory urlHelperFactory, IWebHostEnvironment environment) {
        _iconService = iconService;
        _cache = memoryCache;
        _urlHelperFactory = urlHelperFactory;
        _environment = environment;
    }

    /// <summary>
    /// Processes the <c>svg-icon</c> tag and generates the required HTML content.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="output"></param>
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        // Remove the custom element.
        output.TagName = null;
        
        // Check if either 'name' or 'path' attribute is provided
        if (!string.IsNullOrWhiteSpace(Name))
        {
            // Handle the 'name' attribute
            string svgContent = GetSvgContentForName();
            output.Content.SetHtmlContent(svgContent);
        }
        else if (!string.IsNullOrWhiteSpace(Path))
        {
            // Handle the 'path' attribute
            var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            Path = urlHelper.Content(Path);
            Name = $"icon-{System.IO.Path.GetFileName(Path).ToLowerInvariant().Split('.')[0]}";
            string svgContent = GetSvgContentForPath();
            output.Content.SetHtmlContent(svgContent);
        }
        else
        {
            // Neither 'name' nor 'path' attribute is provided, do nothing
            output.SuppressOutput();
        }
    }

    /// <summary>
    /// Find the SVG contents in memory or use the IconService from Umbraco to get the SVG contents.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private string GetSvgContentForName()
    {
        string svg = _cache.GetOrCreate(Name, entry =>
        {
            var svgContents = _iconService.GetIcon(Name)?.SvgString ?? string.Empty;

            if (string.IsNullOrWhiteSpace(svgContents))
            {
                entry.Dispose();
                return string.Empty;
            }

            return ConvertSvgToSymbol(svgContents, Name);
        });

        if (string.IsNullOrWhiteSpace(svg)) return string.Empty;

        TrackSvgIconUse(Name);
        return $"<svg><use xlink:href='#{Name}' /></svg>";
    }

    /// <summary>
    /// Find the SVG contents in memory or use the file system to find the SVG contents.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private string GetSvgContentForPath()
    {
        string svg = _cache.GetOrCreate(Name, entry =>
        {

            var filePath = _environment.MapPathContentRoot(Path);
            
            // Check if the file exists on disk
            if (!System.IO.File.Exists(filePath))
            {
                entry.Dispose();
                return string.Empty;
            }

            // Read the string contents of the file
            try
            {
                string svgContents = File.ReadAllText(filePath);
                return ConvertSvgToSymbol(svgContents, Name);
            }
            catch (Exception)
            {
                entry.Dispose();
                return null;
            }
        });

        if (String.IsNullOrWhiteSpace(svg)) return string.Empty;

        TrackSvgIconUse(Name);
        return $"<svg><use xlink:href='#{Name}' /></svg>";
    }

    /// <summary>
    /// Maintains a hash set of unique strings. This is used to pull back icons from our cache.
    /// </summary>
    /// <param name="name"></param>
    private void TrackSvgIconUse(string name)
    {
        var cacheKey = "humble_svgs";
        var cache = _cache.GetOrCreate(cacheKey, entry => new HashSet<string>());
        cache.Add(name);
        _cache.Set(cacheKey, cache);
    }
    
    /// <summary>
    /// Converts an <c>SVG</c> element to a <c>SYMBOL</c>.
    /// </summary>
    /// <param name="svg"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    private string ConvertSvgToSymbol(string svg, string id)
    {
        // Load the SVG content into an HtmlDocument
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(svg);

        // Find the SVG element and create a new SYMBOL element
        var svgElement = doc.DocumentNode.SelectSingleNode("//svg");

        // Exit: couldn't find the SVG.
        if (svgElement == null)
        {
            return svg;
        }
        
        var symbolElement = doc.CreateElement("symbol");
        symbolElement.Attributes.Add("id", id);

        // Copy the viewBox attribute from the SVG to the SYMBOL
        var viewBox = svgElement.GetAttributeValue("viewBox", "");
        symbolElement.Attributes.Add("viewBox", viewBox);

        // Clear all attributes from the SVG element except viewBox
        svgElement.Attributes.RemoveAll();

        // Append the SVG child nodes as children to the SYMBOL
        symbolElement.AppendChildren(svgElement.ChildNodes);

        // Return the modified SVG content
        return symbolElement.OuterHtml;

    }
}