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
    [Table("emplyee")]
    public class Emplyee
    {
        [Key]
        public int Id { get; set; }

        [StringLength(70) , Required]
        public string? Name { get; set; }

        [StringLength(35) , Required]
        public string? TitleJop { get; set; }

        public Jop TheJop { get; set; }

        public decimal BaseSalery { get; set; }

        public double Persant { get; set; }

        public TypeSalery type { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateBirth { get; set; }

        [JsonConverter(typeof(DateConvertJosndateoly))]
        public DateOnly StartWork { get; set; }

        [JsonConverter(typeof(DateConvertJosnTimeonly))]
        public TimeOnly StartTimeWork { get; set; }

        [JsonConverter(typeof(DateConvertJosnTimeonly))]
        public TimeOnly EndTimeWork { get; set; }

        public DayOfWeek WeekEnd { get; set; }

        [StringLength(97)]
        public string? GideID { get; set; }

        [StringLength(10000000)]
        public byte[]? Image { get; set; }
        public IEnumerable<SaleryPayment>? saleryPayments { get; set; }

        public IEnumerable<ResertvationAndSale>? AllSalesFormThisEmplyee { get; set; }

        public IEnumerable<FinishesUnit>? AllSaleToFinishUnit { get; set; }

        public IEnumerable<AttendingAndLeaving>? AttendingAndLeavings { get; set; }

        public IEnumerable<Report>? Reports { get; set; }

        public IEnumerable<TaskCarry>? TaskCarries { get; set; }

        ///Not Mapped/////////////////////////////


        [NotMapped]
        public IEnumerable<Report>? ReportFromWork =>
           Reports != null ? Reports.Where(x => !x.DoneReport) : default;

        [NotMapped]
        public IEnumerable<TaskCarry>? TaskfromWork =>
            TaskCarries is not null ? TaskCarries.Where(x => !x.DoneTask) : null;

        [NotMapped]
        public int TotalHourWork
        {
            get
            {
                var count = EndTimeWork - StartTimeWork;
                return (int)Math.Round(count.TotalHours);

            }
        }

        [NotMapped]
        public int TotalCountHourInWeek
        {
            get => TotalHourWork * 6;
        }

        [NotMapped]
        public int TotalCountHourInMonth
        {
            get => (TotalHourWork * 30);
        }

        [NotMapped]
        public float GetHourWorkInToDay
        {
            get
            {
                var Hours = 0f;
                if (DateTime.Now.DayOfWeek != WeekEnd)
                {
                    if (AttendingAndLeavings is not null)
                    {
                        var list = AttendingAndLeavings.Where(x => x.Date.Date == DateTime.Now.Date).OrderBy(r => r.Date);
                        if (list != null)
                        {
                            if (list.Count() == 1)
                            {
                                var Time = DateTime.Now - list.FirstOrDefault()?.Date;
                                Hours = (float)Math.Round(Time.Value.TotalHours, 1);
                            }
                            else if (list.Count() == 2)
                            {
                                var Time = list.FirstOrDefault(x => x.Leaving).Date - list.FirstOrDefault(x => x.Attending)?.Date;
                                Hours = (float)Math.Round(Time.Value.TotalHours, 1);
                            }
                            else
                            {
                                var Attending = list.Where(x => x.Attending).OrderBy(d => d.Date);
                                var leaving = list.Where(x => x.Leaving).OrderBy(d => d.Date);
                                foreach (var A in Attending)
                                {
                                    foreach (var l in leaving)
                                    {
                                        var Time = l.Date - A.Date;
                                        Hours += (float)Math.Round(Time.TotalHours, 2);
                                    }
                                }
                            }
                        }

                    }
                }
                return Hours;
            }
        }

        [NotMapped]
        public float GetHourWorkThisMonth
        {
            get
            {
                var count = 0f;
                if (AttendingAndLeavings != null)
                {
                    var Days = AttendingAndLeavings.AsEnumerable()
                             .Where(x => x.Date.Date.Month == DateTime.Now.Date.Month && x.Date.Date.Year == DateTime.Now.Date.Year)
                             .OrderBy(d => d.Date).ToList();
                    if (Days != null)
                    {
                        var theDayAttend = Days.Select(s => s.Date).Distinct().OrderBy(x => x.Date);
                        foreach (var day in theDayAttend)
                        {
                            var attend = Days.Where(x => x.Date.Date == day.Date && x.Attending).Select(select => select.Date).OrderBy(d => d.Date);
                            var leaving = Days.Where(x => x.Date.Date == day.Date && x.Leaving).Select(s => s.Date).OrderBy(d => d.Date);
                            if (attend != null && leaving != null)
                            {
                                foreach (var att in attend)
                                {
                                    foreach (var leav in leaving)
                                    {
                                        var Time = leav - att;
                                        count += (float)Math.Round(Time.TotalHours, 1);
                                    }
                                }
                            }
                        }
                    }
                }
                return count;
            }
        }

        [NotMapped]
        public decimal SalelryOnHour =>
            type == TypeSalery.Baseonly || type == TypeSalery.BaseAndPersant ? Math.Round(BaseSalery / TotalCountHourInMonth, 1) : 0;

        [NotMapped]
        public decimal GetDiscountSaleryOnThisMonth
        {
            get
            {
                var total = 0m;
                if (type == TypeSalery.Baseonly || type == TypeSalery.BaseAndPersant)
                {
                    var hours = TotalCountHourInMonth - GetHourWorkThisMonth;
                    if (hours > 0)
                        total = (decimal)hours * SalelryOnHour;
                }
                return total;
            }

        }

        [NotMapped]
        public decimal GetOverTimeThismonth
        {
            get
            {
                var total = 0m;
                if (type == TypeSalery.Baseonly || type == TypeSalery.BaseAndPersant)
                {
                    var hours = GetHourWorkThisMonth - TotalCountHourInMonth;
                    if (hours > 0)
                        total = (decimal)hours * SalelryOnHour;
                }
                return total;
            }
        }

        [NotMapped]
        public decimal GetsalesPercantThisMonth
        {
            get
            {

                var total = 0m;
                if (type == TypeSalery.BaseAndPersant || type == TypeSalery.Persant)
                {
                    if (AllSalesFormThisEmplyee != null)
                    {
                        if (AllSalesFormThisEmplyee.Any(x => x.DateSale.Month == DateOnly.FromDateTime(DateTime.Now).Month && x.DateSale.Year == DateOnly.FromDateTime(DateTime.Now).Year))
                        {
                            var Sale = AllSalesFormThisEmplyee.Where(x => x.DateSale.Month == DateOnly.FromDateTime(DateTime.Now).Month && x.DateSale.Year == DateOnly.FromDateTime(DateTime.Now).Year);
                            total = Math.Round(((Sale.Sum(s => s.Total) * (decimal)Persant)) / 100, 1);
                        }
                    }
                    if (AllSaleToFinishUnit != null)
                    {
                        if (AllSaleToFinishUnit.Any(x => x.date.Month == DateOnly.FromDateTime(DateTime.Now).Month && x.date.Year == DateOnly.FromDateTime(DateTime.Now).Year))
                        {
                            var Allsale = AllSaleToFinishUnit.Where(x => x.date.Month == DateOnly.FromDateTime(DateTime.Now).Month && x.date.Year == DateOnly.FromDateTime(DateTime.Now).Year);
                            total += Math.Round((Allsale.Sum(x => x.TotalPriceBuy) * (decimal)Persant) / 100, 1);
                        }
                    }
                    if (saleryPayments != null)
                    {
                        if (saleryPayments.Any(x => x.date.Month == DateOnly.FromDateTime(DateTime.Now).Month && x.date.Year == DateOnly.FromDateTime(DateTime.Now).Year && x.SaleOF == PaymentSaleOF.FromPercant))
                        {
                            var AllPayment = saleryPayments
                                .Where(x => x.date.Month == DateOnly.FromDateTime(DateTime.Now).Month && x.date.Year == DateOnly.FromDateTime(DateTime.Now).Year && x.SaleOF == PaymentSaleOF.FromPercant)
                                .Sum(s => s.MoneyTake);

                            total -= AllPayment;
                        }
                    }
                }
                return total;
            }
        }

        [NotMapped]
        public decimal BaseSaleryOnThisMonth
        {
            get
            {
                if(saleryPayments != null && (type == TypeSalery.Baseonly || type == TypeSalery.BaseAndPersant) )
                {
                    if(saleryPayments.Any(x=>x.SaleOF == PaymentSaleOF.Fromsale && x.date.Month == DateOnly.FromDateTime(DateTime.Now).Month && x.date.Year == DateOnly.FromDateTime(DateTime.Now).Year))
                    {
                        var Allsale = saleryPayments.Where(x => x.SaleOF == PaymentSaleOF.Fromsale && x.date.Month == DateOnly.FromDateTime(DateTime.Now).Month && x.date.Year == DateOnly.FromDateTime(DateTime.Now).Year);
                        return  (BaseSalery -  Allsale.Sum(x => x.MoneyTake));
                    }
                }
                return 0;
            }
        }

        [NotMapped]
        public decimal GetAllPersantSale
        {
            get
            {
                var total = 0m;
                if (type == TypeSalery.BaseAndPersant || type == TypeSalery.Persant)
                {

                    if (AllSalesFormThisEmplyee != null)
                    {
                        total = ((AllSalesFormThisEmplyee.Sum(s => s.TotalPriceBuy) * (decimal)Persant)) / 100;
                    }
                    if(AllSaleToFinishUnit != null)
                    {
                        total+= (AllSaleToFinishUnit.Sum(s => s.TotalPriceBuy) * (decimal)Persant) / 100;
                    }
                    return Math.Round(total,1);
                }
                return 0;
            }
        }

        [NotMapped]
        public string Age
        {
            get
            {
                var timespan = DateTime.Now.Year - DateBirth.Year;
                return $"{timespan} سنة";
            }
        }

        [NotMapped]
        public string AgeInWork
        {
            get
            {
                var timespan = DateTime.Now - StartWork.ToDateTime(TimeOnly.MinValue);
                var total = Math.Round(timespan.TotalDays);
                if(total >= 1 && total < 30)
                {
                    return $"{total} يوم";
                }
                else if(total >= 30 && total < 365)
                {
                    return $"{Math.Round(total / 30) ,1} شهر";
                }
                else
                {
                    return $"{Math.Round(total / 365 , 1)} سنة";
                }
            }
        }

        [NotMapped]
        public int CountSaleTask
        {
            get
            {
                var count = 0;
                if (AllSalesFormThisEmplyee != null)
                {
                    if (AllSalesFormThisEmplyee.Any())
                        count = AllSalesFormThisEmplyee.Count();
                }
                if (AllSaleToFinishUnit != null)
                {
                    if (AllSaleToFinishUnit.Any())
                        count += AllSaleToFinishUnit.Count();
                }

                return count;
            }

        }

        [NotMapped]
        public decimal TotalAllSalePrice
        {
            get
            {
                var total = 0m;
                if (AllSalesFormThisEmplyee != null)
                    if (AllSalesFormThisEmplyee.Any())
                        total = AllSalesFormThisEmplyee.Sum(s => s.TotalPriceBuy);

                if (AllSaleToFinishUnit != null)
                    if (AllSaleToFinishUnit.Any())
                        total += AllSaleToFinishUnit.Sum(s => s.TotalPriceBuy);

                return total;
            }
        }
    }
}
