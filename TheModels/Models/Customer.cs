using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required , StringLength(70)]
        public string? NameCustomer { get; set; }

        [StringLength(75)]
        public string? Phones { get; set; }

        [StringLength(21)]
        public string? PhoneSms { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }

        [StringLength(30)]
        public string? Email { get; set; }

        [StringLength(33)]
        public string? Jop { get; set; }

        [StringLength(90)]
        public string? GideID { get; set; }

        [StringLength(17)]
        public string? IDEgy { get; set; } 

        public double EvaluationCompany { get; set; }

        public IEnumerable<ResertvationAndSale>? Units { get; set; }

        public IEnumerable<Report>? Reports { get; set; }

        public IEnumerable<FinishesUnit>? FinishesUnits { get; set; }

    } 
}
