using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

using static Bank_Transaction_Calculator.StatusClasses;

namespace Bank_Transaction_Calculator
{
    class Program
    {
        public static void Main()
        {
            var jsonFilePath = @"C:\Users\MatthewIgbo\Desktop\Assessment 1\fees.config.json";
            var feeConfig = GetFeeConfig(jsonFilePath);
            bool pass;
            Console.WriteLine("Welcome, how much would you like to transfer? ");
            pass = decimal.TryParse(Console.ReadLine(), out decimal transaction);

            if (!pass)
            {
                do
                {
                    Console.WriteLine("Please enter a valid amount to transfer");
                    pass = decimal.TryParse(Console.ReadLine(), out transaction);
                } while (!pass);
            }
            var transferCharge = CalculateTransactionFee(transaction, feeConfig);
            var transferAmount = transaction - transferCharge;
            Console.WriteLine($"Amount {transaction} \nTransfer Amount {transferAmount} \nCharge {transferCharge} \nDebit Amount (Transfer Amount + Charge) {transaction} . \nThank you for banking with us");

            Console.ReadLine();
        } 

        public static List<Fee> GetFeeConfig(string path)
        {
            string json = File.ReadAllText(path);
            var fees = JsonConvert.DeserializeObject<Root>(json);
            return fees.Fees;
        }

        public static decimal CalculateTransactionFee(decimal AmountToBeTransferred, List<Fee> feesConfig)
        {
            decimal charge = 0.0m;
            foreach (var fee in feesConfig)
            {
                if (AmountToBeTransferred >= fee.MinAmount && AmountToBeTransferred <= fee.MaxAmount)
                {
                    charge = fee.FeeAmount;
                }
            }
            return charge;
            
        }
    }

}
