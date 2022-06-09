using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required , StringLength(30)]
        public string? CategoryName { get; set; }

        [Required, StringLength(30)]
        public string? CategoryNameEnglish { get; set; }
        public IEnumerable<UnitProject>? UnitProjects { get; set; }
    }
}
