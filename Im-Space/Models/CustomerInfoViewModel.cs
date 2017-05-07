using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IM.Web.Models
{
    public class CustomerInfoViewModel
    {
        public string Name { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Age { get; set; }
        public string Region { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }

    public class CustomerInfoViewModelValidator : AbstractValidator<CustomerInfoViewModel>
    {
        public CustomerInfoViewModelValidator()
        {
            RuleFor(c => c.Name).Length(1, 50).NotEmpty();
            RuleFor(c => c.Phone).NotEmpty();
            RuleFor(c => c.Email).EmailAddress().NotEmpty();
            RuleFor(c => c.Gender).NotEmpty();
            RuleFor(c => c.Nationality).NotEmpty();
            RuleFor(c => c.Age).NotEmpty();
            RuleFor(c => c.Region).NotEmpty();
        }
    }
}