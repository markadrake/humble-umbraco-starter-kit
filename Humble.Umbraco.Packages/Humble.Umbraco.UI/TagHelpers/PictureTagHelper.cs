using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Umbraco.Cms.Core.Models;
using Umbraco.Extensions;

namespace Humble.Umbraco.UI.TagHelpers;

[HtmlTargetElement("humble-picture", TagStructure = TagStructure.NormalOrSelfClosing)]
public class PictureTagHelper : TagHelper
{
    public List<MediaWithCrops> MediaWithCropsList { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var content = await output.GetChildContentAsync();
        var mediaSources = new List<string>();

        foreach (var mediaWithCrops in MediaWithCropsList)
        {
            // Determine which breakpoint to use based on the width of the image
            string breakpoint = "s";

            // Get the URL for the specific breakpoint from the LocalCrops
            var cropData = mediaWithCrops.LocalCrops.GetCrop(breakpoint);
            var mediaUrl = mediaWithCrops.Url();

            // Create a <source> element for each media source
            var mediaSource = $"<source media='(min-width: {cropData?.Width}px)' srcset='{mediaUrl}'>";
            mediaSources.Add(mediaSource);
        }

        // Generate the <picture> element
        var pictureElement = $"<picture>{string.Join("", mediaSources)}</picture>";
        output.TagName = null;
        output.Content.SetHtmlContent(pictureElement);
    }
}