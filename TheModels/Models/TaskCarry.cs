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
    [Table("taskcarry")]
    public class TaskCarry
    {
        [Key]
        public int Id { get; set; }

        [StringLength(320)]
        public string? TheTask { get; set; }

        [JsonConverter(typeof(DateConvertJosndateoly))]
        public DateOnly date { get; set; }

        [ForeignKey("Emplyee")]
        public int IdEmplyee { get; set; }

        public Emplyee? Emplyee { get; set; }

        public bool DoneTask { get; set; }

        [StringLength(200)]
        public string? Resulte { get; set; }

        [ForeignKey("Company")]
        public int? IdCompany { get; set; }

        public OtherCompanies? Company { get; set; }
    }
}
