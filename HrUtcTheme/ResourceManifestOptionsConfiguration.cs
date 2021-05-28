using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace OrchardCore.HrUtcTheme
{
    public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
    {
        private static ResourceManifest _manifest;

        static ResourceManagementOptionsConfiguration()
        {
            _manifest = new ResourceManifest();


            _manifest
                .DefineScript("HrUtcTheme-main")
                .SetUrl("~/HrUtcTheme/js/main.min.js", "~/HrUtcTheme/js/main.js")
                .SetVersion("7.0.0");
            _manifest
                .DefineScript("HrUtcTheme-vendor")
                .SetUrl("~/HrUtcTheme/js/vendor.min.js", "~/HrUtcTheme/js/vendor.js")
                .SetVersion("7.0.0");

            _manifest
                .DefineStyle("HrUtcTheme-main")
                .SetUrl("~/HrUtcTheme/css/main.min.css", "~/HrUtcTheme/css/main.css")
                .SetVersion("1.0.0");

            _manifest
                .DefineStyle("HrUtcTheme-vendor")
                .SetDependencies("HrUtcTheme")
                .SetUrl("~/HrUtcTheme/css/vendor.min.css", "~/HrUtcTheme/css/vendor.css")
                .SetVersion("1.0.0");
        }

        public void Configure(ResourceManagementOptions options)
        {
            options.ResourceManifests.Add(_manifest);
        }
    }
}
