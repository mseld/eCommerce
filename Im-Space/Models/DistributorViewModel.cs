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
    public class DistributorViewModel : IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Exhibition Name")]
        public string ExhibitionName { get; set; }

        [Display(Name = "The name of the owner of the exhibition")]
        public string OwnerName { get; set; }

        [Display(Name = "Exhibition Director Name")]
        public string DirectorName { get; set; }

        [Display(Name = "Mobile exhibition director")]
        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }

        [Display(Name = "Client Address")]
        public string ClientAddress { get; set; }

        public string Fax { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PostalCode)]
        public string Mailbox { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<Distributor, DistributorViewModel>();
            Mapper.CreateMap<DistributorViewModel, Distributor>();
        }
    }

    public class DistributorViewModelValidator : AbstractValidator<DistributorViewModel>
    {
        public DistributorViewModelValidator()
        {
            RuleFor(c => c.ExhibitionName).Length(1, 50).NotEmpty();
            RuleFor(c => c.OwnerName).Length(1, 50).NotEmpty();
            RuleFor(c => c.DirectorName).Length(1, 50).NotEmpty();
            RuleFor(c => c.CellPhone).NotEmpty();
            RuleFor(c => c.ClientAddress).Length(1, 100).NotEmpty();
            RuleFor(c => c.Email).EmailAddress().Length(1, 50).NotEmpty();
            RuleFor(c => c.Mailbox).Length(10, 200).NotEmpty();
        }
    }
}