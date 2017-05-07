using AutoMapper;
using FluentValidation;
using IM.Web.Domain;
using IM.Web.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IM.Web.Models
{
    public class CommentViewModel : IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Message Type")]
        public string MessageType { get; set; }

        public string Section { get; set; }

        public string Subject { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Confirm Email")]
        [DataType(DataType.EmailAddress)]
        public string ConfirmEmail { get; set; }

        public HttpPostedFileBase Attachment { get; set; }

        public string FileId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<Comment, CommentViewModel>();
            Mapper.CreateMap<CommentViewModel, Comment>();
        }
    }

    public class CommentViewModelValidator : AbstractValidator<CommentViewModel>
    {
        public CommentViewModelValidator()
        {
            RuleFor(c => c.MessageType).NotEmpty();
            RuleFor(c => c.Section).NotEmpty();
            RuleFor(c => c.Subject).Length(1,50).NotEmpty();
            RuleFor(c => c.Name).Length(1, 50).NotEmpty();
            RuleFor(c => c.Address).Length(1, 100).NotEmpty();
            RuleFor(c => c.Email).EmailAddress().NotEmpty();
            RuleFor(c => c.ConfirmEmail).Equal(c => c.Email).WithMessage("The Email and confirmation email do not match.".T());
            RuleFor(c => c.Message).Length(10, 200).NotEmpty();
        }
    }
}