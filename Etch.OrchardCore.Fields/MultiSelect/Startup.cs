using Etch.OrchardCore.Fields.MultiSelect.Drivers;
using Etch.OrchardCore.Fields.MultiSelect.Fields;
using Etch.OrchardCore.Fields.MultiSelect.Settings;
using Etch.OrchardCore.Fields.MultiSelect.ViewModels;
using Fluid;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;

namespace Etch.OrchardCore.Fields.MultiSelect
{
    [Feature("Etch.OrchardCore.Fields.MultiSelect")]
    public class Startup : StartupBase
    {
        public Startup()
        {
            TemplateOptions.Default.MemberAccessStrategy.Register<MultiSelectField>();
            TemplateOptions.Default.MemberAccessStrategy.Register<DisplayMultiSelectFieldViewModel>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataMigration, Migrations>();

            services.AddContentField<MultiSelectField>()
                .UseDisplayDriver<MultiSelectFieldDisplayDriver>();

            services.AddScoped<IContentPartFieldDefinitionDisplayDriver, MultiSelectFieldSettingsDriver>();
        }
    }
}
