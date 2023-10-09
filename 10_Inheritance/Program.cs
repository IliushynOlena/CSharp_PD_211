using System.Text;

namespace _10_Inheritance
{
    //protected - allow access from inherit class
    //protected internal -- allow access from inherit class onli in assembly

    abstract class Person
    {
        protected string name;
        private readonly DateTime birthdate;
        public Person()
        {
            name = "No name";
            birthdate = new DateTime(2000,5,12);   
        }
        public Person(string name, DateTime birthdate)
        {
            this.name = name;
            if(birthdate > DateTime.Now)
                this.birthdate = new DateTime();
            else
                this.birthdate = birthdate; 
        }
        public virtual void Print()
        {
            Console.WriteLine($"Name : {name}\n Birthdate : {birthdate.ToLongDateString()}");
        }
        public override string ToString()
        {
            return $"Name : {name}\n Birthdate : {birthdate.ToLongDateString()}";
        }
        public abstract void DoWork();
    }
    //class Name : BaseClass, Interface1,Interface2,Interface3
    class Worker : Person
    {
        private decimal salary;

        public decimal Salary
        {
            get { return salary; }
            set 
            { 
                this.salary = value >= 0? value : 0;
            }
        }
        public Worker():base()
        {
            salary = 0; 
        }
        public Worker(string n, DateTime b, decimal salary): base(n,b)
        {
            Salary = salary;
        }
        public override void DoWork()
        {
            Console.WriteLine("Doing some work");
        }
        //override - override base method
        //new - hides a base member
        public override void Print()
        {
            base.Print();//Person.Print();
            Console.WriteLine($"Salary {Salary}$");
        }

    }
    //sealed as finally in C++
    sealed class Programmer :Worker
    {
        public int CodeLines { get; private set; }
        public Programmer():base()
        {
            CodeLines = 0;  
        }
        public Programmer(string n, DateTime b, decimal s):base(n,b,s)
        {
            CodeLines = 0;
        }
        public sealed override void DoWork()
        {
            Console.WriteLine("Write C# code");
        }
        public override void Print()
        {
            base.Print();//Worker.Print();
            Console.WriteLine($"Code lines {CodeLines}$");
        }
        public void WriteLine()
        {
            CodeLines++;
        }
    }
    class TechLead : Worker
    {
        public int ProjectCount { get; set; }
        //public override void DoWork()
        //{
        //    Console.WriteLine("Manage Team Projects");
        //}
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Worker worker = new Worker("Mukola", new DateTime(1999,3,3), 10000);
            worker.DoWork();
            worker.Print();

            Person[] people = new Person[]
            {
                //new Person(),
                worker,
                new Programmer("Nick",new DateTime(2003,4,7),8000)
            };

            foreach (var person in people)
            {
                Console.WriteLine("-----------------Info-----------");
                person.Print();
                
            }
            Console.WriteLine("----------------------------------------");
            Programmer pr = null;
            //1 - use cast()
            try
            {
                pr = (Programmer)people[1];
                //Console.WriteLine(pr);
                pr.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //2 - use as
            pr = people[1] as Programmer;
            if (pr == null)
                Console.WriteLine("Incorrect type");
            else
                pr.Print();

            //3 use is with as
            if (people[1] is Programmer)
            {
                pr = people[1] as Programmer;
                pr.Print();
            }
            else
                Console.WriteLine("Incorrect type");



        }
    }
}