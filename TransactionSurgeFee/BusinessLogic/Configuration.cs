using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using TransactionSurgeFee.Model;

namespace TransactionSurgeFee.BusinessLogic
{
    public class Configuration
    {

        public static FeesCharges GetFeeSection()
        {
            FeesCharges fees = new FeesCharges();

            var path = @"C:\Users\toby\source\repos\TransactionSurgeFee\TransactionSurgeFee\wwwroot\fees.config.json";
            try
            {
                string fileContent = String.Empty;
                StreamReader reader = new StreamReader(path);
                fileContent = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(fileContent))
                {
                  fees =  JsonConvert.DeserializeObject<FeesCharges>(fileContent);
                }
               
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return fees;

        }

      

    }
}