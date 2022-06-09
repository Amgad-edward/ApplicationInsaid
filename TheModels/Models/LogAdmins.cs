using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("logadminis")]
    public class LogAdmins
    {
        [Key]
        public int Id { get; set; }

        [StringLength(21) , Required]
        public string? userName { get; set; }

        [StringLength(16) , Required]
        public string? Password { get; set; }

        public bool ISAdmin { get; set; }

        [ForeignKey("Emplyee")]
        public int? IdEmplyee { get; set; }

        public Emplyee? Emplyee { get; set; }


        [NotMapped]
        public string? Re_Password { get; set; }
    }
}
