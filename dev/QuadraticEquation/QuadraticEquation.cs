class Program
{
    static void Main(string[] args)
    {
        string A, B, C;
        double a, b, c, x, D;
        bool result;

        do
        {
            Console.WriteLine("Input a");
            A = Console.ReadLine();
            result = Double.TryParse(A, out a);
        }
        while (!result);

        do
        {
            Console.WriteLine("Input b");
            B = Console.ReadLine();
            result = Double.TryParse(B, out b);
        }
        while (!result);

        do
        {
            Console.WriteLine("Input c");
            C = Console.ReadLine();
            result = Double.TryParse(C, out c);
        }
        while (!result);

        D = b * b - 4 * a * c;
            
        if (D < 0)
        {
            Console.WriteLine(" There is no solution");
        }
        else if(D == 0)
        {
            Console.WriteLine("x = "+ (-b) /( 2*a));
        }
        else
        {
            Console.WriteLine("x1 = "+ ((-b) + Math.Sqrt(D))/(2*a));
            Console.WriteLine("x2 = " + ((-b) - Math.Sqrt(D)) / (2 * a));
        }
    }
}
