using System;
using System.Data.Common;
using System.Drawing;

namespace _5th_Lab
{
    class Program
    {
        #region 5.1.1

        static int fact(int a)
        {

            int Fact = 1;
            for (int i = 1; i <= a; i++)
            {
                Fact = Fact * i;
            }
            return Fact;
        }
        static int Cab(int a, int b)
        {
            return fact(a) / (fact(b) * fact(a - b));
        }

        #endregion
        #region 5.1.2

        static double square(double a, double b, double c, out double s)
        {
            double p = (a + b + c) / 2;
            s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return s;
        }

        #endregion
        #region 5.2.6
        static void delmax(double[] a, int len_a)
        {
            double amax = a[0];
            int imax = 0;
            for (int i = 0; i < len_a; i++)
            {
                if (a[i] > amax)
                {
                    amax = a[i];
                    imax = i;
                }
            }
            for (int i = imax; i < len_a - 1; i++)
            {
                a[i] = a[i + 1];
            }
        }
        #endregion
        #region 5.2.10
        static int Amax(int[,] d)
        {
            int maxa = 0;
            int indexd = 0;
            for (int i = 0; i < d.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (d[i, j] > maxa)
                    {
                        maxa = d[i, j];
                        indexd = j;
                    }
                }
            }
            return indexd;

        }
        static int Amin(int[,] x)
        {
            int min = 100000000, indexmin = 0;

            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = i + 1; j < x.GetLength(1); j++)
                {
                    if (x[i, j] < min)
                    {
                        min = x[i, j];
                        indexmin = j;
                    }
                }
            }

            return indexmin;
        }
        static int[,] change(int[,] x)
        {
            int max_j = Amax(x);
            int min_j = Amin(x);

            if (max_j == min_j)
            {
                for (int i = 0; i < x.GetLength(0); i++)
                {
                    for (int j = max_j + 1; j < x.GetLength(1) - 1; j++)
                    {
                        x[i, j] = x[i, j + 1];
                    }
                }
            }

            else
            {
                if (max_j > min_j)
                {
                    for (int i = 0; i < x.GetLength(0); i++)
                    {
                        for (int j = max_j; j < x.GetLength(1) - 1; j++)
                        {
                            x[i, j] = x[i, j + 1];
                        }
                    }

                    for (int i = 0; i < x.GetLength(0); i++)
                    {
                        for (int j = min_j; j < x.GetLength(1) - 1; j++)
                        {
                            x[i, j] = x[i, j + 1];
                        }
                    }
                }

                else
                {
                    for (int i = 0; i < x.GetLength(0); i++)
                    {
                        for (int j = min_j; j < x.GetLength(1) - 1; j++)
                        {
                            x[i, j] = x[i, j + 1];
                        }
                    }

                    for (int i = 0; i < x.GetLength(0); i++)
                    {
                        for (int j = max_j; j < x.GetLength(1) - 1; j++)
                        {
                            x[i, j] = x[i, j + 1];
                        }
                    }
                }
            }

            return x;
        }

        #endregion
        #region 5.2.23
        static int min_(int[,] x)
        {
            int min = 10000000;

            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    if (x[i, j] < min)
                    {
                        min = x[i, j];
                    }
                }
            }
            return min;
        }

        static int[,] copy(int[,] a)
        {
            int[,] b = new int[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    b[i, j] = a[i, j];
                }
            }

            return b;
        }

        static void ShowMatrix(int[,] x)
        {
            int rows = x.GetLength(0);
            int columns = x.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    Console.Write("{0, -5}", x[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int[,] change(int[,] x, out int[,] b)
        {
            int n = 0;

            b = copy(x);

            int[,] c = copy(x);

            int max = x[0, 0], min = min_(x), max_i = 0, max_j = 0;
            int[] mas = new int[5];
            int mas_i = 0;

            do
            {
                max = x[0, 0];
                max_i = 0;
                max_j = 0;

                for (int i = 0; i < x.GetLength(0); i++)
                {
                    for (int j = 0; j < x.GetLength(1); j++)
                    {
                        if (x[i, j] > max)
                        {
                            max = x[i, j];
                            max_i = i;
                            max_j = j;
                        }
                    }
                }

                if (max > 0)
                {
                    b[max_i, max_j] = max * 2;
                }
                else b[max_i, max_j] = max / 2;

                x[max_i, max_j] = min;
                mas[mas_i] = b[max_i, max_j];

                n++;
                mas_i++;

            } while (n < 5);

            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    if (b[i, j] <= max && b[i, j] != mas[0] && b[i, j] != mas[1] && b[i, j] != mas[2] && b[i, j] != mas[3] && b[i, j] != mas[4])
                    {
                        if (b[i, j] > 0)
                        {
                            b[i, j] = b[i, j] / 2;
                        }
                        else b[i, j] = b[i, j] * 2;
                    }
                }
            }
            return b;
        }
        #endregion
        #region 5.3.1
        static int factorial(int i)
        {
            int a = 1;
            for (int j = 1; j <= i; j++)
            {
                a = a * j;
            }
            return a;
        }
        delegate double fx(double x, int i);
        static double f1(double x, int i)
        {
            double chs1;
            return chs1 = Math.Cos(i * x) / factorial(i);
        }
        static double f2(double x, int i)
        {
            double chs2;
            return chs2 = Math.Pow(-1, i) * Math.Cos(i * x) / i * i;
        }
        static double Sum(fx f, double a, double b, double h)
        {
            double s = 0;
            int i = 1;
            for (double x = a; x <= b; x = x + h)
            {
                s = s + f(x, i);
                i++;
            }
            return s;
        }
        #endregion
        #region 5.3.3
        static double average(double[] a)
        {
            double av = 0;
            for (int i = 0; i < a.Length; i++)
            {
                av = av + a[i] / a.Length;
            }
            return av;
        }
        delegate void Switch(double[] a);
        static void sw1(double[] a)
        {
            double p;
            for (int i = 0; i < a.Length - 1; i = i + 2)
            {
                p = a[i];
                a[i] = a[i + 1];
                a[i + 1] = p;
            }
        }
        static void sw2(double[] a)
        {
            double p;
            for (int i = a.Length - 1; i > 0; i = i - 2)
            {
                p = a[i];
                a[i] = a[i - 1];
                a[i - 1] = p;
            }
        }
        static double sum(Switch sw, double[] a)
        {
            double S = 0;
            sw(a);
            for (int i = 1; i < a.Length; i = i + 2)
            {
                S = S + a[i];
            }
            return S;
        }
        #endregion


        #region Main
        static void Main(string[] args)
        {
            #region 5.1.1 Main

            int n1 = 8, n2 = 10, n3 = 11, k = 5;
            Console.WriteLine(Cab(n1, k));
            Console.WriteLine(Cab(n2, k));
            Console.WriteLine(Cab(n3, k));
            Console.WriteLine();
            #endregion
            #region 5.1.2 Main
            double a1, b1, c1, a2, b2, c2, s1 = 0, s2 = 0;

            Console.WriteLine("Введите стороны первого треугольника: ");
            double.TryParse(Console.ReadLine(), out a1);
            double.TryParse(Console.ReadLine(), out b1);
            double.TryParse(Console.ReadLine(), out c1);

            Console.WriteLine("Введите стороны второго треугольника: ");
            double.TryParse(Console.ReadLine(), out a2);
            double.TryParse(Console.ReadLine(), out b2);
            double.TryParse(Console.ReadLine(), out c2);


            if (a1 > 0 & b1 > 0 & c1 > 0 & a2 > 0 & b2 > 0 & c2 > 0)
            {
                if (a1 + b1 > c1 && a1 + c1 > b1 && b1 + c1 > a1)
                {
                    square(a1, b1, c1, out s1);
                    Console.WriteLine($"Площадь первого треугольника: {s1}");
                }
                else
                {
                    Console.WriteLine("Такой треугольник не существует");
                }

                if (a2 + b2 > c2 && a2 + c2 > b2 && b2 + c2 > a2)
                {
                    square(a2, b2, c2, out s2);
                    Console.WriteLine($"Площадь второго треугольника: {s2}");
                }
                else
                {
                    Console.WriteLine("Такой треугольник не существует");
                }



                if (s1 > s2)
                {
                    Console.WriteLine("Первый треугольник больше второго");
                }
                else if (s1 == s2)
                {
                    Console.WriteLine("Треугольники равны");
                }
                else
                {
                    Console.WriteLine("Второй треугольник больше первого");
                }
            }

            else
            {
                Console.WriteLine("Треугольники должны быть больше 0");
            }
            #endregion
            #region 5.2.6 Main
            int j_q = 0;
            double[] A = new double[7 + 8 - 2];
            double[] B = new double[8];
            Console.WriteLine($"введите элементы массива A");
            for (int i = 0; i < 7; i++)
            {
                double.TryParse(Console.ReadLine(), out A[i]);
            }
            Console.WriteLine($"введите элементы массива B");
            for (int i = 0; i < 8; i++)
            {
                double.TryParse(Console.ReadLine(), out B[i]);
            }
            Console.WriteLine("массив A:");
            for (int i = 0; i < 7; i++)
            {
                Console.Write($"{A[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine("массив B:");
            for (int i = 0; i < 8; i++)
            {
                Console.Write($"{B[i]} ");
            }
            Console.WriteLine();
            delmax(A, 7);
            delmax(B, 8);
            for (int i = 7 - 1; i < A.Length; i++)
            {
                A[i] = B[j_q];
                j_q++;
            }
            Console.WriteLine("итог:");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"{A[i]} ");
            }
            Console.WriteLine();




            #endregion
            #region 5.2.10 Main
            int[,] matrix = new int[,]
            {
                {7,4,8,6},
                {3,8,1,2},
                {6,9,3,6},
                {4,6,2,1}
            };
            change(matrix);
            Console.WriteLine("Final matrix: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }

            #endregion
            #region 5.2.23 Main
            int[,] A2 = new int[4, 7]
            {
                {4,4,4,10,4,4,4},
                {4,4,4,10,4,4,4},
                {4,4,4,10,4,10,4},
                {4,4,4,10,4,4,4}
            };
            int[,] B2 = new int[6, 9]
            {
                {2,2,2,5,2,2,2,2,2},
                {2,2,2,5,2,2,2,2,2},
                {2,2,2,5,2,2,2,2,2},
                {2,2,2,5,2,2,2,2,2},
                {2,2,2,5,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2}
            };
            Console.WriteLine("матрицы А2:");
            ShowMatrix(A2);

            Console.WriteLine("матрица B2:");
            ShowMatrix(B2);

            change(A2, out A2);
            Console.WriteLine("измененная матрица А2: ");
            ShowMatrix(A2);

            change(B2, out B2);
            Console.WriteLine("измененная матрица B2: ");
            ShowMatrix(B2);
            Console.ReadLine();
            #endregion
            #region 5.3.1 Main


            const double pi = Math.PI;
            double aa1 = 0.1, bb1 = 1, hh1 = 0.1, aa2 = pi / 5, bb2 = pi, hh2 = pi / 25;
            Console.WriteLine("Summ 1: ");
            Console.WriteLine($"{1 + Sum(f1, aa1, bb1, hh1)}");
            Console.WriteLine("Summ 2: ");
            Console.WriteLine($"{Sum(f2, aa2, bb2, hh2)}");



            #endregion
            #region 5.3.3 Main

            const int n_r = 9;
            double[] F = new double[n_r] { 10, 5, 8, 9, 7, 6, 2, 3, 4 };
            Console.WriteLine("array F:");
            for (int i = 0; i < n_r; i++)
            {
                Console.Write($"{F[i]} ");
            }
            Console.WriteLine();
            double l_r, sw_r = 0;
            l_r = average(F);
            Console.WriteLine($"average = {l_r}");
            if (F[0] > l_r)
            {
                sw_r = sum(sw1, F);
            }
            else
            {
                sw_r = sum(sw2, F);
            }
            Console.WriteLine("new array:");
            for (int i = 0; i < n_r; i++)
            {
                Console.Write($"{F[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine($"the sum = {sw_r}");

            #endregion
        }

        #endregion

    }
}
