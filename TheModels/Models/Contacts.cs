using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("contact")]
    public class Contacts
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30),Required]
        public SocialMedia NameContect { get; set; }

        [StringLength(200) , Required]
        public string? Address { get; set; }
    }
}
