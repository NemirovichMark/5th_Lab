namespace lab5
{
    internal class Program
    {
        static int VarCount(int n, int k)
        {

            return Fact(n) / (Fact(k) * Fact(n - k));



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
        static void lvl1_1()
        {
            int n = 8, k = 5;
            Console.WriteLine("Number of options for 5 people out of 8 = " + VarCount(n, k));
            int n1 = 11, k1 = 10;
            Console.WriteLine("Number of options for 10 people out of 11 = " + VarCount(n1, k1));
        }
        static double Square(double a, double b, double c)
        {

            double p = (a + b + c) / 2;
            if (c > p || a > p || b > p)
            {
                Console.WriteLine("It's not a triangle");
                return 0;
            }

            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return s;
        }
        static void lvl1_2()
        {
            int a = 5, b = 5, c = 7;
            double q = Square(a, b, c);
            Console.WriteLine("The area of the first triangle  = " + q);
            int a1 = 6, b1 = 6, c1 = 11;
            double q2 = Square(a1, b1, c1);
            Console.WriteLine("The area of the second triangle  = " + q2);
            if (q > q2)
            {
                Console.WriteLine("The area of the first triangle is larger");

            }
            else
            {
                Console.WriteLine("The area of the second triangle is larger");
            }
        }
        static int[] DeleteMax(int[] arr)
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
        static void lvl2_6()
        {
            int[] a = new int[7] { 3, 5, 1, 11, 8, 14, 16 };
            int[] b = new int[8] { 8, 7, 1, 0, 9, 3, 2, 4 };
            Console.WriteLine("The first array without the max ");
            a = DeleteMax(a);
            foreach (int u in a)
            {
                Console.Write(u + " ");
            }
            Console.WriteLine();
            Console.WriteLine("The second array without the maximum ");
            b = DeleteMax(b);
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
            Console.WriteLine("Combined Array");
            foreach (int u in c)
            {
                Console.Write(u);
            }
        }
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
        delegate int FindColumnToDelete(int[,] arr);
        static int FindMaxUpper(int[,] arr)
        {
            int min = int.MaxValue;
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
            return imin;
        }
        static int[,] DeleteColumns2(int[,] arr, FindColumnToDelete f1, FindColumnToDelete f2)
        {
            int imax = f1(arr);

            int imin = f2(arr);


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
        static int[,] DeleteColumns(int[,] arr)
        {
            int max = int.MinValue;
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

            int min = int.MaxValue;
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
        static void lvl2_10()
        {
            int[,] a = new int[3, 3]
            {
                { 11, 9, 1 },
                { 23, 3, 41 },
                { 43, 61, 4 }
            };
            PrintMatrix(a);
            a = DeleteColumns(a);
            Console.WriteLine("new matrix");
            PrintMatrix(a);
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
        static void DoubleMax(int[,] arr)
        {

            int f = int.MaxValue;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(f = FindMax(f, arr));
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
        static int FindMaxLower(int[,] arr)
        {
            int max = int.MinValue;
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
            return imax;
        }
        static void lvl2_23()
        {
            int[,] a = new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9, }
            };
            PrintMatrix(a);
            Console.WriteLine();
            DoubleMax(a);
            Console.WriteLine();
            PrintMatrix(a);
            Console.WriteLine();
            int[,] b = new int[4, 4]
            {
                { 1, 2, 3, 5 },
                { 4, 5, 6, 8 },
                { 12, 34, 12, 0 },
                { 13, 22, 54, -1 }
            };
            PrintMatrix(b);
            Console.WriteLine();
            DoubleMax(b);
            Console.WriteLine();
            PrintMatrix(b);
        }
        static void lvl3_7_10()
        {
            int[,] a = new int[3, 3]
            {
                { 1, 90, 15 },
                { 2, 31, 4 },
                { 4, 6, 9 }
            };
            PrintMatrix(a);
            a = DeleteColumns2(a, FindMaxUpper, FindMaxLower);
            Console.WriteLine("new matrix");
            PrintMatrix(a);

        }
        delegate void ProccessRow(int[,] a, int i);
        static void SortRowUp(int[,] arr, int i)
        {

            for (int t = 0; t < arr.GetLength(1); t++)
            {
                for (int j = t; j < arr.GetLength(1); j++)
                {
                    if (arr[i, t] > arr[i, j])
                    {
                        int temp = arr[i, t];
                        arr[i, t] = arr[i, j];
                        arr[i, j] = temp;
                    }
                }
            }

        }

        static void SortRowDown(int[,] arr, int i)
        {

            for (int t = 0; t < arr.GetLength(1); t++)
            {
                for (int j = t; j < arr.GetLength(1); j++)
                {
                    if (arr[i, t] < arr[i, j])
                    {
                        int temp = arr[i, t];
                        arr[i, t] = arr[i, j];
                        arr[i, j] = temp;
                    }
                }
            }

        }
        static void SortMatrix(int[,] arr, ProccessRow f1, ProccessRow f2)
        {

            for (int i = 0; i < arr.GetLength(0); i += 2)
            {
                f1(arr, i);
            }

            for (int i = 1; i < arr.GetLength(0); i += 2)
            {
                f2(arr, i);
            }
        }
        static void lvl3_2()
        {
            int[,] a = new int[4, 4]
            {
                { 1, 11, 24, 16 },
                { 42, 15, 1, 72 },
                { 10, 92, 101, 11 },
                { 2, 8, 18, 54 }
            };
            PrintMatrix(a);
            SortMatrix(a, SortRowUp, SortRowDown);
            Console.WriteLine("new matrix");
            PrintMatrix(a);
        }
        static List<int> MakeListUp(int[,] arr)
        {
            List<int> a = new List<int>();
            for (int i = arr.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = arr.GetLength(0) - 1; j >= i; j--)
                {
                    a.Add(arr[i, j]);
                }
            }
            return a;
        }
        static List<int> MakeListDown(int[,] arr)
        {
            List<int> a = new List<int>();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    a.Add(arr[i, j]);
                }
            }
            return a;
        }
        delegate List<int> MakeListFromMatrix(int[,] arr);
        static int SummMatrix(int[,] arr, MakeListFromMatrix f1)
        {

            List<int> a = f1(arr);

            int sum = 0;
            foreach (int i in a)
            {
                sum += i * i;
            }
            return sum;
        }

        static void lvl3_4()
        {
            int[,] a = new int[3, 3]
            {
                { 2, 7, 1 },
                { 9, 4, 3 },
                { 1, 5, 11 },
            };
            PrintMatrix(a);
            Console.WriteLine(SummMatrix(a, MakeListDown));
        }
    }
}
       