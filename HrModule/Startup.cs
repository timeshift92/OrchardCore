using Fluid;
using HrModule.Migrations;
using HrModule.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using System;

namespace HrModule
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentPart<DirectionPart>();
            services.AddContentPart<QuestionPart>();
            services.AddContentPart<AnswerPart>();
            services.AddScoped<IDataMigration, DirectionMigrations>();
            services.AddScoped<IDataMigration, QuestionMigrations>();
            services.AddScoped<IDataMigration, AnswerMigrations>();


        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "HrModule",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
