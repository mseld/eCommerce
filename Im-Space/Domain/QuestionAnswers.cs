using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IM.Web.Domain
{
    public class QuestionAnswer
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string AnswerId { get; set; }
        public string Note { get; set; }
        public int QuestionGroupId { get; set; }
        public int? AnswerGroupId { get; set; }
        public int parentId { get; set; }
    }
}