using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheModels.Models
{
    [Table("thepaymentcost")]
    public class ThePaymentCost
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Buildingcost")]
        public int? IdBuildingcost { get; set; }

        public BuildingCost? Buildingcost { get; set; }

        [ForeignKey("Finishcost")]
        public int? IdBFinishingcost { get; set; }

        public FinishCost? Finishcost { get; set; }

        public decimal ManeyPayment { get; set; }

        public DateOnly date { get; set; }

        [NotMapped]
        public decimal Remaining
        {
            get
            {
                if(Buildingcost is not null)
                {
                    return (Buildingcost.TotalRemaining - ManeyPayment);
                }
                else if(Finishcost != null)
                {
                    return (Finishcost.TotalRemaining - ManeyPayment);
                }
                return 0;
            }
        }

    }
}
