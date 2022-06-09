using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("imagedesignfinish")]
    public class ImageDesignFinish
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Finishunit")]
        public int IdunitFinish { get; set; }

        public FinishesUnit? Finishunit { get; set; }

        [StringLength(100000000)]
        public byte[]? Image { get; set; }
    }
}
