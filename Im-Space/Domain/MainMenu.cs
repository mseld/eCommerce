using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace IM.Web.Domain
{
    [XmlRoot("Mainmenu")]
    public class MainMenu : List<Menu>
    {

    }
    
    public class Menu
    {        
        [XmlAttribute("id")]
        public int Id { get; set; }

        [Required]
        [XmlAttribute("text")]
        public string Text { get; set; }

        [Required]
        [XmlAttribute("textLocalized")]
        public string TextLocalized { get; set; }

        [DefaultValue("#")]
        [XmlAttribute("href")]
        public string Href { get; set; }

        [XmlAttribute("order")]
        public int Order { get; set; }

        [ForeignKey("ParentId")]
        [XmlArray("Items")]
        public virtual List<Menu> Items { get; set; }

        [XmlIgnore]
        public int? ParentId { get; set; }

        [NotMapped]
        [XmlAttribute("parentId")]
        public string ParentIdAsString
        {
            get
            {
                return this.ParentId.HasValue ? this.ParentId.ToString() : null;
            }

            set
            {
                this.ParentId = !string.IsNullOrEmpty(value) ? int.Parse(value) : default(int?);
            }
        }

        [XmlIgnore]
        public virtual Menu Parent { get; set; }

    }
}