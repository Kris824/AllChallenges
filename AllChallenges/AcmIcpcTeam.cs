using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllChallenges
{
    internal class AcmIcpcTeam
    {
        public static List<int> AcmTeam(List<string> topic)
        {
            var result = new List<int>();
            var polymaths = topic.Where(x => !x.Contains('0')).ToList();
            var polyMathsCount = polymaths.Count;
            var totalNumberOfTeams = 0;
            var count = topic.Count;
            if (polyMathsCount > 0)
            {
                for (var index = 1; index <= polyMathsCount; index++)
                {
                    totalNumberOfTeams += count - index;
                }

                return new List<int> {totalNumberOfTeams, topic[0].Length};
            }


            var inverseTopic = new StringBuilder();
            for (var i = 0; i < count; i++)
            {
                foreach (var ch in topic[i])
                {
                    inverseTopic.Append(ch == '1' ? '0' : '1');
                    var inverseTopicStr = inverseTopic.ToString();

                    var exists = true;
                    foreach (var subTopic in topic)
                    {
                        for (var index = 0; index < inverseTopicStr.Length; index++)
                        {
                            var ich = inverseTopicStr[index];
                            if (ich == '0') continue;
                            if (ich != subTopic[index])
                            {
                                exists = false;
                                break;
                            }
                        }
                    }
                }
            }

            return result;
        }

        public static List<int> AcmTeam2(List<string> topic)
        {
            var result = new List<int>();
            var polymaths = topic.Where(x => !x.Contains('0')).ToList();
            var polyMathsCount = polymaths.Count;
            var totalNumberOfTeams = 0;
            var count = topic.Count;
            if (polyMathsCount > 0)
            {
                for (var index = 1; index <= polyMathsCount; index++)
                {
                    totalNumberOfTeams += count - index;
                }

                return new List<int> { totalNumberOfTeams, topic[0].Length };
            }

            var numberOfSubjects = topic[0].Length;
            var integerTopics = new List<int>();
            foreach (var subTopic in topic)
            {
                var reverseTopic = subTopic.Reverse().ToList();
                var n = 0;
                for(var i = 0; i < numberOfSubjects; i++)
                {
                    if (reverseTopic[i] == '1')
                    {
                        n += (int) Math.Pow(2.0, i);
                    }
                }

                integerTopics.Add(n);
            }

            var orResultList = new List<Tuple<int, int, int>>();
            var maxValue = 0;
            for (var i = 0; i < count - 1; i++)
            {
                for (var j = (i + 1); j < count; j++)
                {
                    var orResult = integerTopics[i] | integerTopics[j];
                    if (orResult <= maxValue) continue;

                    orResultList.Add(new Tuple<int, int, int>(orResult, integerTopics[i], integerTopics[j]));
                    maxValue = orResult;
                }
            }

            return result;
        }
    }
}
