using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AllChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = 0;
            // 5. Queen's attack

            var obstacles = new List<List<int>>
            {
                new List<int> {5, 5},
                new List<int> {4, 2},
                new List<int> {2, 3},
                new List<int> {4, 2}
            };

            obstacles = new List<List<int>>();

            var lines = File.ReadAllLines(@"D:\kishan\AllChallenges\AllChallenges\Input6.txt");
            obstacles.AddRange(lines.Select(line => line.Split(", "))
                .Select(elements => new List<int> {int.Parse(elements[0]), int.Parse(elements[1])}));

            //obstacles = new List<List<int>>
            //{
            //    new List<int> {3, 5}
            //};

            result = QueensAttack.NumberOfMoves3(100, 100, 48, 81, obstacles);


            //// 4. Max Deletions
            //Console.WriteLine(MaxDeletions.EqualizerArray(new List<int> { 1 ,2 ,2, 3}));

            //// 3.Jumping on clouds
            //var list = new List<int> {0, 0, 0, 0, 1, 0};
            //Console.WriteLine(JumpingOnClouds.NumberOfJumps(list));

            //// 2. Repeated string
            //Console.WriteLine(RepeatedString.GetRepeatedString("abcac", 10));
            //Console.WriteLine(RepeatedString.GetRepeatedString("aba", 10));
            //Console.WriteLine(RepeatedString.GetRepeatedString("a", 1000000000000));

            // 1. nonDivisibleSubset
            //var firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            //var n = Convert.ToInt32(firstMultipleInput[0]);

            //var k = Convert.ToInt32(firstMultipleInput[1]);

            //var s = Console.ReadLine()?.TrimEnd().Split(' ').ToList().Take(n).Select(sTemp => Convert.ToInt32(sTemp)).ToList();

            //var result = NonDivisibleSubset.GetNonDivisibleSubset(k, s);

            //var result = NonDivisibleSubset.GetNonDivisibleSubset2(9,
            //    new List<int>
            //    {
            //        61197933, 56459859, 319018589, 271720536, 358582070, 849720202, 481165658, 675266245, 541667092,
            //        615618805, 129027583, 755570852, 437001718, 86763458, 791564527, 163795318, 981341013, 516958303,
            //        592324531, 611671866, 157795445, 718701842, 773810960, 72800260, 281252802, 404319361, 757224413,
            //        682600363, 606641861, 986674925, 176725535, 256166138, 827035972, 124896145, 37969090, 136814243,
            //        274957936, 980688849, 293456190, 141209943, 346065260, 550594766, 132159011, 491368651, 3772767,
            //        131852400, 633124868, 148168785, 339205816, 705527969, 551343090, 824338597, 241776176, 286091680,
            //        919941899, 728704934, 37548669, 513249437, 888944501, 239457900, 977532594, 140391002, 260004333,
            //        911069927, 586821751, 113740158, 370372870, 97014913, 28011421, 489017248, 492953261, 73530695,
            //        27277034, 570013262, 81306939, 519086053, 993680429, 599609256, 639477062, 677313848, 950497430,
            //        672417749, 266140123, 601572332, 273157042, 777834449, 123586826
            //    });

            //Console.WriteLine(result);

            //result = NonDivisibleSubset.GetNonDivisibleSubset2(3, new List<int> {1, 7, 2, 4});

            //Console.WriteLine(result);

            //result = NonDivisibleSubset.GetNonDivisibleSubset2(4, new List<int> { 19, 10, 12, 24, 25, 22 });

            //Console.WriteLine(result);

            //result = NonDivisibleSubset.GetNonDivisibleSubset(7,
            //    new List<int> {278, 576, 496, 727, 410, 124, 338, 149, 209, 702, 282, 718, 771, 575, 436});

            //Console.WriteLine(result);

            //DateTime dt = new DateTime(2022, 5, 4);
            //Console.WriteLine(dt - DateTime.Now);
            //// Climbing leader board
            //int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

            //List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

            //int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

            //List<int> player = Console.ReadLine().TrimEnd().Split(' ').Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

            //List<int> result = ClimbingLeaderBoard.climbingLeaderboard4(ranked, player);
            //Console.WriteLine(string.Join('\n', result));

            //// Picking Numbers;
            //while (true)
            //{
            //    int n = Convert.ToInt32(Console.ReadLine().Trim());
            //    List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();
            //    int result = PickingNumbers.pickingNumbers(a);
            //    Console.WriteLine(result);
            //}
            //// Binary Numbers
            //while (true)
            //{
            //    int n = Convert.ToInt32(Console.ReadLine().Trim());
            //    BinaryNumbers.ConvertToBinary(n);
            //}

            //// Hour glass
            //int[][] arr = new int[6][]
            //{
            //    new int[]{ 1, 1, 1, 0, 0, 0 },
            //    new int[]{ 0, 1, 0, 0, 0, 0 },
            //    new int[]{ 1, 1, 1, 0, 0, 0 },
            //    new int[]{ 0, 0, 2, 4, 4, 0 },
            //    new int[]{ 0, 0, 0, 2, 0, 0 },
            //    new int[]{ 0, 0, 1, 2, 4, 0 }
            //};

            ////for (int i = 0; i < 6; i++)
            ////{
            ////    arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            ////}

            //HourGlass.MaxHourGlass(arr);

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
