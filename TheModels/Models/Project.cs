using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("project")]
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [StringLength(35),Required]
        public string? ProjectName { get; set; }

        [StringLength(47)]
        public string? License { get; set; }

        [StringLength(400)]
        public string? ProjectInfo { get; set; }

        public int CountFloor { get; set; }

        public double TotalSapce { get; set; }

        public decimal TotalPrice { get; set; }
        
        public List<ProjectImage>? ImageProject { get; set; }

        public List<UnitProject>? UnitProjects { get; set; }

        public List<BuildingCost>? BuildingCosts { get; set; }

        [NotMapped]
        public IEnumerable<(Customer customer,string unti )>? CustomerOwners
        {
            get
            {
                if(UnitProjects != null)
                {
                    var sales = UnitProjects.Where(x => x.ISSoldDone);
                    foreach (var unti in sales)
                    {
                        yield return new() { customer = unti.ReservationSale.ToCustomer, unti = $"وحدة رقم : {unti.UnitNumber} , {unti.Floor.NameFloor} , {unti.SpaceMater}Mater" };
                    }
                }

            }
        }

        [NotMapped]
        public decimal TotalPatymentAll => (TotalPrice + TotalCostPayment);

        [NotMapped]
        public decimal TotalCostPayment
        {
            get
            {
                var total = 0m;
                if(BuildingCosts != null)
                {
                    total = BuildingCosts.Sum(x => x.TotalPrice);
                }
                return total;
            }
        }

        [NotMapped]
        public decimal TotalConstructAssay
        {
            get
            {
                var total = 0m;
               if(BuildingCosts is not null)
                {
                    if (BuildingCosts.Any())
                    {
                        total = BuildingCosts.Where(x => !x.ISPaymentDone).Sum(s => s.TotalPrice);
                    }
                }
                return total;
            }
        }
        [NotMapped]
        public decimal PriceMeter => Math.Round(TotalPrice / (decimal)TotalSapce,2);

        [NotMapped]
        public decimal TotalPaymentCostDone
        {
            get
            {
                if(BuildingCosts is not null)
                {

                    var Payments = BuildingCosts.SelectMany(x => x.ManeyPaymentCosts);
                    if(Payments != null)
                    {
                        if (Payments.Any())
                            return Payments.Sum(x => x.ManeyPayment);
                    }
                }
                return 0;
            }
        }

        [NotMapped]
        public decimal TotalReminaning => (TotalCostPayment - TotalPaymentCostDone);

        [NotMapped]
        public decimal PriceMaterByCast
        {
            get
            {
                var Matermetial = Math.Round(TotalCostPayment / (decimal)TotalSapce,1);
                return (Matermetial + PriceMeter);
            }
        }

        [NotMapped]
        public decimal PriceCastOneMaterByUnit
        {
            get
            {
                if(UnitProjects is not null)
                {
                    var count = UnitProjects.Count();
                    var mater = Math.Round(PriceMaterByCast / count, 1);
                    return mater;
                }
                return 0;
            }
        }

        [NotMapped]
        public decimal TotalProfitThisProject
        {
            get
            {
                decimal totalprofit = 0m;
                if(UnitProjects != null)
                {
                    if (UnitProjects.Any(x => x.ISSoldDone))
                    {
                        var units = UnitProjects.Where(x => x.ISSoldDone);
                        totalprofit = units.Sum(s => s.ReservationSale.ProfitThisUnit);
                    }
                }
                return totalprofit;
            }
        }

        [NotMapped]
        public int CountSaleUnit
        {
            get
            {
                if(UnitProjects != null)
                {
                    var unnitsale = UnitProjects.Where(x => x.ISSoldDone);
                    return unnitsale.Count();
                }
                return 0;
            }
        }

        [NotMapped]
        public int CountUnitNotSale
        {
            get
            {
                if (UnitProjects != null)
                {
                    var unnitsale = UnitProjects.Where(x => !x.ISSoldDone);
                    return unnitsale.Count();
                }
                return 0;
            }
        }

        [NotMapped]
        public int CountUnit => UnitProjects is not null ? UnitProjects.Count() : 0;

        [NotMapped]
        public IEnumerable<IGrouping<string?, BuildingCost>>? GetByGroupInvoiceNumber
        {
            get
            {
                if(BuildingCosts != null)
                {
                    if (BuildingCosts.Any(x => x.ISPaymentDone))
                    {
                        return BuildingCosts.Where(x => x.ISPaymentDone).GroupBy(x => x.InvoiceNumber);
                    }
                }
                
                return default;
            }
        }
    }
}
