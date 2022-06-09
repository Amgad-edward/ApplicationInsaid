using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("projectimage")]
    public class ProjectImage
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Project")]
        public int Idproject { get; set; }

        public Project? Project { get; set; }

        [StringLength(10000000)]
        public byte[]? Image { get; set; }
    }
}
