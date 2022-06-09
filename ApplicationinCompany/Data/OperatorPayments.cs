


using TheModels;
using TheModels.Models;
using TheModels.Helper_Services;

namespace ApplicationinCompany.Data
{
    public interface OperatorPayments
    {
        PaymentMoney? Payment { get; set; }

        PaymentFinish? PaymentFinish { get; set; }

        CollectionsPayment? Collections { get; } 

        string Ramaining { get; }

        decimal MoneyRemaining { get; }

        Task<bool> PaymentDone();
    }


}
