using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IM.Web.Domain
{
    public class Questionnaire
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CellPhone { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string DealingPeriod { get; set; }
    }
}