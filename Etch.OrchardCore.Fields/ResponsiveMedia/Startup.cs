using Fluid;
using Microsoft.Extensions.DependencyInjection;
using Etch.OrchardCore.Fields.ResponsiveMedia.Drivers;
using Etch.OrchardCore.Fields.ResponsiveMedia.Fields;
using Etch.OrchardCore.Fields.ResponsiveMedia.Settings;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Modules;
using Etch.OrchardCore.Fields.ResponsiveMedia.Models;
using Etch.OrchardCore.Fields.ResponsiveMedia.ViewModels;
using OrchardCore.Data.Migration;

namespace Etch.OrchardCore.Fields.ResponsiveMedia
{
    [Feature("Etch.OrchardCore.Fields.ResponsiveMedia")]
    public class Startup : StartupBase
    {
        static Startup()
        {
            TemplateOptions.Default.MemberAccessStrategy.Register<DisplayResponsiveMediaFieldViewModel>();
            TemplateOptions.Default.MemberAccessStrategy.Register<ResponsiveMediaItem>();
            TemplateOptions.Default.MemberAccessStrategy.Register<ResponsiveMediaSource>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataMigration, Migrations>();

            services.AddContentField<ResponsiveMediaField>()
                .UseDisplayDriver<ResponsiveMediaFieldDisplayDriver>();

            services.AddScoped<IContentPartFieldDefinitionDisplayDriver, ResponsiveMediaFieldSettingsDriver>();
        }
    }
}
