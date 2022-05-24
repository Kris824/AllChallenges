using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllChallenges
{
    public class MaxDeletions
    {
        public static int EqualizerArray(List<int> list)
        {
            list.Sort();
            var distinctList = list.Distinct().ToList();
            var numberOfOccurrences = 0;
            foreach (var element in distinctList)
            {
                var firstIndex = list.IndexOf(element);
                var lastIndex = list.LastIndexOf(element);
                var currentEleOccurrences = lastIndex - firstIndex + 1;
                if (currentEleOccurrences <= numberOfOccurrences) continue;
                numberOfOccurrences = currentEleOccurrences;
            }

            return list.Count - numberOfOccurrences;
        }
    }
}
