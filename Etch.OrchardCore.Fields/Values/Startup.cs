using Fluid;
using Microsoft.Extensions.DependencyInjection;
using Etch.OrchardCore.Fields.Values.Drivers;
using Etch.OrchardCore.Fields.Values.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Modules;
using Etch.OrchardCore.Fields.Values.Settings;
using OrchardCore.Data.Migration;

namespace Etch.OrchardCore.Fields.Values
{
    [Feature("Etch.OrchardCore.Fields.Values")]
    public class Startup : StartupBase
    {
        public Startup()
        {
            TemplateOptions.Default.MemberAccessStrategy.Register<ValuesField>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataMigration, Migrations>();

            services.AddContentField<ValuesField>()
                .UseDisplayDriver<ValuesFieldDisplayDriver>();

            services.AddScoped<IContentPartFieldDefinitionDisplayDriver, ValuesFieldSettingsDriver>();
        }
    }
}
