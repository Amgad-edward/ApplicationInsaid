using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheModels.Helper_Services;

namespace TheModels.Models
{
    [Table("othercompanies")]
    public class OtherCompanies
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30),Required]
        public string? Name { get; set; }

        [Required]
        public Specialty Specialty { get; set; }

        [StringLength(25)]
        public string? NameManegar { get; set; }

        [StringLength(30)]
        public string? TheOtherActive { get; set; }

        [StringLength(70)]
        public string? Address { get; set; }

        [StringLength(35)]
        public string? NumberCommercial { get; set; }

        [StringLength(77)]
        public string? TaxNumber { get; set; }

        public bool Iscompetitivecompany { get; set; }

        public bool IsCompanyToBenefit { get; set; }

        public float Persant { get; set; }

        public IEnumerable<FinishesUnit>? SaleToFinish { get; set; }

        public IEnumerable<Materials>? Materials { get; set; }

        public IEnumerable<AccountOtherCompany>? Accounts { get; set; }

        public IEnumerable<TaskCarry>? RepostsThisCompany { get; set; }

        [NotMapped]
        public List<Getinvoidice>? GetAllInvice
        {
            get
            {
                var list = new List<Getinvoidice>();
               if(Materials != null)
                {
                    if(Materials.SelectMany(x=>x.BuildingCosts) is not null)
                    {
                        var Building = Materials.SelectMany(s=>s.BuildingCosts).GetInvioce();
                        list.AddRange(Building);
                    }
                    if(Materials.SelectMany(s=>s.FinishCosts) is not null)
                    {
                        var Finish = Materials.SelectMany(s=>s.FinishCosts).GetInvioce();
                        list.AddRange(Finish);
                    }
                   
                }

                return list;
            }
        }

        [NotMapped]
        private IsCompany _isCompany;

        [NotMapped]
        public IsCompany isCompany
        {
            get => _isCompany;
            set
            {
                _isCompany = value;
                if (value == IsCompany.IsCompanyToBenefit)
                {
                    this.IsCompanyToBenefit = true;
                    this.Iscompetitivecompany = false;
                }
                else if(value == IsCompany.Iscompetitivecompany)
                {
                    this.IsCompanyToBenefit = false;
                    this.Iscompetitivecompany = true;
                }
                else
                {
                    this.IsCompanyToBenefit = false;
                    this.Iscompetitivecompany = false;
                }
                    
            }
        }

        [NotMapped]
        public decimal MoneyFromUnitThisMonth
        {
            get
            {
                var total = 0m;
                if(SaleToFinish != null)
                {
                    if(SaleToFinish.Any(x=>x.date.Month == DateOnly.FromDateTime(DateTime.Now).Month&& x.date.Year == DateOnly.FromDateTime(DateTime.Now).Year))
                    {
                        var AllPrice = SaleToFinish.Where(x => x.date.Month == DateOnly.FromDateTime(DateTime.Now).Month && x.date.Year == DateOnly.FromDateTime(DateTime.Now).Year)
                                .Sum(s => s.TotalPriceBuy);
                        total = Math.Round((AllPrice * (decimal)Persant) / 100,1);
                    }
                    if(Accounts is not null)
                    {
                        if(Accounts.Any(x => x.Date.Month == DateOnly.FromDateTime(DateTime.Now).Month && x.Date.Year == DateOnly.FromDateTime(DateTime.Now).Year))
                        {
                            var Payment = Accounts.Where(x => x.Date.Month == DateOnly.FromDateTime(DateTime.Now).Month && x.Date.Year == DateOnly.FromDateTime(DateTime.Now).Year)
                                          .Sum(s => s.Maney);
                            total -= Payment;
                        }
                    }
                }
                return total;
            }
        }

        [NotMapped]
        public decimal TotalManeyToThisCompany
        {
            get
            {
                var total = 0m;
                if (Accounts != null)
                    if (Accounts.Any())
                        total = Accounts.Sum(s => s.Maney);

                return total;
            }
        }

        [NotMapped]
        public string? FullName => $"{Name} - {NameManegar}({Active})";

        [NotMapped]
        public string? Info
        {
            get
            {
                var str = "";
                if (NumberCommercial is not null)
                    str = $"رقم سجل :({NumberCommercial})";
                else if (TaxNumber is not null)
                    str += $"  ضريبى : ({TaxNumber})";
                return str;
            }
        }

        [NotMapped]
        public string? Active => (Specialty == Specialty.Other ? TheOtherActive : Specialty.GetTextEnum());
    }
}
