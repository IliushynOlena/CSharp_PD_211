using System.Text.RegularExpressions;

namespace _23_RegularExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                СПЕЦ. СИМВОЛИ
                \d - Визначає символи цифр. 
                \D - Визначає любий символ, який не є цифрою. 
                \w - Визначає любий символ цифри, букви або нижнє підкреслення. 
                \W - Визначає любий символ, який не є цифрою, буквою або нижнім підкресленням.. 
                \s - Визначає любий недрукований символ, включаючи пробіл. (таб і перехід на новий рядок)
                \S - Визначає любий символ, крім символів табуляции, нового рядка и повернення каретки.
                .  - Визначає любий символ крім символа нового рядка.  
                \. - Визначає символ крапки.        
            */
            string pattern = @"\d";
            Regex regex = new Regex(pattern);
            bool flag = true;
            //while (flag)
            //{
            //    string str = Console.ReadKey().KeyChar.ToString();
            //    if(str == " ")
            //        flag = false;

            //    bool success =  regex.IsMatch(str);
            //    //Console.WriteLine(success ? "match found \"{0}\"" : $"mathc not found \"{pattern}\"", pattern);
            //    Console.WriteLine(success ? $"  match found \"{pattern}\"" : $"  match not found \"{pattern}\"");
            //}

            /*
                КВАНТИФИКАТОРЫ
                ^ - з початку рядка. 
                $ - з кінця рядка. 
                * - нуль і більше входжень підшаблону в сторці.  
                + - одне і більше  входжень підшаблону в сторці.  
                ? - нуль чи одне  входження підшаблону в сторці.    
             */
            //pattern = @"\d+";
            //pattern = @"\D+";
            //pattern = @"^\d+";
            //pattern = @"\d+$";
            pattern = @"^\d+$";
            regex = new Regex(pattern);
            var array = new[] { "test", "123", "test123test", "123test", "test123" };         
            foreach (string str in array)
            {
                Console.WriteLine(regex.IsMatch(str) ? $" String \"{pattern}\" matches" : 
                    $" String \"{pattern}\" not matches");

            }

            pattern = @"^[A-Z]+[a-z]*$";
            regex = new Regex(pattern);
            while (true)
            {
                Console.WriteLine("Enter string : ");
                string input = Console.ReadLine();
                if (input == "exit") break;
                Console.WriteLine( input != null && regex.IsMatch(input) ? $" String \"{pattern}\" matches" :
                   $" String \"{pattern}\" not matches");
            }

            string value = "4 - 5 AND 5 y 789";
             Match match =  Regex.Match(value, @"\d");    
               
            if(match.Success)
                Console.WriteLine(match.Value);

            match =  match.NextMatch();
            if (match.Success)
                Console.WriteLine(match.Value);

            while (match.Success)
            {
                Console.WriteLine(match.Value);
                match = match.NextMatch();
            }

            Match m = Regex.Match("123 Axx-1xxy \n Axyx-2xyyxy", @"A.*y");
            if (m.Success)
            {
                Console.WriteLine(m.Value);
                Console.WriteLine(m.Length);
                Console.WriteLine(m.Index);
            }
            m = m.NextMatch();
            if (m.Success)
            {
                Console.WriteLine(m.Value);
                Console.WriteLine(m.Length);
                Console.WriteLine(m.Index);
            }


            string value1 = "saidsaid said shed shed see spear spread super";
            MatchCollection matches =  Regex.Matches(value1, @"s\w+d");
            Console.WriteLine("----------------------------");
            foreach (Match item in matches)
            {
                Console.WriteLine($"Index {item.Index}, Value = {item.Value}");
            }


            string inputString = "Don't replace Dot Net replaced Net Net dots";
            string outstring = Regex.Replace(inputString, "N.t", "NET");
            Console.WriteLine(inputString);
            Console.WriteLine(outstring);
            //[RegularExpression(pattern)]

        }
    }
}