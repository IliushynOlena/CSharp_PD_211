using System.Runtime.Serialization.Formatters.Binary;

namespace _21_Serializable
{
    [Serializable]
    public class Passport
    {
        public int Number { get; set; }
        public Passport()
        {
            Number = 600458;
        }
        public override string ToString()
        {
            return Number.ToString();
        }
    }
    [Serializable]
    class Person
    {
        public Passport Passport { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        private int _identNumber;
        const string Planet = "Earth";
        public Person(int number)
        {
            _identNumber = number;
            Passport = new Passport();  
        }
        public override string ToString()
        {
            return $"Name {Name}\nAge : {Age}\nIdentification number : {_identNumber}\n" +
                $"Planet {Planet}\nPassport {Passport}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                 new Person(11111111){ Name = "Jack", Age = 25},
                 new Person(22222222){ Name = "Bob", Age = 15},
                 new Person(33333333){ Name = "Tom", Age = 45}
            };
            foreach (var item in people)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                using (Stream fstream = File.Create("People.bin"))
                {
                    formatter.Serialize(fstream, people);
                }
                Console.WriteLine("Binary Serialize Ok!!!");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            List<Person> newList = null;
            using (Stream fstream = File.OpenRead("People.bin"))
            {
                newList = (List<Person>)formatter.Deserialize(fstream);
            }
            foreach (var item in newList)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

        }
    }
}