using System.Collections.Generic;

namespace AllChallenges
{
    public class JumpingOnClouds
    {
        // [0 1 0 0 0 1 0]
        // [0 0 1 0 0 1 0]
        // [0 1 0 0]
        // [0 0 0 0 1 0]
        public static int NumberOfJumps(List<int> list)
        {
            var length = list.Count;
            if (length == 2)
            {
                return 1;
            }

            length -= 2;
            var numberOfJumps = 0;
            var i = 0;
            for (; i < length;)
            {
                i = list[i + 2] == 0 ? i + 2 : ++i;
                numberOfJumps++;
            }

            numberOfJumps = i == length ? ++numberOfJumps : numberOfJumps;
            return numberOfJumps;
        }
    }
}