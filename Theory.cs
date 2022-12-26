using System;

namespace Лаба5
{
    class Program
    {
        #region Task 1_1
        static void Main(string[] args)
        {
            int k = 5;
            Console.WriteLine(Answ(8, k));
            Console.WriteLine(Answ(10, k));
            Console.WriteLine(Answ(11, k));

        }
        static int Answ(int n, int k)
        {
            int answ = work(n) / (work(k) * work(n - k));
            return answ;
        }
        static int work(int s)
        {
            int ok = 1;
            for (int i = 1; i <= s; i++)
            {
                ok = ok * i;
            }
            return (ok);
        }
        #endregion

        #region Task 1_2
        static void Main(string[] args)
        {
            double a, b, c, n, m, q;
            Console.WriteLine("Enter number 'a': ");
            string in_a = Console.ReadLine();
            double.TryParse(in_a, out a);
            Console.WriteLine("Enter number 'b': ");
            string in_b = Console.ReadLine();
            double.TryParse(in_b, out b);
            Console.WriteLine("Enter number 'c': ");
            string in_c = Console.ReadLine();
            double.TryParse(in_c, out c);
            Console.WriteLine("Enter number 'n': ");
            string in_n = Console.ReadLine();
            double.TryParse(in_n, out n);
            Console.WriteLine("Enter number 'm': ");
            string in_m = Console.ReadLine();
            double.TryParse(in_m, out m);
            Console.WriteLine("Enter number 'q': ");
            string in_q = Console.ReadLine();
            double.TryParse(in_q, out q);
            double p1 = Answ(a, b, c);
            double p2 = Answ(n, m, q);
            if (p1 > p2)
            {
                Console.WriteLine($"The larger triangle has an area of {p1}");
            }
            else
            {
                Console.WriteLine($"The larger triangle has an area of {p2}");
            }
        }
        static double Answ(double a, double b, double c)
        {
            double p = per(a, b, c);
            double answ = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return answ;
        }
        static double per(double a, double b, double c)
        {
            double P = (a + b + c) / 2;
            return P;
        }
        #endregion

        #region Task 2_6
        static void Main(string[] args)
        {
            int n = 7, m = 8, index_n, index_m, j = 0;
            double[] a = new double[n + m];
            double[] b = new double[m];
            Console.WriteLine("Enter elements 'a' separated by a space");
            string s = Console.ReadLine();
            string[] c = s.Split(' ');
            for (int i = 0; i < n; i++)
            {
                double.TryParse(c[i], out a[i]);
            }
            Console.WriteLine("Enter elements 'b' separated by a space");
            string s1 = Console.ReadLine();
            string[] c1 = s1.Split(' ');
            for (int i = 0; i < m; i++)
            {
                double.TryParse(c1[i], out b[i]);
            }
            index_n = max(a, n);
            index_m = max(b, m);
            for (int i = index_n; i < index_n + index_m; i++)
            {
                a[i] = b[j];
                j++;
            }
            Console.WriteLine("Answer: ");
            for (int i = 0; i < index_n + index_m; i++)
            {
                Console.Write($"{a[i]} ");
            }

            static int max(double[] c, int l)
            {
                double max = c[0];
                for (int i = 0; i < l; i++)
                {
                    if (max < c[i])
                    {
                        max = c[i];
                    }
                }
                for (int i = 0; i < l - 1; i++)
                {
                    if (c[i] == max)
                    {
                        for (int j = i; j < l - 1; j++)
                        {
                            c[j] = c[j + 1];
                        }
                        l--;
                        i--;
                    }
                }
                if (c[l - 1] == max)
                {
                    c[l - 1] = 0;
                    l--;
                }
                return l;
            }
        }
        #endregion

        #region Task 2_10
        static void Main(string[] args)
        {
            int n, m, index_jup = 0, index_jd = 0;
            Console.WriteLine("Enter the size of the square matrix: ");
            string vvod = Console.ReadLine();
            if (int.TryParse(vvod, out n) & n > 1)
            {
                int.TryParse(vvod, out n);
            }
            else
            {
                Console.WriteLine("Enter an integer > 1");
                return;
            }
            int[,] a = new int[n, n];
            m = n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("Enter the element y: " + i + " x: " + j);
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,5:d} ", a[i, j]);
                }
                Console.WriteLine();
            }
            int max_down = a[0, 0];
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (max_down < a[i, j])
                    {
                        max_down = a[i, j];
                        index_jd = j;

                    }
                }
            }
            int min_up = a[0, 1];
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (min_up > a[i, j])
                    {
                        min_up = a[i, j];
                        index_jup = j;

                    }
                }
            }
            m = del(a, n, m, index_jd);
            m = del(a, n, m, index_jup);
            Console.WriteLine("The answer is output as a matrix: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,5:d} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
        static int del(int[,] a, int n, int m, int index)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = index; j < m - 1; j++)
                {
                    a[i, j] = a[i, j + 1];
                }
            }
            m--;
            return m;
        }
        #endregion
        }
}
