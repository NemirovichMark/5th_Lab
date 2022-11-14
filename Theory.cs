using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace laba5
{
    internal class Program
    {
        static int factorial(int n)
        {
            int fact = 1;
            for (int i = 1; i <= n; i++)
            {
                fact *= i;
            }
            return fact;
        }
        static int var(int k,int nn)
        {
            return (factorial(nn) / (factorial(k) * factorial(nn - k)));
        }
        static double Strio(int a1,int b1,int c1)
        {
            int p=(a1+b1+c1)/2;
            if (a1 >= b1 + c1 || b1 >= c1 + a1 || c1 >= a1 + b1)
                Console.WriteLine(" Ваш треугольник не очень");
            return (Math.Pow(p * (p - a1) * (p - b1) * (p - c1), 0.5));
        }
        static int[] array(int[] S)
        {
            int index = 0, max = S[0];
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] > max)
                {
                    max = S[i];
                    index = i;
                }
            }
            int[] result = new int[S.Length-1];
            int index2 = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i]!=max)
                {
                    result[index2] = S[i];
                    index2++;
                }
            }
            return result;
        }
        static int[,] matrix(int[,] SS,int index1,int index2)
        {
            int[,] S1;
            if (index1 == index2)
            {
                S1 = new int[SS.GetLength(0), SS.GetLength(1) - 1];
            }
            else
            {
                S1 = new int[SS.GetLength(0), SS.GetLength(1) - 2];
            }

            for (int i = 0; i < SS.GetLength(0); i++)
            {
                int cntj = 0;
                for (int j = 0; j < SS.GetLength(1); j++)
                {
                    if (j != index1 && j != index2)
                    {
                        S1[i, cntj] = SS[i, j];
                        cntj += 1;
                    }
                }
            }

            return S1;
        }
        static int Int()
        {
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Nope, try again");
                return Int();

            }
            else if (a <= 0)
            {
                Console.WriteLine("Nope, try again");
                return Int();
            }
            return a;
        }
        static double[,] matrix2 (double[,] Sm)
        {
            double[] aa = new double[Sm.GetLength(0) * Sm.GetLength(1)];
            int schet = 0;
            for (int i = 0; i < Sm.GetLength(0); i++)
            {
                for (int j = 0; j < Sm.GetLength(1); j++)
                {
                    aa[schet] = Sm[i, j];
                    schet++;
                }
            }
            Array.Sort(aa);
            Array.Reverse(aa);
            for (int i = 0; i < Sm.GetLength(0); i++)
            {
                for (int j = 0; j < Sm.GetLength(1); j++)
                {
                    if (Sm[i, j] == aa[0] || Sm[i, j] == aa[1] || Sm[i, j] == aa[2] || Sm[i, j] == aa[3] || Sm[i, j] == aa[4])
                    {
                        Sm[i, j] *= 2;
                    }
                    else
                        Sm[i, j] /= 2;
                }
            }
            return Sm;
        }
        delegate double Member(int i, double x, int now);
        delegate int Down(int previ, int i);
        delegate double Y(double x);

        static int Down1(int previ, int i) => previ * i;
        static int Down2(int previ, int i) => previ * -1;

        static double Memb1(int i, double x, int now) => Math.Cos(i * x) / now;
        static double Memb2(int i, double x, int now) => (Math.Cos(i * x) * now) / (i * i);

        static double Y1(double x) => Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));
        static double Y2(double x) => (x * x - (Math.PI * Math.PI / 3)) / 4;
        static void Summ(Member memb, Down down, Y y, int first_numb, double a, double b, double h)
        {
            for (double x = a; x <= b; x += h)
            {
                int i = 1, now = 1;
                double sum = first_numb;

                while (Math.Abs(memb(i, x, now)) > 0.0001)
                {
                    now = down(now, i);
                    sum += memb(i, x, now);
                    i++;
                }
                Console.WriteLine(Math.Round(sum, 3) + " " + Math.Round(y(x), 3));
            }
        }
        static void Matrixx(double[,] matrix, int index, out double[] array)
        {
            array = new double[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                array[j] = matrix[index, j];
            }
        }
        delegate void Deleg(double[] array);
        static void up(double[] array)
        {
            Array.Sort(array);
        }
        static void down(double[] array)
        {
            Array.Sort(array);
            Array.Reverse(array);
        }
        static void Return(Deleg James, double[,] matrix, int index)
        {
            Matrixx(matrix, index, out double[] array);
            James(array);
            double[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                matrix[index, i] = array2[i];
            }
        }
        delegate int[] trio(int[,] FF);
        static int[] verh(int[,] FF)
        {
            int[] aram = new int[15];
            int count = 0;
            for (int i = 0; i < FF.GetLength(0); i++)
            {
                for (int j = 0; j < FF.GetLength(1); j++)
                {
                    if (i>=j)
                    {
                        aram[count]= FF[i,j]*FF[i,j];
                        count++;
                    }
                }
            }
            return aram;
        }
        static int[] niz(int[,] FF)
        {
            int[] aram = new int[15];
            int count = 0;
            for (int i = 0; i < FF.GetLength(0); i++)
            {
                for (int j = 0; j < FF.GetLength(1); j++)
                {
                    if (i <= j)
                    {
                        aram[count] = FF[i, j] * FF[i, j];
                        count++;
                    }
                }
            }
            return aram;
        }
        static double otday(int[,] FF,trio keks)
        {
            int summa = 0;
            int[] aram = keks(FF);
            for (int i = 0; i < aram.Length; i++)
            {
                summa += aram[i];
            }
            for (int i = 0; i < aram.Length; i++)
            {
                Console.Write($" {aram[i]}  ");
            }
            Console.WriteLine();
            return (Math.Pow(summa, 0.5));
        }


        static void Main(string[] args)
        {

            #region 1
            
            Console.WriteLine($"  {var(5, 8)}  ");
            Console.WriteLine($"  {var(5, 10)}  ");
            Console.WriteLine($"  {var(5, 11)}  ");
            Console.WriteLine("=========");
            
            #endregion


            #region 2
            
            Console.WriteLine("Введите а");
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Nope");
                return;
            }
            else if (a <= 0)
            {
                Console.WriteLine("Nope");
                return;
            }
            Console.WriteLine("Введите b");
            if (!int.TryParse(Console.ReadLine(), out int b))
            {
                Console.WriteLine("Nope");
                return;
            }
            else if (b <= 0)
            {
                Console.WriteLine("Nope");
                return;
            }
            Console.WriteLine("Введите с");
            if (!int.TryParse(Console.ReadLine(), out int c))
            {
                Console.WriteLine("Nope");
                return;
            }
            else if (c <= 0)
            {
                Console.WriteLine("Nope");
                return;
            }
             


            Console.WriteLine("Введите а1");
            if (!int.TryParse(Console.ReadLine(), out int a1))
            {
                Console.WriteLine("Nope");
                return;
            }
            else if (a1 <= 0)
            {
                Console.WriteLine("Nope");
                return;
            }
            Console.WriteLine("Введите b1");
            if (!int.TryParse(Console.ReadLine(), out int b1))
            {
                Console.WriteLine("Nope");
                return;
            }
            else if (b1 <= 0)
            {
                Console.WriteLine("Nope");
                return;
            }
            Console.WriteLine("Введите с1");
            if (!int.TryParse(Console.ReadLine(), out int c1))
            {
                Console.WriteLine("Nope");
                return;
            }
            else if (c1 <= 0)
            {
                Console.WriteLine("Nope");
                return;
            }
            if (Strio(a, b, c) > Strio(a1, b1, c))
                Console.WriteLine(Strio(a, b, c));
            else
                Console.WriteLine(Strio(a1, b1, c1));
            
            #endregion


            #region 3
            
            int[] a11 = new int[7] { 1, 2, 3, 4, 5, 6, 7 };
            int[] a2 = new int[8] { 10, 9, 8, 7, 6, 5, 4, 3 };
            int[] a12=array(a11);
            int[] a13=array(a2);
            int[] a3 = new int[a12.Length + a13.Length];
            for (int i = 0; i < a12.Length; i++)
            {
                a3[i] = a12[i];
            }
            for (int i = 0; i < a13.Length; i++)
            {
                a3[i+a12.Length] = a13[i];
            }
            foreach (var keks in a3)
                Console.Write($"  {keks}  ");
            Console.WriteLine();
            Console.WriteLine("=========");
            
            #endregion


            #region 4
            
            int[,] Sa = new int[5, 5]
            {
                {1, 2, 3, 4, 5},
                {5,7,8,9,10 },
                {0,-1,2,4,6 },
                {3,6,2,1,7 },
                {4,7,8,9,10 }
            };
            int maximus = Sa[0, 0];
            int indexj=0;
            int indexjj = 0;
            int minimus = 1000;
            for (int i = 0; i < Sa.GetLength(0); i++)
            {
                for (int j=0; j<Sa.GetLength(1); j++)
                {
                    if (i>=j)
                    {
                        if(Sa[i,j]>maximus)
                        {
                            maximus= Sa[i,j];
                            indexj = j;
                        }
                    }
                    if (i<j)
                    {
                        if (Sa[i,j]<minimus)
                        {
                            minimus= Sa[i,j];
                            indexjj = j;
                        }
                    }
                }
            }
            int[,] Sl = matrix(Sa, indexj,indexjj);
            for (int i = 0; i < Sl.GetLength(0); i++)
            {
                for (int j = 0; j < Sl.GetLength(1); j++)
                {
                    Console.Write(Sl[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            
            #endregion


            #region 5
            double[,] mSS = new double[5, 5]
            {
                { 3,  6, -2,  6, 12 },
                { -1, 5, 11, -9,  8 },
                { 6,  3, -1,  2,  8 },
                { 11,-10, 5,  2,  7 },
                { 2,  8, -9,  1,  4 }
            };
            double[,] mSS2 = new double[4, 4]
            {
                {3,  6, -2,  6},
                {-1, 5, 11, -9},
                {6,  3, -1,  2},
                {11,-10, 5,  2},
            };
            matrix2(mSS);
            for (int i = 0; i < mSS.GetLength(0); i++)
            {
                for (int j = 0; j < mSS.GetLength(1); j++)
                {
                    Console.Write(mSS[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            matrix2(mSS2);
            for (int i = 0; i < mSS2.GetLength(0); i++)
            {
                for (int j = 0; j < mSS2.GetLength(1); j++)
                {
                    Console.Write(mSS2[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            #endregion


            #region 6
            
            Summ(Memb1, Down1, Y1, 1, 0.1, 1, 0.1);
            Console.WriteLine();
            Summ(Memb2, Down2, Y2, 0, Math.PI / 5, Math.PI, Math.PI / 25);
            
            #endregion


            #region 7
            double[,] mmm = new double[5, 5]
           {
                { 3,  6, -2,  6, 12 },
                { -1, 5, 11, -9,  8 },
                { 6,  3, -1,  2,  8 },
                { 11,-10, 5,  2,  7 },
                { 2,  8, -9,  1,  4 }
           };
            for (int i = 0; i < mmm.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    Return(up, mmm, i);
                }
                else Return(down, mmm, i);
            }
            for (int i = 0; i < mmm.GetLength(0); i++)
            {
                for (int j = 0; j < mmm.GetLength(1); j++)
                {
                    Console.Write(mmm[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            #endregion


            #region 8
            int[,] mmm1 = new int[5, 5]
           {
                { 3,  6, -2,  6, 12 },
                { -1, 5, 11, -9,  8 },
                { 6,  3, -1,  2,  8 },
                { 11,-10, 5,  2,  7 },
                { 2,  8, -9,  1,  4 }
           };
            Console.WriteLine(otday(mmm1, verh));
            Console.WriteLine();
            Console.WriteLine(otday(mmm1, niz));
            #endregion
        }
    }
}
