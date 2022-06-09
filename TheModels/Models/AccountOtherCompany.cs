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
    [Table("accountothercompany")]
    public class AccountOtherCompany
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Company")]
        public int Idcompany { get; set; }

        public OtherCompanies? OtherCompanies { get; set; }

        public decimal Maney { get; set; }


        [JsonConverter(typeof(DateConvertJosndateoly))]
        public DateOnly Date { get; set; }


    }
}
