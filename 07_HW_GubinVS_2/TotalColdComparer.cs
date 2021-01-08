using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _07_HW_GubinVS_2
{
    class TotalColdComparer : IComparer<DataFields>
    {
        public int Compare([AllowNull] DataFields x, [AllowNull] DataFields y)
        {
            if (x.TotalCold < y.TotalCold)
            {
                return -1;
            }
            else if (x.TotalCold > y.TotalCold)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}
