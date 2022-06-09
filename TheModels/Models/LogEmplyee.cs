using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("logemplyee")]
    public class LogEmplyee
    {
        [Key]
        public int Id { get; set; }

        [StringLength(21) , Required]
        public string? UserName { get; set; }

        [StringLength(16), Required]
        public string? Password { get; set; }

        [ForeignKey("Emplyee")]
        public int Idemplyee { get; set; }

        public Emplyee? Emplyee { get; set; }

        [NotMapped]
        public string? Getgide
        {
            get
            {
                if(Emplyee != null)
                {
                    return Emplyee.GideID;
                }
                return "";
            }
        }
    }
}
