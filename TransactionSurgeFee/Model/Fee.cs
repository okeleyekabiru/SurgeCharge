﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionSurgeFee.Model
{
   public class Fee
    {
        public double MinAmount { get; set; }
        public double MaxAmount { get; set; }

        public double FeeAmount  { get; set; }
    }
}
