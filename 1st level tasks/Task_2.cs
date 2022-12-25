static double p(double a, double b, double c)
{
    return (a + b + c) / 2;
}

static double s(double a, double b, double c, double p)
{
    return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
}

double a1, b1, c1;
do
{
    Console.Write("First triangle\t| Enter the first side: ");
}
while (!double.TryParse(Console.ReadLine(), out a1));

do
{
    Console.Write("First triangle\t| Enter the second side: ");
}
while (!double.TryParse(Console.ReadLine(), out b1));

do
{
    Console.Write("First triangle\t| Enter the third side: ");
}
while (!double.TryParse(Console.ReadLine(), out c1));

double a2, b2, c2;
do
{
    Console.Write("Second triangle\t| Enter the first side: ");
}
while (!double.TryParse(Console.ReadLine(), out a2));

do
{
    Console.Write("Second triangle\t| Enter the second side: ");
}
while (!double.TryParse(Console.ReadLine(), out b2));

do
{
    Console.Write("Second triangle\t| Enter the third side: ");
}
while (!double.TryParse(Console.ReadLine(), out c2));

double p1 = p(a1, b1, c1);
double s1 = s(a1, b1, c1, p1);
bool f1 = s1 > 0 ? true : false;

double p2 = p(a2, b2, c2);
double s2 = s(a2, b2, c2, p2);
bool f2 = s2 > 0 ? true : false;

if (f1 || f2)
{
    if (s1 > s2) Console.WriteLine("The first triangle is larger than the second");
    else Console.WriteLine("The second triangle is larger than the first");
}
else
{
    Console.WriteLine("Not triangles");
}
