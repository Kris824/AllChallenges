using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AllChallenges
{
    public class QueensAttack
    {
        public static int NumberOfMoves(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
        {
            if (n == 1)
            {
                return 0;
            }

            var numberOfMoves = 0;

            if (k == 0)
            {
                // east
                numberOfMoves += n - c_q;

                // south-east
                numberOfMoves += r_q <= n - c_q ? r_q - 1 : n - c_q;

                // south
                numberOfMoves += r_q - 1;

                // south-west
                // 8,4 --> 
                // 4,8
                numberOfMoves += r_q > c_q ? c_q - 1 : r_q - 1;

                //west
                numberOfMoves += c_q - 1;

                // north-west
                numberOfMoves += n - r_q >= c_q ? c_q - 1 : n - r_q;

                // north
                numberOfMoves += n - r_q;

                // north-east
                numberOfMoves += r_q > c_q ? (n - r_q) : (n - c_q);

                return numberOfMoves;
            }

            var horizontalSorted = obstacles.OrderBy(x => x[0]);
            var verticalSorted = obstacles.OrderBy(x => x.Last());

            // East
            var row = r_q;
            var col = c_q + 1;
            for (; col <= n; col++)
            {
                var position = new List<int> { row, col };
                if (obstacles.Any(c => c.SequenceEqual(position)))
                {
                    break;
                }
            }

            numberOfMoves += col - c_q - 1;

            // south - east
            row = r_q - 1;
            col = c_q + 1;


            for (; col <= n && row > 0; col++, row--)
            {
                var position = new List<int> { row, col };
                if (obstacles.Any(c => c.SequenceEqual(position)))
                {
                    break;
                }
            }

            numberOfMoves += r_q - row - 1;

            // south
            row = r_q - 1;
            col = c_q;
            for (; row > 0; row--)
            {
                var position = new List<int> { row, col };
                if (obstacles.Any(c => c.SequenceEqual(position)))
                {
                    break;
                }
            }

            numberOfMoves += r_q - row - 1;

            // south - west
            row = r_q - 1;
            col = c_q - 1;
            for (; col > 0 && row > 0; col--, row--)
            {
                var position = new List<int> { row, col };
                if (obstacles.Any(c => c.SequenceEqual(position)))
                {
                    break;
                }
            }

            numberOfMoves += r_q - row - 1;

            // west
            row = r_q;
            col = c_q - 1;
            for (; col > 0; col--)
            {
                var position = new List<int> { row, col };
                if (obstacles.Any(c => c.SequenceEqual(position)))
                {
                    break;
                }
            }

            numberOfMoves += c_q - col - 1;

            // north - west
            row = r_q + 1;
            col = c_q - 1;
            for (; col > 0 && row <= n; col--, row++)
            {
                var position = new List<int> { row, col };
                if (obstacles.Any(c => c.SequenceEqual(position)))
                {
                    break;
                }
            }

            numberOfMoves += row - r_q - 1;

            // north
            row = r_q + 1;
            col = c_q;
            for (; row <= n; row++)
            {
                var position = new List<int> { row, col };
                if (obstacles.Any(c => c.SequenceEqual(position)))
                {
                    break;
                }
            }

            numberOfMoves += row - r_q - 1;

            // north - east
            row = r_q + 1;
            col = c_q + 1;
            for (; col <= n && row <= n; col++, row++)
            {
                var position = new List<int> { row, col };
                if (obstacles.Any(c => c.SequenceEqual(position)))
                {
                    break;
                }
            }

            numberOfMoves += row - r_q - 1;

            return numberOfMoves;
        }

        public static int NumberOfMoves2(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
        {
            if (n == 1)
            {
                return 0;
            }

            var numberOfMoves = 0;

            if (k == 0)
            {
                numberOfMoves += 3 * n - 3;

                numberOfMoves += r_q <= n - c_q ? r_q - 1 : n - c_q;

                numberOfMoves += r_q > c_q ? (c_q - r_q) : r_q - c_q;

                numberOfMoves += n - r_q >= c_q ? c_q - 1 : n - r_q;

                return numberOfMoves;
            }

            // East

            var enumerableObstacles = obstacles.Distinct(new ListComparer());

            var horizontalObstacles = enumerableObstacles.Where(x => x[0] == r_q).ToArray();

            var obstacle = horizontalObstacles.FirstOrDefault(x => x[1] > c_q);

            numberOfMoves -= 6;
            numberOfMoves += obstacle?[1] - 1 ?? n;

            // West
            obstacle = horizontalObstacles.FirstOrDefault(x => x[1] < c_q);
            if (obstacle != null)
            {
                numberOfMoves -= obstacle[1];
            }

            // north

            var verticalObstacles = obstacles.Where(x => x[1] == c_q).ToArray();

            obstacle = verticalObstacles.FirstOrDefault(x => x[0] > r_q);
            numberOfMoves += obstacle?[0] - 1 ?? n;

            // south
            obstacle = verticalObstacles.FirstOrDefault(x => x[0] < r_q);
            if (obstacle != null)
            {
                numberOfMoves -= obstacle[0];
            }

            // south - east
            var row = r_q - 1;
            var col = c_q + 1;
            var southEwNsObstacles = obstacles.Where(x => x[0] < r_q).ToArray();
            var subObstacles = southEwNsObstacles.Where(x => x[1] > c_q).ToArray();
            for (; col <= n && row > 0; col++, row--)
            {
                var position = new List<int> { row, col };
                if (subObstacles.Any(c => c.SequenceEqual(position)))
                {
                    break;
                }
            }

            numberOfMoves -= row;

            // south - west
            row = r_q - 1;
            col = c_q - 1;

            subObstacles = southEwNsObstacles.Where(x => x[1] < c_q).ToArray();
            for (; col > 0 && row > 0; col--, row--)
            {
                var position = new List<int> { row, col };
                if (subObstacles.Any(c => c.SequenceEqual(position)))
                {
                    break;
                }
            }

            numberOfMoves -= row;

            // north - west
            row = r_q + 1;
            col = c_q - 1;
            southEwNsObstacles = obstacles.Where(x => x[0] > r_q).ToArray();
            subObstacles = southEwNsObstacles.Where(x => x[1] < c_q).ToArray();
            for (; col > 0 && row <= n; col--, row++)
            {
                var position = new List<int> { row, col };
                if (subObstacles.Any(c => c.SequenceEqual(position)))
                {
                    break;
                }
            }

            numberOfMoves += row;

            // north - east
            row = r_q + 1;
            col = c_q + 1;
            subObstacles = southEwNsObstacles.Where(x => x[1] > c_q).ToArray();
            for (; col <= n && row <= n; col++, row++)
            {
                var position = new List<int> { row, col };
                if (subObstacles.Any(c => c.SequenceEqual(position)))
                {
                    break;
                }
            }

            numberOfMoves += row;

            return numberOfMoves;
        }

        public static int NumberOfMoves3(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
        {
            if (n == 1)
            {
                return 0;
            }

            var numberOfMoves = 0;

            numberOfMoves += 3 * n - 3;

            // south-east
            numberOfMoves += r_q <= n - c_q ? r_q - 1 : n - c_q;

            // south-west-north-east
            numberOfMoves += r_q > c_q ? (c_q - r_q) : r_q - c_q;

            // north-west
            numberOfMoves += n - r_q >= c_q ? c_q - 1 : n - r_q;

            obstacles = obstacles.Distinct(new ListComparer()).ToList();

            var horizontalObstacles = obstacles.Where(x => x[0] == r_q).ToList();

            var obstacle = horizontalObstacles.FirstOrDefault(x => x[1] >= c_q);

            if (obstacle != null)
            {
                numberOfMoves -= (n - obstacle.Last() + 1);
            }

            obstacle = horizontalObstacles.FirstOrDefault(x => x[1] <= c_q);

            if (obstacle != null)
            {
                numberOfMoves -= obstacle.Last();
            }

            var verticalObstacles = obstacles.Where(x => x[1] == c_q).ToList();

            obstacle = verticalObstacles.FirstOrDefault(x => x[0] >= r_q);
            if (obstacle != null)
            {
                numberOfMoves -= (n - obstacle[0] + 1);
            }

            obstacle = verticalObstacles.FirstOrDefault(x => x[0] <= r_q);
            if (obstacle != null)
            {
                numberOfMoves -= obstacle[0];
            }

            // south-east

            var subObstacles = obstacles.Where(x => x[0] < r_q && x[1] > c_q).ToList();
            subObstacles = subObstacles.OrderBy(x => x[1]).ToList();
            var sEObstacle = subObstacles.FirstOrDefault(x => r_q - x[0] == x[1] - c_q);
            
            if(sEObstacle != null)
                numberOfMoves -= r_q <= n - c_q ? sEObstacle[0] : n - sEObstacle[1] + 1;

            // south - west
            subObstacles = obstacles.Where(x => x[0] < r_q && x[1] < c_q).ToList();
            subObstacles = subObstacles.OrderByDescending(x => x[0]).ToList();
            sEObstacle = subObstacles.FirstOrDefault(x => r_q - x[0] == c_q - x[1]);
            
            if (sEObstacle != null)
                numberOfMoves -= r_q > c_q ? sEObstacle[1] : sEObstacle[0];

            // north - west
            subObstacles = obstacles.Where(x => x[0] > r_q && x[1] < c_q).ToList();
            subObstacles = subObstacles.OrderBy(x => x[0]).ToList();
            sEObstacle = subObstacles.FirstOrDefault(x => x[0] - r_q == c_q - x[1]);
            
            if (sEObstacle != null)
                numberOfMoves -= n - r_q >= c_q ? sEObstacle[1] : n - sEObstacle[0] + 1;

            // north - east
            subObstacles = obstacles.Where(x => x[0] > r_q && x[1] > c_q).ToList();
            subObstacles = subObstacles.OrderBy(x => x[0]).ToList();
            sEObstacle = subObstacles.FirstOrDefault(x => x[0] - r_q ==  x[1] - c_q);
            
            if (sEObstacle != null)
                numberOfMoves -= r_q > c_q ? n - sEObstacle[0] + 1 : n - sEObstacle[1] + 1;

            return numberOfMoves;
        }
    }

    public class ListComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> list1, List<int> list2)
        {
            return list1[0] == list2[0] && list1[1] == list2[1];
        }

        public int GetHashCode(List<int> obj)
        {
            return obj.OrderBy(x => x)
                .Aggregate(17, (current, val) => current * 23 + val.GetHashCode());
        }
    }
}
