using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("weight")]
    public class Weight
    {
        [Key]
        public int Id { get; set; }

        [StringLength(31),Required]
        public string? NameWeight { get; set; }

        [ForeignKey("Weightsmall")]
        public int? IdWeightsmall { get; set; }

        public Weight? Weightsmall { get; set; }

        public double CountOfSmall { get; set; }


        [NotMapped]
        public string NameTitel
        {
            get
            {
                if(Weightsmall != null)
                {
                    return $"{NameWeight} ({CountOfSmall} {Weightsmall.NameWeight})";
                }
                return NameWeight;
            }

        }

    }
}
