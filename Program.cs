using System;

namespace ConsoleApp1
{
    class Program
    {
        static void ParseError()
        {
            Console.WriteLine("Input error");
            Environment.Exit(0);
        }

        static List<int> InputList()
        {
            var input = Console.ReadLine().Split();
            var n = input.Length;
            var a = new List<int>(n);
            foreach (var s in input)
            {
                if (!int.TryParse(s, out var elem))
                {
                    ParseError();
                }

                a.Add(elem);
            }

            return a;
        }

        static List<List<int>> InputMatrix()
        {
            var a = new List<List<int>>();
            var input = Console.ReadLine().Split();
            var m = input.Length;
            while (input[0] != "")
            {
                var temp = new List<int>(m);
                foreach (var s in input)
                {
                    if (!int.TryParse(s, out var elem))
                    {
                        ParseError();
                    }

                    temp.Add(elem);
                }

                a.Add(temp);
                input = Console.ReadLine().Split();
            }

            return a;
        }

        static List<List<double>> InputMatrixDouble()
        {
            var a = new List<List<double>>();
            var input = Console.ReadLine().Split();
            var m = input.Length;
            while (input[0] != "")
            {
                var temp = new List<double>(m);
                foreach (var s in input)
                {
                    if (!double.TryParse(s, out var elem))
                    {
                        ParseError();
                    }

                    temp.Add(elem);
                }

                a.Add(temp);
                input = Console.ReadLine().Split();
            }

            return a;
        }

        static void PrintList(List<int> a)
        {
            foreach (var elem in a)
            {
                Console.Write(elem + "\t");
            }

            Console.WriteLine();
        }

        static void PrintMatrix(List<List<int>> a)
        {
            foreach (var row in a)
            {
                foreach (var elem in row)
                {
                    Console.Write(elem + "\t");
                }

                Console.WriteLine();
            }
        }

        static void PrintMatrixDouble(List<List<double>> a)
        {
            foreach (var row in a)
            {
                foreach (var elem in row)
                {
                    Console.Write(elem + "\t");
                }

                Console.WriteLine();
            }
        }

        static int Factorial(int n)
        {
            var f = 1;
            for (var i = 2; i <= n; i++)
            {
                f *= i;
            }

            return f;
        }

        static double Permutations(int n, int k)
        {
            if (n <= 0 || k <= 0) ParseError();
            var c = Factorial(n) / Factorial(k) / Factorial(n - k);
            return c;
        }

        static double TriangleArea(int a, int b, int c)
        {
            var p = (a + b + c) / 2.0;
            var s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return s;
        }

        static bool IsTriangleExists(int a, int b, int c)
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                return true;
            }

            return false;
        }

        static void DeleteElementByIndex(List<int> a, int index)
        {
            var n = a.Count - 1;
            for (var i = index; i < n; i++)
            {
                (a[i], a[i + 1]) = (a[i + 1], a[i]);
            }

            a.RemoveAt(n);
        }

        static void DeleteColByIndex(List<List<int>> a, int index)
        {
            foreach (var row in a)
            {
                DeleteElementByIndex(row, index);
            }
        }

        static int MaxOfArrayIndex(List<int> a)
        {
            var max = 0;
            var maxIndex = -1;
            for (var i = 0; i < a.Count; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        static double[] MinOfMatrixIndex(List<List<double>> a)
        {
            var min = 0.0;
            var minIndexI = 0;
            var minIndexJ = 0;
            for (var i = 0; i < a.Count; i++)
            {
                for (var j = 0; j < a[i].Count; j++)
                {
                    if (a[i][j] < min)
                    {
                        min = a[i][j];
                        minIndexI = i;
                        minIndexJ = j;
                    }
                }
            }

            return new double[3] { min, minIndexI, minIndexJ };
        }

        static void MaxOfAllTime(List<List<double>> a)
        {
            var n = a.Count;
            var m = a[0].Count;
            var boolList = new List<int[]>(n);
            for (var i = 0; i < n; i++)
            {
                boolList.Add(new int[m]);
            }

            for (var k = 0; k < 5; k++)
            {
                var funcOut = MinOfMatrixIndex(a);
                var max = funcOut[0];
                var maxIndexI = (int)funcOut[1];
                var maxIndexJ = (int)funcOut[2];
                for (var i = 0; i < n; i++)
                {
                    for (var j = 0; j < m; j++)
                    {
                        if (a[i][j] > max && boolList[i][j] == 0)
                        {
                            max = a[i][j];
                            maxIndexI = i;
                            maxIndexJ = j;
                        }
                    }
                }

                if (a[maxIndexI][maxIndexJ] > 0)
                {
                    a[maxIndexI][maxIndexJ] *= 2;
                }
                else
                {
                    a[maxIndexI][maxIndexJ] = Math.Round(a[maxIndexI][maxIndexJ] / 2, 2);
                }

                boolList[maxIndexI][maxIndexJ] = 1;
            }

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    if (boolList[i][j] == 0)
                    {
                        if (a[i][j] > 0)
                        {
                            a[i][j] = Math.Round(a[i][j] / 2, 2);
                        }
                        else
                        {
                            a[i][j] *= 2;
                        }
                    }
                }
            }
        }

        delegate void ListSort(List<int> a);

        static void ByDecreasing(List<int> a)
        {
            var element = 1;
            var pointer = 2;
            while (element < a.Count)
            {
                if (element == 0 || a[element] < a[element - 1])
                {
                    element = pointer;
                    pointer++;
                }
                else
                {
                    (a[element], a[element - 1]) = (a[element - 1], a[element]);
                    element--;
                }
            }
        }

        static void ByIncreasing(List<int> a)
        {
            var element = 1;
            var pointer = 2;
            while (element < a.Count)
            {
                if (element == 0 || a[element] > a[element - 1])
                {
                    element = pointer;
                    pointer++;
                }
                else
                {
                    (a[element], a[element - 1]) = (a[element - 1], a[element]);
                    element--;
                }
            }
        }

        static void SortByRows(List<List<int>> a)
        {
            ListSort del;
            for (var i = 0; i < a.Count; i++)
            {
                if (i % 2 == 0)
                {
                    del = ByDecreasing;
                }
                else
                {
                    del = ByIncreasing;
                }

                del.Invoke(a[i]);
            }
        }

        delegate int FindMax(List<List<int>> a);

        static int InFirstLine(List<List<int>> a)
        {
            var max = 0;
            var maxIndex = -1;
            for (var i = 0; i < a[0].Count; i++)
            {
                if (a[0][i] > max)
                {
                    max = a[0][i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        static int InDiagonal(List<List<int>> a)
        {
            var max = 0;
            var maxIndex = 0;
            for (var i = 0; i < a.Count; i++)
            {
                if (a[i][i] > max)
                {
                    max = a[i][i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        static void SwitchColsByIndex(List<List<int>> a, int col1, int col2)
        {
            foreach (var row in a)
            {
                (row[col1], row[col2]) = (row[col2], row[col1]);
            }
        }

        public static void Main(string[] args)
        {
            #region lvl1_task1

            Console.Write("Enter K: ");
            if (!int.TryParse(Console.ReadLine(), out var k))
            {
                ParseError();
            }

            Console.Write("Enter N: ");
            if (!int.TryParse(Console.ReadLine(), out var n))
            {
                ParseError();
            }

            Console.Write("Permutations count: " + Permutations(n, k));

            #endregion


            #region lvl1_task2

            Console.Write("Input triangle (A) ([a] [b] [c]): ");
            var input = Console.ReadLine().Split();
            if (input.Length != 3)
            {
                ParseError();
            }

            if (!int.TryParse(input[0], out var a) || a < 0)
            {
                ParseError();
            }

            if (!int.TryParse(input[1], out var b) || b < 0)
            {
                ParseError();
            }

            if (!int.TryParse(input[2], out var c) || c < 0)
            {
                ParseError();
            }

            double s1, s2;
            if (IsTriangleExists(a, b, c))
            {
                s1 = TriangleArea(a, b, c);
            }
            else
            {
                Console.WriteLine("Triangle not exists");
                return;
            }

            Console.Write("Input triangle (B) ([a] [b] [c]): ");
            input = Console.ReadLine().Split();
            if (!int.TryParse(input[0], out a) || a < 0)
            {
                ParseError();
            }

            if (!int.TryParse(input[1], out b) || b < 0)
            {
                ParseError();
            }

            if (!int.TryParse(input[2], out c) || c < 0)
            {
                ParseError();
            }

            if (IsTriangleExists(a, b, c))
            {
                s2 = TriangleArea(a, b, c);
            }
            else
            {
                Console.WriteLine("Triangle not exists");
                return;
            }

            if (s1 > s2)
            {
                Console.WriteLine($"The first triangle has a large area. {Math.Round(s1, 3)}");
            }
            else if (s1 < s2)
            {
                Console.WriteLine($"The second triangle has a large area. {Math.Round(s2, 3)}");
            }
            else
            {
                Console.WriteLine($"The areas of the triangles are the same. {Math.Round(s1, 3)}");
            }

            #endregion

            #region lvl2_task6

            Console.WriteLine("Input array (A):");
            var arrA = InputList();
            var maxA = MaxOfArrayIndex(arrA);
            Console.WriteLine("Input array (B):");
            var arrB = InputList();
            var maxB = MaxOfArrayIndex(arrB);
            DeleteElementByIndex(arrA, maxA);
            DeleteElementByIndex(arrB, maxB);
            arrA.InsertRange(arrA.Count, arrB);
            Console.WriteLine("Output array: ");
            PrintList(arrA);

            #endregion


            #region lvl2_task10

            Console.WriteLine("Input matrix:");
            var arr = InputMatrix();
            var max = 0;
            var maxIndex = -1;
            var min = arr[0][1];
            var minIndex = 1;
            for (var i = 0; i < arr.Count; i++)
            {
                for (var j = 0; j <= i; j++)
                {
                    if (arr[i][j] > max)
                    {
                        max = arr[i][j];
                        maxIndex = j;
                    }
                }
            }

            for (var i = 0; i < arr.Count; i++)
            {
                for (var j = i + 1; j < arr[i].Count; j++)
                {
                    if (arr[i][j] < min)
                    {
                        min = arr[i][j];
                        minIndex = j;
                    }
                }
            }

            DeleteColByIndex(arr, maxIndex);
            if (maxIndex != minIndex)
            {
                if (minIndex > maxIndex)
                {
                    minIndex--;
                }

                DeleteColByIndex(arr, minIndex);
            }

            Console.WriteLine("Output matrix:");
            PrintMatrix(arr);

            #endregion


            #region lvl2_task23

            Console.WriteLine("Input matrix (A):");
            var arr1 = InputMatrixDouble();
            MaxOfAllTime(arr1);
            Console.WriteLine("Output matrix (A):");
            PrintMatrixDouble(arr1);
            Console.WriteLine();
            Console.WriteLine("Input matrix (B):");
            var arr2 = InputMatrixDouble();
            MaxOfAllTime(arr2);
            Console.WriteLine("Output matrix (B):");
            PrintMatrixDouble(arr2);

            #endregion


            #region lvl3_task2

            Console.WriteLine("Input matrix:");
            arr = InputMatrix();
            SortByRows(arr);
            Console.WriteLine("Output matrix:");
            PrintMatrix(arr);

            #endregion

            #region lvl3_task6

            Console.WriteLine("Input matrix:");
            arr = InputMatrix();
            FindMax del;
            del = InDiagonal;
            var maxIndex1 = del(arr);
            del = InFirstLine;
            var maxIndex2 = del(arr);
            if (maxIndex1 != maxIndex2) SwitchColsByIndex(arr, maxIndex1, maxIndex2);
            Console.WriteLine("Output matrix:");
            PrintMatrix(arr);

            #endregion
        }
    }
}
