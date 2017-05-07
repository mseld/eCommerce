using IM.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IM.Web.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Textlocalized { get; set; }
        public QuestionTypes QuestionType { get; set; }
        public bool HasOthersOption { get; set; }
        public string Value { get; set; }
        public int? AnswerGroupId { get; set; }
        public int QuestionGroupId { get; set; }
        public virtual List<AnswerViewModel> Answers { get; set; }
    }

    public class AnswerViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Textlocalized { get; set; }
    }
}