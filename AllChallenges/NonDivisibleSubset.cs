using System;
using System.Collections.Generic;
using System.Linq;

namespace AllChallenges
{
    public class NonDivisibleSubset
    {
        public static int GetNonDivisibleSubset(int k, List<int> s)
        {
            var subsets = new List<List<int>>();
            var subset = new List<int> { s[0] };
            var tempSet = subset.ToList();
            var subsetWithoutFirstElement = s.Skip(1);
            // Identify first subset
            foreach (var i in subsetWithoutFirstElement)
            {
                foreach (var j in subset)
                {
                    if ((j + i) % k != 0)
                    {
                        if (!tempSet.Contains(i))
                        {
                            tempSet.Add(i);
                        }
                    }
                    else
                    {
                        tempSet.Remove(i);
                        break;
                    }
                }

                subset = tempSet.ToList();
            }

            subsets.Add(subset);

            // Identify other subsets by skipping each element at a time from above identified set.
            foreach (var i in subset)
            {
                var subsetWithoutIdentifiedElements = s.Where(x => x != i).ToList();
                if (subsetWithoutIdentifiedElements.Count <= 0) continue;
                var subset2 = new List<int> {subsetWithoutIdentifiedElements[0]};
                subsetWithoutFirstElement = subsetWithoutIdentifiedElements.Skip(1);

                tempSet = subset2.ToList();

                foreach (var j in subsetWithoutFirstElement)
                {
                    foreach (var i1 in subset2)
                    {
                        if ((j + i1) % k != 0)
                        {
                            if (!tempSet.Contains(j))
                            {
                                tempSet.Add(j);
                            }
                        }
                        else
                        {
                            tempSet.Remove(j);
                            break;
                        }
                    }

                    subset2 = tempSet.ToList();
                }

                subsets.Add(subset2);
            }

            var subsetExceptFirstSubset = s.Except(subset).ToList();

            var ordered = subsets.OrderByDescending(x => x.Count);
            var maxLength = ordered.First().Count;
            if (maxLength >= subsetExceptFirstSubset.Count) return maxLength;

            subset.Clear();
            var num = subsetExceptFirstSubset[0];
            subsetWithoutFirstElement = subsetExceptFirstSubset.Skip(1);
            subset.Add(num);
            tempSet = subset.ToList();
            foreach (var j in subsetWithoutFirstElement)
            {
                foreach (var i1 in subset)
                {
                    if ((j + i1) % k != 0)
                    {
                        if (!tempSet.Contains(j))
                        {
                            tempSet.Add(j);
                        }
                    }
                    else
                    {
                        tempSet.Remove(j);
                        break;
                    }
                }

                subset = tempSet.ToList();
            }

            maxLength = maxLength < subset.Count ? subset.Count : maxLength;

            return maxLength;
        }

        public static int GetNonDivisibleSubset2(int k, List<int> s)
        {
            var arrRemainder = new int[k];
            var length = s.Count;
            for (var i = 0; i < length; i++)
            {
                arrRemainder[s[i] % k]++;
            }

            var maxSubsetLength = 0;
            if (arrRemainder[0] > 0)
            {
                maxSubsetLength++;
            }

            var lengthBy2 = (k + 1) / 2;
            for (var i = 1; i < lengthBy2; i++)
            {
                maxSubsetLength += Math.Max(arrRemainder[i], arrRemainder[k - i]);
            }

            if (k % 2 == 0 && arrRemainder[k / 2] > 0)
            {
                maxSubsetLength++;
            }

            return maxSubsetLength;
        }
    }
}
