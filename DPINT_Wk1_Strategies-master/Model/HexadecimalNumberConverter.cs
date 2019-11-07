﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk1_Strategies.Model
{
    class HexadecimalNumberConverter : INumberConverter
    {
        public string ToLocalString(int number)
        {
            return Convert.ToString(number, 16);
        }

        public int ToNumerical(string fromText)
        {
            return Convert.ToInt32(fromText, 16);
        }
    }
}
