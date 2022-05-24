using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllChallenges
{
    class ClimbingLeaderBoard
    {
        public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
        {
            List<KeyValuePair<int, int>> rankedPlayers = new List<KeyValuePair<int, int>>();
            int prev = 0;
            int rank = 1;
            foreach (int num in ranked)
            {
                rank = prev > num ? ++rank : rank;
                rankedPlayers.Add(new KeyValuePair<int, int>(num, rank));
                prev = num;
            }

            List<int> result = new List<int>();
            KeyValuePair<int, int> pair = new KeyValuePair<int, int>();
            foreach (int num in player)
            {
                pair = rankedPlayers.Where(rp => rp.Key >= num).LastOrDefault();
                rank = pair.Key == 0 ? 1 : (pair.Key == num ? pair.Value : pair.Value + 1);
                result.Add(rank);
            }

            return result;
        }

        public static List<int> climbingLeaderboard2(List<int> ranked, List<int> player)
        {
            List<int> result = new List<int>();
            ranked = ranked.Distinct().ToList();
            foreach(int num in player)
            {
                if (ranked.Contains(num))
                {
                    result.Add(ranked.IndexOf(num) + 1);
                }
                else
                {
                    ranked.Add(num);
                    ranked = ranked.Distinct().OrderByDescending(r => r).ToList();
                    result.Add(ranked.IndexOf(num) + 1);
                    ranked.Remove(num);
                }
            }
            
            return result;
        }

        public static List<int> climbingLeaderboard3(List<int> ranked, List<int> player)
        {
            List<int> result = new List<int>();
            ranked = ranked.Distinct().ToList();
            int[] rankedArr = ranked.ToArray();
            foreach (int num in player)
            {
                if (rankedArr.Contains(num))
                {
                    result.Add(Array.IndexOf(rankedArr, num) + 1);
                }
                else
                {
                    rankedArr = rankedArr.Where(r => r > num).ToArray();
                    result.Add(rankedArr.Length + 1);
                }
            }

            return result;
        }

        public static List<int> climbingLeaderboard4(List<int> ranked, List<int> player)
        {
            List<int> result = new List<int>();
            ranked = ranked.Distinct().ToList();
            int[] rankedArr = ranked.ToArray();
            int rank = 0;
            int length = rankedArr.Length;
            foreach (int num in player)
            {
                rank = Array.BinarySearch(rankedArr, 0, length, num);
                if (rank < 0)
                {
                    result.Add(length + 1);
                }
                else
                {
                    length = rank;
                    result.Add(rank);
                }
            }

            return result;
        }
    }
}
