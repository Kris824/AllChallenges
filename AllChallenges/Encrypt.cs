using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllChallenges
{
    class Encrypt
    {
        public static string Encryption(string s)
        {
            s = s.Replace(" ", "");
            var length = s.Length;
            var sqrtLowerBound = (int) Math.Floor(Math.Sqrt(length));
            var sqrtUpperBound = sqrtLowerBound * sqrtLowerBound < length ? sqrtLowerBound + 1 : sqrtLowerBound;

            var matrixStr = new List<string>();
            var startIndex = 0;
            var strLength = sqrtUpperBound;
            while (startIndex < length)
            {
                strLength = startIndex + strLength <= length ? strLength : length - startIndex;
                matrixStr.Add(s.Substring(startIndex, strLength));
                startIndex += strLength;
            }

            var result = new StringBuilder();
            for (var i = 0; i < sqrtUpperBound; i++)
            {
                foreach (var ms in matrixStr)
                {
                    if (i < ms.Length)
                    {
                        result.Append(ms[i]);
                    }
                }

                result.Append(" ");
            }

            return result.ToString().Trim();
        }
    }
}
