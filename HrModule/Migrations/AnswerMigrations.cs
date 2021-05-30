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
    public class AnswerMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public AnswerMigrations(IContentDefinitionManager contentDefinitionManager) =>
            _contentDefinitionManager = contentDefinitionManager;
    
        public int UpdateFrom1() { return 1; }
        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(AnswerPart), part => part
            .Attachable()
            .WithField(nameof(AnswerPart.Answer), field => field
            .OfType(nameof(HtmlField))
            .WithDisplayName("Answer")
            .WithSettings(new HtmlFieldSettings { Hint = "The Answer" })
            .WithEditor("MonacoEditor"))
             );

            _contentDefinitionManager.AlterTypeDefinition("AnswerPage", type => type
           .Creatable()
           .Listable()
           .WithPart(nameof(AnswerPart))

           );

            return 0;
        }
    }
}
