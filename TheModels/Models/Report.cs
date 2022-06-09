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
    [Table("report")]
    public class Report
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string? Titel { get; set; }

        [StringLength(1200)]
        public string? Comment { get; set; }

        [ForeignKey("Customer")]
        public int idCustomer { get; set; }

        public Customer? Customer { get; set; }

        [ForeignKey("Emplyee")]
        public int IdEmplyee { get; set; }

        public Emplyee? Emplyee { get; set; }

        [JsonConverter(typeof(DateConvertJosndateoly))]
        public DateOnly? Date { get; set; }

        public bool IsOkyDone { get; set; }

        public bool Think { get; set; }

        public bool BackcallHim { get; set; }

        public bool DoNotAgree { get; set; }

        public bool HeIsCome { get; set; }

        public bool Telephone { get; set; }

        public bool WhatsApp { get; set; }

        public bool DoneReport { get; set; }
    }
}
