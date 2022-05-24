using System;
using System.Collections.Generic;
using System.Text;

namespace AllChallenges
{
    class HourGlass
    {
        public static void MaxHourGlass(int[][] hg)
        {
            int n = hg.Length - 2;
            int maxSum = 0;
            int hourGlassLength = 0;
            int tempSum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //Console.WriteLine();
                    hourGlassLength = j + 3;
                    tempSum = 0;
                    for (int k = j; k < hourGlassLength; k++)
                    {
                        //Console.Write($"{hg[i][k]} ");
                        tempSum += hg[i][k];
                    }

                    //Console.WriteLine();
                    //Console.Write($"  {hg[i + 1][j + 1]} ");
                    tempSum += hg[i + 1][j + 1];
                    //Console.WriteLine();
                    for (int k = j; k < hourGlassLength; k++)
                    {
                        //Console.Write($"{hg[i + 2][k]} ");
                        tempSum += hg[i + 2][k];
                    }

                    maxSum = maxSum > tempSum ? maxSum : tempSum;
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}
