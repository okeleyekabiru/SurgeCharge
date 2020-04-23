using System;
using TransactionSurgeFee.BusinessLogic;
using TransactionSurgeFee.UiConsole;

namespace TransactionSurgeFee
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           Page uiPage = new Page();
           uiPage.LandingPage();
            // Configuration.GetFeeSection();
        }
    }
}
