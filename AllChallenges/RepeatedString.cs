using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllChallenges
{
    public class RepeatedString
    {
        public static long GetRepeatedString(string s, long n)
        {
            var length = s.Length;
            long numberOfOccurrences = s.ToCharArray().Count(x => x == 'a');

            if (length == n)
            {
                return numberOfOccurrences;
            }

            if (length > n)
            {
                s = s[..(int) n];
                numberOfOccurrences = s.ToCharArray().Count(x => x == 'a');
            }
            else
            {
                var div = n / length;
                var rem = n % length;
                numberOfOccurrences *= div;
                if (rem <= 0) return numberOfOccurrences;
                s = s[..(int) rem];
                numberOfOccurrences += s.ToCharArray().Count(x => x == 'a');
            }
            
            return numberOfOccurrences;
        }
    }
}
