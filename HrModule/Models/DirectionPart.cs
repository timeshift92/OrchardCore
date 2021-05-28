using OrchardCore.ContentManagement;
using System.Collections.Generic;

namespace HrModule.Models
{
    class DirectionPart : ContentPart
    {
        public string Name { get; set; }
        public List<QuestionPart> Questions { get; set; }

    }
}
