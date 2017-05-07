using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IM.Web.Models
{
    public class QuestionnaireViewModel
    {
        public string CompanyName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }
        public string Region { get; set; }
        public string DealingPeriod  { get; set; }

        public List<QuestionViewModel> Questions { get; set; }
    }

    public class QuestionnaireViewModelValidator : AbstractValidator<QuestionnaireViewModel>
    {
        public QuestionnaireViewModelValidator()
        {
            RuleFor(c => c.CompanyName).Length(1, 50).NotEmpty();
            RuleFor(c => c.CellPhone).NotEmpty();
            RuleFor(c => c.Region).NotEmpty();
            RuleFor(c => c.DealingPeriod).NotEmpty();
        }
    }
}