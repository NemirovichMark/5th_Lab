using System.Linq;

static void ShowMatrix(double[,] matrix)
{
    Console.WriteLine();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j], 4} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

static void ShowArray(double[] array)
{
    Console.WriteLine();
    foreach (double x in array) Console.Write($"{x} ");
    Console.WriteLine();
}

static double[] MatrixToArray(double[,] matrix)
{
    double[] array = new double[matrix.GetLength(0) * matrix.GetLength(1)];
    int c = 0;
    foreach (double value in matrix)
    {
        array[c++] = value;
    }
    return array;
}

static double[] Find5Max(double[,] matrix)
{
    var element = 1;
    var pointer = 2;
    double[] array = MatrixToArray(matrix);
    double[] result = new double[5];
    while (element < array.Length)
    {
        if (element == 0 || array[element] <= array[element - 1])
        {
            element = pointer;
            pointer++;
        }
        else
        {
            var temp = array[element - 1];
            array[element - 1] = array[element];
            array[element] = temp;
            element--;
        }
    }
    for (int i = 0; i < 5; i++)
    {
        result[i] = array[i];
    }
    ShowArray(result);
    return result;
}

static double[] DeleteElement(double[] array, double element)
{
    double[] result = new double[array.Length - 1];
    int c = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] != element)
        {
            result[c++] = array[i];
        }
        else
        {
            element = int.MinValue;
        }
    }
    return result;
}

static void UpdateMatrix(double[,] matrix)
{
    double[] maximums = Find5Max(matrix);
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (maximums.Contains(matrix[i, j]))
            {
                maximums = DeleteElement(maximums, matrix[i, j]);
                matrix[i, j] = matrix[i, j] > 0 ? matrix[i, j] * 2 : matrix[i, j] / 2;
            }
            else
            {
                matrix[i, j] = matrix[i, j] > 0 ? matrix[i, j] / 2 : matrix[i, j] * 2;
            }
        }
    }
}

int n1, m1;
do
{
    do
    {
        Console.Write("enter the number of rows of the first matrix: ");
    }
    while (!int.TryParse(Console.ReadLine(), out n1));

    do
    {
        Console.Write("enter the number of columns of the first matrix: ");
    }
    while (!int.TryParse(Console.ReadLine(), out m1));
}
while (n1 * m1 < 5 || n1 < 0 || m1 < 0);

int n2, m2;
do
{
    do
    {
        Console.Write("enter the number of rows of the second matrix: ");
    }
    while (!int.TryParse(Console.ReadLine(), out n2));

    do
    {
        Console.Write("enter the number of columns of the second matrix: ");
    }
    while (!int.TryParse(Console.ReadLine(), out m2));
}
while (n2 * m2 < 5 || n2 < 0 || m2 < 0);


Random randomizer = new Random();
double[,] A = new double[n1, m1];
for (int i = 0; i < n1; i++)
{
    for (int j = 0; j < m1; j++)
    {
        A[i, j] = randomizer.Next(-50, 50);
    }
}
Console.WriteLine("First matrix:");
ShowMatrix(A);
UpdateMatrix(A);
ShowMatrix(A);

double[,] B = new double[n2, m2];
for (int i = 0; i < n2; i++)
{
    for (int j = 0; j < m2; j++)
    {
        B[i, j] = randomizer.Next(-50, 50);
    }
}
Console.WriteLine("Second matrix:");
ShowMatrix(B);
UpdateMatrix(B);
ShowMatrix(B);
