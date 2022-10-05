using System;
using System.Collections.Generic;
using System.Text;

namespace AllChallenges
{
    class TaumsBday
    {
        public static long TaumBday(int b, int w, int bc, int wc, int z)
        {
            long retVal;
            long l_b = b, l_w = w, l_bc = bc, l_wc = wc, l_z = z;
            if (l_bc + l_z < l_wc)
            {
                retVal = l_b * l_bc + (l_bc + l_z) * l_w;
            }
            else if (l_wc + l_z < l_bc)
            {
                retVal = (l_wc + l_z) * l_b + l_wc * l_w;
            }
            else
            {
                retVal = l_b * l_bc + l_w * l_wc;
            }

            return retVal;
        }
    }
}
