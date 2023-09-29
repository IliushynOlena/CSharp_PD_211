using System.Text;

namespace _05_StringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello";//5b
            str += ", world!!!";
            str += ", world!!!";
            str += ", world!!!";

            StringBuilder b = new StringBuilder();
            Console.WriteLine( $" Length : {b.Length}");
            Console.WriteLine( $" Capacity : {b.Capacity}");

            b.Append("bla"); 
            Console.WriteLine($" Length : {b.Length}");
            Console.WriteLine($" Capacity : {b.Capacity}");
            b.Append("bla");
            Console.WriteLine($" Length : {b.Length}");
            Console.WriteLine($" Capacity : {b.Capacity}");
            b.Append("bla");
            Console.WriteLine($" Length : {b.Length}");
            Console.WriteLine($" Capacity : {b.Capacity}");
            b.Append("bla");
            Console.WriteLine($" Length : {b.Length}");
            Console.WriteLine($" Capacity : {b.Capacity}");
            b.Append("bla");
            Console.WriteLine($" Length : {b.Length}");
            Console.WriteLine($" Capacity : {b.Capacity}");
            b.AppendLine("bla");
            Console.WriteLine($" Length : {b.Length}");
            Console.WriteLine($" Capacity : {b.Capacity}");
            b.Append("bla");
            b.Append("bla");
            b.Append("bla");
            b.Append("bla");
            b.Append("bla");
            Console.WriteLine($" Length : {b.Length}");
            Console.WriteLine($" Capacity : {b.Capacity}");

            Console.WriteLine(b);


        }
    }
}