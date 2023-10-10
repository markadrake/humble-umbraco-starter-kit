using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Text;

namespace Humble.Umbraco.UI.TagHelpers;

/// <summary>
/// Tag helper for rendering SVG icons as SYMBOLS of a sprite.
/// </summary>
[HtmlTargetElement("humble-sprite", TagStructure = TagStructure.NormalOrSelfClosing)]
public class SvgSpriteTagHelper : TagHelper
{
    private readonly IMemoryCache _cache;

    public SvgSpriteTagHelper(IMemoryCache memoryCache)
    {
        _cache = memoryCache;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        // Remove the custom element.
        output.TagName = null;
        
        // Create an <svg> element with a "display: none" style attribute
        var svgBuilder = new StringBuilder();
        svgBuilder.Append("<svg style=\"display: none;\">");

        // Iterate over our SVG icons.
        var cache = _cache.GetOrCreate("humble_svgs", entry => new HashSet<string>());
        foreach (var key in cache)
        {
            // Get the cached SVG content (assuming it's a <symbol> element)
            if (_cache.TryGetValue(key, out string svgContent) && !string.IsNullOrWhiteSpace(svgContent))
            {
                // Append the SVG content to the <svg> element
                svgBuilder.Append(svgContent);
            }
        }
        
        // Close the <svg> element
        svgBuilder.Append("</svg>");

        // Set the generated SVG content as the TagHelper output
        output.Content.SetHtmlContent(svgBuilder.ToString());
    }
}