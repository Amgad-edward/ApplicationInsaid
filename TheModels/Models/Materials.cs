using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("materials")]
    public class Materials
    {
        [Key]
        public int Id { get; set; }

        [StringLength(70),Required]
        public string? NameMaterial { get; set; }

        [ForeignKey("Weight")]
        public int Idweight { get; set; }

        public Weight? Weight { get; set; }

        [StringLength(75)]
        public string? ICodeGS1 { get; set; }

        [ForeignKey("Company")]
        public int? IdCompany { get; set; }

        public OtherCompanies? Company { get; set; }

        public IEnumerable<BuildingCost>? BuildingCosts { get; set; }

        public IEnumerable<FinishCost>? FinishCosts { get; set; }

       

        [NotMapped]
        public string? WeightTitel
        {
            get
            {
                if(Weight.Weightsmall is not null)
                {
                    return $"{Weight.NameWeight} ({Weight.NameTitel})";
                }
                return Weight.NameWeight;
            }
        }

        [NotMapped]
        public bool IsAddMaterailInCost => BuildingCosts.Any() | FinishCosts.Any();

        [NotMapped]
        public string? FullName
        {
            get
            {
                if(Company is not null)
                {
                    return $"{NameMaterial} شركة {Company.Name}";
                }
                return NameMaterial;
            }
        }

    }
}
