using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("gallery")]
    public class Gallery
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string? Title { get; set; }

        [StringLength(200),Required]
        public string? UrlImage { get; set; }

        [ForeignKey("Subject")]
        public int? IdSunject { get; set; }

        public AllSubjects? Subjects { get; set; }
    }
}
