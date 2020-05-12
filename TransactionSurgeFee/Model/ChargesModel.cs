using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionSurgeFee.Model
{
   public class ChargesModel
    {
        public double Amount { get; set; }
        public double AmountCharge { get; set; }
        public double AmountDebited { get; set; }
        public double AdvisedAmount{ get; set; }
    }
}
