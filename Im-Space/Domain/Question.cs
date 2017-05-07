using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IM.Web.Domain
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public string Textlocalized { get; set; }
        public bool Required { get; set; }
        public QuestionTypes QuestionType { get; set; }
        public int Order { get; set; }
        public bool HasOthersOption { get; set; }
        public int QuestionGroupId { get; set; }
        public int? AnswerGroupId { get; set; }
    }

    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public string Textlocalized { get; set; }
        public int? Score { get; set; }
        public int? AnswerGroupId { get; set; }
    }

    public enum QuestionTypes
    {
        Text = 1,
        Multiline = 2,
        Radiobutton = 3
    }
}