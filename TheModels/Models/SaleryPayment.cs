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
    [Table("salerypayment")]
    public class SaleryPayment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Emplyee")]
        public int Idemplyee { get; set; }

        public Emplyee? Emplyee { get; set; }

        public Months ToMonth { get; set; }

        public decimal MoneyTake { get; set; }

        [JsonConverter(typeof(DateConvertJosndateoly))]
        public DateOnly date { get; set; }

        public PaymentSaleOF SaleOF { get; set; }

    }
}
