using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("allsubjects")]
    public class AllSubjects
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public TitelSubject titelSubject { get; set; }

        [StringLength(30),Required]
        public string? Titel { get; set; }

        [StringLength(100)]
        public string? TitelAfter { get; set; }

        [StringLength(1200)]
        public string? Discription { get; set; }

        [StringLength(100)]
        public string? Link { get; set; }

        public IEnumerable<Gallery>? Images { get; set; }

        [NotMapped]
        public string[]? GetImagesUrl
        {
            get
            {
                if(Images is not null)
                {
                    return Images.Select(x => x.UrlImage).ToArray();
                }
                return default;
            }
        }
    }
}
