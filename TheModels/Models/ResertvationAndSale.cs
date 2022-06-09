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
    [Table("resertvationandsale")]
    public class ResertvationAndSale
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Unit")]
        public int IdUnit { get; set; }

        public UnitProject? Unit { get; set; }

        [ForeignKey("ToCustomer")]
        public int IdCustomer { get; set; }

        public Customer? ToCustomer { get; set; }

        public decimal TotalPriceBuy { get; set; }

        public decimal PriceAdding { get; set; }

        public SystemPayment systemPayments { get; set; }

        [JsonConverter(typeof(DateConvertJosndateoly))]
        public DateOnly DateSale { get; set; }

        [ForeignKey("ByEmplyee")]
        public int? IdEmplyee { get; set; }

        public Emplyee? ByEmplyee { get; set; }

        public List<PaymentMoney>? PaymentMoney { get; set; }

        [ForeignKey("FinishUnit")]
        public int? IdFinishUint { get; set; }
        public FinishesUnit? FinishUnit { get; set; }


        [NotMapped]
        public decimal Total => (TotalPriceBuy + PriceAdding);

        [NotMapped]
        public decimal PriceMeter => Math.Round(TotalPriceBuy / (decimal)Unit.SpaceMater,1);

        [NotMapped]
        public decimal TotalRemaining
        {
            get
            {
                var total = Total;
                if (PaymentMoney != null)
                {
                    total = total - PaymentMoney.Where(x => x.DonePayment).Sum(ss => ss.Money);
                }
                return total;
            }
        }

        [NotMapped]
        public decimal TotalPayment
        {
            get
            {
                var total = 0m;
                if (PaymentMoney != null)
                {
                    total = PaymentMoney.Where(x => x.DonePayment).Sum(ss => ss.Money);
                }
                return total;
            }
        }

        [NotMapped]
        public (IEnumerable<PaymentMoney> list, decimal total)? InstallmentNotpayment
        {
            get
            {
                if (PaymentMoney is not null && systemPayments == SystemPayment.Installments)
                {
                    var all = PaymentMoney.Where(x => x.DatePayment > DateTime.Now && !x.DonePayment && x.Paymentis == PaymentIs.Installment);
                    if (all != null)
                        return new() { total = all.Sum(x => x.Money), list = all };

                }
                return default;
            }
        }

        [NotMapped]
        public int SpanMonthLenght { get; set; }

        [NotMapped]
        public int CountInstallment { get; set; }

        [NotMapped]
        public decimal ProfitThisUnit
        {
            get
            {
                var price = 0m;
                if (Unit != null)
                {
                    price = Math.Round(TotalPriceBuy - Unit.TotalCostThisUintPrice);
                    if (ByEmplyee != null)
                        price -= Math.Round((price * (decimal)ByEmplyee.Persant) / 100, 1);
                }
                return price;
            }
        }

        [NotMapped]
        public decimal ManeyPayNow { get; set; }

        [NotMapped]
        public CashPayment PaymentOf { get; set; }

        [NotMapped]
        public string? PrccessNumberSheekorvisa { get; set; } = "";

        [NotMapped]
        public List<PaymentMoney> GetTablePayments
        {
            get
            {
                var list = new List<PaymentMoney>();
                if (systemPayments == SystemPayment.Installments)
                {
                    var Remaining = Total - ManeyPayNow;

                    if (ManeyPayNow > 0)
                    {
                        list.Add(new PaymentMoney
                        {
                            Idsale = ID,
                            DatePayment = DateSale.ToDateTime(TimeOnly.MinValue),
                            Money = ManeyPayNow,
                            NumberPaymentProcess =  HelperEx.PaymentDown + $"{DateSale.Year}{DateSale.Month}" + new Random().Next(5000 , 99000000).ToString(),
                            Paymentis = PaymentIs.DownPayment,
                            CashPayment = PaymentOf,
                            DonePayment = true,
                            SheekBank = PrccessNumberSheekorvisa
                        });
                    }
                    var Length = SpanMonthLenght;
                    var InstallManey = Math.Round(Remaining / CountInstallment, 2);
                    for (int i = 0; i < CountInstallment; i++)
                    {
                        list.Add(new PaymentMoney
                        {
                            Idsale = ID,
                            DatePayment = DateSale.AddMonths(Length).ToDateTime(TimeOnly.MinValue),
                            Money = InstallManey,
                            NumberPaymentProcess = "",
                            Paymentis = PaymentIs.Installment,
                            CashPayment = CashPayment.None,
                            DonePayment = false,
                            SheekBank = PrccessNumberSheekorvisa
                        });
                        Length += SpanMonthLenght;
                    }
                }
                else if(systemPayments == SystemPayment.Reservation)
                {
                    if(ManeyPayNow > 0)
                    {
                        var Remaining = Total - ManeyPayNow;
                        list.Add(new PaymentMoney
                        {
                            Idsale = ID,
                            DatePayment = DateSale.ToDateTime(TimeOnly.MinValue),
                            Money = ManeyPayNow,
                            NumberPaymentProcess = HelperEx.Payment + $"{DateSale.Year}{DateSale.Month}" + new Random().Next(5000, 99000000).ToString(),
                            Paymentis = PaymentIs.DownPayment,
                            CashPayment = PaymentOf,
                            DonePayment = true,
                            SheekBank = PrccessNumberSheekorvisa
                        });
                    }
                }
                else
                {
                    if (ManeyPayNow > 0)
                    {
                        list.Add(new PaymentMoney
                        {
                            Idsale = ID,
                            DatePayment = DateSale.ToDateTime(TimeOnly.MinValue),
                            Money = ManeyPayNow,
                            NumberPaymentProcess = HelperEx.Payment + $"{DateSale.Year}{DateSale.Month}" + new Random().Next(5000, 99000000).ToString(),
                            Paymentis = PaymentIs.Payment,
                            CashPayment = PaymentOf,
                            DonePayment = true,
                            SheekBank = PrccessNumberSheekorvisa
                        });
                    }
                }
                return list;
            }
        }

        [NotMapped]
        public decimal TheRemaining => (Total - ManeyPayNow);

        [NotMapped]
        public string? NameUint
        {
            get
            {
                if(Unit is not null && ToCustomer is not null && Unit.Project is not null && Unit.Category is not null && Unit.Floor is not null)
                {
                    return $"{ToCustomer.NameCustomer} - {Unit.Project.ProjectName}({Unit.Category.CategoryName}) - دور : {Unit.Floor.NameFloor} رقم الوحدة :{Unit.UnitNumber}";
                }
                else
                {
                    return $"";
                }
            }
        }

        [NotMapped]
        public bool IsUnitISFinish => FinishUnit is not null;

        [NotMapped]
        public string? Titel
        {
            get
            {
                if(Unit is not null)
                {
                    if(Unit.Project != null)
                    {
                        return Unit.UnitInformation;
                    }
                }
                return string.Empty;
            }
        }
    }
}
