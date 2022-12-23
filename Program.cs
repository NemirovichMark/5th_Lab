using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;

namespace ConsoleApp1
{
    class System
    {
        

        delegate double[] Deleg(double[] list);

        static double[] nechet(double[] list)
        {
            Array.Sort(list);
            Array.Reverse(list);
            return list;
        }
        static double[] chet(double[] list)
        {
            Array.Sort(list);
            return list;
        }

        static void Main(string[] args)
        {
            static void print_answer(double[,] a)
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        Console.Write(a[i, j]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }

            static void PrintAns(double[] list)
            {
                foreach (double value in list)
                {
                    Console.Write($"{value} ");
                }
                Console.WriteLine();
            }



            static double[,] sol3_2(double[,] a)
            {
                Deleg howToWork;
                for (int i = 0; i < a.GetLength(0); i++)
                {

                    double[] temp = new double[a.GetLength(1)];
                    for (int j = 0; j < a.GetLength(0); j++)
                        temp[j] = a[i, j];
                    if (i % 2 == 0) 
                    {
                        howToWork = chet;
                    }
                    else
                    {
                        howToWork = nechet;
                    }
                    temp = howToWork(temp);
                    for (int j = 0; j < a.GetLength(0); j++)
                        a[i, j] = temp[j];

                }
                return a;
            }
            static void task3_2()
            {
                double[,] list = new double[4, 4] { {1,5,3,2},
                                                 {1,5,3,7},
                                                 {5,2,4,9},
                                                 {3,7,9,8}};
                list = sol3_2(list);
                for (int i = 0; i < list.GetLength(0); i++)
                {
                    for (int j = 0; j < list.GetLength(1); j++)
                    {
                        Console.Write(list[i, j]);
                        Console.Write(' ');
                    }
                    Console.WriteLine();
                }
            }
            task3_2();


            static double[,] sol2_10(double[,] list, int index)
            {
                for (int i = 0; i < list.GetLength(0); i++)
                {
                    if (index != list.GetLength(1) - 1)
                    {
                        for (int j = index; j < list.GetLength(1) - 1; j++)
                        {
                            list[i, j] = list[i, j + 1];
                        }
                    }
                    else break;
                }
                double[,] b = new double[list.GetLength(0), list.GetLength(1) - 1];
                for (int i = 0; i < b.GetLength(0); i++)
                    for (int j = 0; j < b.GetLength(1); j++)
                        b[i, j] = list[i, j];
                return b;
            }

            static void task2_10()
            {
                double[,] list = new double[4, 4] {{1,2,3,-40},
                                         {4,5,6,70},
                                         {6,1000,8,9},
                                         {2,3,4,5}};
                double max = double.MinValue;
                int indexj1 = 0;
                for (int i = 0; i < list.GetLength(0); i++)
                {
                    for (int j = 0; j < list.GetLength(1); j++)
                    {
                        if (list[i, j] > max)
                        {
                            max = list[i, j];
                            indexj1 = j;
                        }
                    }
                }
                Console.WriteLine($"{indexj1} {max}");
                double min = double.MaxValue;
                int indexj2 = 0;
                for (int i = 0; i < list.GetLength(0); i++)
                {
                    for (int j = 0; j < list.GetLength(1); j++)
                    {
                        if (list[i, j] < min)
                        {
                            min = list[i, j];
                            indexj2 = j;
                        }
                    }
                }
                Console.WriteLine($"{indexj1} {min}");
                list = sol2_10(list, indexj1);
                if (indexj1 != indexj2)
                {
                    list = sol2_10(list, indexj2);
                }
                print_answer(list);
            }
            task2_10();


            static void FixdMatrix(double[,] matrix)
            {
                double[] ans = new double[matrix.GetLength(0) * matrix.GetLength(1)];
                int k = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        ans[k] = matrix[i, j];
                        k++;
                    }
                }

                for (int i = 0; i < ans.Length; i++)
                {
                    for (int j = 0; j < ans.Length - 1; j++)
                    {
                        if (ans[j] < ans[j + 1])
                        {
                            double p = ans[j]; ans[j] = ans[j + 1]; ans[j + 1] = p;
                        }
                    }
                }

                int count = 0;
                if (ans.Length > 5)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if ((matrix[i, j] == ans[0] || matrix[i, j] == ans[1] || matrix[i, j] == ans[2] || matrix[i, j] == ans[3] || matrix[i, j] == ans[4]) && (count < 5))
                            {
                                matrix[i, j] *= 2;
                                count++;
                            }
                            else
                            {
                                matrix[i, j] /= 2;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            matrix[i, j] *= 2;
                        }
                    }
                }
            }

            static void Task2_23()
            {
                double[,] matrix = new double[4, 4] {{1,2,3,-40},
                                                    {4,5,6,70},
                                                    {6,1000,8,9},
                                                    {2,3,4,5}};
                //double[,] matrix = new double[4, 4] {{1.44,2,3,-40},
                //                                    {4,5,6.543,70},
                //                                    {6,10.6,8,9},
                //                                    {2,3,4.3,5}};
                Console.WriteLine();
                print_answer(matrix);
                FixdMatrix(matrix);
                print_answer(matrix);
                

            }
            Task2_23();
        }
    }
}