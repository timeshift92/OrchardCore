using Fluid;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrchardCore.Web1.Filters;

namespace OrchardCore.Web1
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOrchardCms();
            services.Configure<TemplateOptions>(o =>
            {
                o.Filters.AddFilter("shuffle", ArrayFilters.Shuffle);
                o.Filters.AddFilter("checkResult", ArrayFilters.CheckResult);
                o.Filters.AddFilter("translit", TranslitFilter.Transliteration);
            });
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseOrchardCore();
        }
    }
}
