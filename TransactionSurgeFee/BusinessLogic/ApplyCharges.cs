using System;
using System.Collections.Generic;
using System.Text;
using TransactionSurgeFee.Model;

namespace TransactionSurgeFee.BusinessLogic
{
  public  class ApplyCharges
    {
   
      

        public static double AmountToPay(Func<FeesCharges> fees, double amount)
        {
             double feeToPay = 0;
             double maxAmount =0;
            foreach (var elem in fees.Invoke().Fees)
            {
                if (amount >= elem.MinAmount && amount <= elem.MaxAmount)
                {
                    feeToPay = elem.FeeAmount;
                   maxAmount = elem.MaxAmount;

                }



            }

            
            var amountToPay = amount + feeToPay;
          
            return amountToPay;
        }

      
        }
    }

