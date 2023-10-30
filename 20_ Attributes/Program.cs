using System;

namespace Attributes_Serelization
{
  


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method)]
    public class CoderAttribute : Attribute
    {
        public string Name { get; set; } = "Olena";
        public DateTime Date { get; set; } = DateTime.Now;
        public CoderAttribute() { }
        public CoderAttribute(string name, string date)
        {
            try
            {
                Name = name;
                Date = Convert.ToDateTime(date);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public override string ToString()
        {
            return $"Coder : {Name} , Date{Date}";
        }
    }
    [Obsolete , Serializable]
    [Coder]
    class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public double Salary { get; set; }
        [Coder]
        public Employee() { }
        [Coder("Sasha", "2023-10-30")]
        public void IncreaseSalary(double plus)
        {
            Salary += plus;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine("Attributes of class Employee : ");
            foreach (var item in typeof(Employee).GetCustomAttributes(true))
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("______________________________________-");
            Console.WriteLine("Attributes of members of class Employee : ");
            foreach (var item in typeof(Employee).GetMembers())
            {
                Console.WriteLine(item.ToString());
                foreach (var atrr in item.GetCustomAttributes(true))
                {
                    Console.WriteLine(atrr);
                }
            }

        }
    }
}
