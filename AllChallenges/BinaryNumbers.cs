using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AllChallenges
{
    class BinaryNumbers
    {
        public static void ConvertToBinary(int n)
        {
            StringBuilder sb = new StringBuilder();
            int rem = 0;
            while (n > 1)
            {
                rem = n % 2;
                sb.Append(rem);
                n /= 2;
            }

            sb.Append(n);
            string binary = new string(sb.ToString().Reverse().ToArray());
            Console.WriteLine(binary);
            string[] binaryArr = binary.Split('0');
            IEnumerable<string> ordered = binaryArr.OrderByDescending(s => s.Length);
            Console.WriteLine(ordered.First().Count());
        }
    }
}
