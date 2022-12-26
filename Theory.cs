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
            if (a >= b + c || b >= a + c || c >= a + b)
            {
                Console.WriteLine("The triangle does not exist");
                return;
            }
            Console.WriteLine("Enter number 'n': ");
            string in_n = Console.ReadLine();
            double.TryParse(in_n, out n);
            Console.WriteLine("Enter number 'm': ");
            string in_m = Console.ReadLine();
            double.TryParse(in_m, out m);
            Console.WriteLine("Enter number 'q': ");
            string in_q = Console.ReadLine();
            double.TryParse(in_q, out q);
            if (n >= m + q || m >= n + q || q >= n + m)
            {
                Console.WriteLine("The triangle does not exist");
                return;
            }
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
            if (index_jup == index_jd)
            {
                m = del(a, n, m, index_jd);
            }
            else
            {
                m = del(a, n, m, index_jd);
                m = del(a, n, m, index_jup);
            }
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

        #region Task 2_23
        static void Main(string[] args)
        {
            int n, m, index_jup = 0, index_jd = 0;
            Console.WriteLine("Enter the size n of the matrix: ");
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
            Console.WriteLine("Enter the size m of the matrix: ");
            string vvod2 = Console.ReadLine();
            if (int.TryParse(vvod2, out m) & m > 1)
            {
                int.TryParse(vvod2, out m);
            }
            else
            {
                Console.WriteLine("Enter an integer > 1");
                return;
            }
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("Enter the element y: " + i + " x: " + j);
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,5:d} ", a[i, j]);
                }
                Console.WriteLine();
            }
            matrix(a, n, m);
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
        static void matrix(int[,] a, int n, int m)
        {
            int[] a_a = new int[n * m];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a_a[k] = a[i, j];
                    k++;
                }
            }
            int rem;
            for (int i = 0; i < n * m - 1; i++)
            {
                if (a_a[i] < a_a[i + 1])
                {
                    rem = a_a[i];
                    a_a[i] = a_a[i + 1];
                    a_a[i + 1] = rem;
                    i = -1;
                }
            }
            int ch = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((a[i, j] == a_a[0] || a[i, j] == a_a[1] || a[i, j] == a_a[2] || a[i, j] == a_a[3] || a[i, j] == a_a[4]) && ch < 5)
                    {
                        if (a[i, j] > 0)
                        {
                            a[i, j] *= 2;
                        }
                        else
                        {
                            a[i, j] += a[i, j] * (-1) / 2;
                        }
                        ch++;
                    }
                    else
                    {
                        if (a[i, j] > 0)
                        {
                            a[i, j] /= 2;
                        }
                        else
                        {
                            a[i, j] *= 2;
                        }
                    }
                }
            }
        }
        #endregion

        #region Task 3_1
        const double eps = 0.0001;
        static void Si(double a, double b, double h, f fi, Y yi, double s)
        {
            for (double x = a; x <= b; x += h)
            {
                double y = yi(x);
                double sum = fi(x) + s;
                Console.WriteLine($"s = {sum}, y = {y}");
            }
        }
        static void Main(string[] args)
        {
            Si(0.1, 1, 0.1, f1, Y1, 1);
            Console.WriteLine();
            Si(Math.PI / 5, Math.PI, Math.PI / 25, f2, Y2, 0);
        }
        delegate double f(double x);
        delegate double Y(double x);
        static double f1(double x)
        {
            double dem = 1, element, answ = 0;
            for (int i = 1; i == i; i++)
            {
                dem *= i;
                element = Math.Cos(i * x) / dem;
                answ += element;
                if (element <= eps)
                {
                    break;
                }
            }
            return answ;
        }
        static double Y1(double x)
        {
            double y = Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
            return y;
        }
        static double f2(double x)
        {
            double koef = -1, element = 1, answ = 0;
            for (int i = 1; i == i; i++)
            {
                element = Math.Cos(i * x) / (i * i) * koef;
                answ += element;
                koef *= -1;
                if (element <= eps)
                {
                    break;
                }
            }
            return answ;
        }
        static double Y2(double x)
        {
            double y = (Math.Pow(x, 2) - (Math.Pow(Math.PI, 2) / 3)) / 4;
            return y;
        }
        #endregion

        #region Task 3_2
        static void Si(f fi, int[,] a, int n, int m, int k)
        {
            for (; k < n; k += 2)
            {
                fi(a, n, m, k);
            }
        }
        static void Main(string[] args)
        {
            int n, m;
            Console.WriteLine("Enter the size n of the matrix: ");
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
            Console.WriteLine("Enter the size m of the matrix: ");
            string vvod2 = Console.ReadLine();
            if (int.TryParse(vvod2, out m) & m > 1)
            {
                int.TryParse(vvod2, out m);
            }
            else
            {
                Console.WriteLine("Enter an integer > 1");
                return;
            }
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("Enter the element y: " + i + " x: " + j);
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,5:d} ", a[i, j]);
                }
                Console.WriteLine();
            }
            Si(f1, a, n, m, 1);
            Si(f2, a, n, m, 0);
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
        delegate void f(int[,] a, int n, int m, int k);
        static void f1(int[,] a, int n, int m, int k)
        {
            int rem;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m - 1; j++)
                {
                    if (a[k, j] < a[k, j + 1])
                    {
                        rem = a[k, j];
                        a[k, j] = a[k, j + 1];
                        a[k, j + 1] = rem;
                    }
                }
            }
        }
        static void f2(int[,] a, int n, int m, int k)
        {
            int rem;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m - 1; j++)
                {
                    if (a[k, j] > a[k, j + 1])
                    {
                        rem = a[k, j];
                        a[k, j] = a[k, j + 1];
                        a[k, j + 1] = rem;
                    }
                }
            }
        }
        #endregion

    }
}
