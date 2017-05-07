using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IM.Web.Domain
{
    public class CustomerInfo
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }

        [Required]
        public Genders Gender { get; set; }

        [Required, MaxLength(100)]
        public string Nationalty { get; set; }

        public string Age { get; set; }

        [Required]
        public string Region { get; set; }

        [ForeignKey("Nationalty")]
        public virtual Country Country { get; set; }
    }

    public enum Genders
    {
        Male = 1,
        Female = 2
    }
}