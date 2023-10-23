using System;

namespace _16_Dictionary
{  
    internal class Program
    {        
        static void Main(string[] args)
        {
            Dictionary<string,string> countries = new Dictionary<string,String>();

            countries.Add("UA", "Ukraine");
            countries.Add("PL", "Poland");
            countries.Add("USA", "United States");
            countries.Add("FR", "France");
            countries.Add("GB", "Great Britain");

            foreach (KeyValuePair<string,string> item in countries)
            {
                Console.WriteLine($"Key : {item.Key, 7} . Value : {item.Value,15}");

            }

            var country = countries["USA"];//get
            Console.WriteLine(country);
            countries["USA"] = "America";//set
            countries["IN"] = "India";//set
            countries["RUN"] = "RUNNING";//set
            countries.Remove("FR");
            Console.WriteLine();
            foreach (KeyValuePair<string, string> item in countries)
            {
                Console.WriteLine($"Key : {item.Key,7} . Value : {item.Value,15}");
            }
            Console.WriteLine();
            Dictionary<char,Person> people = new Dictionary<char,Person>();
            people.Add('A', new Person() { Name = "Andriy" });
            people.Add('P', new Person() { Name = "Petro" });
            people.Add('M', new Person() { Name = "Mukola" });
            people.Add('O', new Person() { Name = "Olga" });
            // people.Add('A', new Person() { Name = "Anna" }); // exception
           

            foreach (var item in people)
            {
                Console.WriteLine($"Key : {item.Key,7} . Value : {item.Value.Name,15}");
            }

            if(people.ContainsKey('A'))
            {
                people['A'] = new Person() { Name = "Anna" };
                Console.WriteLine("Info was changed!!!!");
            }
            foreach (var item in people)
            {
                Console.WriteLine($"Key : {item.Key,7} . Value : {item.Value.Name,15}");
            }

            foreach (var item in people.Keys)
            {
                Console.WriteLine("Key : " + item);
            }

            foreach (var item in people.Values)
            {
                Console.WriteLine("Value : " + item.Name);
            }


        }

        class Person
        {
            public string Name { get; set; }
        }
    }
}