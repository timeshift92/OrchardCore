using HrModule.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrModule.Migrations
{
    public class DirectionMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public DirectionMigrations(IContentDefinitionManager contentDefinitionManager) =>
            _contentDefinitionManager = contentDefinitionManager;

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(DirectionPart), part => part
            .Attachable()
            );

            _contentDefinitionManager.AlterTypeDefinition("DirectionPage", type => type
            .Creatable()
            .Listable()
            .WithPart(nameof(DirectionPart))

            );

            return 1;
        }
    }

}
