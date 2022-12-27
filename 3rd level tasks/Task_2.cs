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

static void Descending(ref int a, ref int b)
{
    if (a <= b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}

static void Ascending(ref int a, ref int b)
{
    if (a >= b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}

static void Sort(int[,] x, dlgt t, int index, int m)
{
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < m; j++)
        {
            t(ref x[index, i], ref x[index, j]);
        }
    }
}

static void Solution(int[,] x, int n, int m)
{
    for (int i = 0; i < n; i++)
    {
        dlgt t = Descending;
        t = i % 2 == 0 ? Ascending : Descending;
        Sort(x, t, i, m);
    }
}

int n;
do
{
    Console.Write("enter the number of rows of the first matrix: ");
}
while (!int.TryParse(Console.ReadLine(), out n));

int m;
do
{
    Console.Write("enter the number of columns of the first matrix: ");
}
while (!int.TryParse(Console.ReadLine(), out m));

Random randomizer = new Random();
int[,] A = new int[n, m];
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        A[i, j] = randomizer.Next(-30, 30);
    }
}
Console.WriteLine("Before: ");
ShowMatrix(A);
Console.WriteLine("After: ");
Solution(A, n, m);
ShowMatrix(A);

delegate void dlgt(ref int a, ref int b);
