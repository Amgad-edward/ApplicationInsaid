using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("finishesunit")]
    public class FinishesUnit
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int Idcategory { get; set; }

        public Category? Category { get; set; }

        [ForeignKey("Customer")]
        public int IdCustomer { get; set; }

        public Customer? Customer { get; set; }

        public float SapceMetar { get; set; }

        public decimal TotalPriceBuy { get; set; }

        [StringLength(170)]
        public string? Information { get; set; }

        [ForeignKey("UintResertvation")]
        public int? IdUintResertvation{ get; set; }

        public ResertvationAndSale? UnitResertvation { get; set; }

        [ForeignKey("ByEmplyee")]
        public int? IdEpmlyee { get; set; }

        public Emplyee? ByEmplyee { get; set; }

        [ForeignKey("ByCompany")]
        public int? IdCompanysGet { get; set; }

        public OtherCompanies? ByCompany { get; set; }

        [StringLength(77)]
        public string? Guid { get; set; }

        public bool ShowInWebSaite { get; set; }

        [JsonConverter(typeof(DateConvertJosndateoly))]
        public DateOnly date { get; set; }

        public bool DoneFinishing { get; set; }

        public bool DoneRequistTax { get; set; }

        public List<ImageDesignFinish>? ImageDesignFinishes { get; set; }

        public List<FinishCost>? FinishCosts { get; set; }

        public List<PaymentFinish>? PaymentMoney { get; set; }

        [NotMapped]
        public decimal TotalCostPayment
        {
            get
            {
                if(FinishCosts != null)
                {
                    if (FinishCosts.Any(x => x.ISPaymentDone))
                        return FinishCosts.Where(x => x.ISPaymentDone).Sum(s => s.TotalPrice);
                }
                return 0;
            }
        }

        [NotMapped]
        public decimal TotalCostruct
        {
            get
            {
                if (FinishCosts != null)
                {
                    if (FinishCosts.Any(x => !x.ISPaymentDone))
                        return FinishCosts.Where(x => !x.ISPaymentDone).Sum(s => s.TotalPrice);
                }
                return 0;
            }
        }

        [NotMapped]
        public decimal CostMetar
        {
            get
            {
                return Math.Round(TotalCostPayment / (decimal)SapceMetar, 1);
            }
        }

        [NotMapped]
        public decimal Profite
        {
            get
            {
                var total = TotalPriceBuy - TotalCostPayment  ;
                if(ByEmplyee != null)
                {
                    total -= Math.Round((TotalPriceBuy / (decimal)ByEmplyee.Persant) / 100, 1);
                }
                else if(ByCompany != null)
                {
                    total -= Math.Round((TotalPriceBuy / (decimal)ByCompany.Persant) / 100, 1);
                }
                if (FinishCosts != null)
                    total += FinishCosts.Sum(s => s.ProfitMaterail);

                return total;
            }
        }

        [NotMapped]
        public string? Titel
        {
            get
            {
                if(UnitResertvation != null)
                {
                    return UnitResertvation.NameUint;
                }
                else
                {
                    return $"{Customer.NameCustomer} - مساحة : {SapceMetar}";
                }
            }
        }

        [NotMapped]
        public decimal TotalPayment
        {
            get
            {
                if(PaymentMoney is not null)
                {
                    if (PaymentMoney.Any())
                        return PaymentMoney.Where(x=>x.DonePayment).Sum(s => s.Money);
                }
                return 0;
            }
        }

        [NotMapped]
        public decimal TotalRemaining => (TotalPriceBuy - TotalPayment);

        [NotMapped  ]
        public decimal PRICEMETER
        {
            get
            {
                if(UnitResertvation != null && UnitResertvation.Unit is not null)
                {
                    return Math.Round(TotalPriceBuy / (decimal)UnitResertvation.Unit.SpaceMater, 1);
                }
                else if(SapceMetar > 0)
                {
                    return Math.Round(TotalPriceBuy / (decimal)SapceMetar, 1);
                }

                return default;
            }
        }
    }
}
