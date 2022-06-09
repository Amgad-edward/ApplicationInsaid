using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("paymantmoney")]
    public class PaymentMoney
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("RevervationSale")]
        public int Idsale { get; set; }

        public ResertvationAndSale? RevervationSale { get; set; }

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
        public decimal Remaning => (RevervationSale.TheRemaining - Money);
    }
}
