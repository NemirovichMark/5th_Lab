using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http.Headers;

namespace _5th_Lab
{
    public class Class_Of_Usefull_Methods
    {
        static bool Checking_For_Double(string message)
        {
            bool Key = true;
            try
            {
                double v = Convert.ToDouble(message);
            }
            catch
            {
                Key = false;
            }
            return Key;
        }
        static public double Getting_Double_From_User()
        {
            double result = 0;
            while (true)
            {
                string message = Console.ReadLine();
                if (Checking_For_Double(message)) { 
                    result = Convert.ToDouble(message); 
                    return result; 
                }
            else Console.WriteLine("Mistake!");
            }
        }
        static bool Checking_For_Int(string message)
        {
            bool Key = true;
            try
            {
                double v = Convert.ToInt32(message);
            }
            catch
            {
                Key = false;
            }
            return Key;
        }
        static public int Getting_Int_From_User()
        {
            int result = 0;
            while (true)
            {
                string message = Console.ReadLine();
                if (Checking_For_Double(message))
                {
                    result = Convert.ToInt32(message);
                    return result;
                }
                else Console.WriteLine("Mistake!");
            }
        }
        public static void Printing_Array(int[] array) { 
            
            for (int i = 0; i < array.Length; i++) Console.Write($"{array[i]} "); 
            Console.WriteLine(); 
        }
        public static void Printing_Matrix(int[,] array) { 
            for (int i = 0; i < array.GetLength(0); i++) { 
                for (int x = 0; x < array.GetLength(1); x++) Console.Write($"{array[i, x]} "); 
                Console.WriteLine(); 
            } 
        }
        public static void Printing_Array(double[] array) { 
            for (int i = 0; i < array.Length; i++) Console.Write($"{array[i]} "); 
            Console.WriteLine(); }
        public static void Printing_Matrix(double[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int x = 0; x < array.GetLength(1); x++) Console.Write($"{array[i, x]} ");
                Console.WriteLine();
            }
        }
    }
    public class Task_1_Level_1 : Class_Of_Usefull_Methods
    {
        static int Getting_Factorial(int Num)
        {
            int Result = 1;
            for (int i = 1; i <= Num; i++) Result *= i;
            return Result;
        }
        static int Counting_Ways(int Amount_Of_Group, int Amount_Of_All)
        {
            int Ways = Getting_Factorial(Amount_Of_All) / (Getting_Factorial(Amount_Of_Group) * Getting_Factorial(Amount_Of_All - Amount_Of_Group)); ;
            return Ways;
        }
        public void Cycling_Task()
        {
            int Amount_From_Task = 5;
            int[] Variables_From_Task = { 8, 10, 11 };
            foreach (var arg in Variables_From_Task)
            {
                Console.WriteLine($"Amount of ways for group of {Amount_From_Task} people from {arg} at all is {Counting_Ways(Amount_From_Task, arg)}");
            }
        }
    }
    public class Task_2_Level_1 : Class_Of_Usefull_Methods
    {
        static double[] Taking_Arguments()
        {
            double[] Arr = new double[3];
            for (int i = 0; i < 3; i++) {
                do
                {
                    Arr[i] = Getting_Double_From_User();
                    if (Arr[i] <= 0) Console.WriteLine("Please, enter right params!");
                } while (Arr[i] <= 0);
             };
            return Arr;
        }
        static double Getting_Square(double[] arr)
        {
            double p = (arr[0] + arr[1] + arr[2]) / 2;
            double Square = Math.Sqrt(p * (p - arr[0]) * (p - arr[1]) * (p - arr[2]));
            return Square;
        }
        public void Cycling_Task()
        {
            Console.WriteLine("Enter params of triangles one by one!");
            double Square_1 = Getting_Square(Taking_Arguments());
            double Square_2 = Getting_Square(Taking_Arguments());
            if (Square_1 > Square_2) Console.WriteLine("First Square is bigger!");
            else if (Square_1 < Square_2) Console.WriteLine("Second Square is bigger!");
            else Console.WriteLine("They have similar squares!");
        }
    }
    public class Task_6_Level_2 : Class_Of_Usefull_Methods
    {
        static int Finding_Index_Max_In_Array(double[] arr)
        {
            double maxi = arr[0];
            int index = 0;
            for (int i = 1; i < arr.Length; i++) if (maxi < arr[i]) { maxi = arr[i]; index = i; }
            return index;
        }
        static double[] Deleting_Elem_In_Array(double[] arr_1, int index)
        {
            double[] arr_2 = new double[arr_1.Length - 1];
            for (int i = 0; i < arr_1.Length; i++)
            {
                if (i < index) arr_2[i] = arr_1[i];
                else if (i > index) arr_2[i - 1] = arr_1[i];
            }
            return arr_2;
        }

        static double[] Creating_Array_From_Two(double[] arr_1, double[] arr_2)
        {
            double[] final_array = new double[arr_1.Length + arr_2.Length];
            int point = 0;
            while (true)
            {
                if (point == arr_1.Length + arr_2.Length) break;
                else if (point < arr_1.Length) final_array[point] = arr_1[point];
                else final_array[point] = arr_2[point - arr_1.Length];
                point++;
            }
            return final_array;
        }
        public void Cycling_Task()
        {
            Console.WriteLine("Enter length of two arrays one by one. Then enter all elements of arrays one by one");
            double[] arr_1 = new double[Getting_Int_From_User()];

            

            double[] arr_2 = new double[Getting_Int_From_User()];

            for (int i = 0; i < arr_1.Length; i++) arr_1[i] = Getting_Double_From_User();
            for (int i = 0; i < arr_2.Length; i++) arr_2[i] = Getting_Double_From_User();

            int Maxi_Index_First = Finding_Index_Max_In_Array(arr_1);
            int Maxi_Index_Second = Finding_Index_Max_In_Array(arr_2);

            double[] final_arr_1 = Deleting_Elem_In_Array(arr_1, Maxi_Index_First);
            double[] final_arr_2 = Deleting_Elem_In_Array(arr_2, Maxi_Index_Second);

            double[] final_arr = Creating_Array_From_Two(final_arr_1, final_arr_2);

            Printing_Array(final_arr);
        }
    }
    public class Task_10_Level_2 : Class_Of_Usefull_Methods
    {
        static int Finding_Maxi(double[,] matrix)
        {
            int point = 1;
            int Maxi_Ind = 0;
            double Maxi = matrix[0, 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int x = 0; x < point; x++)
                {
                    if (matrix[i, x] > Maxi) { Maxi = matrix[i, x]; Maxi_Ind = x; }
                }
                point++;
            }
            return Maxi_Ind;
        }
        static int Finding_Mini(double[,] matrix)
        {
            int point = 1;
            int Mini_Ind = 1;
            double Mini = matrix[0, 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int x = point; x < matrix.GetLength(0); x++)
                {
                    if (matrix[i, x] < Mini) { Mini = matrix[i, x]; Mini_Ind = x; }
                }
                point++;
            }
            return Mini_Ind;
        }
        static double[,] Clearing_Matrix(double[,] matrix, int pos_maxi, int pos_mini)
        {
            if(pos_maxi!=pos_mini){
                double[,] Final_Matrix = new double[matrix.GetLength(0), matrix.GetLength(1) - 2];

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int pointer = 0;
                    for (int x = 0; x < matrix.GetLength(1); x++)
                    {
                        if ((x == pos_mini) || (x == pos_maxi)) { pointer++; continue; }
                        Final_Matrix[i, x - pointer] = matrix[i, x];
                    }
                }
                return Final_Matrix;
            }
            else
            {
                double[,] Final_Matrix = new double[matrix.GetLength(0), matrix.GetLength(1) - 1];

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int pointer = 0;
                    for (int x = 0; x < matrix.GetLength(1); x++)
                    {
                        if (x == pos_mini) { pointer++; continue; }
                        Final_Matrix[i, x - pointer] = matrix[i, x];
                    }
                }
                return Final_Matrix;
            }
        }
        public void Cycling_Task()
        {
            double[,] Matrix =
            {
                {20, 20, 20, 20, 20 },
                {20, 20, 20, 20, 0 },
                {20, 2220, 20, 20, 20},
                {20, 20, 20, 20, 20},
                {20, 20, 20, 20, 220},
            };

            int Maxi_Pos = Finding_Maxi(Matrix);
            int Mini_Pos = Finding_Mini(Matrix);
            Console.WriteLine(Mini_Pos);
            Console.WriteLine(Maxi_Pos);
            Printing_Matrix(Clearing_Matrix(Matrix, Maxi_Pos, Mini_Pos));
        }
    }
    public class Task_23_Level_2 : Class_Of_Usefull_Methods
    {
        public static void Printing_Array(double[] array)
        {
            for (int i = 0; i < array.Length; i++) Console.Write($"{array[i]} ");
            Console.WriteLine();
        }
        public static void Printing_Matrix(double[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int x = 0; x < array.GetLength(1); x++) Console.Write($"{array[i, x]} ");
                Console.WriteLine();
            }
        }

        static bool Checking_Presence_Of_Point(int[] Point, int[,] Indexes)
        {
            bool key = false;
            for (int i = 0; i < Indexes.GetLength(0); i++) if ((Indexes[i, 0] == Point[0]) && (Indexes[i, 1] == Point[1])) { key = true; break; }
            return key;
        }

        static bool Checking_Presence_In_List(int i, int x, List<List<int>> indexes)
        {
            bool key = false;
            for (int z = 0; z < indexes.Count(); z++)
            {
                if ((indexes[z][0] == i) && (indexes[z][1] == x)) { key = true; break; }
            }
            return key;
        }

        static double[,] Reconstructing_Matrix(double[,] Matrix, int[,] Indexes)
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int x = 0; x < Matrix.GetLength(1); x++)
                {
                    int[] Point = { i, x };
                    if (Checking_Presence_Of_Point(Point, Indexes))
                    {
                        if (Matrix[i, x] > 0) Matrix[i, x] *= 2;
                        else Matrix[i, x] /= 2;
                    }
                    else
                    {
                        if (Matrix[i, x] > 0) Matrix[i, x] *= 2;
                        else Matrix[i, x] /= 2;
                    }
                }
            }
            return Matrix;
        }

        static bool Matrix_Checking(double[,] matrix)
        {
            if (matrix.GetLength(0) * matrix.GetLength(1) < 5) return true;
            else return false;
        }

        static int[,] Getting_Indexes_Of_Maxis(double[,] Matrix)
        {
            List<List<int>> indexes = new List<List<int>>();
            for (int i = 0; i < 5; i++) indexes.Add(Finding_Another_Maxi(Matrix, indexes));
            int[,] Indexes = Rebuilding_List_Into_Array(indexes);
            return Indexes;
        }

        static List<int> Finding_Another_Maxi(double[,] Matrix, List<List<int>> indexes)
        {
            double Maxi = Matrix[0, 0];
            List<int> Maxi_Indexes = new List<int>();
            Maxi_Indexes.Add(0);
            Maxi_Indexes.Add(0);

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int x = 0; x < Matrix.GetLength(1); x++)
                {
                    if (Checking_Presence_In_List(i, x, indexes)) continue;
                    if (Matrix[i, x] > Maxi) { Maxi = Matrix[i, x]; Maxi_Indexes.Clear(); Maxi_Indexes.Add(i); Maxi_Indexes.Add(x); }
                }
            }

            return Maxi_Indexes;
        }

        static int[,] Rebuilding_List_Into_Array(List<List<int>> indexes)
        {
            int[,] Indexes = new int[indexes.Count(), 2];

            for (int i = 0; i < indexes.Count(); i++)
            {

                Indexes[i, 0] = indexes[i][0];
                Indexes[i, 1] = indexes[i][1];
            }
            return Indexes;
        }
        static void Main_Process_With_Matrix(double[,] Matrix)
        {
            int[,] Indexes = Getting_Indexes_Of_Maxis(Matrix);
            Printing_Matrix(Reconstructing_Matrix(Matrix, Indexes));
        }
        public void Cycling_Task()
        {
            double[,] Matrix_1 =
            {
        {1, 2, 3, 4, 5 },
        {-32, -32, -90, -4, -2 },
        };
            if (Matrix_Checking(Matrix_1)) Console.WriteLine("Not enough elements in matrix!");
            if (Matrix_Checking(Matrix_1))
            {
                for (int i = 0; i < Matrix_1.GetLength(0); i++)
                {
                    for (int x = 0; x < Matrix_1.GetLength(1); x++)
                    {
                        Matrix_1[i, x] *= 2;
                    }
                }
            }
            else Main_Process_With_Matrix(Matrix_1);
        }
    }



    public class Task_2_Level_3 : Class_Of_Usefull_Methods
    {
        delegate double[] Del(double[] array);
        public double[] Sorting_Array_Up(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        double temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
        public double[] Sorting_Array_Down(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] < array[j])
                    {
                        double temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
        public double[,] Cycling_Rows_From_Matrix(double[,] matrix)
        {

            double[] array = new double[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Del method;
                if (i % 2 == 0) method = Sorting_Array_Down;
                else method = Sorting_Array_Up;
                for (int x = 0; x < matrix.GetLength(1); x++) array[x] = matrix[i, x];


                double[] sorted_array = method(array);


                for (int x = 0; x < matrix.GetLength(1); x++) matrix[i, x] = sorted_array[x];
            }
            return matrix;
        }
        public void Cycling_Task()
        {
            double[,] Matrix =
            {
                {0, -20, 10, 30, 90 },
                {-20, -40, 80, 20, 0 },
                {-220, -20, 150, 0, 10},
                {200, 10, 20, 0, 40},
                {20, 30, 20, -40, 60 },
                };

            double[,] Final_Matrix = Cycling_Rows_From_Matrix(Matrix);

            Printing_Matrix(Final_Matrix);
        }
    }
    public class Task_4_Level_3 : Class_Of_Usefull_Methods
    {
        delegate double[] Del(double[,] matrix);
        
        public double[] Taking_Down_Triangle(double[,] matrix)
        {
            int len = 0;
            for (int i = 0; i <= matrix.GetLength(0); i++) len += i;
            double[] array = new double[len];

            int point = 0;
            int limit = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int x = 0; x <= limit; x++)
                {
                    array[point] = matrix[i, x];
                    point++;
                }
                limit++;
            }
            return array;
        }
        public double[] Taking_Upper_Triangle(double[,] matrix)
        {
            int len = 0;
            for (int i = 0; i <= matrix.GetLength(0); i++) len += i;
            double[] array = new double[len];

            int point = 0;
            int limit = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int x = limit; x < matrix.GetLength(0); x++)
                {
                    array[point] = matrix[i, x];
                    point++;
                }
                limit++;
            }
            return array;
        }
        public double Summing(double[] vector)
        {
            double sum = 0;
            for (int i = 0; i < vector.Length; i++) sum += vector[i] * vector[i];
            return sum;
        }
        public bool Making_Decision()
        {
            Random gen = new Random();
            int prob = gen.Next(100);
            return prob > 50;
        }
        public void Cycling_Task()
        {
            Del method;
            double[,] matrix = {
                {0, -20, 10, 30, 90 },
                {-20, -40, 80, 20, 0 },
                {-220, -20, 150, 0, 10},
                {200, 10, 20, 0, 40},
                {20, 90, 20, -40, 60 },
                };

            if (Making_Decision()) method = Taking_Upper_Triangle;
            else method = Taking_Down_Triangle;
            double[] array = method(matrix);
            Printing_Array(array);
            Console.WriteLine(Summing(method(matrix)));
        }
    }


















    public class Programm
    {
        static void Main(string[] args)
        {

            Task_1_Level_1 Task_1 = new Task_1_Level_1();
            Task_1.Cycling_Task();
            Console.WriteLine();

            Task_2_Level_1 Task_2 = new Task_2_Level_1();
            Task_2.Cycling_Task();
            Console.WriteLine();

            Task_6_Level_2 Task_3 = new Task_6_Level_2();
            Task_3.Cycling_Task();
            Console.WriteLine();


            Task_10_Level_2 Task_4 = new Task_10_Level_2();
            Task_4.Cycling_Task();
            Console.WriteLine();

            Task_23_Level_2 Task_5 = new Task_23_Level_2();
            Task_5.Cycling_Task();
            Console.WriteLine();

            Task_2_Level_3 Task_6 = new Task_2_Level_3();
            Task_6.Cycling_Task();
            Console.WriteLine();

            Task_4_Level_3 Task_7 = new Task_4_Level_3();
            Task_7.Cycling_Task();
            Console.WriteLine();

            
        }
    }
}
