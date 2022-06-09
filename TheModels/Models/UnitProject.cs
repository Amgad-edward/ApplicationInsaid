using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("unitproject")]
    public class UnitProject
    {
        [Key]
        public int Id { get; set; }

        public double SpaceMater { get; set; }

        [ForeignKey("Project")]
        public int IdProject { get; set; }

        public Project? Project { get; set; }

        [ForeignKey("Category")]
        public int Idcategory { get; set; }

        public Category? Category { get; set; }

        [ForeignKey("Floor")]
        public int IdFloor { get; set; }

        public Floor? Floor { get; set; }

        [StringLength(30)]
        public string? UnitNumber { get; set; } 


        [StringLength(10000000)]
        public byte[]? MapImage { get; set; }


        [StringLength(70)]
        public string? Description { get; set; }

        [ForeignKey("ReservationSale")]
        public int? IdResetvationsale { get; set; }

        public ResertvationAndSale? ReservationSale { get; set; }

        public bool AdvertisementForTheCustomer { get; set; }

        [StringLength(75)]
        public string? Guid { get; set; }

        [NotMapped]
        public bool ISSoldDone => ReservationSale is not null;

        [NotMapped]
        public decimal TotalCostThisUintPrice
        {
            get
            {
                if (Project != null)
                    return Project.PriceCastOneMaterByUnit * (decimal)SpaceMater;

                return 0;
            }
        }

        [NotMapped]
        public static string? GetCodeTaxCompany { get; set; }

        [NotMapped]
        public string? CodeEGS => $"EG-{GetCodeTaxCompany}-{Id}";

        [NotMapped]
        public string? UnitName
        {
            get
            {
                return $"وحدة {Category.CategoryName}\n Unit {Category.CategoryNameEnglish}";
            }
        }

        [NotMapped]
        public string? UnitInformation
        {
            get
            {
                if (Project is not null)
                    return $"{Project.ProjectName}({Category.CategoryName}) - دور : {Floor.NameFloor}  رقم الوحدة بالمبنى :{UnitNumber}";
               
                return "";
            }
        }


    }
}
