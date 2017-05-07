using System.ComponentModel.DataAnnotations;

namespace IM.Web.Domain
{
    public class Setting
    {
        [Key]
        public string Key { get; set; }

        public string Value { get; set; }
    }
}