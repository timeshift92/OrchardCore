using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using System.Collections.Generic;

namespace HrModule.Models
{
    class QuestionPart : ContentPart
    {
        public HtmlField Question { get; set; }
        public List<AnswerPart> Answers { get; set; } 
        public AnswerPart RightAnswer { get; set; }
    }
}
