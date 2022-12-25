class lab5lvl3
{
    static void inputsqr(int[,] ma, int l, int m)
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
    static void outputsqr(int[,] a, int l, int m)
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
    #region task2
    delegate void fi(int a, int b, out int first, out int sec);
    static void f1(int a, int  b, out int first, out int sec) // permutation decrease
    {
        if (a <= b)
        {
            first = a;
            sec = b;
        }
        else
        {
            first = b;
            sec = a;
        }
    }

    static void f2(int a, int b, out int first, out int sec) // permutation increase
    {
        if (a >= b)
        {
            first = a;
            sec = b;
        }
        else
        {
            first = b;
            sec = a;
        }
    }
    static void sort(int[,] x, fi f, int idx , int m)
    {
        
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                f(x[idx, i], x[idx, j], out x[idx, j], out x[idx, i]); // permutation & use deligate
            }
        }
    }
 
   
    static void fix(int[,] x, int l , int m)
    {
        for (int i = 0; i < l; i++)
        {
            fi u = f1; // create delegate by default

            if (i % 2 == 0) //if even number other function
            {
                u = f2;
            }
                    else u = f1;

            sort(x,u,i,m); //sort task

        }

    }
#endregion
    #region task6
    delegate int max(int[,] x, int m);
    static int maxfcolumn(int[,] a, int m)
    {
        int max = -1000000000;
        int jmax = -1;
        for (int j = 0; j< m; j++)
        {
            if (a[0,j]>max)
            {
                max = a[0,j];
                jmax = j;
            }
        }
        return jmax;

    }
    static int maxdcolumn(int[,] a, int m)
    {
        int max = -1000000000;
        int jmax = -1;
        for (int j = 0; j < m; j++)
        {
            if (a[j, j] > max)
            {
                max = a[0, j];
                jmax = j;
            }
        }
        return jmax;

    }
    static void permutation(int[,] a, int l)
    {
        max maximum = maxfcolumn;
        int jndfmax = maximum(a, l);

        maximum = maxdcolumn;
        int jnddmax = maximum(a, l);

        for (int i = 0; i<l; i++)
        {
            int t = a[i,jnddmax];
            a[i, jnddmax] = a[i, jndfmax];
            a[i, jndfmax] = t;
        }


    }
    #endregion

    static void Main()
    {
        Console.WriteLine("choose task 2 or 6");
        int numb = Convert.ToInt32(Console.ReadLine());
        if (numb == 2)
        {
            int l, m;
            try
            {
                Console.WriteLine("введите pазмер строки");
                l = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("введите pазмер столбцов");
                m = Convert.ToInt32(Console.ReadLine());

                int[,] a = new int[l,m];
                inputsqr(a, l, m); //input array
                Console.WriteLine("array before");
                outputsqr(a, l, m); // output array
                fix(a, l, m); //task2 function
                Console.WriteLine("array after");
                outputsqr(a, l, m); // output array

            }
            catch
            {
                Console.WriteLine("введите заново");
            }
            


        }
        else if (numb == 6)
        {
            int l, m;
            try
            {
                Console.WriteLine("введите pазмер квадратной матрицы");
                l = Convert.ToInt32(Console.ReadLine());
                

                int[,] a = new int[l, l];
                inputsqr(a, l, l); //input array
                Console.WriteLine("array before");
                outputsqr(a, l, l);
                permutation(a,l);
                Console.WriteLine("array after");
                outputsqr(a, l, l); // output array

            }
            catch
            {
                Console.WriteLine("введите заново");
            }
        }
        else Console.WriteLine("choose from list");

    }
}
