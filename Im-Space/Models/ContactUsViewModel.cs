using AutoMapper;
using FluentValidation;
using IM.Web.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IM.Web.Models
{
    public class ContactUsViewModel : IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<ContactUs, ContactUsViewModel>();
            Mapper.CreateMap<ContactUsViewModel, ContactUs>();
        }
    }

    public class ContactUsViewModelValidator : AbstractValidator<ContactUsViewModel>
    {
        public ContactUsViewModelValidator()
        {
            RuleFor(c => c.Name).Length(1, 50).NotEmpty();
            RuleFor(c => c.Email).EmailAddress().NotEmpty();
            RuleFor(c => c.Message).Length(1, 200).NotEmpty();
        }
    }
}