using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheModels;

namespace TheModels.Models
{
    [Table("buildingcost")]
    public class BuildingCost
    {
        [Key]
        public int Id { get; set; }

        [StringLength(70)]
        public string? ToAccount { get; set; }

        [StringLength(70)]
        public string? InvoiceNumber { get; set; }

        public decimal TotalPrice { get; set; }

        public double CountWeight { get; set; }

        [ForeignKey("Maker")]
        public int? Idmaker { get; set; }

        public Maker? Maker { get; set; }

        [ForeignKey("Material")]
        public int? IdMaterial { get; set; }

        public Materials? Material { get; set; }

        [ForeignKey("Project")]
        public int IdProject { get; set; }

        public Project? Project { get; set; }

        [JsonConverter(typeof(DateConvertJosndateoly))]
        public DateOnly Date { get; set; }

        public bool ISPaymentDone { get; set; }

        public double Evaluation { get; set; }

        public bool DoneRequistTax { get; set; }

        public List<ThePaymentCost>? ManeyPaymentCosts { get; set; }

        [NotMapped]
        public string MaketWeight
        {
            get
            {
                if(Maker != null)
                {
                    if(Maker.Weight != null && TotalPrice > 0 && CountWeight > 0)
                    {
                        return $"{Math.Round(TotalPrice / (decimal)CountWeight, 1)} للـ{Maker.Weight.NameWeight}";
                    }
                }

                return "دفع اجمالى";
            }
        }

        [NotMapped]
        public string MaterailWeight
        {
            get
            {
                if(Material != null && TotalPrice > 0 && CountWeight > 0)
                {
                    return $"{Math.Round(TotalPrice / (decimal)CountWeight, 1)} للـ{(Material.Weight != null ? Material.Weight.NameWeight : Material.NameMaterial)}";
                }
                return "اجمالى";
            }
        }

        [NotMapped]
        public decimal TotalRemaining
        {
            get
            {
                if (ISPaymentDone)
                {
                    if(ManeyPaymentCosts != null)
                    {
                        if (ManeyPaymentCosts.Any())
                        {
                            return (TotalPrice -  ManeyPaymentCosts.Sum(s => s.ManeyPayment));
                        }
                    }
                    return TotalPrice;
                }
                return 0;
            }
        }

        [NotMapped]
        public decimal TotalPayment
        {
            get
            {
                if (ISPaymentDone)
                {
                    if (ManeyPaymentCosts != null)
                    {
                        if (ManeyPaymentCosts.Any())
                        {
                            return ManeyPaymentCosts.Sum(s => s.ManeyPayment);
                        }
                    }
                }
                return 0;
            }
        }

        [NotMapped]
        public decimal PaymentNow { get; set; }


        [NotMapped]
        public string NameCost
        {
            get
            {
                if (Maker is not null)
                {
                    return $"حساب {Maker.NameMaker} بمبلغ {TotalPrice.TotextMoney()} {Date.ToShortDateString()}";
                }
                else if (Material is not null)
                {
                    return $"حساب {Material.NameMaterial} ({CountWeight} - {(Material.Weight!= null ? Material.Weight.NameWeight : Material.NameMaterial)}) \n بمبلغ {TotalPrice.TotextMoney()} {Date.ToShortDateString()}";
                }
                else
                {
                    return $"حساب {ToAccount} بمبلغ {TotalPrice.TotextMoney()} {Date.ToShortDateString()}";
                }
            }
        }

        [NotMapped]
        public string TheWeighteOf
        {
            get
            {
                if(Maker is not null)
                {
                    return MaketWeight;
                }
                else if(Material is not null)
                {
                    return MaterailWeight;
                }
                return "";
            }
        }

       
    }
}
