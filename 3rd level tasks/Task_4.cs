static void ShowMatrix(int[,] matrix)
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

static int UpperTriangle(int[,] matrix)
{
    int [] A = new int[((1 + matrix.GetLength(0)) * matrix.GetLength(0)) / 2];
    int sum = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = i; j < matrix.GetLength(1); j++)
        {
            sum += matrix[i, j] * matrix[i, j];
        }
    }
    return sum;
}

static int LowerTriangle(int[,] matrix)
{
    int [] A = new int[((1 + matrix.GetLength(0)) * matrix.GetLength(0)) / 2];
    int sum = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j <= i; j++)
        {
            sum += matrix[i, j] * matrix[i, j];
        }
    }
    return sum;
}


int n;
do
{
    Console.Write("enter matrix size: ");
}
while (!int.TryParse(Console.ReadLine(), out n));


Random randomizer = new Random();
int[,] A = new int[n, n];
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        A[i, j] = randomizer.Next(-10, 10);
    }
}
ShowMatrix(A);

string choice;
do
{
    Console.WriteLine("1 - Upper Triangle\n2 - Lower Triangle");
    choice = Console.ReadLine();
}
while(choice != "1" && choice != "2");

dlgt f = choice == "1" ? UpperTriangle : LowerTriangle;
Console.WriteLine(f(A));

delegate int dlgt(int[,] matrix);
