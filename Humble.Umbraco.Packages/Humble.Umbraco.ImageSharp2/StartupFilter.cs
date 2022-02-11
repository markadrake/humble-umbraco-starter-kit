using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using SixLabors.ImageSharp.Web.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble.Umbraco.ImageSharp2
{
    /// <summary>
    /// Startup filter allows us to register ImageSharp.Web into the application pipeline.
    /// </summary>
    public class StartupFilter : IStartupFilter
    {
        /// <summary>
        /// Register ImageSharp.Web in the application pipeline.
        /// </summary>
        /// <param name="next"></param>
        /// <returns>IApplicationBuilder</returns>
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseImageSharp();
                next(app);
            };
        }
    }
}
