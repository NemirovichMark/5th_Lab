using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace lab_5
{
    delegate double[,] sorted_matrix(double[,] matrix, int index, bool sign);
    delegate double y(double x);
    delegate double[] array_of_matrix(double[,] matrix);
    class Program
    {
        #region methods
        static int Fac(int x)
        {
            if (x == 1) return 1;
            return x * Fac(x - 1);
        }

        static double S(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        static double[] Del_el(double[] array, int index)
        {
            double[] answ = new double[array.Length - 1];
            for (int i = 0; i < array.Length; i++)
            {
                if (i < index) answ[i] = array[i];
                else if (i > index) answ[i - 1] = array[i];
            }
            return answ;
        }

        static int Max_array(double[] array)
        {
            double answ = array[0];
            int answ_index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > answ)
                {
                    answ = array[i];
                    answ_index = i;
                }
            }
            return answ_index;
        }

        static double[,] Del_col_matrix(double[,] matrix, int column)
        {
            int row = matrix.GetUpperBound(0) + 1;
            int col = matrix.Length / row;
            double[,] answ = new double[row, col - 1];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (j < column) answ[i, j] = matrix[i, j];
                    else if (j > column) answ[i, j - 1] = matrix[i, j];
                }
            }
            return answ;
        }

        static double[,] Five_max(double[,] matrix)
        {
            int row = matrix.GetUpperBound(0) + 1;
            int col = matrix.Length / row;
            double[] answ = new double[5] { -999999999999999999, -999999999999999999, -999999999999999999, -999999999999999999, -999999999999999999 };
            int[,] answ_index = new int[5, 2];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] > answ[0])
                    {
                        answ[4] = answ[3];
                        answ[3] = answ[2];
                        answ[2] = answ[1];
                        answ[1] = answ[0];
                        answ[0] = matrix[i, j];
                        answ_index[4, 0] = answ_index[3, 0]; answ_index[4, 1] = answ_index[3, 1];
                        answ_index[3, 0] = answ_index[2, 0]; answ_index[3, 1] = answ_index[2, 1];
                        answ_index[2, 0] = answ_index[1, 0]; answ_index[2, 1] = answ_index[1, 1];
                        answ_index[1, 0] = answ_index[0, 0]; answ_index[1, 1] = answ_index[0, 1];
                        answ_index[0, 0] = i; answ_index[0, 1] = j;
                    }
                    else if (matrix[i, j] > answ[1])
                    {
                        answ[4] = answ[3];
                        answ[3] = answ[2];
                        answ[2] = answ[1];
                        answ[1] = matrix[i, j];
                        answ_index[4, 0] = answ_index[3, 0]; answ_index[4, 1] = answ_index[3, 1];
                        answ_index[3, 0] = answ_index[2, 0]; answ_index[3, 1] = answ_index[2, 1];
                        answ_index[2, 0] = answ_index[1, 0]; answ_index[2, 1] = answ_index[1, 1];
                        answ_index[1, 0] = i; answ_index[1, 1] = j;
                    }
                    else if (matrix[i, j] > answ[2])
                    {
                        answ[4] = answ[3];
                        answ[3] = answ[2];
                        answ[2] = matrix[i, j];
                        answ_index[4, 0] = answ_index[3, 0]; answ_index[4, 1] = answ_index[3, 1];
                        answ_index[3, 0] = answ_index[2, 0]; answ_index[3, 1] = answ_index[2, 1];
                        answ_index[2, 0] = i; answ_index[2, 1] = j;
                    }
                    else if (matrix[i, j] > answ[3])
                    {
                        answ[4] = answ[3];
                        answ[3] = matrix[i, j];
                        answ_index[4, 0] = answ_index[3, 0]; answ_index[4, 1] = answ_index[3, 1];
                        answ_index[3, 0] = i; answ_index[3, 1] = j;
                    }
                    else if (matrix[i, j] > answ[4])
                    {
                        answ[4] = matrix[i, j];
                        answ_index[4, 0] = i; answ_index[4, 1] = j;
                    }
                }
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] /= 2;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                matrix[answ_index[i, 0], answ_index[i, 1]] *= 4;
            }
            return matrix;
        }

        static double[,] Sort_row(double[,] matrix, int index_row, bool sign)
        {
            int row = matrix.GetUpperBound(0) + 1;
            int col = matrix.Length / row;
            double temp;
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < col-i-1; j++)
                {
                    if (sign == true)
                    {
                        if (matrix[index_row, j] > matrix[index_row, j + 1])
                        {
                            temp = matrix[index_row, j];
                            matrix[index_row, j] = matrix[index_row, j + 1];
                            matrix[index_row, j + 1] = temp;
                        }
                    }
                    else
                    {
                        if (matrix[index_row, j] < matrix[index_row, j + 1])
                        {
                            temp = matrix[index_row, j];
                            matrix[index_row, j] = matrix[index_row, j + 1];
                            matrix[index_row, j + 1] = temp;
                        }
                    }
                }
            }
            return matrix;
        }

        static double[,] Sort_matrix(double[,] matrix, sorted_matrix x)
        {
            int row = matrix.GetUpperBound(0) + 1;
            int col = matrix.Length / row;
            for (int i = 0; i < row; i++)
            {
                if (i % 2 == 0) matrix = x(matrix, i, true);
                else matrix = x(matrix, i, false);
            }
            return matrix;
        }

        static double func_1(double x)
        {
            double answ = x*x - Math.Sin(x);
            return answ;
        }

        static double func_2(double x)
        {
            double answ = Math.Pow(Math.E, x) - 1;
            return answ;
        }

        static int intervals(y func, double left, double right, double step)
        {
            int answ = 0;
            int cnt = 0;
            double last_sign = func(left);
            for (double i = left+step; i <= right; i += step)
            {
                double x = func(i);
                if ((x < 0 && last_sign < 0) || (x > 0 && last_sign > 0)) cnt++;
                else
                {
                    if (cnt > answ) answ = cnt;
                    cnt = 0;
                }
            }
            if (cnt > answ) answ = cnt;
            return answ;
        }

        static double[] diag(double[,] matrix)
        {
            double[] array = new double[(int)Math.Sqrt(matrix.Length)];
            for (int i = 0; i < Math.Sqrt(matrix.Length); i++)
            {
                array[i] = matrix[i, i];
            }
            return array;
        }

        static double[] first_row(double[,] matrix)
        {
            double[] array = new double[(int)Math.Sqrt(matrix.Length)];
            for (int i = 0; i < Math.Sqrt(matrix.Length); i++)
            {
                array[i] = matrix[0, i];
            }
            return array;
        }

        static int max_array(array_of_matrix get_array, double[,] matrix)
        {
            double[] array = get_array(matrix);
            int index = 0;
            double max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    index = i;
                }
            }
            return index;
        }

        static double[,] change_columns(double[,] matrix, int ind1, int ind2)
        {
            for (int i = 0; i<Math.Sqrt(matrix.Length); i++)
            {
                double temp = matrix[i, ind1];
                matrix[i, ind1] = matrix[i, ind2];
                matrix[i, ind2] = temp;
            }
            return matrix;
        }
        #endregion
        static void Main(string[] args)
        {
            Console.Clear();

            #region I|1
            Console.WriteLine("---------- EX I|1 ----------");
            Console.WriteLine();

            int kondidats = 8, places = 5;
            Console.WriteLine(Fac(kondidats) / (Fac(places) * (kondidats - places)));
            kondidats = 10;
            Console.WriteLine(Fac(kondidats) / (Fac(places) * (kondidats - places)));
            kondidats = 11;
            Console.WriteLine(Fac(kondidats) / (Fac(places) * (kondidats - places)));

            Console.WriteLine();
            #endregion

            #region I|2
            Console.WriteLine("---------- EX I|2 ----------");
            Console.WriteLine();

            double x1 = S(10, 4.1, 9), x2 = S(8, 8.1, 13);
            if (x1 > x2) Console.WriteLine("First triangle");
            else if (x1 == x2) Console.WriteLine("First triangle = Second triangle");
            else Console.WriteLine("Second triangle");

            Console.WriteLine();
            #endregion

            #region II|6
            Console.WriteLine("---------- EX II|6 ----------");
            Console.WriteLine();

            double[] A = new double[7] { 0, 0.5, 10, -5, 5, 12, 2 };
            double[] B = new double[8] { 2, 14, 5, 0.42, 1, -321, 24, 41};
            A = Del_el(A, Max_array(A));
            B = Del_el(B, Max_array(B));
            double[] array = new double[A.Length + B.Length];
            
            for (int i = 0; i < array.Length; i++)
            {
                if (i < A.Length) array[i] = A[i];
                else array[i] = B[i - A.Length];
            }
            foreach (double i in array) Console.Write(i + " ");
            Console.WriteLine();
            
            Console.WriteLine();
            #endregion

            #region II|10
            Console.WriteLine("---------- EX II|10 ----------");
            Console.WriteLine();

            double[,] matrix = new double[4, 4] { { 0, 5, 1, -10 },
                                                  { 0.5, -412.42, 1231, 12 },
                                                  { 9, 42, 1, -3 },
                                                  { 0.99999, 123, 42, 1} };
            int row = matrix.GetUpperBound(0) + 1;
            int col = matrix.Length / row;
            double max = matrix[0,0], min = matrix[0,0];
            int max_ind1 = 0, max_ind2 = 0, min_ind1 = 0, min_ind2 = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (j <= i)
                    {
                        if (matrix[i, j] > max)
                        {
                            max = matrix[i, j];
                            max_ind1 = i;
                            max_ind2 = j;
                        }
                    }
                    else
                    {
                        if (matrix[i, j] < min)
                        {
                            min = matrix[i, j];
                            min_ind1 = i;
                            min_ind2 = j;
                        }
                    }
                }
            }

            if (max_ind2 == min_ind2) matrix = Del_col_matrix(matrix, max_ind2);
            else if (max_ind2 < min_ind2) matrix = Del_col_matrix(Del_col_matrix(matrix, min_ind2), max_ind2);
            else matrix = Del_col_matrix(Del_col_matrix(matrix, max_ind2), min_ind2);
            col = matrix.Length / row;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++) Console.Write("{0,7} ", matrix[i, j]);
                Console.WriteLine();
            }

            Console.WriteLine();
            #endregion

            #region II|23
            Console.WriteLine("---------- EX II|23 ----------");
            Console.WriteLine();

            double[,] matrix1 = new double[4, 3] {{1, 5, 9},
                                                  {-4, 10, 20},
                                                  {6, 2, 1},
                                                  {9, 1, 4}};
            double[,] matrix2 = new double[3, 4] {{5, 100, 24, 1},
                                                  {5, 12, 4, 9},
                                                  {-14, 421, -24, -123}};

            matrix = Five_max(matrix1);
            row = matrix.GetUpperBound(0) + 1;
            col = matrix.Length / row;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++) Console.Write("{0,7} ", matrix[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();

            matrix = Five_max(matrix2);
            row = matrix.GetUpperBound(0) + 1;
            col = matrix.Length / row;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++) Console.Write("{0,7} ", matrix[i, j]);
                Console.WriteLine();
            }

            Console.WriteLine();
            #endregion

            #region III|2
            Console.WriteLine("---------- EX III|2 ----------");
            Console.WriteLine();

            matrix = new double[4, 4] { {4, 1, 4, 5},
                                        {0, 51, 2, 4},
                                        {1, -12 ,24, 21},
                                        {5, 1, 4, -53}};
            row = matrix.GetUpperBound(0) + 1;
            col = matrix.Length / row;
            matrix = Sort_matrix(matrix, Sort_row);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++) Console.Write("{0,7} ", matrix[i, j]);
                Console.WriteLine();
            }

            Console.WriteLine();
            #endregion

            #region III|5
            Console.WriteLine("---------- EX III|5 ----------");
            Console.WriteLine();

            Console.WriteLine(intervals(func_1, 0, 2, 0.1));
            Console.WriteLine(intervals(func_2, -1, 1, 0.2));

            Console.WriteLine();
            #endregion

            #region III|6
            Console.WriteLine("---------- EX III|6 ----------");
            Console.WriteLine();

            matrix = new double[4, 4] { { 0, 5, 1, -10 },
                                        { 0.5, -412.42, 1231, 12 },
                                        { 9, 42, 1, -3 },
                                        { 0.99999, 123, 42, 1} };
            int max_diag = max_array(diag, matrix);
            int max_on_row = max_array(first_row, matrix);
            matrix = change_columns(matrix, max_diag, max_on_row);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++) Console.Write("{0,7} ", matrix[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine();
            #endregion
        }
    }
}