using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IM.Web.Domain
{
    public class Distributor
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        [Display(Name = "Exhibition Name")]
        public string ExhibitionName { get; set; }

        [Required, MaxLength(50)]
        [Display(Name = "The name of the owner of the exhibition")]
        public string OwnerName { get; set; }

        [Required, MaxLength(50)]
        [Display(Name = "Exhibition Director Name")]
        public string DirectorName { get; set; }

        [Required]
        [Display(Name = "Mobile exhibition director")]
        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }

        [Required, MaxLength(100)]
        [Display(Name = "Client Address")]
        public string ClientAddress { get; set; }

        public string Fax { get; set; }

        [Required]
        [Display(Name = "Subject")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string Mailbox { get; set; }
    }
}