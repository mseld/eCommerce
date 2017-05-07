using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IM.Web.Areas.Admin.Models;
using IM.Web.Helpers;
using FluentValidation;

namespace IM.Web.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(c => c.Email).EmailAddress().NotEmpty();
            RuleFor(c => c.Password).NotEmpty();
        }
    }    
}