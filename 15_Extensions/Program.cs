namespace _15_Extensions
{
    static class ExampleExtensions
    {
        public static int NumberWords(this string data)
        {
            if (string.IsNullOrEmpty(data)) return 0;
           
            return data.Split(new char[] { ' ',',','.','!','?' }, 
                StringSplitOptions.RemoveEmptyEntries).Length;
        }
        public static int NumberSymbol(this string data, char s)
        {
            if (string.IsNullOrEmpty(data)) return 0;

            int count = 0;
            foreach (char sym in data)
            {
                if (sym == s) ++count;
            }
            return count;
        }
        public static int AddAllNumbers(this string data)
        {
            if (string.IsNullOrEmpty(data)) return 0;
            int summa = 0;
            var res = data.Split(new char[] { '+' },
                StringSplitOptions.RemoveEmptyEntries);

       
            for (int i = 0; i < res.Length; i++)
            {
                summa += Convert.ToInt32( res[i]);
            }
            return summa ;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter message : ");
            string name = Console.ReadLine();
            
            //int res =  name.NumberWords();
            Console.WriteLine($"Numbers of word in line {name.NumberWords()} ");
            Console.WriteLine($"Numbers of symbol 'o' in line {name.NumberSymbol('o')} ");
            string example = Console.ReadLine();
            Console.WriteLine($"Summa all numbers {example.AddAllNumbers()} ");

        }
    }
}