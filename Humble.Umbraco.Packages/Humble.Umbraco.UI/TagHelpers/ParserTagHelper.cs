using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using Umbraco.Extensions;

namespace Humble.Umbraco.UI.TagHelpers;

[HtmlTargetElement("humble-parser", TagStructure = TagStructure.NormalOrSelfClosing)]
public class HumbleParserTagHelper : TagHelper
{
    private readonly IUmbracoContextAccessor _umbracoContextAccessor;
    private readonly UmbracoHelper _umbracoHelper;
    
    public HumbleParserTagHelper(IUmbracoContextAccessor umbracoContextAccessor, UmbracoHelper umbracoHelper)
    {
        _umbracoContextAccessor = umbracoContextAccessor;
        _umbracoHelper = umbracoHelper;
    }

    public IHtmlEncodedString Content { get; set; }
    
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = null;
        var umbracoContext = _umbracoContextAccessor.GetRequiredUmbracoContext();
        var contentService = umbracoContext.Content;

        if (contentService == null)
        {
            return;
        }

        IPublishedContent content = _umbracoHelper.AssignedContentItem; // Set this based on your requirements

        var replacePattern = new Regex(@"{{([a-zA-Z]+)}}", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
        var newContents = Content.ToString();

        var matches = replacePattern.Matches(newContents);

        foreach (Match match in matches)
        {
            string key = match.Groups[1].Value;
            var typeProperty = content.GetType().GetProperty(key, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);

            if (typeProperty != null)
            {
                newContents = newContents.Replace(match.Value, typeProperty.GetValue(content, null).ToString());
                continue;
            }

            var contentProperty = content.GetProperty(key);
            if (contentProperty == null) continue;

            var value = contentProperty.GetValue();
            if (value == null) continue;

            newContents = newContents.Replace(match.Value, value.ToString());
        }

        output.Content.SetHtmlContent(newContents);
    }
}