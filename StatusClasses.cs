using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Transaction_Calculator
{
    class StatusClasses
    {

        public class Root
        {
            public List<Fee> Fees { get; set; }
        }

        public class Fee
        {
            public int MinAmount { get; set; }
            public int MaxAmount { get; set; }
            public int FeeAmount { get; set; }
        }

    }
}

