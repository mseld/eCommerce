using System.ComponentModel.DataAnnotations;

namespace IM.Web.Domain
{
    public class Translation
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string LanguageCode { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public TranslationArea Area { get; set; }
    }

    public enum TranslationArea
    {
        Frontend = 1,
        Backend = 2
    }
}