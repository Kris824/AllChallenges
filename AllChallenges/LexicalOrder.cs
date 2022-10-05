using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AllChallenges
{
    class LexicalOrder
    {
        public static string BiggerIsGreater(string w)
        {
            var length = w.Length;
            switch (length)
            {
                case 1:
                    return "no answer";
                case 2:
                    return w[0] < w[1] ? string.Concat(w.Reverse()) : "no answer";
            }

            var lastCharIndex = w.Length - 1;
            var lastChar = w[lastCharIndex];
            var charToReplace = char.MinValue;
            var newLength = length - 2;
            while (newLength >= 0)
            {
                for (var i = newLength; i >= 0; i--)
                {
                    if (w[i] >= lastChar) continue;
                    charToReplace = w[i];
                    break;
                }

                if (charToReplace != char.MinValue || newLength == 0) break;

                lastCharIndex = newLength;
                lastChar = w[lastCharIndex];
                newLength--;
            }

            if (charToReplace == char.MinValue)
            {
                return "no answer";
            }

            var lastIndex = w.LastIndexOf(charToReplace);
            var sb = new StringBuilder(w) {[lastIndex] = lastChar, [lastCharIndex] = charToReplace};
            var substring = sb.ToString(lastIndex + 1, sb.Length - lastIndex - 1);
            if (substring.Length <= 1) return sb.ToString();

            sb.Replace(substring, "");
            substring = string.Concat(substring.OrderBy(x => x));
            sb.Append(substring);

            return sb.ToString();
        }

        public static string BiggerIsGreater2(string w)
        {
            var length = w.Length;
            var lastchar = w[length - 1];
            var beginSearch = length - 2;
            var replaceIndex = -1;
            for (var i = beginSearch; i >= 0; i--)
            {
                if(w[i] > lastchar) continue;
                replaceIndex = i;
                break;
            }

            var subString = w.Substring(replaceIndex, length);

            return string.Empty;
        }

        public static string BiggerIsGreater3(string w)
        {
            var length = w.Length;
            switch (length)
            {
                case 1:
                    return "no answer";
                case 2:
                    return w[0] < w[1] ? string.Concat(w.Reverse()) : "no answer";
            }

            var lastCharIndex = w.Length - 1;
            var lastChar = w[lastCharIndex];
            var charToReplace = char.MinValue;
            var newLength = length - 2;
            var lastIndex = -1;
            while (newLength >= 0)
            {
                for (var i = newLength; i >= 0; i--)
                {
                    if (w[i] >= lastChar) continue;
                    charToReplace = w[i];
                    lastIndex = i;
                    break;
                }

                if (charToReplace != char.MinValue || newLength == 0) break;

                lastCharIndex = newLength;
                lastChar = w[lastCharIndex];
                newLength--;
            }

            if (charToReplace == char.MinValue)
            {
                return "no answer";
            }

            var remainingStr = w.Substring(lastIndex + 1, length - lastIndex - 2);
            if (remainingStr.Length > 1)
            {
                var result = BiggerIsGreater3(remainingStr);

                if (!string.IsNullOrEmpty(result))
                {
                    var resLength = result.Length;
                    remainingStr = w.Substring(0, length - resLength);
                    remainingStr += result;
                    return remainingStr;
                }
            }

            var sb = new StringBuilder(w) { [lastIndex] = lastChar, [lastCharIndex] = charToReplace };
            var substring = sb.ToString(lastIndex + 1, sb.Length - lastIndex - 1);
            if (substring.Length <= 1) return sb.ToString();

            sb.Replace(substring, "", lastIndex + 1, substring.Length);
            substring = string.Concat(substring.OrderBy(x => x));
            sb.Append(substring);

            return sb.ToString();
        }

        private static string CheckSubstring(string substring)
        {
            var length = substring.Length;
            var beginSearch = length - 2;
            var searchChar = substring[beginSearch];
            var charToReplace = char.MinValue;
            var lastIndex = -1;
            while (beginSearch > 0)
            {
                for (var i = beginSearch - 1; i >= 0; i--)
                {
                    if (substring[i] >= searchChar) continue;
                    charToReplace = substring[i];
                    lastIndex = i;
                    break;
                }

                if (charToReplace != char.MinValue || beginSearch == 0) break;

                beginSearch--;
                searchChar = substring[beginSearch];
            }

            if (charToReplace == char.MinValue) return string.Empty;

            var remainingStr = substring.Substring(lastIndex + 1, length - lastIndex - 1);
            if (remainingStr.Length > 1)
            {
                substring = CheckSubstring(remainingStr);
            }

            var sb = new StringBuilder(substring) { [lastIndex] = searchChar, [beginSearch] = charToReplace };

            var strToSort = sb.ToString(lastIndex + 1, sb.Length - lastIndex - 1);
            sb.Replace(strToSort, "");
            strToSort = string.Concat(strToSort.OrderBy(x => x));
            sb.Append(strToSort);

            return sb.ToString();
        }
    }
}
