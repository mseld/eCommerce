using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation;

namespace IM.Web.Domain
{
    public class ContentPage
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(500)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [UIHint("RichTextEditor"), AllowHtml]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [MaxLength(500)]
        [Display(Name = "Link text")]
        public string LinkText { get; set; }

        [Display(Name = "Header link position")]
        [UIHint("LinkPosition")]
        public int? HeaderPosition { get; set; }

        [Display(Name = "Footer Section")]
        [UIHint("LinkSection")]
        public int? FooterSection { get; set; }

        [Display(Name = "Footer link position")]
        [UIHint("LinkPosition")]
        public int? FooterPosition { get; set; }

        [MaxLength(160)]
        [Display(Name = "Meta description tag")]
        public string MetaDescription { get; set; }

        [MaxLength(160)]
        [Display(Name = "Meta keywords tag")]
        public string MetaKeywords { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Redirect url")]
        public string RedirectToUrl { get; set; }

        [Display(Name = "Visable")]
        public bool Visable { get; set; }

        [Display(Name = "Type")]
        public PageType Type { get; set; }
    }

    public enum PageType
    {
        [Display(Name = "Link")]
        Link = 0,
        [Display(Name = "Blank Page")]
        Blank = 1,
        [Display(Name = "Normal Page")]
        Normal = 2
    }

    public class ContentPageValidator : AbstractValidator<ContentPage>
    {
        public ContentPageValidator()
        {
            RuleFor(c => c.Title).NotEmpty();
        }
    }
}