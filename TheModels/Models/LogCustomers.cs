using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("logcustomers")]
    public class LogCustomers
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30) , Required]
        public string? UserNameOrEmail { get; set; }

        [StringLength(21) , Required]
        public string? Password { get; set; }

        [ForeignKey("Customer")]
        public int IdCustomer { get; set; }

        public Customer? Customer { get; set; }

        [NotMapped]
        public string? GetGide
        {
            get
            {
                if(Customer != null)
                {
                    return Customer.GideID;
                }
                return null;
            }
        }

    }
}
