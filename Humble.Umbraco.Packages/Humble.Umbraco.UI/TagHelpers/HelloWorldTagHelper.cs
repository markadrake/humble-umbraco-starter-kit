using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Humble.Umbraco.UI.TagHelpers;

public class HelloWorldTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "p";
        output.Content.SetContent("Hello, World!");
    }
}