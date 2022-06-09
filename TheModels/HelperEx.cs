using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheModels.Helper_Services;
using TheModels.Models;


namespace TheModels
{
    public static class HelperEx
    {
        public const string PaymentDown = "PYD";
        public const string PaymentInstallment = "PYI";
        public const string Payment = "PYP";


        public static string TotextMoney(this decimal source)
        {
            return $"{Math.Round(source, 1)} جم";
        }

        public static string GetTextEnum(this Enum enums)
        {
            var field = enums.GetType().GetField(enums.ToString());
            if (field != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes is { } && attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
            }
            return string.Empty;
        }

        public static IEnumerable<Getinvoidice> GetInvioce(this IEnumerable<BuildingCost> buildingCosts)
        {
            var list = new List<Getinvoidice>();
            if (buildingCosts != null)
            {
                var Numberinvioce = buildingCosts.Where(x => x.Material is not null && x.ISPaymentDone).Select(s => s.InvoiceNumber).Distinct();
                foreach (var Number in Numberinvioce)
                {
                    var InviocesList = buildingCosts.Where(x => x.InvoiceNumber == Number);
                    var Get = new Getinvoidice();
                    Get.Date = InviocesList.FirstOrDefault().Date;
                    Get.InvoiceNumber = Number;
                    Get.ManeyPaymnet = InviocesList.Sum(s => s.TotalPayment);
                    Get.TotalPrice = InviocesList.Sum(s => s.TotalPrice);
                    Get.ManeyRemaining = InviocesList.Sum(s => s.TotalRemaining);
                    foreach (var invioce in InviocesList)
                    {
                        Get.Items.Add(invioce);
                    }
                    list.Add(Get);
                }
            }

            return list;
        }

        public static IEnumerable<Getinvoidice> GetInvioce(this IEnumerable<FinishCost> FinishCosts)
        {
            var list = new List<Getinvoidice>();
            if (FinishCosts is not null)
            {
                var Numberinvioce = FinishCosts.Where(x => x.Material is not null && x.ISPaymentDone).Select(s => s.InvoiceNumber).Distinct();
                foreach (var Number in Numberinvioce)
                {
                    var InviocesList = FinishCosts.Where(x => x.InvoiceNumber == Number);
                    var Get = new Getinvoidice();
                    Get.Date = InviocesList.FirstOrDefault().Date;
                    Get.InvoiceNumber = Number;
                    Get.ManeyPaymnet = InviocesList.Sum(s => s.TotalPayment);
                    Get.TotalPrice = InviocesList.Sum(s => s.TotalPrice);
                    Get.ManeyRemaining = InviocesList.Sum(s => s.TotalRemaining);
                    foreach (var invioce in InviocesList)
                    {
                        Get.Items.Add(invioce);
                    }
                    list.Add(Get);
                }
            }

            return list;
        }
    }
}
