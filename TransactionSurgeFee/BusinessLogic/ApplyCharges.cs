using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransactionSurgeFee.Model;

namespace TransactionSurgeFee.BusinessLogic
{
  public  class ApplyCharges
    {
   
      

        public static ChargesModel AmountToPay(Func<FeesCharges> fees, double amount)
        {
            double debitAmount = 0;
             double feeToPay = 0;
             double maxAmount =0;
            foreach (var elem in fees.Invoke().Fees)
            {
                if (amount >= elem.MinAmount && amount <= elem.MaxAmount)
                {
                    feeToPay = elem.FeeAmount;
                  

                }



            }

            var actualfee = feeToPay;
            if (feeToPay > 0)
            {

           

          var  transferAmount = amount - feeToPay;

            feeToPay = fees.Invoke().Fees.Where(c => transferAmount <= c.MaxAmount && transferAmount >= c.MinAmount)
                .Select(c => c.FeeAmount).FirstOrDefault();
         debitAmount = transferAmount + feeToPay;


            }

            if(actualfee.Equals(feeToPay))
            return new ChargesModel
            {
                AdvisedAmount = amount - feeToPay,
                AmountCharge = feeToPay,
                AmountDebited = debitAmount ,
                Amount =  amount
            };

            return new ChargesModel
            {
                 AdvisedAmount = amount - actualfee
                ,AmountDebited = amount,
                Amount = amount,
                AmountCharge = actualfee
            };

        }

      
        }
    }

