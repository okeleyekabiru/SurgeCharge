using System;
using System.Collections.Generic;
using System.Text;
using TransactionSurgeFee.BusinessLogic;

namespace TransactionSurgeFee.UiConsole
{
  public  class Page
    {
        public  void LandingPage()
        {
            Console.WriteLine("================================================================");
            Console.WriteLine("                Welcome to surge transaction");
            Console.WriteLine();
            Console.WriteLine("       Transfer to a friend this holiday free of charge with T && C apply");
            Console.WriteLine();
            Console.WriteLine("                press any key to proceed");
            Console.WriteLine();
            Console.WriteLine("=================================================================");
            Console.ReadLine();
            Console.Clear();
            RunPage();

        }

        public void RunPage()
        {
          
            Console.WriteLine("================================================================");
            var fees = Configuration.GetFeeSection();
            foreach (var VARIABLE in fees.Fees)
            {
                Console.WriteLine();
                Console.WriteLine($"transfer between N{VARIABLE.MinAmount} to N{VARIABLE.MaxAmount} minus the charge eg {VARIABLE.MaxAmount - VARIABLE.FeeAmount}");
                Console.WriteLine();
            }
            Console.WriteLine("                press any key to proceed");
            Console.WriteLine("=================================================================");
            Console.ReadLine();
            Console.Clear();
            InputPage();
        }

        public void InputPage()
        {
            bool isValidInput = false;
            int input;
            do
            {
                Console.WriteLine();
                 Console.WriteLine("                           please provide the amount to  transfer");
           isValidInput = int.TryParse(Console.ReadLine(),out  input);


           Console.WriteLine();
            Console.WriteLine("=================================================================");
            } while (!isValidInput);

            var amount = ApplyCharges.AmountToPay(Configuration.GetFeeSection,input);
            Console.WriteLine("================================================");
            Console.WriteLine("Amount  TransferAmount  Charges   Amount to be Debited  ");
            Console.WriteLine($"{amount.Amount}       {amount.AdvisedAmount}        {amount.AmountCharge}          {amount.AmountDebited} ");
            Console.WriteLine($"the transaction amount of {amount.AdvisedAmount} will be model");
            Console.WriteLine("press any key to continue");
            Console.WriteLine("===============================================");
            Console.Read();
        }
    }
}