using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Web.Common.ApplicationBuilder;

namespace Humble.Umbraco.UI.Routes;

public class SvgSpriteController : Controller
{
    public IActionResult Index()
    {
        return View("~/Views/sprite.cshtml");
    }
}

public class SvgSpriteComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.Configure<UmbracoPipelineOptions>(options =>
        {
            options.AddFilter(new UmbracoPipelineFilter(nameof(SvgSpriteController))
            {
                Endpoints = app => app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "sprite",
                        pattern: "sprite.svg",
                        defaults: new { controller = "SvgSprite", action = "Index" });
                })
            });
        });
    }
}