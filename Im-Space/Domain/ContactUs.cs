using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IM.Web.Domain
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required, MaxLength(200)]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}