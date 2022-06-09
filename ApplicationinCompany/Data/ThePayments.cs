using System;
using System.Collections.Generic;
using System.Linq;
using TheModels;
using TheModels.Models;
using TheModels.InterfaceUnitWork;
using TheModels.Helper_Services;



namespace ApplicationinCompany.Data
{
    public class ThePayments : OperatorPayments 
    {

        private readonly CollectionsPayment? ThePaymentLoad;

        private readonly IUntiWork db;

        public PaymentMoney? Payment { get; set; } 

        public PaymentFinish? PaymentFinish { get; set; } 

        public string Ramaining
        {
            get
            {
                if(ThePaymentLoad.Resertvation != null)
                {
                    var Pay = ThePaymentLoad.Resertvation;
                    if(Pay != null)
                    {
                        if (Pay.TotalRemaining > 0)
                            return $"المتبقى : {(Pay.TotalRemaining - Payment.Money).ToMoney()} - ({(Pay.TotalRemaining - Payment.Money).ConvertNumberToText()} جنيها)";

                    }
                }
                else if(ThePaymentLoad != null)
                {
                    var Pay = ThePaymentLoad.FinishesUnit;
                    if(Pay is not null)
                    {
                        return $"المتبقى : {(Pay.TotalRemaining - PaymentFinish.Money).ToMoney()} - ({(Pay.TotalRemaining - PaymentFinish.Money).ConvertNumberToText()} جنيها)";
                    }
                }
                return string.Empty;
            }
        }


        public CollectionsPayment? Collections => ThePaymentLoad;

        public decimal MoneyRemaining
        {
            get
            {
                if (ThePaymentLoad.Resertvation != null)
                {
                    var Pay = ThePaymentLoad.Resertvation;
                    if (Pay != null)
                    {
                        return Pay.TotalRemaining;
                    }
                }
                else if (ThePaymentLoad != null)
                {
                    var Pay = ThePaymentLoad.FinishesUnit;
                    if (Pay is not null)
                    {
                        return Pay.TotalRemaining;
                    }
                }
                return default;
            }
        }

        public ThePayments(CollectionsPayment pay , IUntiWork untiWork)
        {
            this.ThePaymentLoad = pay;
            this.db = untiWork;
            Get();
          
        }

      
        private void Get()
        {
            if(ThePaymentLoad.Resertvation != null)
            {
                var Pay = ThePaymentLoad.Resertvation;
                if(Pay is not null)
                {
                    if(Pay.TheRemaining > 0)
                    {

                        if(Pay.systemPayments == SystemPayment.Installments)
                        {
                            Payment = Pay.PaymentMoney.FirstOrDefault(x => !x.DonePayment && x.DatePayment.Date <= DateTime.Now &&x.Paymentis == PaymentIs.Installment);
                            if(Payment == null)
                            {
                                Payment = new PaymentMoney
                                {
                                    Idsale = Pay.ID,
                                    Paymentis = PaymentIs.Installment
                                };
                            }
                        }
                        else if(Pay.systemPayments == SystemPayment.Reservation)
                        {
                            Payment = new PaymentMoney();
                            Payment.Idsale = Pay.ID;
                            Payment.Paymentis = PaymentIs.Payment;
                        }
                    }
                }
            }
            else if(ThePaymentLoad.FinishesUnit != null)
            {
                var Pay = ThePaymentLoad.FinishesUnit;
                if(Pay != null)
                {
                    if(Pay.TotalRemaining > 0)
                    {
                        PaymentFinish = new PaymentFinish();
                        PaymentFinish.IdFinish = Pay.Id;
                        PaymentFinish.Paymentis = PaymentIs.Payment;
                    }
                }
            }
        }

        public async Task<bool> PaymentDone()
        {
            if(ThePaymentLoad.Resertvation is not null)
            {
                var Pay = ThePaymentLoad.Resertvation;
                if(Pay != null)
                {
                    if (Payment.Paymentis == PaymentIs.Installment)
                        Payment.NumberPaymentProcess = $"{HelperEx.PaymentInstallment}-{DateTime.Now.Year}-{Random.Shared.Next(DateTime.Now.DayOfYear)}-{new Random().Next(700, 6653210)}";
                    else if (Payment.Paymentis == PaymentIs.Payment)
                        Payment.NumberPaymentProcess = $"{HelperEx.Payment}-{DateTime.Now.Year}-{Random.Shared.Next(DateTime.Now.DayOfYear)}-{new Random().Next(3200, 96586340)}";
                    if (Pay.PaymentMoney == null || !Pay.PaymentMoney.Any())
                        Pay.PaymentMoney = new List<PaymentMoney>();
                    Payment.DonePayment = true;
                    Payment.Money = Payment.Money.ToRound(2);
                    Pay.PaymentMoney.Add(Payment);
                    await db.SaveChangeAsync();
                    return true;
                }
               
            }
            else if(ThePaymentLoad.FinishesUnit is not null)
            {
                var Pay = ThePaymentLoad.FinishesUnit;
                if (Pay != null)
                {
                    if (PaymentFinish.Paymentis == PaymentIs.Installment)
                        PaymentFinish.NumberPaymentProcess = $"{HelperEx.PaymentInstallment}-{DateTime.Now.Year}-{Random.Shared.Next(DateTime.Now.DayOfYear)}-{new Random().Next(3654, 659845560)}";
                    else if (PaymentFinish.Paymentis == PaymentIs.Payment)
                        PaymentFinish.NumberPaymentProcess = $"{HelperEx.Payment}-{DateTime.Now.Year}-{Random.Shared.Next(DateTime.Now.DayOfYear)}-{new Random().Next(1200,888956540)}";
                  
                    if (Pay.PaymentMoney == null || !Pay.PaymentMoney.Any())
                        Pay.PaymentMoney = new List<PaymentFinish>();

                    PaymentFinish.DonePayment = true;
                    PaymentFinish.Money = PaymentFinish.Money.ToRound(2);
                    Pay.PaymentMoney.Add(PaymentFinish);
                    await db.SaveChangeAsync();
                    return true;
                }
            }

            return false;
        }


    }
}
