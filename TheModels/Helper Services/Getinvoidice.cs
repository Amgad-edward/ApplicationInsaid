using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheModels.Models;

namespace TheModels.Helper_Services
{
    public class Getinvoidice 
    {
       
        public string? InvoiceNumber { get; set; }

        public decimal TotalPrice { get; set; }

        [JsonConverter(typeof(DateConvertJosndateoly))]
        public DateOnly Date { get; set; }

        public decimal ManeyPaymnet { get; set; }

        public decimal ManeyRemaining { get; set; }

        public List<ItemInvioce>? Items { get; set; } = new List<ItemInvioce>();


    }
}
