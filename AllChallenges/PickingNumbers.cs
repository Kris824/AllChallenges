using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllChallenges
{
    class PickingNumbers
    {
        public static int pickingNumbers(List<int> a)
        {
            List<int> orderedDistinct = a.Distinct().OrderBy(num => num).ToList();
            int maxCount = 0;
            int retVal = 0;
            foreach(int num in orderedDistinct)
            {
                maxCount = 0;
                maxCount += a.Where(n => n == num).Count();
                maxCount += a.Where(n => n == (num + 1)).Count();

                retVal = retVal > maxCount ? retVal : maxCount;
            }

            return retVal;
        }
    }
}
