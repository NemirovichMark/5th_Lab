static int fact(int n)
{
    int f = 1;
    for (int i = 2; i <= n; i++) f *= i;
    return f;
}

static double comb(int n, int k)
{
    return fact(n) / (fact(k) * fact(n - k));
}

Console.WriteLine($"team of 8 people 5 candidates (number of combinations): {comb(8, 5)}");
Console.WriteLine($"team of 10 people 5 candidates (number of combinations): {comb(10, 5)}");
Console.WriteLine($"team of 11 people 5 candidates (number of combinations): {comb(11, 5)}");
