using System;

namespace _5th_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Level I
            Console.WriteLine("------ Level I -----------------------\n");

            #region Task 1
            Console.WriteLine("Task 1:\n");

            Console.WriteLine($"5 from 8: {Combination(5, 8)}");
            Console.WriteLine($"5 from 10: {Combination(5, 10)}");
            Console.WriteLine($"5 from 11: {Combination(5, 11)}");

            #endregion

            #region Task 2
            Console.WriteLine("\nTask 2:\n");

            (int a, int b, int c) t1 = (7, 3, 5);
            (int a, int b, int c) t2 = (4, 8, 8);

            Console.WriteLine($"Triangle #1: a = {t1.a}, b = {t1.b}, c = {t1.c}");
            Console.WriteLine($"Triangle #2: a = {t2.a}, b = {t2.b}, c = {t2.c}");

            int comparisonResult = CompareTriangles(t1, t2);

            switch (comparisonResult)
            {
                case 0:
                    Console.WriteLine("Result: triangles are equal");
                    break;
                case 1:
                    Console.WriteLine("Result: t1 > t2");
                    break;
                case 2:
                    Console.WriteLine("Result: t1 < t2");
                    break;
                default:
                    Console.WriteLine("Entered values is incorrect!");
                    break;
            }

            Console.WriteLine();
            #endregion

            #endregion

            #region Level II
            Console.WriteLine("------ Level II -----------------------\n");

            #region Task 6
            Console.WriteLine("\nTask 6:\n");

            int[] firstArray = new int[7] { 9, 12, 0, 7, 2, 5, 4 };
            int[] secondArray = new int[8] { 3, 15, 85, 40, 13, 28, 9, 0 };

            Console.Write("First array: ");
            for (int i = 0; i < firstArray.Length; i++)
                Console.Write($"{firstArray[i]} ");
            Console.WriteLine();

            Console.Write("Second array: ");
            for (int i = 0; i < secondArray.Length; i++)
                Console.Write($"{secondArray[i]} ");
            Console.WriteLine();

            int firstMaxIndex = ArrayMaxIndex(firstArray);
            int secondMaxIndex = ArrayMaxIndex(secondArray);

            firstArray = ArrayRemoveAt(firstArray, firstMaxIndex);
            secondArray = ArrayRemoveAt(secondArray, secondMaxIndex);

            firstArray = ArrayUnite(firstArray, secondArray);

            Console.Write("Result array: ");
            for (int i = 0; i < firstArray.Length; i++)
                Console.Write($"{firstArray[i]} ");
            Console.WriteLine();
            #endregion

            #region Task 10
            Console.WriteLine("\nTask 10:\n");

            int[,] matrix = new int[,]
            {
                { 0, 4, 5, 1 },
                { 3, 6, 8, 2 },
                { 5, 0, 12, 11 },
                { 4, 3, 7, 5 }
            };

            Console.WriteLine("Initial matrix:");
            WriteMatrix(matrix);
            Console.WriteLine();

            matrix = MatrixDeleteByRule(matrix);

            Console.WriteLine("Result matrix:");
            WriteMatrix(matrix);
            Console.WriteLine();
            #endregion

            #region Task 23
            Console.WriteLine("\nTask 23:\n");

            matrix = new int[,]
            {
                { 0, -2, -4 },
                { -6, -8, -10 },
                { -12, -14, -16 }
            };

            int[,] matrix2 = new int[,]
            {
                { 1, 12, 3, 0, 9, 5 },
                { 11, 6, 7, 9, 9, 2 },
                { 3, 5, 17, 14, 0, 3 },
                { 0, 15, 3, 6, 2, 5 }
            };

            Console.WriteLine("Initial matrix #1:");
            WriteMatrix(matrix);
            Console.WriteLine();

            MatrixLevelUp(matrix);

            Console.WriteLine("Result matrix #1:");
            WriteMatrix(matrix);
            Console.WriteLine();

            Console.WriteLine("Initial matrix #2:");
            WriteMatrix(matrix2);
            Console.WriteLine();

            MatrixLevelUp(matrix2);

            Console.WriteLine("Result matrix #2:");
            WriteMatrix(matrix2);
            Console.WriteLine();
            #endregion

            #endregion

            #region Level III
            Console.WriteLine("------ Level III -----------------------\n");

            #region Task 1
            Console.WriteLine("\nTask 1:\n");

            (decimal start, decimal end, decimal step) parameters = (0.1m, 1m, 0.1m);
            Summarize(FirstSumAddend, FirstReccurrent, FirstReferenceFunc, 1, parameters, 0.0001);

            Console.WriteLine();

            parameters = ((decimal)(Math.PI / 5), (decimal)Math.PI, (decimal)(Math.PI / 25));
            Summarize(SecondSumAddend, SecondReccurrent, SecondReferenceFunc, 0, parameters, 0.0001);
            #endregion

            #region Task 2
            Console.WriteLine("\nTask 2:\n");

            matrix = new int[,]
            {
                { 1, 12, 3, 0, 9, 5 },
                { 11, 6, 7, 9, 9, 2 },
                { 3, 5, 17, 14, 0, 3 },
                { 0, 15, 3, 6, 2, 5 }
            };

            Console.WriteLine("Initial matrix:");
            WriteMatrix(matrix);

            MatrixOddEvenSort(matrix, MatrixSort);

            Console.WriteLine();
            Console.WriteLine("Result matrix:");
            WriteMatrix(matrix);
            Console.WriteLine();

            #endregion

            #region Task 3
            Console.WriteLine("\nTask 3:\n");

            int[] array = new int[] { 4, 8, 9, 0, 3, 5, 4, 7, 1, 8, 9, 4 };
            Console.Write("Initial array: ");
            WriteArray(array);
            Console.WriteLine();

            int sum = ArrayOddIndexSum(array);
            Console.WriteLine($"Odd index sum: {sum}");
            #endregion

            #endregion
        }

        static int Combination(int take, int all)
        {
            int combination = 0;

            if (take > all)
                return -1;

            int n = Fact(all);
            int k = Fact(take);
            int diff = Fact(all - take);

            combination = n / (k * diff);

            return combination;
        }


        static bool TriangleExists((int a, int b, int c) t)
        {
            if (t.a >= t.b + t.c)
                return false;
            if (t.b >= t.a + t.c)
                return false;
            if (t.c >= t.b + t.a)
                return false;
            return true;
        }

        static int CompareTriangles((int a, int b, int c) t1, (int a, int b, int c) t2)
        {
            if (!TriangleExists(t1) || !TriangleExists(t2))
                return -1;

            bool hasNegativeValues = t1.a < 0 ||
                t1.b < 0 ||
                t1.c < 0 ||
                t2.a < 0 ||
                t2.b < 0 ||
                t2.c < 0;

            if (hasNegativeValues)
                return -1;

            double p1 = (t1.a + t1.b + t1.c) / 2;
            double p2 = (t2.a + t2.b + t2.c) / 2;

            double s1 = Math.Sqrt(p1 * (p1 - t1.a) * (p1 - t1.b) * (p1 - t1.c));
            double s2 = Math.Sqrt(p2 * (p2 - t2.a) * (p2 - t2.b) * (p2 - t2.c));

            if (s1 > s2)
                return 1;
            else if (s1 < s2)
                return 2;

            return 0;
        }

        static int[] ArrayRemoveAt(int[] array, int index)
        {
            int[] newArray = new int[array.Length - 1];
            int newIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (i == index)
                    continue;
                newArray[newIndex] = array[i];
                newIndex++;
            }

            return newArray;
        }

        static int[] ArrayUnite(int[] firstArray, int[] secondArray)
        {
            int[] newArray = new int[firstArray.Length + secondArray.Length];

            int newIndex = 0;

            for (int i = 0; i < firstArray.Length; i++)
            {
                newArray[newIndex] = firstArray[i];
                newIndex++;
            }

            for (int i = 0; i < secondArray.Length; i++)
            {
                newArray[newIndex] = secondArray[i];
                newIndex++;
            }

            return newArray;
        }

        static int ArrayMaxIndex(int[] array)
        {
            int max = array[0];
            int idx = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    idx = i;
                }
            }

            return idx;
        }

        static int[,] MatrixDeleteByRule(int[,] matrix)
        {
            int max = matrix[1, 0];
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int maxColumn = 1;

            // Find max of lower triangle of matrix
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (j >= i)
                        break;

                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxColumn = j;
                    }
                }
            }

            columns = matrix.GetLength(1);
            
            int min = matrix[0, 1];
            int minColumn = 1;

            // Find min of upper triangle of matrix
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (j <= i)
                        continue;

                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minColumn = j;
                    }
                }
            }

            if (maxColumn > minColumn)
            {
                matrix = MatrixRemoveColumn(matrix, maxColumn);
                matrix = MatrixRemoveColumn(matrix, minColumn);
            }
            else
            {
                matrix = MatrixRemoveColumn(matrix, minColumn);
                matrix = MatrixRemoveColumn(matrix, maxColumn);
            }

            return matrix;

            return matrix;
        }

        static int[,] MatrixRemoveColumn(int[,] matrix, int columnIndex)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int[,] newMatrix = new int[rows, columns - 1];


            for (int i = 0; i < rows; i++)
            {
                int newColIndex = 0;
                for (int j = 0; j < columns; j++)
                {
                    if (j == columnIndex)
                        continue;

                    newMatrix[i, newColIndex] = matrix[i, j];
                    newColIndex++;
                }
            }

            return newMatrix;
        }

        static void MatrixLevelUp(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int startIdx = MatrixGetOneDimIndex(0, 0, columns);
            int endIdx = MatrixGetOneDimIndex(rows - 1, columns - 1, columns);

            MatrixSort(matrix, MatrixSortKind.Desc, startIdx, endIdx);

            int elementChangedCount = 0;
            int nextI = 0;
            int nextJ = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] >= 0)
                        matrix[i, j] *= 2;
                    else
                        matrix[i, j] /= 2;

                    elementChangedCount++;

                    if (elementChangedCount == 5)
                    {
                        if (j + 1 == columns)
                        {
                            nextJ = 0;
                            nextI = i + 1;
                        }
                        else
                        {
                            nextJ = j + 1;
                            nextI = i;
                        }
                        break;
                    }
                }

                if (elementChangedCount == 5)
                    break;
            }

            for (int i = nextI; i < rows; i++)
            {
                int j = 0;

                if (i == nextI)
                    j = nextJ;

                for (; j < columns; j++)
                {
                    if (matrix[i, j] >= 0)
                        matrix[i, j] /= 2;
                    else
                        matrix[i, j] *= 2;
                }
            }
        }

        enum MatrixSortKind { Asc, Desc }

        // End and start indexes should be one dimensional
        static void MatrixSort(int[,] matrix, MatrixSortKind sortKind, int startIdx, int endIdx)
        {
            int sortIndex = startIdx + 1;
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            while (sortIndex <= endIdx)
            {
                (int row, int column) reflectedIdx = MatrixReflectIndex(sortIndex, columns);
                int rowIdx = reflectedIdx.row;
                int colIdx = reflectedIdx.column;

                reflectedIdx = MatrixReflectIndex(sortIndex - 1, columns);
                int prevRowIdx = reflectedIdx.row;
                int prevColIdx = reflectedIdx.column;

                if (sortKind == MatrixSortKind.Desc)
                {
                    if (sortIndex == startIdx || matrix[prevRowIdx, prevColIdx] >= matrix[rowIdx, colIdx])
                    {
                        sortIndex++;
                    }
                    else
                    {
                        int swap = matrix[prevRowIdx, prevColIdx];
                        matrix[prevRowIdx, prevColIdx] = matrix[rowIdx, colIdx];
                        matrix[rowIdx, colIdx] = swap;

                        sortIndex--;
                    }
                }
                else
                {
                    if (sortIndex == startIdx || matrix[prevRowIdx, prevColIdx] <= matrix[rowIdx, colIdx])
                    {
                        sortIndex++;
                    }
                    else
                    {
                        int swap = matrix[prevRowIdx, prevColIdx];
                        matrix[prevRowIdx, prevColIdx] = matrix[rowIdx, colIdx];
                        matrix[rowIdx, colIdx] = swap;

                        sortIndex--;
                    }
                }
            }
        }

        delegate void MatrixSortFunc(int[,] matrix, MatrixSortKind sortKind, int startIdx, int endIdx);

        static void MatrixOddEvenSort(int[,] matrix, MatrixSortFunc sortFunc)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int startIdx = MatrixGetOneDimIndex(i, 0, columns);
                int endIdx = MatrixGetOneDimIndex(i, columns - 1, columns);

                if ((i + 1) % 2 != 0)
                    sortFunc(matrix, MatrixSortKind.Desc, startIdx, endIdx);
                else
                    sortFunc(matrix, MatrixSortKind.Asc, startIdx, endIdx);
            }
        }

        static (int row, int column) MatrixReflectIndex(int oneDimensionalIndex, int columns)
        {
            int rowIndex = oneDimensionalIndex / columns;
            int columnIndex = oneDimensionalIndex % columns;

            return (rowIndex, columnIndex);
        }
        static int MatrixGetOneDimIndex(int row, int column, int columns) => row * columns + column;

        delegate double GetSumAddend(int i, decimal x, int reccurrent);
        delegate int GetReccurrent(int prevReccurrent, int i);
        delegate double TraceReferenceFunc(decimal x);

        static int FirstReccurrent(int prevReccurrent, int i) => prevReccurrent * i;
        static int SecondReccurrent(int prevReccurrent, int i) => -prevReccurrent;

        static double FirstReferenceFunc(decimal x) => Math.Exp(Math.Cos((double)x)) * Math.Cos(Math.Sin((double)x));
        static double SecondReferenceFunc(decimal x) => ((double)(x * x) - (Math.PI * Math.PI / 3)) / 4;

        static double FirstSumAddend(int i, decimal x, int reccurrent)
        {
            double addend = Math.Cos(i * (double)x) / reccurrent;
            return addend;
        }

        static double SecondSumAddend(int i, decimal x, int reccurrent)
        {
            double addend = reccurrent * Math.Cos(i * (double)x) / (i * i);
            return addend;
        }

        static void Summarize(GetSumAddend getSumAddend,
            GetReccurrent getReccurrent,
            TraceReferenceFunc referenceFunc,
            double initSum,
            (decimal start, decimal end, decimal step) parameters,
            double epsiland)
        {
            for (decimal x = parameters.start; x <= parameters.end; x += parameters.step)
            {
                double sum = initSum;
                double addend = 1;
                int reccurrent = 1;

                for (int i = 1; addend > epsiland; i++)
                {
                    reccurrent = getReccurrent(reccurrent, i);
                    addend = getSumAddend(i, x, reccurrent);
                    sum += addend;
                }

                Console.WriteLine(LogSummarization(referenceFunc, x, sum));
            }
        }

        static int ArrayOddIndexSum(int[] array)
        {
            double avg = ArrayAvg(array);

            if (array[0] > avg)
                SwapPairsArray(array, false);
            else
                SwapPairsArray(array, true);

            Console.Write("Swapped array: ");
            WriteArray(array);
            Console.WriteLine();

            int sum = 0;
            for (int i = 1; i < array.Length; i += 2)
                sum += array[i];

            return sum;
        }

        delegate void SwapPairsArrayFunc(int[] array, bool fromEnd);

        static void SwapPairsArray(int[] array, bool fromEnd)
        {
            int bound = 0;

            if (!fromEnd)
            {
                if (array.Length % 2 == 0)
                    bound = array.Length - 1;
                else
                    bound = array.Length - 2;

                for (int i = 0; i < bound; i += 2)
                {
                    int swap = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = swap;
                }
            }
            else
            {
                if (array.Length % 2 != 0)
                    bound += 1;

                for (int i = array.Length - 1; i > bound; i -= 2)
                {
                    int swap = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = swap;
                }
            }
        }

        static double ArrayAvg(int[] array)
        {
            int sum = ArraySum(array);
            return (double)sum / array.Length;
        }

        static int ArraySum(int[] array)
        {
            int sum = 0;
            foreach (var num in array)
                sum += num;
            return sum;
        }

        static string LogSummarization(TraceReferenceFunc referenceFunc, decimal x, double currentAddend)
        {
            double y = referenceFunc(x);
            return $"s = {Math.Round(currentAddend, 3)}\t y = {Math.Round(y, 3)}\t x = {Math.Round(x, 3)}";
        }

        static void WriteArray(int[] array)
        {
            foreach (var num in array)
                Console.Write($"{num} ");
        }

        static void WriteMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    Console.Write("{0, -5}", matrix[i, j]);
                Console.WriteLine();
            }
        }

        static int Fact(int n)
        {
            int fact = n;
            while (n > 1)
            {
                n -= 1;
                fact *= n;
            }

            return fact;
        }
    }
}
