using System;
using System.IO.Pipes;

namespace Project
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
        static double[] less(double[] list)
        {
            for (int i = list.Length - 1; i >= 0; i -= 2)
            {
                double temp = list[i];
                list[i] = list[i - 1];
                list[i - 1] = temp;
            }
            return list;
        }
        static double[] more(double[] list)
        {
            for (int i = 0; i < list.Length; i += 2)
            {
                double temp = list[i];
                list[i] = list[i + 1];
                list[i + 1] = temp;
            }
            return list;
        }
        static void Main(string[] args)
        {
            static void print_answer(double[,] a, int n, int m)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write(a[i, j]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }

            static int sol_1_1(int n)
            {
                int ans = 1;
                for (int i = 1; i <= n; i++)
                {
                    ans *= i;
                }
                return ans;
            }

            static void task_1_1()
            {
                int ans1 = sol_1_1(8) / (sol_1_1(5) * sol_1_1(8 - 5));
                int ans2 = sol_1_1(10) / (sol_1_1(5) * sol_1_1(10 - 5));
                int ans3 = sol_1_1(11) / (sol_1_1(5) * sol_1_1(11 - 5));
                Console.WriteLine(ans1);
                Console.WriteLine(ans2);
                Console.WriteLine(ans3);
            }
            task_1_1();

            static double sol_1_2(double a, double b, double c)
            {
                double p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }

            static void task1_2()
            {
                double a1 = 4, b1 = 3, c1 = 6;
                double a2 = 3, b2 = 5, c2 = 7;
                if (a1 + b1 > c1 && a1 + c1 > b1 && b1 + c1 > a1 & a2 + b2 > c2 && a2 + c2 > b2 && b2 + c2 > a2)
                {
                    double square1 = sol_1_2(a1, b1, c1);
                    double square2 = sol_1_2(a2, b2, c2);
                    if (square1 > square2)
                        Console.WriteLine($"The first triangle has bigger square {square1}");
                    else
                        Console.WriteLine($"The second triangle has bigger square {square2}");
                }
                else
                {
                    Console.WriteLine("There is no such triangle");
                }
            }
            task1_2();

            static int[] sol_2_6(int[] list, int index)
            {
                for (int i = index; i < list.Length - 1; i++)
                {
                    list[i] = list[i + 1];
                }
                Array.Resize(ref list, list.Length - 1);
                return list;
            }

            static void task2_6()
            {
                int[] a = new int[7] { 1, 2, 3, 99, 5, 6, 7 };
                int[] b = new int[8] { 8, 9, 10, 98, 12, 13, 14, 15 };
                int max1 = 0, index1 = 0;
                int max2 = 0, index2 = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] > max1)
                    {
                        max1 = a[i];
                        index1 = i;
                    }
                }
                a = sol_2_6(a, index1);
                for (int i = 0; i < b.Length; i++)
                {
                    if (b[i] > max2)
                    {
                        max2 = b[i];
                        index2 = i;
                    }
                }
                int p = 0;
                b = sol_2_6(b, index2);
                Array.Resize(ref a, a.Length + b.Length);
                for (int i = a.Length - b.Length; i < a.Length; i++)
                {
                    a[i] = b[p];
                    p++;
                }
                foreach (int i in a)
                    Console.WriteLine(i);
            }
            task2_6();

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
                double[,] list = new double[4, 4] {{1,2,3,4},
                                         {4,5,6,7},
                                         {6,7,8,9},
                                         {2,3,4,5}};
                double max = double.MinValue;
                int indexj1 = 0;
                for (int i = 0; i < list.GetLength(0); i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        if (list[i, j] > max)
                        {
                            max = list[i, j];
                            indexj1 = j;
                        }
                    }
                }
                double min = double.MaxValue;
                int indexj2 = 0;
                for (int i = 0; i < list.GetLength(0); i++)
                {
                    for (int j = list.GetLength(1) - 1; j > i; j--)
                    {
                        if (list[i, j] < min)
                        {
                            min = list[i, j];
                            indexj2 = j;
                        }
                    }
                }
                list = sol2_10(list, indexj1);
                if (indexj1 != indexj2)
                {
                    list = sol2_10(list, indexj2);
                }
                print_answer(list, list.GetLength(0), list.GetLength(1));
            }
            task2_10();

            static double[] sol2_23(double[] a, int[] aIndex)
            {
                int k = 0;
                for (int i = 0; i != a.Length; i++)
                {
                    if (aIndex[k] == i)
                    {
                        a[i] = a[i] * 2;
                        k++;
                    }
                    else a[i] = a[i] / 2;

                }
                return a;
            }

            static void task2_23()
            {
                double[] list = new double[10] { 122, -153.22, 0.2, -33.3, 40, -7, 68, 9, -13, 241 };
                double[] aNotSorted = new double[10];
                Array.Copy(list, aNotSorted, list.Length);
                Array.Sort(list);
                Array.Reverse(list);
                Array.Resize(ref list, 5);
                int[] aIndex = new int[5];
                for (int j = 0; j != aIndex.Length; j++)
                {
                    for (int i = 0; i != aNotSorted.Length; i++)
                    {
                        if (list[j] == aNotSorted[i])
                        {
                            aIndex[j] = i;
                            break;
                        }
                    }
                }
                Array.Sort(aIndex);

                aNotSorted = sol2_23(aNotSorted, aIndex);
                foreach (double x in aNotSorted)
                    Console.WriteLine(x);

            }
            task2_23();

            static double[,] sol3_2(double[,] a)
            {
                Deleg howToWork;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (i % 2 == 0)
                    {
                        double[] temp = new double[a.GetLength(1)];
                        for (int j = 0; j < a.GetLength(0); j++)
                            temp[j] = a[i, j];
                        howToWork = chet;
                        temp = howToWork(temp);
                        for (int j = 0; j < a.GetLength(0); j++)
                            a[i, j] = temp[j];
                    }
                    else
                    {
                        double[] temp = new double[a.GetLength(1)];
                        for (int j = 0; j < a.GetLength(0); j++)
                            temp[j] = a[i, j];
                        howToWork = nechet;
                        temp = howToWork(temp);
                        for (int j = 0; j < a.GetLength(0); j++)
                            a[i, j] = temp[j];
                    }
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

            static double sol3_3(double[] list)
            {
                double s = 0;
                for (int i = 0; i < list.Length; i++)
                {
                    if (i % 2 == 1)
                    {
                        s += list[i];
                    }
                }
                return s;

            }

            static void task3_3()
            {
                Deleg howToWork2;

                double[] list = new double[10] { 2, -5, -1, -8, 9, -7, -2, 7, -5, -9 };
                int count = 1;
                double s = 0;
                for (int i = 0; i < list.Length; i++)
                {
                    s += list[i];
                    count++;
                }
                double sr = s / count;
                if (list[0] > sr)
                {
                    howToWork2 = more;
                }
                else
                {
                    howToWork2 = less;
                }
                list = howToWork2(list);
                var sum = sol3_3(list);
                Console.WriteLine(sum);
            }
            task3_3();
        }
    }
}
