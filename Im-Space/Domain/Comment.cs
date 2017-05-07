using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IM.Web.Domain
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Message Type")]
        public string MessageType { get; set; }

        [Required]
        public string Section { get; set; }

        [Required, MaxLength(50)]
        public string Subject { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required,MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string FileId { get; set; }

        [Required,MaxLength(200)]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

    }
}