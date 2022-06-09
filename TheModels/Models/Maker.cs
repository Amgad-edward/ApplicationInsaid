using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("maker")]
    public class Maker
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30),Required]
        public string? NameMaker { get; set; }

        [StringLength(75)]
        public string? GideID { get; set; }

        [StringLength(75),Required]
        public string? JopTitel { get; set; }

        [StringLength(75)]
        public string? Phones { get; set; }

        [ForeignKey("Weight")]
        public int? Idweight { get; set; }

        public Weight? Weight { get; set; }

        [StringLength(77)]
        public string? TaxNumber { get; set; }

        public IEnumerable<BuildingCost>? BuildingCosts { get; set; }

        public IEnumerable<FinishCost>? FinishCosts { get; set; }

        [NotMapped]
        public decimal TotalPrice
        {
            get
            {
                var total = 0m;
                if (BuildingCosts.Any())
                {
                    total = BuildingCosts.Sum(x => x.TotalPrice);
                }
                if (FinishCosts.Any())
                {
                    total += FinishCosts.Sum(x => x.TotalPrice);
                }
                return total;
            }
        }

        [NotMapped]
        public int CountTask
        {
            get
            {
                var count = 0;
               if(BuildingCosts != null)
                {
                    count = BuildingCosts.Count();
                }
               if(FinishCosts != null)
                {
                    count += FinishCosts.Count();
                }
                return count;
            }
        }

        [NotMapped]
        public decimal AveragePrice
        {
            get
            {
                if(BuildingCosts.Any() || FinishCosts.Any())
                {
                    var totalavrage = new List<decimal>();

                    if (BuildingCosts != null)
                    {
                        if (BuildingCosts.Any())
                        {
                            var avreage = BuildingCosts.Average(x => Math.Round(x.TotalPrice / ((decimal)x.CountWeight > 0 ? (decimal)x.CountWeight : 1)));
                            totalavrage.Add(avreage);
                        }
                    }
                    if (FinishCosts != null)
                    {
                        if (FinishCosts.Any())
                        {
                            var avreage = FinishCosts.Average(x => Math.Round(x.TotalPrice / ((decimal)x.Weight > 0 ? (decimal)x.Weight : 1)));
                            totalavrage.Add(avreage);
                        }
                    }
                    return totalavrage.Average();
                }
                return 0m;
            }
        }

        [NotMapped]
        public string? AveragePriceing
        {
            get
            {
                return $"{AveragePrice} {(Weight != null ? $"للـ {Weight.NameWeight}" : "")}";
            }
        }

        [NotMapped]
        public double AverageEvaluation
        {
            get
            {
               if(BuildingCosts != null || FinishCosts is not null)
                {
                    if (BuildingCosts.Any() || FinishCosts.Any())
                    {
                        var totalavrage = new List<double>();

                        if (BuildingCosts != null)
                        {
                            if (BuildingCosts.Any())
                            {
                                var avreage = BuildingCosts.Average(x => x.Evaluation);
                                totalavrage.Add(Math.Round(avreage));
                            }
                        }
                        if (FinishCosts != null)
                        {
                            if (FinishCosts.Any())
                            {
                                var avreage = FinishCosts.Average(x => x.Evaluation);
                                totalavrage.Add(Math.Round(avreage));
                            }
                        }
                        return totalavrage.Average();
                    }
                    
                }
                return 0;
            }
        }

       

    }
}
