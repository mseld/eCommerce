using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using IM.Web.Domain;
using FluentValidation;

namespace IM.Web.Areas.Admin.Models
{
    public class LocationsViewModel
    {
        public LocationsViewModel()
        {
            Locations = new List<LocationViewModel>();
        }

        public List<LocationViewModel> Locations { get; set; }
    }

    public class LocationViewModel : IHaveCustomMappings
    {
        public LocationViewModel()
        {
        }

        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Latitude")]
        public string Latitude { get; set; }

        [Display(Name = "Longitude")]
        public string Longitude { get; set; }


        [Display(Name = "Description")]
        public string Description { get; set; }


        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<Location, LocationViewModel>();
            Mapper.CreateMap<LocationViewModel, Location>();
        }
    }

    public class LocationViewModelValidator : AbstractValidator<LocationViewModel>
    {
        public LocationViewModelValidator()
        {
            RuleFor(m => m.Name).NotEmpty().Length(3,50);
            RuleFor(m => m.Latitude).NotEmpty();
            RuleFor(m => m.Longitude).NotEmpty();
            RuleFor(m => m.Description).Length(5, 50);
            //RuleFor(r => r).Must(
            //  r => !countryService.FindAll().Any(d => d.Code != r.Code && d.Name == r.Name))
            //  .WithName("Name")
            //  .WithMessage("Name is already used".TA());
        }
    }
}