using System;
using System.Data.Common;
using System.Drawing;

namespace _5th_Lab
{
    class Program
    {
        #region 5.1.1

        static int fact(int a)
        {

            int Fact = 1;
            for (int i = 1; i <= a; i++)
            {
                Fact = Fact * i;
            }
            return Fact;
        }
        static int Cab(int a, int b)
        {
            return fact(a) / (fact(b) * fact(a - b));
        }

        #endregion
        #region 5.1.2

        static double square(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return s;
        }

        #endregion
        #region 5.2.6
        static void delmax(double[] a, int len_a)
        {
            double amax = a[0];
            int imax = 0;
            for (int i = 0; i < len_a; i++)
            {
                if (a[i] > amax)
                {
                    amax = a[i];
                    imax = i;
                }
            }
            for (int i = imax; i < len_a - 1; i++)
            {
                a[i] = a[i + 1];
            }
        }
        #endregion
        #region 5.2.10
        static int indexmax(int[,] matrix)
        {
            int maxel = 0;
            int indexelm = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (matrix[i,j] > maxel)
                    {
                        maxel = matrix[i,j];
                        indexelm = j;
                    }
                }
                
            }
            return indexelm;
        }
        static int indexmin(int[,] matrix)
        {
            int minel = 10000000;
            int indexminel = 0;
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = i+1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] < minel)
                    {
                        indexminel = j;
                        minel = matrix[i,j];
                    }
                }
                
            }
            return indexminel;

        }
        static void delcolm(int[,] matrix)
		{
            int z = indexmax(matrix);
            int h = indexmin(matrix);
			if (z == h)
			{
				int s = indexmax(matrix);
				for (int y = 0; y < matrix.GetLength(0); y++)
				{	
					for (int x = s; x < matrix.GetLength(1)-1; x++)
					{
						matrix[y,x] = matrix[y,x+1];

					}
				}
			}
			else
			{
				int s = indexmax(matrix);
				for (int y = 0; y < matrix.GetLength(0); y++)
				{	
					for (int x = s; x < matrix.GetLength(1)-1; x++)
					{
						matrix[y,x] = matrix[y,x+1];

					}
				}

				int d = indexmin(matrix);
				for (int y = 0; y < matrix.GetLength(0); y++)
				{	
					for (int x = d; x < matrix.GetLength(1)-1; x++)
					{
						matrix[y,x] = matrix[y,x+1];

					}
				}


			}

		}

        #endregion
        #region 5.2.23
		static int maxel(int[,] matrix)
		{
			int max = 0;
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (Math.Abs(matrix[i,j]) > max)
					{
						max = Math.Abs(matrix[i,j]);
					}
				}
			}
			return max;
		}
		static void xr(int[,] matrix, int maxl)
		{
			maxl = maxel(matrix);
			int c = 0;
            int f = 0;
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (Math.Abs(matrix[i,j]) == maxl)
					{
						if (c < 5)
						{ 
							matrix[i,j] *= 2;
							
						}
						c++;
						if (c > 5 && f < 5)
						{
                            f++;
							matrix[i,j] /= 2;
						}

					}
					else if (matrix[i,j] < maxl && f < 5)
					{
                        f++;
						matrix[i,j] /= 2;
					}
				}
			}
		}
		#endregion
        #region 5.3.1
        static int factorial(int i)
        {
            int a = 1;
            for (int j = 1; j <= i; j++)
            {
                a = a * j;
            }
            return a;
        }
        delegate double fx(double x, int i);
        static double f1(double x, int i)
        {
            double chs1;
            return chs1 = Math.Cos(i * x) / factorial(i);
        }
        static double f2(double x, int i)
        {
            double chs2;
            return chs2 = Math.Pow(-1, i) * Math.Cos(i * x) / i * i;
        }
        static double Sum(fx f, double a, double b, double h)
        {
            double s = 0;
            int i = 1;
            for (double x = a; x <= b; x = x + h)
            {
                s = s + f(x, i);
                i++;
            }
            return s;
        }
        #endregion
        #region 5.3.3
        static double average(double[] a)
        {
            double av = 0;
            for (int i = 0; i < a.Length; i++)
            {
                av = av + a[i] / a.Length;
            }
            return av;
        }
        delegate void Switch(double[] a);
        static void sw1(double[] a)
        {
            double p;
            for (int i = 0; i < a.Length - 1; i = i + 2)
            {
                p = a[i];
                a[i] = a[i + 1];
                a[i + 1] = p;
            }
        }
        static void sw2(double[] a)
        {
            double p;
            for (int i = a.Length - 1; i > 0; i = i - 2)
            {
                p = a[i];
                a[i] = a[i - 1];
                a[i - 1] = p;
            }
        }
        static double sum(Switch sw, double[] a)
        {
            double S = 0;
            sw(a);
            for (int i = 1; i < a.Length; i = i + 2)
            {
                S = S + a[i];
            }
            return S;
        }
        #endregion


        #region Main
        static void Main(string[] args)
        {
            #region 5.1.1 Main

            int n1 = 8, n2 = 10, n3 = 11, k = 5;
            Console.WriteLine(Cab(n1, k));
            Console.WriteLine(Cab(n2, k));
            Console.WriteLine(Cab(n3, k));
            Console.WriteLine();
            #endregion
            #region 5.1.2 Main
            Console.WriteLine("Введите количество треугольников");
            int n;
            int.TryParse(Console.ReadLine(), out n);
            double[] tr = new double[n];
            int cd = 0;
            while (cd < n)
            {

                double a1, b1, c1;
                Console.WriteLine($"Введите стороны {cd} треугольник");
                double.TryParse(Console.ReadLine(), out a1);
                double.TryParse(Console.ReadLine(), out b1);
                double.TryParse(Console.ReadLine(), out c1);
                if (a1 <= 0 || b1 <= 0 || c1 <= 0)
                {
                    Console.WriteLine("Все стороны должы быть больше 0");
                    continue;
                    
                }
                else if (a1 + b1 > c1 && a1 + c1 > b1 && b1 + c1 > a1)
                {
                    Console.WriteLine($"Площадь {cd} треугольника: {square(a1, b1, c1)}");
                    tr[cd] = square(a1,b1,c1);
                }
                else
                {
                    Console.WriteLine("Такой треугольник не существует");
                }
                cd++;

                

            }
            double max = 0;
            int indextr = 0;
            for (int i = 0; i < tr.Length; i++)
            {
                if (tr[i] > max)
                {
                    max = tr[i];
                    indextr = i;
                }
            }
            Console.WriteLine($"Наибольшая площадь треугольника у {indextr}: {max} ");
            Console.ReadLine();
            #endregion
            #region 5.2.6 Main
            int j_q = 0;
            int Alen = 3;
            int Blen = 6;
            double[] A = new double[Alen + Blen - 2];
            double[] B = new double[Blen];
            Console.WriteLine($"введите элементы массива A");
            for (int i = 0; i < Alen; i++)
            {
                double.TryParse(Console.ReadLine(), out A[i]);
            }
            Console.WriteLine($"введите элементы массива B");
            for (int i = 0; i < Blen; i++)
            {
                double.TryParse(Console.ReadLine(), out B[i]);
            }
            Console.WriteLine("массив A:");
            for (int i = 0; i < Alen; i++)
            {
                Console.Write($"{A[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine("массив B:");
            for (int i = 0; i < Blen; i++)
            {
                Console.Write($"{B[i]} ");
            }
            Console.WriteLine();
            delmax(A, Alen);
            delmax(B, Blen);
            for (int i = 3 - 1; i < A.Length; i++)
            {
                A[i] = B[j_q];
                j_q++;
            }
            Console.WriteLine("итог:");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"{A[i]} ");
            }
            Console.WriteLine();




            #endregion
            #region 5.2.10 Main
        static void Main(string[] args)
        {
            int[,] matrix = new int[,]
            {
                {8,1,0,7},
                {1,6,8,4},
                {9,0,2,6},
                {6,5,4,7}
            };
            int a = indexmax(matrix);
            int b = indexmin(matrix);
            if (a == b)
			{ 
				delcolm(matrix);
				for (int y = 0; y < matrix.GetLength(0); y++)
				{
					for (int x = 0; x < matrix.GetLength(1)-1; x++)
					{
						Console.Write(matrix[y,x] + " ");
					}
					Console.WriteLine();
				}
			}
			else 
			{
				delcolm(matrix);
				for (int y = 0; y < matrix.GetLength(0); y++)
				{
					for (int x = 0; x < matrix.GetLength(1)-2; x++)
					{
						Console.Write(matrix[y,x] + " ");
					}
					Console.WriteLine();
				}

			}
            
            
           Console.ReadLine();        
        }   
        #endregion
            #region 5.2.23 Main
			int[,] matrix = new int[,]
			{
				{-2,-2,-6},
				{-6,-6,-2},
				{-6,-2,-2}
			};
			int[,] matrix2 = new int[,]
			{
				{10,-2,10},
				{10,10,-2},
				{-2,-2,10}
			};
			int elmax = maxel(matrix);
			xr(matrix,elmax);
			xr(matrix2,elmax);
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					Console.Write(matrix[i,j] + " ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
			for (int i = 0; i < matrix2.GetLength(0); i++)
			{
				for (int j = 0; j < matrix2.GetLength(1); j++)
				{
					Console.Write(matrix2[i,j] + " ");
				}
				Console.WriteLine();
			}
			Console.ReadLine();
			
			#endregion
            #region 5.3.1 Main


            const double pi = Math.PI;
            double aa1 = 0.1, bb1 = 1, hh1 = 0.1, aa2 = pi / 5, bb2 = pi, hh2 = pi / 25;
            Console.WriteLine("Summ 1: ");
            Console.WriteLine($"{1 + Sum(f1, aa1, bb1, hh1)}");
            Console.WriteLine("Summ 2: ");
            Console.WriteLine($"{Sum(f2, aa2, bb2, hh2)}");



            #endregion
            #region 5.3.3 Main

            const int n_r = 9;
            double[] F = new double[n_r] { 10, 5, 8, 9, 7, 6, 2, 3, 4 };
            Console.WriteLine("array F:");
            for (int i = 0; i < n_r; i++)
            {
                Console.Write($"{F[i]} ");
            }
            Console.WriteLine();
            double l_r, sw_r = 0;
            l_r = average(F);
            Console.WriteLine($"average = {l_r}");
            if (F[0] > l_r)
            {
                sw_r = sum(sw1, F);
            }
            else
            {
                sw_r = sum(sw2, F);
            }
            Console.WriteLine("new array:");
            for (int i = 0; i < n_r; i++)
            {
                Console.Write($"{F[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine($"the sum = {sw_r}");

            #endregion
        }

        #endregion

    }
}
