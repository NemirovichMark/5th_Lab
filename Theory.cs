using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;

namespace Lab_5
{
    internal class Program
    {
        static void Output_Matrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,1} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        static int Factorial(int f)
        {
            int fact = 1;
            for (int i = 1; i <= f; ++i)
            {
                fact *= i;
            }
            return fact;
        }
        static int Variants(int k, int n)
        {
            return (Factorial(n) / (Factorial(k) * Factorial(n - k)));
        }
        static double Square(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        static int[] Without_Max(int[] arr)
        {
            int max_ = int.MinValue;
            int max_i = 0;
            int[] arr_2 = new int[arr.Length - 1];
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
            {
                if (arr[i] > max_)
                {
                    max_ = arr[i];
                    max_i = i;
                }
            }
            --n;
            for (int i = 0; i < max_i; ++i)
            {
                arr_2[i] = arr[i];
            }
            for (int i = max_i; i < n; ++i)
            {
                arr_2[i] = arr[i + 1];
            }
            return arr_2;
        }
        static int[,] Deleting_Columns(int[,] matrix)
        {
            int max = int.MinValue;
            int max_i = 0;
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j <= i; ++j)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        max_i = j;
                    }
                }
            }
            int min = int.MaxValue;
            int min_i = 0;
            for (int i = matrix.GetLength(0) - 2; i >= 0; --i)
            {
                for (int j = matrix.GetLength(0) - 1; j > i; --j)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        min_i = j;
                    }
                }
            }
            if (max_i < min_i)
            {
                int[,] a = new int[matrix.GetLength(0), matrix.GetLength(1) - 2];
                for (int i = 0; i < matrix.GetLength(0); ++i)
                {
                    for (int j = 0; j < max_i; ++j)
                    {
                        a[i, j] = matrix[i, j];
                    }
                }

                for (int i = 0; i < matrix.GetLength(0); ++i)
                {
                    for (int j = min_i; j < matrix.GetLength(1) - 1; ++j)
                    {
                        a[i, j] = matrix[i, j + 1];
                    }
                }

                for (int i = 0; i < matrix.GetLength(0); ++i)
                {
                    for (int j = max_i; j < matrix.GetLength(1) - 2; ++j)
                    {
                        a[i, j] = matrix[i, j + 1];
                    }
                }
                return a;
            }
            if (max_i > min_i)
            {
                int[,] a = new int[matrix.GetLength(0), matrix.GetLength(1) - 2];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < min_i; ++j)
                    {
                        a[i, j] = matrix[i, j];
                    }
                }

                for (int i = 0; i < matrix.GetLength(0); ++i)
                {
                    for (int j = max_i; j < matrix.GetLength(1) - 1; ++j)
                    {
                        a[i, j] = matrix[i, j + 1];
                    }
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = min_i; j < matrix.GetLength(1) - 2; ++j)
                    {
                        a[i, j] = matrix[i, j + 1];
                    }
                }
                return a;
            }
            {
                int[,] a = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
                for (int i = 0; i < matrix.GetLength(0); ++i)
                {
                    for (int j = 0; j < min_i; ++j)
                    {
                        a[i, j] = matrix[i, j];
                    }
                }
                for (int i = 0; i < matrix.GetLength(0); ++i)
                {
                    for (int j = min_i; j < matrix.GetLength(1) - 1; ++j)
                    {
                        a[i, j] = matrix[i, j + 1];
                    }
                }
                return a;
            }
        }
        static int Search_Max(int a, int[,] matrix)
        {
            int max_ = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                {
                    for (int j = 0; j < matrix.GetLength(1); ++j)
                    {
                        if (matrix[i, j] > max_ && matrix[i, j] < a)
                        {
                            max_ = matrix[i, j];
                        }
                    }
                }
            }
            return max_;
        }
        static int[,] FindMaxes(int[,] matrix)
        {
            int[] arr = new int[matrix.GetLength(0)*matrix.GetLength(1)];
            int[] maxes_ = new int[5];
            int p = 0;
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    arr[p] = matrix[i,j];
                    ++p;
                }
            }

            int index = 0;
            int empty = 0;
            while(index < arr.Length)
            {
                if (index == 0 || arr[index] <= arr[index - 1])
                {
                    ++index;
                } 
                else
                {
                    empty = arr[index];
                    arr[index] = arr[index - 1];
                    arr[index - 1] = empty;
                    --index;
                }
            }
            
            for (int i = 0; i < 5; i++)
            {
                maxes_[i] = arr[i];
            }
            double count = 0;
            for (int i = matrix.GetLength(0) - 1; i >= 0; --i)
            {
                for (int j = matrix.GetLength(1) - 1; j >= 0; --j)
                {
                    if (matrix[i,j] > 0)
                    {
                        count = 2;
                    }
                    else
                    {
                        count = 0.5;
                    }
                    if (matrix[i,j] == maxes_[0])
                    {
                        matrix[i, j] = (int)(matrix[i, j] * count);
                        ++count;
                        maxes_[0] *= (int)(maxes_[0] * count);
                    }
                    else if (matrix[i,j] == maxes_[1])
                    {
                        matrix[i, j] = (int)(matrix[i, j] * count);
                        ++count;
                        maxes_[1] *= (int)(maxes_[1] * count);
                    }
                    else if (matrix[i, j] == maxes_[2])
                    {
                        matrix[i, j] = (int)(matrix[i, j] * count);
                        ++count;
                        maxes_[2] *= (int)(maxes_[2] * count);
                    }
                    else if (matrix[i, j] == maxes_[3])
                    {
                        matrix[i, j] = (int)(matrix[i, j] * count);
                        ++count;
                        maxes_[3] *= (int)(maxes_[3] * count);
                    }
                    else if (matrix[i, j] == maxes_[4])
                    {
                        matrix[i, j] = (int)(matrix[i, j] * count);
                        ++count;
                        maxes_[4] *= (int)(maxes_[4] * count);
                    }
                    else
                    {
                        matrix[i, j] = matrix[i, j] / 2;
                    }
                }
            }
            return matrix;
        }

        delegate double fi(double x, int i);
        static double f1(double x, int i)
        {
            return Math.Cos(i * x) / Factorial(i);
        }
        static double f2(double x, int i)
        {
            return Math.Pow(-1, i) * Math.Cos(i * x) / i * i;
        }
        static double Total(fi f, double a, double b, double h)
        {
            double s = 0;
            int i = 1;
            for (double x = a; x <= b; x = x + h)
            {
                s = s + f(x, i);
                ++i;
            }
            return s;
        }

        delegate void fx(int[,] matrix, int i);
        static void f_1(int[,] matrix, int i)
        {

            for (int p = 0; p < matrix.GetLength(1); ++p)
            {
                for (int j = p; j < matrix.GetLength(1); ++j)
                {
                    if (matrix[i, p] > matrix[i, j])
                    {
                        int empty = matrix[i, p];
                        matrix[i, p] = matrix[i, j];
                        matrix[i, j] = empty;
                    }
                }
            }

        }

        static void f_2(int[,] matrix, int i)
        {

            for (int p = 0; p < matrix.GetLength(1); ++p)
            {
                for (int j = p; j < matrix.GetLength(1); ++j)
                {
                    if (matrix[i, p] < matrix[i, j])
                    {
                        int empty = matrix[i, p];
                        matrix[i, p] = matrix[i, j];
                        matrix[i, j] = empty;
                    }
                }
            }

        }
        static void Sorted(int[,] matrix, fx f1, fx f2)
        {

            for (int i = 0; i < matrix.GetLength(0); i += 2)
            {
                f1(matrix, i);
            }

            for (int i = 1; i < matrix.GetLength(0); i += 2)
            {
                f2(matrix, i);
            }
        }
        static void Main(string[] args)
        {
            #region Lvl_1

            #region Num_1
            {
                int squad = 5;
                int applicants_1 = 8, applicants_2 = 10, applicants_3 = 11;
                Console.WriteLine($"if 8, then {Variants(squad, applicants_1)} variants, if 10, then {Variants(squad, applicants_2)} variants, if 11, then {Variants(squad, applicants_3)} variants");
            }
            #endregion
            #region Num_2
            {
                double a1 = 15, b1 = 20, c1 = 25, a2 = 16, b2 = 30, c2 = 34;
                if (a1 > 0 & a2 > 0 & b1 > 0 & b2 > 0 & c1 > 0 & c2 > 0)
                {
                    if ((a1 + b1 > c1) & (a1 + c1 > b1) & (b1 + c1 > a1) & (a2 + b2 > c2) & (a2 + c2 > b2) & (b2 + c2 > a2))
                    {
                        if (Square(a1, b1, c1) > Square(a2, b2, c2))
                        {
                            Console.WriteLine($"Square_1 > Square_2 => answer = {Square(a1, b1, c1)} ");
                        }
                        else
                        {
                            Console.WriteLine($"Square_2 > Square_1 => answer = {Square(a2, b2, c2)} ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            #endregion

            #endregion

            #region Lvl_2

            #region Num_6
            {
                int[] arr_1 = new int[7] { 5, 2, 6, 3, 8, 11, 34 };
                int[] arr_2 = new int[8] { 4, 66, 3, 21, 68, 42, 77, 1 };
                arr_1 = Without_Max(arr_1);
                arr_2 = Without_Max(arr_2);
                int[] arr_3 = new int[arr_1.Length + arr_2.Length];
                for (int i = 0; i < arr_1.Length; ++i)
                {
                    arr_3[i] = arr_1[i];
                }
                int j = 0;
                for (int i = arr_1.Length; i < arr_1.Length + arr_2.Length; ++i)
                {
                    arr_3[i] = arr_2[j];
                    ++j;
                }
                for (int i = 0; i < arr_3.Length; ++i)
                {
                    Console.Write($"{arr_3[i]} ");
                }
                Console.WriteLine();
            }
            #endregion

            #region Num_10
            {
                int[,] matrix = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
                matrix = Deleting_Columns(matrix);
                Output_Matrix(matrix);
            }
            #endregion

            #region Num_23
            {
                int[,] matrix1 = {{1,2,3,4,5},
                       {6,7,8,9,10},
                       {11,12,13,14,15}};
                int[,] matrix2 = {{-1, -2, -3, -4, -5},
                       {-6, -7, -8, -9, 10},
                       {-11, -12, -13, -14, -15}};
                int[,] matrixEdit1 = FindMaxes(matrix1);
                int[,] matrixEdit2 = FindMaxes(matrix2);
                Output_Matrix(matrixEdit1);
                Console.WriteLine();
                Output_Matrix(matrixEdit2);
            }
            #endregion

            #endregion

            #region Lvl_3

            #region Num_1
            {
                double a1 = 0.1, b1 = 1, h1 = 0.1, a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;
                Console.WriteLine($"{1 + Total(f1, a1, b1, h1)}");
                Console.WriteLine($"{Total(f2, a2, b2, h2)}");
            }
            #endregion

            #region Num_2
            {
                int[,] matrix = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
                Sorted(matrix, f_1, f_2);
                Output_Matrix(matrix);
            }
            #endregion

            #endregion

        }
    }
}
    


