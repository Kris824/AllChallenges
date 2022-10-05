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

                return new List<int> { totalNumberOfTeams, topic[0].Length };
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
            var integerTopics = new List<long>();
            foreach (var subTopic in topic)
            {
                var reverseTopic = subTopic.Reverse().ToList();
                long n = 0;
                for (var i = 0; i < numberOfSubjects; i++)
                {
                    if (reverseTopic[i] == '1')
                    {
                        n += (long)Math.Pow(2.0, i);
                    }
                }

                integerTopics.Add(n);
            }

            long maxValue = 0;
            var numberOfTeams = 0;
            for (var i = 0; i < count - 1; i++)
            {
                for (var j = (i + 1); j < count; j++)
                {
                    var orResult = integerTopics[i] | integerTopics[j];
                    if (orResult < maxValue) continue;
                    if (orResult == maxValue)
                    {
                        numberOfTeams++;
                    }
                    else if (orResult > maxValue)
                    {
                        numberOfTeams = 1;
                    }

                    maxValue = orResult;
                }
            }

            var toBinary = Convert.ToString(maxValue, 2);
            var maxSubjects = toBinary.Count(ch => ch == '1');
            result.Add(maxSubjects);
            result.Add(numberOfTeams);

            return result;
        }

        public static List<int> AcmTeam3(List<string> topic)
        {
            var numberOfSubjects = topic[0].Length;
            var numberOfSpeakers = topic.Count;
            var maxSubjectsCovered = 0;
            var maxTeams = 0;
            for (var k = 0; k < numberOfSpeakers - 1; k++)
            {
                var speaker1 = topic[k];
                for (var i = k + 1; i < numberOfSpeakers; i++)
                {
                    var speaker2 = topic[i];
                    var subjectsCovered = 0;
                    for (var j = 0; j < numberOfSubjects; j++)
                    {
                        if (speaker1[j] == '1' || speaker2[j] == '1')
                        {
                            subjectsCovered++;
                        }
                    }

                    if (subjectsCovered < maxSubjectsCovered) continue;

                    if (subjectsCovered > maxSubjectsCovered)
                    {
                        maxTeams = 1;
                        maxSubjectsCovered = subjectsCovered;
                    }
                    else if (subjectsCovered == maxSubjectsCovered)
                    {
                        maxTeams++;
                    }
                }
            }

            return new List<int> { maxSubjectsCovered, maxTeams };
        }
    }
}
