using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Humble.Umbraco.UI.Extensions;
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
    /// <summary>
    /// Gets or sets the content. 
    /// Although this accepts any object, it should be either of type 'string' or 'IHtmlEncodedString'.
    /// </summary>
    public object Content { get; set; }
    private readonly IUmbracoContextAccessor _umbracoContextAccessor;
    private readonly UmbracoHelper _umbracoHelper;
    
    public HumbleParserTagHelper(IUmbracoContextAccessor umbracoContextAccessor, UmbracoHelper umbracoHelper)
    {
        _umbracoContextAccessor = umbracoContextAccessor;
        _umbracoHelper = umbracoHelper;
    }
    
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = null;
        var umbracoContext = _umbracoContextAccessor.GetRequiredUmbracoContext();
        var contentService = umbracoContext.Content;
        if (contentService == null) return;
        
        IPublishedContent content = umbracoContext?.PublishedRequest?.PublishedContent;
        if (Content is string stringContent)
        {
            var newContents = stringContent.Parse(content);
            output.Content.SetHtmlContent(newContents);
        }
        else if (Content is IHtmlEncodedString htmlContent)
        {
            var newContents = htmlContent.Parse(content);
            output.Content.SetHtmlContent(newContents.ToHtmlString());
        }
    }
}