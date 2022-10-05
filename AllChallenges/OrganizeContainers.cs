using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllChallenges
{
    class OrganizeContainers
    {
        public static string OrganizingContainers(List<List<int>> container)
        {
            var containerArr = container.Select(x => x.ToArray()).ToArray();
            var length = containerArr[0].Length;

            var row = 0;
            var possible = true;
            var usefulColumns = new List<int>();
            for (var k = 0; k < length; k++)
            {
                var column = 0;
                for (var i = 0; i < length; i++)
                {
                    if (!usefulColumns.Contains(column))
                    {
                        var horizontalSum = 0;
                        var verticalSum = 0;
                        for (var j = 0; j < length; j++)
                        {
                            horizontalSum += j == column ? 0 : containerArr[row][j];
                            verticalSum += column == i && j == row ? 0 : containerArr[j][column];
                        }

                        if (horizontalSum == verticalSum)
                        {
                            usefulColumns.Add(column);
                            break;
                        }
                    }

                    column++;
                }

                if (column == length)
                {
                    possible = false;
                    break;
                }

                row++;
            }

            return possible ? "Possible" : "Impossible";
        }
    }
}
