class homew6lvl2
{
    static public int max(int[] ma, int l)
    {
        int maxx = -100000000;
        int imax = 0;
        for (int i = 0; i < l; i++)
        {
            if (ma[i] > maxx)
            {
                maxx = ma[i];
                imax = i;
            }
        }
        return imax;
    }

    
    static public int[] del(int[] ma, int indexmax, int l)
    {
        for (int i = indexmax; i < l - 1; i++)
            ma[i] = ma[i + 1];
        return ma;
    }
    static public int[] merge(int[] ma, int[] mb, int l, int m)
    {
        int c = 0;
        for (int i = l - 1; i < (l + m - 2); i++)
        {
            ma[i] = mb[c];
            c++;
        }
        return ma;

    }
    static void inputone(int[] ma, int l)
    {
        Console.WriteLine("введите массив");
        for (int i = 0; i<l; i++)
        {
            try
            {
                ma[i] = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("введите заново");
            }
        }
        
    }
    static void outputone(int[] a, int l)
    {
        for (int i = 0; i < l; i++)
            Console.WriteLine(a[i]);
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
                    ma[i,j] = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("введите заново");
                }
            }
        }

    }
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
    static public int maxsqr(double[,] a, int l)
    {
        double max = -100000000;
        int jmax = 0;
        for (int i = 0; i < l; i++)
        {
            for (int j = 0; j < l; j++)
            {
                if ((max < a[i, j])&&(i>=j))
                {
                    jmax = j;
                    max = a[i, j];
                }
            }
        }

        return jmax;
    }
    static public int minsqr(double[,] a, int l)
    {
        double min = 100000000;
        int jmin = 0;
        for (int i = 0; i < l; i++)
        {
            for (int j = 0; j < l; j++)
            {
                if ((min > a[i, j])&&(i<j))
                {
                    jmin = j;
                    min = a[i, j];
                }
            }
        }
        return jmin;
    }
    static public double[,] delsqr(double[,] ma, int jndex, int l, int m)
    {
        for (int i = 0; i < l; i++)
        {
            for (int j = jndex; j < m - 1; j++)
                ma[i, j] = ma[i, j + 1];
        }
           
        return ma;
    }
    static double[] find_5_maximums(double[,] x)
    {
        int n = x.GetLength(0), 
            m = x.GetLength(1);
        List<double> tmp = new List<double>(n + m);
        double[] res = new double[5];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                tmp.Add(x[i, j]);
            }
        }

        tmp.Sort();

        int k = 0;
        for (int i = n + m - 5; i <= n + m - 1; i++)
        {
            res[k] = tmp[i];
            k++;
        }
        return res;
    }

    static bool in_array(double[] arr, double value)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == value)
            {
                return true;
            }
        }
        return false;
    }
    static void changematrix(double[,] a, int l, int m)
    {
        double[] mx5 = find_5_maximums(a);
        for (int i = 0; i<l;i++)
            for(int j = 0; j<m;j++)
            {
                if (in_array(mx5, a[i, j]) == true)
                    a[i, j] *= 2;
                else
                    a[i, j] /= 2;
            }
    }
    static void Main()
    {
        Console.WriteLine("введите номер задания(6,10,23)");
        int numb = 0;
        try
        {
            numb = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("введите снова");
        }
        if (numb == 6)
        {
            int[] a = new int[7 + 8 - 2];
            int[] b = new int[8];
            inputone(a, 7);
            inputone(b, 8);
            int imaxa = max(a, 7);
            int imaxb = max(b, 8);
            a = del(a, imaxa, 7);
            b = del(b, imaxb, 8);
            a = merge(a, b, 7, 8);
            outputone(a, 7 + 8 - 2);
        }
        else if (numb == 10)
        {
            try
            {
                int m = Convert.ToInt32(Console.ReadLine());
                if (m > 0)
                {
                    double[,] a = new double[m, m];
                    inputsqr(a, m, m);
                    outputsqr(a, m, m);
                    int jmax = maxsqr(a, m);

                    int jmin = minsqr(a, m);
                    // Console.WriteLine($"jmax -> {jmax}, jmin-> {jmin}");
                    a = delsqr(a, jmin, m, m);
                    a = delsqr(a, jmax, m, m - 1);
                    outputsqr(a, m, m - 2);
                }
                else Console.WriteLine("fall");
            }
            catch
            {
                Console.WriteLine("fall");
            }

        }
        else if (numb == 23)
        {
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
        }

    }
}
