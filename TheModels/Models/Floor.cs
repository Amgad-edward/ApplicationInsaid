using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("floor")]
    public class Floor
    {
        [Key]
       public int Id { get; set; }

       public int Number { get; set; }

       [StringLength(47),Required]
       public string? NameFloor { get; set; }

       public IEnumerable<UnitProject>? Units { get; set; }
    }
}
