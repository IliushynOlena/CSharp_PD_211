using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        int _idenNumber;
        //[NonSerialized]
        const string Planet = "Earth";
        public Person() { }
        public Person(int number)
        {
            _idenNumber = number;
        }
        public override string ToString()
        {
            return $"Name : {Name}, Age{Age}, Identification number {_idenNumber} " +
                $", Planet {Planet} ";
        }
    }

    [Serializable]
    public class User
    {
        [Required(ErrorMessage ="Is not defined")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name not setted")]
        [StringLength(50,MinimumLength =3, ErrorMessage ="Lenght is error")]
        public string Name { get; set; }//""
        [Required(ErrorMessage = "Age not setted")]
        [Range(1,100,ErrorMessage ="Invalid age")]
        public int Age { get; set; }//333
        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }//"slfnsdghoasdhgosdhl"
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage ="Not confirm password")]
        public string ConfirmPassword { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            User user = new User();
            bool isValid = true;
            do
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter age");
                int age = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Login");
                string login = Console.ReadLine();

                Console.WriteLine("Enter password");
                string password = Console.ReadLine();

                Console.WriteLine("Confirm password");
                string confirmPassword = Console.ReadLine();

                Console.WriteLine("Enter email");
                string email = Console.ReadLine();

                Console.WriteLine("Enter phone");

                string phone = Console.ReadLine();
                user.Id = 1;
                user.Name = name;
                user.Age = age;
                user.Password = password;
                user.ConfirmPassword = confirmPassword;
                user.Email = email;
                user.Phone = phone;
                user.Login = login;

                var result = new List<ValidationResult>();
                var contex = new ValidationContext(user);
                if (!(isValid = Validator.TryValidateObject(user, contex, result, true)))
                {
                    foreach (ValidationResult error in result)
                    {
                        Console.WriteLine(error.MemberNames.FirstOrDefault() + ": " + error.ErrorMessage);
                    }
                }


            } while (!isValid);
          
            Console.WriteLine("Model is valid");
            */
           
            List<Person> persons = new List<Person>()
            {
                new Person(123654) { Name = "Olena", Age = 21 },
                new Person(987456) { Name = "Mukola", Age = 22 },
                new Person(258963) { Name = "Oksana", Age = 23 }
            };

            /*
           try
           {
               string filename = "Persons.json";
               string jsonString = JsonSerializer.Serialize(persons);
               File.WriteAllText(filename, jsonString);

               jsonString = File.ReadAllText(filename);
               List<Person> newpersons = JsonSerializer.Deserialize<List<Person>>(jsonString);
               foreach (var item in newpersons)
               {
                   Console.WriteLine(item);
               }

           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);

           }
           */



            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            //XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Person>));
            try
            {
                using (Stream fstream = File.Create("test.xml"))
                {
                    serializer.Serialize(fstream, persons);
                }//Dispose()
                Console.WriteLine("Xml Serialize OK!!!!");
                List<Person> newpersons = null;
                // Person p = null;
                using (Stream fstream = File.OpenRead("test.xml"))
                {
                    //p = (Person)binaryFormatter.Deserialize(fstream);
                    newpersons = (List<Person>)serializer.Deserialize(fstream);
                }
                //Console.WriteLine(p);
                foreach (var item in newpersons)
                {
                    Console.WriteLine(item);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            
        }
    }
}