namespace _5_Lab {
    class Program {

        #region delegate and methods for 3.4
        public delegate double[] GetTriangle(double[,] matrix);

        public static double[] getTopTriangle(double[,] matrix) {
            int size = 0;
            for (int i = 0; i <= matrix.GetLength(0); i++) {
                size += i;
            }

            double[] result = new double[size];
            int curInd = 0;

            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = i; j < matrix.GetLength(1); j++) {
                    result[curInd] = matrix[i, j];
                    curInd++;
                }
            }

            return result;
        }

        public static double[] getBottomTriangle(double[,] matrix) {
            int size = 0;
            for (int i = 0; i <= matrix.GetLength(0); i++) {
                size += i;
            }

            double[] result = new double[size];
            int curInd = 0;

            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j <= i; j++) {
                    result[curInd] = matrix[i, j];
                    curInd++;
                }
            }

            return result;
        }
        #endregion

        #region delegate and methods for 3.5
        public delegate double Function(double num);

        public static double firstFuntion(double num) {
            return (num * num) - Math.Sin(num);
        }

        public static double secondFuntion(double num) {
            return (Math.Pow(Math.E, num)) - 1;
        }
        #endregion

        static void Main(string[] args) {
            // Support Functions -------------
            static double[] getDoubleArray(int size) {
                string[] strNums = Console.ReadLine().Trim().Split();
                
                if (strNums.Length != size) {
                    Console.WriteLine("Wrong array size");
                }

                double[] nums = new double[strNums.Length];

                for (int i = 0; i < strNums.Length; i++) {
                    if (!double.TryParse(strNums[i], out nums[i])) {
                        Console.WriteLine("Wrong input!");
                        return null;
                    }
                }

                return nums;
            }

            static double[,] getUnknownMatrix() {
                Console.WriteLine($"To complete the input of the matrix print empty line");

                bool firstRow = true;
                int rowSize = 0;

                double[][] preResult = new double[0][];
                int resSize = 0;

                while (true) {
                    string s = Console.ReadLine();

                    if (s == "") {
                        break;
                    }

                    string[] strNums = s.Trim().Split();

                    if (firstRow) {
                        rowSize = strNums.Length;
                        firstRow = false;
                    }

                    if (strNums.Length != rowSize) {
                        Console.WriteLine("Incorrect input. Different number of columns in rows");
                        return null;
                    }

                    double[] array = new double[rowSize];
                    for (int i = 0; i < rowSize; i++) {
                        if (!double.TryParse(strNums[i], out array[i])) {
                            Console.WriteLine("One of the elements isn`t a number");
                            return null;
                        }
                    }

                    Array.Resize(ref preResult, resSize + 1);
                    preResult[resSize] = array;
                    resSize++;
                }

                double[,] result = new double[resSize, rowSize];

                for (int i = 0; i < resSize; i++) {
                    for (int j = 0; j < rowSize; j++) {
                        result[i, j] = preResult[i][j];
                    }
                }

                return result;
            }

            static void printArray(double[] nums) {
                Console.WriteLine(String.Join(" ", nums));
            }

            static void printMatrix(double[,] matrix) {
                for (int i = 0; i < matrix.GetLength(0); i++) {
                    for (int j = 0; j < matrix.GetLength(1); j++) {
                        Console.Write(String.Format("{0} ", matrix[i, j]));
                    }
                    Console.WriteLine();
                }
            }


            // Level 1 -----------------------

            static void task_1_1() {

                static int factorial(int num) {
                    int result = 1;
                    for (int i = 1; i <= num; i++) {
                        result *= i;
                    }

                    return result;
                }

                static int answerFunction(int n, int k) {
                    int result = factorial(n) / (factorial(k) * factorial(n - k));
                    return result;
                }

                Console.WriteLine(answerFunction(8, 5));
                Console.WriteLine(answerFunction(10, 5));
                Console.WriteLine(answerFunction(11, 5));
            }

            static void task_1_2() {

                static (double, double, double) getMultipleDouble() {
                    string[] strNums = Console.ReadLine().Trim().Split();

                    if (strNums.Length != 3) {
                        Console.WriteLine("Incorrect Input");
                    }

                    double[] nums = new double[strNums.Length];

                    for (int i = 0; i < 3; i++) {
                        if (!double.TryParse(strNums[i], out nums[i])) {
                            Console.WriteLine("It`s not a number");
                            return (-1, -1, -1);
                        }
                    }

                    return (nums[0], nums[1], nums[2]);
                }

                static double squareByGeron((double, double, double) t) {
                    double p = (t.Item1 + t.Item2 + t.Item3) / 2;
                    double result = Math.Sqrt(p * (p - t.Item1) * (p - t.Item2) * (p - t.Item3));
                    return result;
                }

                static bool isTriangleCorrect((double, double, double) t) {
                    
                    if (t.Item1 <= 0 || t.Item2 <= 0 || t.Item3 <= 0) {
                        Console.WriteLine("Triangle isn`t correct.");
                        return false;
                    }
                    
                    double maxElem = Math.Max(t.Item1, Math.Max(t.Item2, t.Item3));
                    double suma = t.Item1 + t.Item2 + t.Item3;
                    if (suma - maxElem <= maxElem) {
                        Console.WriteLine("Triangle isn`t correct.");
                        return false;
                    }

                    return true;
                }

                Console.WriteLine("Input example: 20 10 17");
                (double, double, double) t1 = getMultipleDouble();
                if (!isTriangleCorrect(t1)) {
                    return;
                }


                (double, double, double) t2 = getMultipleDouble();
                if (!isTriangleCorrect(t2)) {
                    return;
                }

                if (squareByGeron(t1) == squareByGeron(t2)) {
                    Console.WriteLine("Triangles are equal");
                } else if (squareByGeron(t1) > squareByGeron(t2)) {
                    Console.WriteLine("The first trianle is larger");
                } else {
                    Console.WriteLine("The second trianle is larger");
                }
            }


            // Level 2 -----------------------

            static void task_2_6() {
                static void deleteInd(double[] nums, int ind, out double[] _array) {
                    for (int i = ind + 1; i < nums.Length; i++) {
                        nums[i - 1] = nums[i];
                    }

                    Array.Resize(ref nums, nums.Length - 1);
                    _array = nums;
                }

                static double findMaxElem(double[] nums) {

                    double maxElem = nums[0];
                    for (int i = 0; i < nums.Length; i++) {
                        maxElem = Math.Max(maxElem, nums[i]);
                    }

                    return maxElem;
                }

                static void deleteMaxElems(double[] nums, out double[] _array) {
                    double maxElem = findMaxElem(nums);

                    int curInd = 0;

                    while (curInd != nums.Length) {
                        if (nums[curInd] == maxElem) {
                            deleteInd(nums, curInd, out nums);
                            curInd--;
                        }

                        curInd++;
                    }

                    _array = nums;
                }


                double[] a = getDoubleArray(7);
                double[] b = getDoubleArray(8);

                if (a == null || b == null) {
                    return;
                }

                deleteMaxElems(a, out a);
                deleteMaxElems(b, out b);

                Array.Resize(ref a, a.Length + b.Length);
                for (int i = b.Length - 1; i >= 0; i--) {
                    a[a.Length - (b.Length - i)] = b[i];
                }

                printArray(a);
            }

            static void task_2_10() {
                static void deleteCol(double[,] matrix, int ind, out double[,] _matrix) {
                    double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1) - 1];

                    for (int i = 0; i < matrix.GetLength(0); i++) {
                        int curInd = 0;
                        for (int j = 0; j < matrix.GetLength(1) - 1; j++) { 
                            if (j == ind) {
                                curInd++;
                            }
                            result[i, j] = matrix[i, curInd];
                            curInd++;
                        }
                    }

                    _matrix = result;
                }


                double[,] matrix = getUnknownMatrix();

                if (matrix == null) {
                    return;
                }

                if (matrix.GetLength(0) != matrix.GetLength(1)) {
                    Console.WriteLine("Matrix should be square");
                    return;
                }

                int minInd = 1;
                double minElem = matrix[0, 1];
                for (int i = 0; i < matrix.GetLength(0); i++) {
                    for (int j = i + 1; j < matrix.GetLength(1); j++) {
                        if (matrix[i, j] < minElem) {
                            minElem = matrix[i, j];
                            minInd = j;
                        }
                    }
                }


                int maxInd = 0;
                double maxElem = 0;
                for (int i = 0; i < matrix.GetLength(0); i++) {
                    for (int j = 0; j <= i; j++) {
                        if (matrix[i, j] > maxElem) {
                            maxElem = matrix[i, j];
                            maxInd = j;
                        }
                    }
                }

                if (maxInd == minInd) {
                    deleteCol(matrix, maxInd, out matrix);
                } else {
                    deleteCol(matrix, Math.Max(maxInd, minInd), out matrix);
                    deleteCol(matrix, Math.Min(maxInd, minInd), out matrix);
                }

                Console.WriteLine("Task 2.10 answer: ");
                printMatrix(matrix);

            }

            static void task_2_23() {
                
                static double?[] get5Maxs(double[,] matrix) {
                    double?[] nums = new double?[matrix.GetLength(0) * matrix.GetLength(1)];

                    int curInd = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++) {
                        for (int j = 0; j < matrix.GetLength(1); j++) {
                            nums[curInd] = matrix[i, j];
                            curInd++;
                        }
                    }
                    
                    Array.Sort(nums);
                    Array.Reverse(nums);

                    if (nums.Length < 5) {
                        return nums; 
                    }

                    return new double?[5] { nums[0], nums[1], nums[2], nums[3], nums[4] };
                }

                static void updateMatrix(double[,] matrix, out double[,] _matrix) {
                    double?[] nums = get5Maxs(matrix);
                    bool flag = true;


                    for (int i = 0; i < matrix.GetLength(0); i++) {
                        for (int j = 0; j < matrix.GetLength(1); j++) {
                            flag = true;                            
                            for (int k = 0; k < nums.Length; k++) {
                                if (matrix[i, j] == nums[k]) {
                                    matrix[i, j] *= 2;
                                    nums[k] = null;
                                    flag = false;
                                    break;
                                }
                            }

                            if (flag) {
                                matrix[i, j] /= 2;
                            }
                        }
                    }

                    _matrix = matrix;
                }

                Console.WriteLine("Task 2.23 answer:");


                double[,] matrix = getUnknownMatrix();

                if (matrix == null) {
                    return;
                }

                Console.WriteLine("For 1st matrix:");
                updateMatrix(matrix, out matrix);
                printMatrix(matrix);

                Console.WriteLine();

                matrix = getUnknownMatrix();

                if (matrix == null) {
                    return;
                }

                Console.WriteLine("For 2nd matrix:");
                updateMatrix(matrix, out matrix);
                printMatrix(matrix);

            }


            // Level 3 -----------------------
            
            static void task_3_4() {

                static double sumOfTriangle(double[] nums) {
                    double result = 0;

                    foreach(double n in nums) {
                        result += n * n;
                    }

                    return result;
                }


                double[,] matrix = getUnknownMatrix();

                if (matrix == null) {
                    return;
                }

                if (matrix.GetLength(0) != matrix.GetLength(1)) {
                    Console.WriteLine("Matrix should be square");
                    return;
                }

                Console.WriteLine("Task 3.4 answer:");


                GetTriangle gTrial = getTopTriangle;
                Console.WriteLine($"For top triangle: {sumOfTriangle(gTrial(matrix))}");

                gTrial = getBottomTriangle;
                Console.WriteLine($"For bottom triangle: {sumOfTriangle(gTrial(matrix))}");
            }
            
            static void task_3_5() {
                Console.WriteLine("Task 3.5 answer: ");

                Function func = firstFuntion;


                int cnt = 0;
                double prev = func(0);
                for (double i = 0.1; i <= 2; i += 0.1) {
                    double cur = func(i);
                    if (cur > 0 != prev > 0) {
                        cnt++;
                    }
                    prev = cur;
                }
                Console.WriteLine($"1st: {cnt}");


                func = secondFuntion;

                cnt = 0;
                prev = func(-1);
                for (double i = -0.8; i <= 1; i += 0.2) {
                    double cur = func(i);
                    if (cur > 0 != prev > 0) {
                        cnt++;
                    }
                    prev = cur;
                }
                Console.WriteLine($"2nd: {cnt}");
            }


            // -------------------------------

            task_1_1();
        }
    }
}
