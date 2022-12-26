using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Transactions;

/*
#region lvl1 ex1
static void C(int n)
{
    int k = 5;
    int c = 0;
    if (n < k)
        Console.WriteLine("нет комбинаций");
    if (n >= k)
    {
        c = Fact(n) / Fact(k) * Fact(n - k);
        Console.WriteLine($"{c} комбинаций");
    }
}

static int Fact(int n)
{
    if (n == 0)
        return 1;   
    else
        return n * Fact(n - 1);
}


C(8);
C(10);
C(11);
#endregion

#region lvl1 ex2
static double ABC(double a, double b, double c)
{
    double p = (a + b + c) / 2;
    double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    return s;
}


static bool Triangle(double a, double b, double c)
{

    if (a >= b + c)
        return false;
    if (b >= c + a)
        return false;
    if (c >= a + b)
        return false;
    return true;
}

double S1 = 0;
double S2 = 0;
for (int i = 1; i < 3; i++)
{
    double a = 0;
    double b = 0;
    double c = 0;
    try
    {
        Console.WriteLine("введите строны треугольника");
        a = double.Parse(Console.ReadLine());
        b = double.Parse(Console.ReadLine());
        c = double.Parse(Console.ReadLine());
    }
    catch (Exception)
    {
        Console.WriteLine("Error");
    }
    if (Triangle(a, b, c))
    {
        if (i == 1)
        {
            S1 = ABC(a, b, c);
        }
        if (i == 2)
        {
            S2 = ABC(a, b, c);
        }

    }
}
if (S1 > S2)
    Console.WriteLine("площадь первого больше второго");
if (S2 > S1)
    Console.WriteLine("площадь второго больше первого");
else
    Console.WriteLine("площади равны");
#endregion

#region lvl2 ex6
static double[] arr(int n)
{
    double[] a = new double[n];
    double[] flag = new double[1];
    try
    {
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write($"введите {i} элемент");
            a[i] = double.Parse(Console.ReadLine());
        }
        return a;
    }
    catch (Exception)
    {
        Console.WriteLine("Error");
        return flag;
    }
}

static void result(double[] a, double[] b)
{
    int k = 0;
    Array.Resize(ref a, a.Length + b.Length);
    for (int i = a.Length - b.Length; i < a.Length; i++)
    {
        a[i] = b[k];
        k++;
    }
    Console.WriteLine(string.Join(", ", a));
}

double[] A = arr(7);
double[] B = arr(8);
int mx1 = Array.IndexOf(A, A.Max());
int mx2 = Array.IndexOf(B, B.Max());
for (int i = mx1; i < A.Length - 1; i++)
{
    A[i] = A[i + 1];
}
for (int i = mx2; i < B.Length - 1; i++)
{
    A[i] = A[i + 1];
}
Array.Resize(ref A, A.Length - 1);
Array.Resize(ref B, B.Length - 1);

result(A, B);
#endregion

#region lvl2 ex10


static double[][] ASD()
{
    int x = 0;
    int y = 0;
    double[][] flag = new double[0][];
    try
    {
        Console.WriteLine("введите количество строк и столбцов");
        x = int.Parse(Console.ReadLine());
        y = x;
        double[][] a = new double[x][];
        for (int i = 0; i < x; i++)
        {
            double[] a1 = new double[y];
            a[i] = a1;
            for (int j = 0; j < y; j++)
            {
                Console.WriteLine($"введите {i} {j} элемент");
                a[i][j] = double.Parse(Console.ReadLine());
            }
        }
        return a;
    }
    catch (Exception)
    {
        Console.WriteLine("Error");
        return flag;
    }
}

static double[][] res(int x1, int x2, double[][] arr)
{
    if (x1 > x2)
    {   
        for (int i = 0; i < arr.Length; i++)
        {
            var arr1 = new List<double>(arr[i]);
            arr1.RemoveAt(x1);
            arr1.RemoveAt(x2);
            var res = arr1.ToArray();
            arr[i] = res;
        }
        return arr;
    }
    if(x1 < x2)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            var arr1 = new List<double>(arr[i]);
            arr1.RemoveAt(x2);
            arr1.RemoveAt(x1);
            var res = arr1.ToArray();
            arr[i] = res;
        }
        return arr;
    }
    else
    {
        for (int i = 0; i < arr.Length; i++)
        {
            var arr1 = new List<double>(arr[i]);
            arr1.RemoveAt(x2);
            var res = arr1.ToArray();
            arr[i] = res;
        }
        return arr;
    }
}

static void Result(double[][] p)
{
    for (int i = 0; i < p.Length; i++)
    {
        for (int j = 0; j < p[i].Length; j++)
        {
            Console.Write(p[i][j] + "\t");
        }
        Console.WriteLine();
    }
}

double[][] ar = ASD();
double mx = double.MinValue;
double mn = double.MaxValue;
int ind1 = 0;
int ind2 = 0;
Result(ar);

for (int i = 0; i < ar.Length; i++)
{
    for (int j = 0; j <= i; j++)
    {
        if (ar[i][j] > mx)
        {
            mx = ar[i][j];
            ind1 = j;
        }
    }
    for (int j = ar.Length - 1; j > i; j--)
    {
        if (ar[i][j] < mn)
        {
            mn = ar[i][j];
            ind2 = j;
        }
    }
}
Console.WriteLine(ind1);
Console.WriteLine(ind2);
Result(res(ind1, ind2, ar));
#endregion
*/

#region lvl2 ex23

static void outputsqr(double[,] a, int l, int m)
{
    for (int i = 0; i < l; i++)
    {
        for (int j = 0; j < m; j++)
        {
            Console.Write(a[i, j]);
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}

static void inputsqr(double[,] ma, int l, int m)
{
    Console.WriteLine("введите массив");
    for (int i = 0; i < l; i++)
    {
        for (int j = 0; j < m; j++)
        {
            try
            {
                ma[i, j] = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("введите заново");
            }
        }
    }
}

static void changematrix(double[,] a, int l, int m)
{

    double x = -100000;
    for (int i = 0; i < 5; i++)
    {
        x = find_5_maximums(a, x);
    }
    int c = 0;

    for (int i = 0; i < l; i++)
        for (int j = 0; j < m; j++)
        {
            if ((a[i, j] >= x) && (c < 5))
            {
                if (a[i, j] < 0)
                {
                    a[i, j] /= 2;
                }
                else
                {
                    a[i, j] *= 2;
                }
                c += 1;
            }
            else
            {
                if (a[i, j] < 0)
                {
                    a[i, j] *= 2;
                }
                else
                {
                    a[i, j] /= 2;
                }
            }
        }
}

static double find_5_maximums(double[,] x, double a)
{
    double max = -1000000;
    for (int i = 0; i < x.GetLength(0); i++)
    {
        {
            for (int j = 0; j < x.GetLength(1); j++)
            {
                if (x[i, j] > max && x[i, j] < a)
                {
                    max = x[i, j];
                }
            }
        }
    }
    return max;
}

int am, al, bm, bl;
try
{
    Console.WriteLine("введите количество строк матрицы А");
    am = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("введите количество столбцов матрицы А");
    al = Convert.ToInt32(Console.ReadLine());


    Console.WriteLine("введите количество строк матрицы Б");

    bm = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("введите количество столбцов матрицы Б");

    bl = Convert.ToInt32(Console.ReadLine());
    if (((am > 1) && (bm > 1) && (al > 1) && (bm > 1)) && (am * al >= 5) && (bm * bl >= 5))
    {
        double[,] a = new double[am, al];

        inputsqr(a, am, al);
        double[,] b = new double[bm, bl];
        inputsqr(b, bm, bl);
        changematrix(a, am, al);
        changematrix(b, bm, bl);
        outputsqr(a, am, al);
        outputsqr(b, bm, bl);
    }
    else Console.WriteLine(" fall");
}
catch
{
    Console.WriteLine("введите заново");
}

#endregion
/*
#region lvl3 ex2

Resul oper = AR;
double[][] ara = QWE();
double[][] resut = oper(ara);
Result(resut);

static double[][] QWE()
{
    int x = 0;
    int y = 0;
    double[][] flag = new double[0][];
    try
    {
        Console.WriteLine("введите количество строк");
        x = int.Parse(Console.ReadLine());
        Console.WriteLine("введите количество столбцов");
        y = int.Parse(Console.ReadLine());
        double[][] a = new double[x][];
        for (int i = 0; i < x; i++)
        {
            double[] a1 = new double[y];
            a[i] = a1;
            for (int j = 0; j < y; j++)
            {
                Console.WriteLine($"введите {i} {j} элемент");
                a[i][j] = double.Parse(Console.ReadLine());
            }
        }
        return a;
    }
    catch (Exception)
    {
        Console.WriteLine("Error");
        return flag;
    }
}

static double[][] AR(double[][] a)
{
    for (int i = 0; i < a.Length; i++)
    {
        if (i % 2 == 0)
            Array.Sort(a[i]);
        else
        {
            Array.Sort(a[i]);
            Array.Reverse(a[i]);
        }
    }
    return a;
}

delegate double[][] Resul(double[][] a);

#endregion

#region lvl3 ex 1
class HelloWorld
{
    delegate double fc(double x);
    delegate double f(double x, double i);
    static double factorial(double x)
    {
        double fact = 1;
        for (double i = 1; i <= x; i++)
        {
            fact = fact * i;
        }
        return fact;
    }
    static double f1(double x, double i)
    {
        x = Math.Cos(x * 0.0175 * i) / factorial(i);
        return x;
    }
    static double f2(double x, double i)
    {
        x = Math.Pow(-1, i) * (Math.Cos(x * 0.0175 * i) / Math.Pow(i, 2));
        return x;
    }
    static double y1(double x)
    {
        return Math.Pow(Math.E, Math.Cos(x * 0.0175)) * Math.Cos(Math.Sin(x * 0.0175));
    }
    static double y2(double x)
    {
        return (Math.Pow(x, 2) - (Math.Pow(Math.PI, 2) / 2)) / 4;
    }
    static double sum(f f1, double x)
    {
        double summa = 0;
        for (double i = 1; i >= 0; i++)
        {
            if (Math.Abs(f1(x, i)) < 0.001) { return summa; }
            summa = summa + f1(x, i);
        }
        return summa;
    }
    static void sum1(f f1, fc f2, double a, double b, double h, double k)
    {
        for (double x = a; x <= b; x = x + h)
        {
            Console.WriteLine("Summa = " + sum(f1, x) + k + ". Accurancy of function = " + (f2(x) - sum(f1, x) + k));
        }
    }
    static int Main()
    {
        Console.WriteLine("The first: ");
        sum1(f1, y1, 0.1, 1, 0.1, 1);
        Console.WriteLine("The second: ");
        sum1(f2, y2, (Math.PI / 5), (Math.PI), (Math.PI / 25), 0);

        return 0;
    }
}
#endregion
*/