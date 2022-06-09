using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("attendingandleaving")]
    public class AttendingAndLeaving
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Emplyee")]
        public int Idemplyee { get; set; }

        public Emplyee? Emplyee { get; set; }

        public DateTime Date { get; set; }

        public bool Attending { get; set; }

        public bool Leaving { get; set; }

    }
}
