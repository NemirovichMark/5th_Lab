using System.Runtime.Serialization.Formatters;

class Program
{
    static void Main()
    {
        //Task 1.1
        Console.WriteLine("Task 1.1");
        int k = 5;
        int n = 8;
        double c;
        C(n, k, out c);
        Console.WriteLine(c);
        n = 10;
        C(n, k, out c);
        Console.WriteLine(c);
        n = 11;
        C(n, k, out c);
        Console.WriteLine(c);

        //Task 1.2
        Console.WriteLine("Task 1.2");
        double a, b, x;
        double d = 1, e = 1, f = 1;
        string[] g;
        a = 1;
        b = 1;
        Console.WriteLine("Введите a");
        g = Console.ReadLine().Split();
        if (g.Length == 1)
        {
            if (double.TryParse(g[0], out x))
            {
                a = x;
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
        Console.WriteLine("Введите b");
        g = Console.ReadLine().Split();
        if (g.Length == 1)
        {
            if (double.TryParse(g[0], out x))
            {
                b = x;
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
        Console.WriteLine("Введите c");
        g = Console.ReadLine().Split();
        if (g.Length == 1)
        {
            if (double.TryParse(g[0], out x))
            {
                c = x;
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
        else
        {
            Console.WriteLine("Неверный ввод");
        }
        Console.WriteLine("Введите d");
        g = Console.ReadLine().Split();
        if (g.Length == 1)
        {
            if (double.TryParse(g[0], out x))
            {
                d = x;
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
        Console.WriteLine("Введите e");
        g = Console.ReadLine().Split();
        if (g.Length == 1)
        {
            if (double.TryParse(g[0], out x))
            {
                e = x;
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
        Console.WriteLine("Введите f");
        g = Console.ReadLine().Split();
        if (g.Length == 1)
        {
            if (double.TryParse(g[0], out x))
            {
                f = x;
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
        else
        {
            Console.WriteLine("Неверный ввод");
        }
        if (a + b > c & b + c > a & c + a > b & d + e > f & e + f > d & f + d > e)
        {
            ST(a, b, c, out c);
            ST(d, e, f, out f);
            if (c > f)
            {
                Console.WriteLine("У первого больше");
            }
            if (c < f)
            {
                Console.WriteLine("У второго больше");
            }
            if (c == f)
            {
                Console.WriteLine("Они равны");
            }
        }
        else
        {
            Console.WriteLine("Треугольника не существует");
        }

        //Task 2.6
        Console.WriteLine("Task 2.6");
        double[] A = new double[7];
        double[] B = new double[8];
        Console.WriteLine("Введите A в строку");
        g = Console.ReadLine().Split();
        if (g.Length == 7)
        {
            for (int i = 0; i < g.Length; i += 1)
            {
                if (double.TryParse(g[i], out x))
                {
                    A[i] = x;
                }
                else
                {
                    Console.WriteLine("Неверный ввод");
                }
            }
        }
        else
        {
            Console.WriteLine("Неверный ввод");
            Environment.Exit(0);
        }
        Console.WriteLine("Введите B в строку");
        g = Console.ReadLine().Split();
        if (g.Length == 8)
        {
            for (int i = 0; i < g.Length; i += 1)
            {
                if (double.TryParse(g[i], out x))
                {
                    B[i] = x;
                }
                else
                {
                    Console.WriteLine("Неверный ввод");
                }
            }
        }
        else
        {
            Console.WriteLine("Неверный ввод");
            Environment.Exit(0);
        }
        DelMax(A, out A);
        DelMax(B, out B);
        Comb(A, B, out A);
        Console.WriteLine("");
        for (int i = 0; i < A.Length; i++)
        {
            Console.Write($"{A[i]} ");
        }

        //Task 2.10
        Console.WriteLine("Task 2.10");
        double[,] M;
        Console.WriteLine("Введите n");
        g = Console.ReadLine().Split();
        if (g.Length == 1)
        {
            if (int.TryParse(g[0], out k))
            {
                n = k;
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
        M = new double[n, n];
        for (int j = 0; j < n; j += 1)
        {
            Console.WriteLine($"Введите {j} строку");
            g = Console.ReadLine().Split();
            if (g.Length == n)
            {
                for (int i = 0; i < g.Length; i += 1)
                {
                    if (double.TryParse(g[i], out x))
                    {
                        M[j, i] = x;
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод");
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод");
                Environment.Exit(0);
            }
        }
        double min1 = 10000000;
        double max2 = -10000000;
        int mini1 = 0;
        int maxi2 = 0;
        for (int j = 0; j < n; j += 1)
        {
            for (int i = 0; i < n; i += 1)
            {
                if (i <= j)
                {
                    if (M[j, i] < min1)
                    {
                        mini1 = i;
                        min1 = M[j, i];
                    }
                }
                if (i > j)
                {
                    if (M[j, i] > max2)
                    {
                        maxi2 = i;
                        max2 = M[j, i];
                    }
                }
            }
        }
        DelStolb(M, mini1,maxi2, out M);
        Console.WriteLine("");
        for (int j = 0; j < n; j += 1)
        {
            for (int i = 0; i < n - 2; i += 1)
            {
                Console.Write($"{M[j, i]} ");
            }
            Console.WriteLine();
        }

        //Task 2.23
        Console.WriteLine("Task 2.23");
        int n1 = 0;
        int m1 = 0;
        Console.WriteLine("Введите n");
        g = Console.ReadLine().Split();
        if (g.Length == 1)
        {
            if (int.TryParse(g[0], out k))
            {
                n1 = k;
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
        Console.WriteLine("Введите m");
        g = Console.ReadLine().Split();
        if (g.Length == 1)
        {
            if (int.TryParse(g[0], out k))
            {
                m1 = k;
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
        double[,] M1;
        M1 = new double[n1, m1];
        for (int j = 0; j < n1; j += 1)
        {
            Console.WriteLine($"Введите {j} строку");
            g = Console.ReadLine().Split();
            if (g.Length == m1)
            {
                for (int i = 0; i < g.Length; i += 1)
                {
                    if (double.TryParse(g[i], out x))
                    {
                        M1[j, i] = x;
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод");
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод");
                Environment.Exit(0);
            }
        }
        int n2 = 0;
        int m2 = 0;
        Console.WriteLine("Введите n");
        g = Console.ReadLine().Split();
        if (g.Length == 1)
        {
            if (int.TryParse(g[0], out k))
            {
                n2 = k;
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
        Console.WriteLine("Введите m");
        g = Console.ReadLine().Split();
        if (g.Length == 1)
        {
            if (int.TryParse(g[0], out k))
            {
                m2 = k;
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
        double[,] M2;
        M2 = new double[n2, m2];
        for (int j = 0; j < n2; j += 1)
        {
            Console.WriteLine($"Введите {j} строку");
            g = Console.ReadLine().Split();
            if (g.Length == m2)
            {
                for (int i = 0; i < g.Length; i += 1)
                {
                    if (double.TryParse(g[i], out x))
                    {
                        M2[j, i] = x;
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод");
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод");
                Environment.Exit(0);
            }
        }
        T23(M1, out M1);
        T23(M2, out M2);
        Console.WriteLine("");
        for (int j = 0; j < n1; j += 1)
        {
            for (int i = 0; i < m1; i += 1)
            {
                Console.Write($"{M1[j, i]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("");
        for (int j = 0; j < n2; j += 1)
        {
            for (int i = 0; i < m2; i += 1)
            {
                Console.Write($"{M2[j, i]} ");
            }
            Console.WriteLine();
        }

        //Task 3.2
        Console.WriteLine("Task 3.2");
        n = 0;
        int m = 0;
        Console.WriteLine("Введите n");
        g = Console.ReadLine().Split();
        if (g.Length == 1)
        {
            if (int.TryParse(g[0], out k))
            {
                n = k;
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
        Console.WriteLine("Введите m");
        g = Console.ReadLine().Split();
        if (g.Length == 1)
        {
            if (int.TryParse(g[0], out k))
            {
                m = k;
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
        M = new double[n, m];
        for (int j = 0; j < n; j += 1)
        {
            Console.WriteLine($"Введите {j} строку");
            g = Console.ReadLine().Split();
            if (g.Length == m)
            {
                for (int i = 0; i < g.Length; i += 1)
                {
                    if (double.TryParse(g[i], out x))
                    {
                        M[j, i] = x;
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод");
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод");
                Environment.Exit(0);
            }
        }
        for (int j = 0; j < n; j += 1)
        {
            if (j % 2 == 0)
            {
                Rev(Chet, M, j, out M);
            }
            if (j % 2 == 1)
            {
                Rev(Nech, M, j, out M);
            }
        }
        Console.WriteLine("");
        for (int j = 0; j < n; j += 1)
        {
            for (int i = 0; i < m; i += 1)
            {
                Console.Write($"{M[j, i]} ");
            }
            Console.WriteLine();
        }

        //Task 3.3
        Console.WriteLine("Task 3.3");
        Console.WriteLine("Введите числа в строку");
        double s = 0;
        g = Console.ReadLine().Split();
        A = new double[g.Length];
        for (int i = 0; i < g.Length; i += 1)
        {
            if (double.TryParse(g[i], out x))
            {
                A[i] = x;
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
        for (int i = 0; i < A.Length; i += 1)
        {
            s += A[i];
        }
        s = s / A.Length;
        if (A[0] > s)
        {
            Console.WriteLine(Sum(Nach, A));
        }
        else
        {
            Console.WriteLine(Sum(Kon, A));
        }
    }
    static void Fact(int k, out double fk)
    {
        int i;
        fk = 1;
        for (i = 1; i <= k; i++)
            fk = fk * i;
    }
    static void C(int n, int k, out double c)
    {
        double fn;
        double fk;
        double fnk;
        Fact(n, out fn);
        Fact(k, out fk);
        Fact(n - k, out fnk);
        c = fn / (fk * fnk);
    }
    static void PP(double a, double b, double c, out double p)
    {
        p = (a + b + c) / 2;
    }
    static void ST(double a, double b, double c, out double s)
    {
        double p;
        PP(a, b, c, out p);
        s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
    static void DelMax(double[] a, out double[] b)
    {
        double max = -1000000;
        int maxi = 0;
        b = new double[a.Length - 1];
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] > max)
            {
                max = a[i];
                maxi = i;
            }
        }
        int k = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (i != maxi)
            {
                b[k] = a[i];
                k++;
            }
        }
    }
    static void Comb(double[] a, double[] b, out double[] c)
    {
        c = new double[a.Length + b.Length];
        for (int i = 0; i < a.Length; i++)
        {
            c[i] = a[i];
        }
        for (int i = 0; i < b.Length; i++)
        {
            c[i + a.Length] = b[i];
        }
    }
    static void DelStolb(double[,] a, int k, int n, out double[,] b)
    {
        b = new double[a.GetLength(0), a.GetLength(1) - 1];
        for (int j = 0; j < a.GetLength(0); j += 1)
        {
            for (int i = 0; i < a.GetLength(1); i += 1)
            {
                if (i < k)
                {
                    b[j, i] = a[j, i];
                }
                if (i > k)
                {
                    b[j, i - 1] = a[j, i];
                }
            }
        }
        double[,] c = new double[b.GetLength(0), b.GetLength(1) - 1];
        if (k!=n)
        {
            for (int j = 0; j < a.GetLength(0); j += 1)
            {
                for (int i = 0; i < a.GetLength(1); i += 1)
                {
                    if (i < n)
                    {
                        c[j, i] = b[j, i];
                    }
                    if (i > n)
                    {
                        c[j, i - 1] = b[j, i];
                    }
                }
            }
           b = new double[c.GetLength(0), c.GetLength(1)];
            for (int j = 0; j < a.GetLength(0); j += 1)
            {
                for (int i = 0; i < a.GetLength(1); i += 1)
                {
                    b[j, i] = c[j, i];
                }
            }
        }
    }
    static void T23(double[,] a, out double[,] b)
    {
        double a1 = -100000000;
        double a2 = -100000000;
        double a3 = -100000000;
        double a4 = -100000000;
        double a5 = -100000000;
        int maxi1 = 0;
        int maxj1 = 0;
        int maxi2 = 0;
        int maxj2 = 0;
        int maxi3 = 0;
        int maxj3 = 0;
        int maxi4 = 0;
        int maxj4 = 0;
        int maxi5 = 0;
        int maxj5 = 0;
        b = new double[a.GetLength(0), a.GetLength(1)];
            for (int j = 0; j < a.GetLength(0); j += 1)
            {
                for (int i = 0; i < a.GetLength(1); i += 1)
                {
                    if (a[j,i]>a1)
                    {
                    maxi5 = maxi4;
                    maxj5 = maxj4;
                    maxi4 = maxi3;
                    maxj4 = maxj3;
                    maxi3 = maxi2;
                    maxj3 = maxj2;
                    maxi2 = maxi1;
                    maxj2 = maxj1;
                    maxi1 = i;
                    maxj1 = j;
                    a1 = a[j, i];
                    }
                else
                {
                    if (a[j, i] > a2)
                    {
                        maxi5 = maxi4;
                        maxj5 = maxj4;
                        maxi4 = maxi3;
                        maxj4 = maxj3;
                        maxi3 = maxi2;
                        maxj3 = maxj2;
                        maxi2 = i;
                        maxj2 = j;
                        a2 = a[j, i];
                    }
                    else
                    {
                        if (a[j, i] > a3)
                        {
                            maxi5 = maxi4;
                            maxj5 = maxj4;
                            maxi4 = maxi3;
                            maxj4 = maxj3;
                            maxi3 = i;
                            maxj3 = j;
                            a3 = a[j, i];
                        }
                        else
                        {
                            if (a[j, i] > a4)
                            {
                                maxi5 = maxi4;
                                maxj5 = maxj4;
                                maxi4 = i;
                                maxj4 = j;
                                a4 = a[j, i];
                            }
                            else
                            {
                                if (a[j, i] > a5)
                                {
                                    maxi5 = i;
                                    maxj5 = j;
                                    a5 = a[j, i];
                                }
                            }
                        }
                    }
                }
                }
            }
        if (a[maxj1, maxi1] > 0)
        {
            a1 = a1 * 2;
            a[maxj1, maxi1] = a1;
        }
        else
        {
            a1 = a1 / 2;
            a[maxj1, maxi1] = a1;
        }
        if (a[maxj2, maxi2] > 0)
        {
            a2 = a2 * 2;
            a[maxj2, maxi2] = a2;
        }
        else
        {
            a2 = a2 / 2;
            a[maxj2, maxi2] = a2;
        }
        if (a[maxj3, maxi3] > 0)
        {
            a3 = a3 * 2;
            a[maxj3, maxi3] = a3;
        }
        else
        {
            a3 = a3 / 2;
            a[maxj3, maxi3] = a3;
        }
        if (a[maxj4, maxi4] > 0)
        {
            a4 = a4 * 2;
            a[maxj4, maxi4] = a4;
        }
        else
        {
            a4 = a4 / 2;
            a[maxj4, maxi4] = a4;
        }
        if (a[maxj5, maxi5] > 0)
        {
            a5 = a5 * 2;
            a[maxj5, maxi5] = a5;
        }
        else
        {
            a5 = a5 / 2;
            a[maxj5, maxi5] = a5;
        }
        for (int j = 0; j < a.GetLength(0); j += 1)
        {
            for (int i = 0; i < a.GetLength(1); i += 1)
            {
                if (a[j, i] != a1 & a[j, i] != a2 & a[j, i] != a3 & a[j, i] != a4 & a[j, i] != a5)
                {
                    if (a[j, i] > 0)
                    {
                        a[j, i] = a[j, i] / 2;
                    }
                    else
                    {
                        a[j, i] = a[j, i] * 2;
                    }
                }
            }
        }
        for (int j = 0; j < a.GetLength(0); j += 1)
        {
            for (int i = 0; i < a.GetLength(1); i += 1)
            {
                b[j, i] = a[j, i];
            }
        }
    }
    static void Rev(fi f, double[,] a, int k, out double[,] b)
    {
        double[] c = new double[a.GetLength(1)];
        b = new double[a.GetLength(0), a.GetLength(1)];
        for (int i = 0; i < a.GetLength(1); i += 1)
        {
            c[i] = a[k, i];
        }
        f(c);
        for (int i = 0; i < a.GetLength(1); i += 1)
        {
            a[k, i] = c[i];
        }
        for (int j = 0; j < a.GetLength(0); j += 1)
        {
            for (int i = 0; i < a.GetLength(1); i += 1)
            {
                b[j, i] = a[j, i];
            }
        }
    }
    delegate double[] fi(double[] a);
    static double[] Chet(double[] a)
    {
        Array.Sort(a);
        return a;
    }
    static double[] Nech(double[] a)
    {
        Array.Sort(a);
        Array.Reverse(a);
        return a;
    }
    static double[] Nach(double[] a)
    {
        double c = 0;
        for (int i = 0; i < a.Length; i += 1)
        {
            if (i % 2 == 1)
            {
                c = a[i];
                a[i] = a[i - 1];
                a[i - 1] = c;
            }
        }
        return a;
    }
    static double[] Kon(double[] a)
    {
        Array.Reverse(a);
        Nach(a);
        Array.Reverse(a);
        return a;
    }
    static double Sum(fi f, double[] a)
    {
        double s = 0;
        f(a);
        for (int i = 0; i < a.Length; i += 1)
        {
            if (i % 2 == 1)
            {
                s += a[i];
            }
        }
        return s;
    }
}