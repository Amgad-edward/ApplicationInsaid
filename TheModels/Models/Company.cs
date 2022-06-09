using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("company")]
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required , StringLength(35)]
        public string? NameCompany { get; set; }

        [Required, StringLength(35)]
        public string? NameCompanyEng { get; set; }

        [StringLength(30)]
        public string? Maneger { get; set; }

        [StringLength(75)]
        public string? Phones { get; set; }

        [StringLength(90)]
        public string? Address { get; set; }

        [StringLength(115)]
        public string? Locations { get; set; }
        
        [StringLength(200)]
        public string? Information { get; set; }

        [StringLength(70)]
        public string? TitleActivity { get; set; }

        [StringLength(70)]
        public string? NumberCommercialRecord { get; set; }

        [StringLength(70)]
        public string? NumberTax { get; set; }

        [StringLength(200)]
        public string? IDCompanyApi { get; set; }

        [StringLength(200)]
        public string? Security1 { get; set; }

        [StringLength(200)]
        public string? Security2 { get; set; }

        [StringLength(200)]
        public string? ApiToken { get; set; }

        [StringLength(10000000)]
        public byte[]? Logo { get; set; }
    }
}
