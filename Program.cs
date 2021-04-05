using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace Bank_Transaction_Calculator
{
    class Program
    {
        public static void Main()
        {
            var jsonFilePath = @"C:\Users\MatthewIgbo\Desktop\Assessment 1\fees.config.json";
            var feeConfig = GetFeeConfig(jsonFilePath);
            bool pass;
            Console.WriteLine("Welcome, Enter Transaction Fee? ");
            pass = decimal.TryParse(Console.ReadLine(), out decimal transaction);

            if (!pass)
            {
                do
                {
                    Console.WriteLine("Please enter a valid amount to transfer");
                    pass = decimal.TryParse(Console.ReadLine(), out transaction);
                } while (!pass);
            }
            var transferCharge = CalculatorFunctions.CalculateTransactionFee(transaction, feeConfig);
            var transferAmount = transaction - transferCharge;
            Console.WriteLine($"Amount: {transaction} \nTransfer Amount: {transferAmount} \nCharge: {transferCharge} \nDebit Amount (Transfer Amount + Charge): {transaction} \nThank you for banking with us");

            Console.ReadLine();
        } 

        public static List<Fee> GetFeeConfig(string path)
        {
            string json = File.ReadAllText(path);
            var fees = JsonConvert.DeserializeObject<Root>(json);
            return fees.Fees;
        }

        
    }

}
