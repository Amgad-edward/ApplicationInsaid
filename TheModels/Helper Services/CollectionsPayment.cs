using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheModels.Models;

namespace TheModels.Helper_Services
{
    public class CollectionsPayment
    {

       public ResertvationAndSale? Resertvation { get; private set; }

       public FinishesUnit? FinishesUnit { get; private set; }


        public string? NameResulte
        {
            get
            {
                if(Resertvation is not null)
                {
                    return $"{Resertvation.ToCustomer.NameCustomer}";
                }
                else if(FinishesUnit != null)
                {
                    return $"{FinishesUnit.Customer.NameCustomer}";
                }
                return string.Empty;
            }
        }

        public string? SearchName
        {
            get
            {
                if (Resertvation is not null)
                {
                    return $"{Resertvation.ToCustomer.NameCustomer} - {Resertvation.Unit.UnitInformation}";
                }
                else if(FinishesUnit != null)
                {
                    return $"{FinishesUnit.Customer.NameCustomer} - {FinishesUnit.Information}";
                }
                return "";
            }
        }

       

        public static implicit operator CollectionsPayment(ResertvationAndSale resertvationAndSale)
        {
            var col = new CollectionsPayment();
            col.Resertvation = resertvationAndSale;
            col.FinishesUnit = null;
            return col;
        }
        public static implicit operator CollectionsPayment(FinishesUnit finishes)
        {
            var col = new CollectionsPayment();
            col.FinishesUnit = finishes;
            col.Resertvation = null;
            return col;
        }

      

    }

    
}
