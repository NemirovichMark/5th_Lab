using System;
internal class Program{
    static void Main(string[] args){
        // Task3_1();
        //Task1_1();
        //Task1_2();
        //Task2_6();
        //Task2_10();
        //Task2_23();
        //Task3_1();
        Task3_6();

    }
    
    #region 1.1
     static void Task1_1()
    {
        Console.WriteLine($"Для 5 человек из 8 кандидатов:{CCount(8,5)}");
        Console.WriteLine($"Для 10 человек из 11 кандидатов:{CCount(11,10)}");
    }
    static int Fact(int f)
    {
        int a = 1;
        for (int i = 2; i <= f; i++)
        {
            a = a * i;
        }
        return a;
    }
    static int CCount(int n, int k)
    {
        return Fact(n) / (Fact(k) * Fact(n - k));
         }
   

    #endregion

    #region 1.2
    static double S(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        if (c > p || a > p || b > p)
        {
            Console.WriteLine("Это не треугольник");
            return 0;
        }
        double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return s;
    }
    static void Task1_2()
    {
        int a = 3, b = 4, c = 5;
        Console.WriteLine($"Площадь первого треугольника  =  {S(a,b,c)}");
        int a1 = 6, b1 = 7, c1 = 8;
        Console.WriteLine($"Площадь второго треугольника  = {S(a1,b1,c1)}");
        if (S(a,b,c) > S(a1,b1,c1))
        {
            Console.WriteLine("Площадь первого треугольника больше");
        }
        else
        {
            Console.WriteLine("Площадь второго треугольника больше");
        }
    }
    #endregion

    #region 2.6
    static int[] DelMax(int[] arr)
    {
        int max = int.MinValue;
        int imax = 0;
        int[] a = new int[arr.Length - 1];
        int n = arr.Length;
        for (int i = 0; i < n; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                imax = i;
            }
        }
        n--;
        for (int i = 0; i < imax; i++)
        {
            a[i] = arr[i];
        }
        for (int i = imax; i < n; i++)
        {
            a[i] = arr[i + 1];
        }
        return a;
    }
    static void Task2_6()
    {
        int[] a = new int[7] { 1, 2, 3, 10, 5, 6, 7 };
        int[] b = new int[8] { 4, 5, 6, 2, 3, 8, 9, 0 };
        Console.WriteLine("Первый массив без максимального ");
        a = DelMax(a);
        foreach (int u in a)
        {
            Console.Write(u + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Второй массив без максимального ");
        b = DelMax(b);
        foreach (int u in b)
        {
            Console.Write(u + " ");
        }
        Console.WriteLine();
        int[] c = new int[a.Length + b.Length];
        for (int i = 0; i < a.Length; i++)
        {
            c[i] = a[i];
        }
        int bi = 0;
        for (int i = a.Length; i < a.Length + b.Length; i++)
        {
            c[i] = b[bi];
            bi++;
        }
        Console.WriteLine("Объединенный массив");
        foreach (int u in c)
        {
            Console.Write(u + " ");
        }
    }
   
    #endregion

    #region 2.10
    static void PrintMatrix(int[,] arr)
        {

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
      static int[,] DeleteColumns(int[,] arr)
        {
            int max = int.MinValue;//ищу максимальный ниже главной диагонали(включая ее)
            int imax = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        imax = j;
                    }
                }
            }

            int min = int.MaxValue;//ищу минимальный выше главной диагонали
            int imin = 0;
            for (int i = arr.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = arr.GetLength(0) - 1; j > i; j--)
                {
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                        imin = j;
                    }
                }
            }

            if (imax < imin)
            {
                int[,] a = new int[arr.GetLength(0), arr.GetLength(1) - 2];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < imax; j++)
                    {
                        a[i, j] = arr[i, j];
                    }
                }

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = imin; j < arr.GetLength(1) - 1; j++)
                    {
                        a[i, j] = arr[i, j + 1];
                    }
                }

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = imax; j < arr.GetLength(1) - 2; j++)
                    {
                        a[i, j] = arr[i, j + 1];
                    }
                }
                return a;
            }

            if (imax > imin)
            {
                int[,] a = new int[arr.GetLength(0), arr.GetLength(1) - 2];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < imin; j++)
                    {
                        a[i, j] = arr[i, j];
                    }
                }

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = imax; j < arr.GetLength(1) - 1; j++)
                    {
                        a[i, j] = arr[i, j + 1];
                    }
                }

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = imin; j < arr.GetLength(1) - 2; j++)
                    {
                        a[i, j] = arr[i, j + 1];
                    }
                }
                return a;
            }

            {
                int[,] a = new int[arr.GetLength(0), arr.GetLength(1) - 1];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < imin; j++)
                    {
                        a[i, j] = arr[i, j];
                    }
                }
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = imin; j < arr.GetLength(1) - 1; j++)
                    {
                        a[i, j] = arr[i, j + 1];
                    }
                }
                return a;
            }


        }

     static void Task2_10()
        {
            int[,] a = new int[3, 3] { { 1, 90, 15 }, { 2, 30, 4 }, { 4, 6, 90 } };
            PrintMatrix(a);
            a = DeleteColumns(a);
            Console.WriteLine("Новая матрица");
            PrintMatrix(a);
        }

    #endregion

    #region 2.23
    static void DoubleMax(int[,] arr)
    {

        int f = int.MaxValue;
        for (int i = 0; i < 5; i++)
        {
            f = FindMax(f, arr);
        }

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] >= f)
                {
                    arr[i, j] *= 2;
                }
                else
                {
                    arr[i, j] /= 2;
                }
            }
        }
    }
    static int FindMax(int a, int[,] arr)
    {
        int max = int.MinValue;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > max && arr[i, j] < a)
                    {
                        max = arr[i, j];
                    }
                }
            }
        }
        return max;
    }
    static void Task2_23()
    {

        Random random=new Random();
        int z=random.Next(2,6);
        int[,]a=new int[z,z];
        int[,]b=new int[z,z];
        for(int y=0;y<a.GetLength(0);y++){
            for(int x=0;x<a.GetLength(1);x++){
                a[y,x]=random.Next(1,10);
            }
        }
        for(int y=0;y<b.GetLength(0);y++){
            for(int x=0;x<b.GetLength(1);x++){
                b[y,x]=random.Next(1,10);
            }
        }
        Console.WriteLine("Первая матрица:");
        PrintMatrix(a);
        Console.WriteLine("Измененная матрица:");
        DoubleMax(a);  
        PrintMatrix(a);
        Console.WriteLine("Вторая матрица:");
        PrintMatrix(b);
        DoubleMax(b);
        Console.WriteLine("Измененная матрица:");
        PrintMatrix(b);
    }

    #endregion
    
    #region Task3_1
    delegate double Member(int iterator, double x);
     static int Factorial(int n)
        {
            if(n > 0)
            {
                return n * Factorial(n - 1);
            }
            else
            {
                return 1;
            }
        }
        static void Task3_1()
        {
            double upBound = 1;
            double firstMember = 1;
            for (double x = 0.1; x <= upBound; x += 0.1)
            {
                double analitycalFunc = CalculateFunc((i, value) => Math.Cos(i * value) / Factorial(i), x, firstMember);
                double func = Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));
                Console.WriteLine($"x = {Math.Round(x, 2), 3}: " +
                    $"{func} - {analitycalFunc} = {Math.Abs(func - analitycalFunc)}");
            }

            Console.WriteLine("\n\n\n");

            upBound = Math.PI;
            firstMember = 0;
            for(double x = Math.PI / 5; x <= upBound; x += Math.PI / 25)
            {
                double analitycalFunc = CalculateFunc((i, value) => Math.Pow(-1, i) * Math.Cos(i * value) / (i * i), x, firstMember);
                double func = (Math.Pow(x, 2) - Math.Pow(Math.PI, 2) / 3) / 4;
                Console.WriteLine($"x = {Math.Round(x, 2), 3}: " +
                    $"{func} - {analitycalFunc} = {Math.Abs(func - analitycalFunc)}");
            }
        }

        static double CalculateFunc(Member f, double x, double firstMember)
        {
            double epsilon = 0.0001;

            double sum = firstMember;
            double currentMember = double.MaxValue;
            for(int i = 1; Math.Abs(currentMember) > epsilon; i++)
            {
                currentMember = f(i, x);
                sum += currentMember;
            }

            return sum;
        }
   #endregion
   #region Task3_6
   static int S(int[,] a)
        {
            int i = 0, aMax = 0, jMax = 0;
            for (int j = 0; j < a.GetLength(1); j++)
            {
                if (a[i, j] > aMax)
                {
                    aMax = a[i, j];
                    jMax = j;
                }
            }
            return jMax;
    }
    static int MD(int[,] a)
        {
            int aMax = 0, jMax = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                if (a[i, i] > aMax)
                {
                    aMax = a[i, i];
                    jMax = i;
                }
            }
            return jMax;
    }
    delegate int MaxElement(int[,] a);
    static void Changing(int[,] a, MaxElement MD, MaxElement S)
            {
                int ii = MD(a), jj = S(a);
                if (ii == jj)
                {
                    Console.WriteLine("Без изменений");
                }
                else
                {
                    for (int i = 0; i < a.GetLength(0); i++)
                    {
                        int p = a[i, ii]; a[i, ii] = a[i, jj]; a[i, jj] = p;
                    }
                }
    }
    static void Task3_6(){
            Random random = new Random();
            int n = 4;
            int[,]M = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    M[i, j] = random.Next(50);
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Changing(M, MD, S);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
    }
    #endregion
}
