using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("finishcost")]
    public class FinishCost
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FinishUnit")]
        public int IdUnitFinish { get; set; }

        public FinishesUnit? FinishUnit { get; set; }


        [ForeignKey("Maker")]
        public int? Idmaker { get; set; }

        public Maker? Maker { get; set; }

        [ForeignKey("Material")]
        public int? IdMaterail { get; set; }

        public Materials? Material { get; set; }

        [StringLength(70)]
        public string? InvoiceNumber { get; set; }

        public float PercantOfmaterial { get; set; }

        public double Weight { get; set; }

        public decimal TotalPrice { get; set; }

        public bool ISPaymentDone { get; set; }

        public double Evaluation { get; set; }

        public DateOnly Date { get; set; }

        public List<ThePaymentCost>? ManeyPaymentCosts { get; set; }

        [NotMapped]
        public decimal TotalPayment => ManeyPaymentCosts != null && ManeyPaymentCosts.Any() ? ManeyPaymentCosts.Sum(s => s.ManeyPayment) : 0;

        [NotMapped]
        public decimal TotalRemaining => ((TotalPrice - TheMoneyOfpersante) - TotalPayment) ;

        [NotMapped]
        public decimal ProfitMaterail
        {
            get
            {
                decimal total = 0;
                if(PercantOfmaterial > 0)
                {
                    total = Math.Round((TotalPrice * (decimal)PercantOfmaterial) / 100, 1);
                }
                return total;
            }
        }

        [NotMapped]
        public decimal PaymentNow { get; set; }

        [NotMapped]
        public string? MaketWeight
        {
            get
            {
                if(Maker is not null)
                   return Maker.Weight is not null ? Maker.Weight.NameWeight : "";

                return "";
            }
        }

        [NotMapped]
        public string? MaterailWeight
        {
            get
            {
                if (Material is not null)
                {
                    if(Material.Weight is not null)
                    {
                        return Material.Weight.NameWeight;
                    }
                }

                return "";
            }
        }

        [NotMapped]
        public string? MaterailCount
        {
            get
            {
                if(Material is not null)
                {
                    if(Material.Weight != null)
                    {
                        if(Weight < 1)
                        {
                            if(Material.Weight.Weightsmall is not null)
                            {
                                return $"{(Weight * Material.Weight.CountOfSmall)} {Material.Weight.Weightsmall.NameWeight}";
                            }
                        }
                        return $"{Weight} {Material.Weight.NameWeight}";
                    }
                }
                return string.Empty;
            }
        }

        [NotMapped]
        public decimal TheMoneyOfpersante
        {
            get
            {
                if(PercantOfmaterial > 0 && TotalPrice > 0)
                {
                    return Math.Round((TotalPrice * (decimal)PercantOfmaterial) / 100);
                }
                return 0;
            }
        }

        [NotMapped]
        public ThePaymentCost? AddPaymentCost { get; set; } = new ThePaymentCost();

    }
}
