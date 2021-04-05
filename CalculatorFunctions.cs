using System.Collections.Generic;

namespace Bank_Transaction_Calculator
{
    public class CalculatorFunctions
    {
        public static decimal CalculateTransactionFee(decimal amount, List<Fee> feesConfig)
        {
            decimal charge = 0.0m;
            foreach (var fee in feesConfig)
            {
                if (amount >= fee.MinAmount && amount <= fee.MaxAmount)
                {
                    charge = fee.FeeAmount;
                }
            }
            return charge;

        }
    }
}