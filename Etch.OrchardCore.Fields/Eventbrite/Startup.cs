using Etch.OrchardCore.Fields.Eventbrite.Drivers;
using Etch.OrchardCore.Fields.Eventbrite.Fields;
using Etch.OrchardCore.Fields.Eventbrite.Models;
using Etch.OrchardCore.Fields.Eventbrite.Services;
using Etch.OrchardCore.Search.Indexing;
using Fluid;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Indexing;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCore.Settings;

namespace Etch.OrchardCore.Fields.Eventbrite
{
    [Feature("Etch.OrchardCore.Fields.Eventbrite")]
    public class Startup : StartupBase
    {
        public Startup()
        {
            TemplateOptions.Default.MemberAccessStrategy.Register<EventbriteField>();
            TemplateOptions.Default.MemberAccessStrategy.Register<EventbriteEvent>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentField<EventbriteField>()
                .UseDisplayDriver<EventbriteFieldDisplayDriver>();

            services.AddScoped<IDisplayDriver<ISite>, EventbriteSettingsDisplayDriver>();

            services.AddScoped<INavigationProvider, AdminMenu>();

            services.AddScoped<IEventbriteService, EventbriteService>();
            services.AddScoped<IEventbriteSettingsService, EventbriteSettingsService>();

            services.AddScoped<IContentFieldIndexHandler, EventbriteFieldIndexHandler>();

            services.AddHttpClient();
        }
    }
}