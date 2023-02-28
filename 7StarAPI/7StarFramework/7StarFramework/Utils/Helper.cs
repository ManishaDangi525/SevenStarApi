using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenStar.Framework.Utils
{
    public static class Helper
    {

        public static decimal GetOTP()
        {
            decimal abc;
            Random generator = new Random();
            String r = generator.Next(0, 1000000).ToString("D6");
            abc = System.Convert.ToDecimal(r);
            return abc;

        }
    }
}
