using System;

namespace ConsoleApp7
{
    class Program
    {
        static int Factorial(int a)
        {
            int s = 1;
            while (a > 0)
            {
                s *= a;
                a -= 1;
            }
            return s;
        }

        static int Sum(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        static double Geron(int a, int b, int c)
        {
            double p = (a + b + c) / 2;
            if (a >= b + c || b >= a + c || c >= a + b)
            {
                return -1;
            }
            double s = Math.Pow(p * (p - a) * (p - b) * (p - c), 0.5);
            return s;
        }

        static int positive_Int()
        {
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Nope, try again");
                return positive_Int();

            }
            else if (a <= 0)
            {
                Console.WriteLine("Nope, try again");
                return positive_Int();
            }
            return a;
        }
        static int[] Max_in_massive_cut(int[] C)
        {
            int max = C[0], index = 0, count = 0;
            int[] C1 = new int[C.Length - 1];
            for (int i = 1; i < C.Length; i++)
            {
                if (max < C[i])
                {
                    max = C[i];
                    index = i;
                }
            }
            for (int i = 0; i < C.Length; i++)
            {
                if (i != index)
                {
                    C1[count] = C[i];
                    count += 1;
                }
            }
            return C1;
        }

        static int[,] Matrix_cut(int[,] S, int j1, int j2)
        {
            int[,] S1;
            if (j1 == j2)
            {
                S1 = new int[S.GetLength(0), S.GetLength(1) - 1];
            }
            else
            {
                S1 = new int[S.GetLength(0), S.GetLength(1) - 2];
            }

            for (int i = 0; i < S.GetLength(0); i++)
            {
                int cntj = 0;
                for (int j = 0; j < S.GetLength(1); j++)
                {
                    if (j != j1 && j != j2)
                    {
                        S1[i, cntj] = S[i, j];
                        cntj += 1;
                    }
                }
            }

            return S1;
        }

        static double[,] Max_min(double[,] S)
        {
            int cnt = 0;
            double[] S1 = new double[S.GetLength(0) * S.GetLength(1)];

            for (int i = 0; i < S.GetLength(0); i++)
            {
                for (int j = 0; j < S.GetLength(1); j++)
                {
                    S1[cnt] = S[i, j];
                    cnt += 1;
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

            cnt = 0;
            int f = 1;
            for (int i = 0; i < S.GetLength(0); i++)
            {
                for (int j = 0; j < S.GetLength(1); j++)
                {
                    if (cnt == 5)
                    {
                        f = 0;
                    }
                    if (f == 1 && (S[i, j] == S1[0] || S[i, j] == S1[1] || S[i, j] == S1[2] || S[i, j] == S1[3] || S[i, j] == S1[4]))
                    {
                        if (S[i, j] >= 0)
                        {
                            S[i, j] = 2 * S[i, j];
                            cnt += 1;
                        }
                        else
                        {
                            S[i, j] = S[i, j] / 2;
                            cnt += 1;
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

        delegate double Memb(int i, double x, int now);
        delegate int Down(int previ, int i);
        delegate double Ref_f(double x);

        static int Down_1(int previ, int i) => previ * i;
        static int Down_2(int previ, int i) => previ * -1;

        static double Member_1(int i, double x, int now) => Math.Cos(i * x) / now;
        static double Member_2(int i, double x, int now) => (Math.Cos(i * x) * now) / (i * i);

        static double Reference_func(double x) => Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));
        static double Reference_func_2(double x) => (x * x - (Math.PI * Math.PI / 3)) / 4;

        static void Summa_final(Memb memb, Down down, Ref_f ref_f, int first_numb, double a, double b, double h)
        {
            for (double x = a; x <= b; x += h)
            {
                int i = 1, now = 1;
                double sum = first_numb;

                while (Math.Abs(memb(i, x, now)) > 0.0001)
                {
                    now = down(now, i);
                    sum += memb(i, x, now);
                    i++;
                }
                Console.WriteLine(Math.Round(sum, 3) + " " + Math.Round(ref_f(x), 3));
            }
        }

        delegate int[] Mas_del(int[] S);

        static int[] Sort_up(int[] S)
        {
            Array.Sort(S);
            return S;
        }

        static int[] Sort_down(int[] S)
        {
            Array.Sort(S);
            Array.Reverse(S);
            return S;
        }
        static void Mas(int[,] S)
        {

            for (int i = 0; i < S.GetLength(0); i++)
            {
                int[] S1 = new int[S.GetLength(1)];
                for (int j = 0; j < S.GetLength(1); j++)
                {
                    S1[j] = S[i, j];
                }
                Mas_del a;
                if (i % 2 == 0)
                {
                    a = Sort_up;
                }
                else
                {
                    a = Sort_down;
                }
                S1 = a(S1);
                for (int j = 0; j < S.GetLength(1); j++)
                {
                    S[i, j] = S1[j];
                }
            }
            for (int i = 0; i < S.GetLength(0); i++)
            {
                for (int j = 0; j < S.GetLength(1); j++)
                {
                    Console.Write(S[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            #region 1.1
            Console.WriteLine(Sum(8, 5));
            Console.WriteLine(Sum(10, 5));
            Console.WriteLine(Sum(11, 5));
            #endregion

            #region 1.2
            Console.WriteLine("Enter a,b,c of 1st triangle");
            int a = positive_Int();
            int b = positive_Int();
            int c = positive_Int();
            
            Console.WriteLine("Enter a,b,c of 2nd triangle");
            int a_2 = positive_Int();
            int b_2 = positive_Int();
            int c_2 = positive_Int();

            if (Geron(a, b, c) == -1 || Geron(a_2, b_2, c_2) == -1)
            {
                Console.WriteLine("incorrect");
            }
            else if (Geron(a, b, c) > Geron(a_2, b_2, c_2))
            {
                Console.WriteLine("1st square bigger");
            }
            else if (Geron(a, b, c) < Geron(a_2, b_2, c_2))
            {
                Console.WriteLine("2nd square bigger");
            }
            else if (Geron(a, b, c) == Geron(a_2, b_2, c_2))
            {
                Console.WriteLine("equal");
            }
            Console.WriteLine("  ");
            #endregion

            #region 2.6
            int[] A = new int[] { 1, 2, 3, 4, 5, 6, 7};
            int[] B = new int[] { 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] A1 = Max_in_massive_cut(A);
            int[] B1 = Max_in_massive_cut(B);
            int[] D = new int[A1.Length + B1.Length];
            for (int i = 0; i < A1.Length + B1.Length; i++)
            {
                if (i < A1.Length)
                {
                    D[i] = A1[i];
                }
                else
                {
                    D[i] = B1[i - A1.Length];
                }
            }
            for (int i = 0; i < D.Length; i++)
            {
                Console.Write(D[i] + " ");
            }
            Console.WriteLine("     ");
            #endregion

            #region 2.10
            int[,] M = new int[5, 5]
            {
                {-1, -2, -3,  -4, -5 },
                {5, 4, 3, 2,  1 },
                {6,  7, 8,  9,  10 },
                {11,-10, 15,  -22,  -7 },
                {535,  328, -943,  11,  41 }
            };

            int max1 = M[0, 0], min1 = M[0, 1], ind1 = 0, ind2 = 1;
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    if (i >= j && max1 < M[i, j])
                    {
                        max1 = M[i, j];
                        ind1 = j;
                    }
                    if (j > i && min1 > M[i, j])
                    {
                        max1 = M[i, j];
                        ind2 = j;
                    }
                }
            }
            int[,] P = Matrix_cut(M, ind1, ind2);

            for (int i = 0; i < P.GetLength(0); i++)
            {
                for (int j = 0; j < P.GetLength(1); j++)
                {
                    Console.Write(P[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            #endregion

            #region 2.23
            double[,] matrix_1 = new double[5, 5]
            {
                {1,  2, 3,  4, 5},
                {11, 10, 9, 8,  7},
                {12, 13, 14, 15, 16},
                {21, 20, 19,  18,  17},
                {22,  23, 24,  25,  26}
            };
            double[,] matrix_2 = new double[4, 4]
            {
                {3,  6, -2,  -5},
                {-1, -16, 11, -9},
                {-2,  -3, -1,  -2},
                {-11,-10, -14,  -2},
            };

            matrix_1 = Max_min(matrix_1);
            matrix_2 = Max_min(matrix_2);

            for (int i = 0; i < matrix_1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix_1.GetLength(1); j++)
                {
                    Console.Write(matrix_1[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < matrix_2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix_2.GetLength(1); j++)
                {
                    Console.Write(matrix_2[i, j] + "\t");
                }
                Console.WriteLine();
            }
            #endregion

            #region 3.1
            Summa_final(Member_1, Down_1, Reference_func, 1, 0.1, 1, 0.1);
            Console.WriteLine();
            Summa_final(Member_2, Down_2, Reference_func_2, 0, Math.PI / 5, Math.PI, Math.PI / 25);
            #endregion

            #region 3.2
            int[,] Q = new int[3, 3]
            {
                {1,  6, -5},
                {-7, 25, 12},
                {7,  32, -31},

            };

            Mas(Q);
            #endregion
        }
    }
}
