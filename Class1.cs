using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    internal class Level2ex6
    {
        static int max(int[] x)
        {
            int max = x[0], max_i = 0;

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] > max)
                {
                    max = x[i];
                    max_i = i;
                }
            }

            return max_i;
        }

        static int[] delete(int[] x)
        {
            int max_i = max(x);
            for (int i = max_i; i < x.Length - 1; i++)
            {
                x[i] = x[i + 1];
            }
            return x;
        }

        static void Main(string[] args)
        {
            int[] a = new int[13];
            int[] b = new int[8];
            Random random = new Random();

            for (int i = 0; i < 7; i++)
            {
                a[i] = random.Next(0, 40);
            }

            for (int i = 0; i < 8; i++)
            {
                b[i] = random.Next(0, 40);
            }

            Console.WriteLine("Array A: ");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(a[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Array B: ");
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(b[i]);
            }
            Console.WriteLine();

            delete(a);
            delete(b);

            int b_i = 0;

            for (int i = 0; i < 15; i++)
            {
                if (i < 6)
                {
                    a[i] = a[i];
                }
                else
                {
                    if (b_i < 7)
                    {
                        a[i] = b[b_i];
                        b_i++;
                    }
                }
            }

            Console.Write("Final array: ");
            for (int i = 0; i < 13; i++)
            {
                Console.Write($"{a[i]}, ");
            }

        }

    }

    internal class Level2ex23
    {
        static double[,] max_min(double[,] S)
        {
            int count = 0;
            double[] S1 = new double[S.GetLength(0) * S.GetLength(1)];

            for (int i = 0; i < S.GetLength(0); i++)
            {
                for (int j = 0; j < S.GetLength(1); j++)
                {
                    S1[count] = S[i, j];
                    count += 1;
                }
            }

            for (int i = 1; i < S1.Length; i++)
            {
                int j = i;
                while (j > 0 && S1[j - 1] < S1[j])
                {
                    double p = S1[j - 1];
                    S1[j - 1] = S1[j];
                    S1[j] = p;
                    j--;
                }
            }

            count = 0;
            int f = 1;
            for (int i = 0; i < S.GetLength(0); i++)
            {
                for (int j = 0; j < S.GetLength(1); j++)
                {
                    if (count == 5)
                    {
                        f = 0;
                    }
                    if (f == 1 && (S[i, j] == S1[0] || S[i, j] == S1[1] || S[i, j] == S1[2] || S[i, j] == S1[3] || S[i, j] == S1[4]))
                    {
                        if (S[i, j] >= 0)
                        {
                            S[i, j] = 2 * S[i, j];
                            count += 1;
                        }
                        else
                        {
                            S[i, j] = S[i, j] / 2;
                            count += 1;
                        }
                    }
                    else
                    {
                        if (S[i, j] >= 0)
                        {
                            S[i, j] = S[i, j] / 2;
                        }
                        else
                        {
                            S[i, j] = 2 * S[i, j];
                        }
                    }
                }
            }
            return S;
        }
        static void Main(string[] args)
        {
            double[,] S1 = new double[4, 4]
            {
                {8,  61, -24, 2},
                {-11, 52, 1, -7},
                {71,  34, 4, 6},
                {21, 1, 53, 36}
            };
            double[,] S2 = new double[3, 2]
            {
                {10, 10},
                {10, 10},
                {10, 10},
            };

            S1 = max_min(S1);
            S2 = max_min(S2);

            for (int i = 0; i < S1.GetLength(0); i++)
            {
                for (int j = 0; j < S1.GetLength(1); j++)
                {
                    Console.Write(S1[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < S2.GetLength(0); i++)
            {
                for (int j = 0; j < S2.GetLength(1); j++)
                {
                    Console.Write(S2[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    

    }
} 

