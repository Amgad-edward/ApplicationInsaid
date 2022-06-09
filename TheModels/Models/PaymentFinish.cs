using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("paymentfinish")]
    public class PaymentFinish
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("FinishesUnit")]
        public int IdFinish { get; set; }

        public FinishesUnit? FinishesUnit { get; set; }

        public decimal Money { get; set; }

        public PaymentIs Paymentis { get; set; }

        public CashPayment CashPayment { get; set; }

        [StringLength(70)]
        public string? NumberPaymentProcess { get; set; }

        [StringLength(70)]
        public string? SheekBank { get; set; }

        public DateTime DatePayment { get; set; }

        public bool DonePayment { get; set; }

        [NotMapped]
        public decimal Remaining => FinishesUnit.TotalRemaining - Money;
    }
}
