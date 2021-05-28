using HrModule.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
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
    public class QuestionMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public QuestionMigrations(IContentDefinitionManager contentDefinitionManager) =>
            _contentDefinitionManager = contentDefinitionManager;

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(QuestionPart), part => part
            .Attachable()
            .WithField(nameof(QuestionPart.Question), field => field
            .OfType(nameof(HtmlField))
            .WithDisplayName("Question")
            .WithSettings(new HtmlFieldSettings { Hint = "The Question" })
            .WithEditor("MonacoEditor"))


             );

            _contentDefinitionManager.AlterTypeDefinition("QuestionPage", type => type
          .Creatable()
          .Listable()
          .WithPart(nameof(QuestionPart))
          );


            return 1;
        }
    }
}
