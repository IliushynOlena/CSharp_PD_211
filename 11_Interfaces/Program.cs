namespace _11_Interfaces
{
    interface IWorker//public
    {
        //private string name;//error - not allowed
        bool IsWorking { get; set; }
        string Work();
        event EventHandler WorkEnded;

    }

    abstract class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public override string ToString()
        {
            return $"Last Name : {LastName}\nFirst Name : {FirstName}\n" +
                $"Birthday : {Birthdate.ToShortDateString()} ";
        }
    }
    abstract class Employee : Human
    {
        public string Position { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"\nPosition { Position}\nSalary : {Salary}$\n\n";
        }
    }
    interface IWorkable
    {
        bool IsWorking { get; }
        string Work();
    }
    interface IManager
    {
        List<IWorkable> ListOfWorkers { get; set; }//null
        void Organize();
        void MakeBudget();
        void Control();
    }
    class Director : Employee, IManager//implement/realize
    {
        public List<IWorkable> ListOfWorkers  { get ; set; }

        public void Control()
        {
            Console.WriteLine("Controling work.....");
        }

        public void MakeBudget()
        {
            Console.WriteLine("I count money!!!!");
        }

        public void Organize()
        {
            Console.WriteLine("Organize work.....");
        }
    }
    class Seller : Employee, IWorkable
    {
        private bool isWorking = true;
        public bool IsWorking { get { return isWorking; } }

        public string Work()
        {
            return "I sell products!!!!";
        }
    }
    class Cashier : Employee, IWorkable
    {
        private bool isWorking = true;
        public bool IsWorking { get { return isWorking; } }

        public string Work()
        {
            return "Getting pay for product!!!!";
        }
    }
    class Administrator : Employee, IWorkable, IManager
    {
        public bool IsWorking => true;

        public List<IWorkable> ListOfWorkers { get ; set ; }

        public void Control()
        {
            Console.WriteLine("Axaxaxax.... I am a big boss!!!!");
        }

        public void MakeBudget()
        {
            Console.WriteLine("I have a milion )))))))");
        }

        public void Organize()
        {
            Console.WriteLine("You must listen to me!!!");
        }

        public string Work()
        {
            return "I do my work(((((((";
        }
    }



    class Program
    {
        static void Main()
        {
            //Director director = new Director
            IManager director = new Director
            {
                FirstName = "Bob",
                LastName = "Tomson",
                Birthdate = new DateTime(1995, 7, 10),
                Position = "Big boss",
                Salary = 12000

            };
            Console.WriteLine(director);

            IWorkable seller = new Seller
            {
                FirstName = "Ivanka",
                LastName = "Petruk",
                Birthdate = new DateTime(2002, 7, 10),
                Position = "Seller",
                Salary = 500
            };
            Console.WriteLine(seller);
            Console.WriteLine(seller.Work());
            //Console.WriteLine(seller.Salary);

            if(seller is Seller)
                Console.WriteLine($"Seller salary { (seller as Seller).Salary }$");

            director.ListOfWorkers = new List<IWorkable>
            {
                seller,
                new Cashier
                {
                    FirstName = "Olya",
                    LastName = "Kuharchuk",
                    Birthdate = new DateTime(1999, 10,27),
                    Position = "Cashier",
                    Salary = 500
                },
                new Administrator
                {
                    FirstName = "Masha",
                    LastName = "Oliunuk",
                    Birthdate = new DateTime(1987, 10,27),
                    Position = "Administrator",
                    Salary = 1000
                }
            };
            Console.WriteLine("------------------------------");
            foreach (IWorkable item in director.ListOfWorkers)
            {
                if(item is Seller)
                    Console.WriteLine("Seller");

                if (item is Cashier)
                    Console.WriteLine("Cashier");

                Console.WriteLine(item);

                if(item.IsWorking)
                    Console.WriteLine(item.Work());
            }



            Administrator admin = new Administrator();//references - address


            IManager manager = admin;//address
            manager.Control();

            IWorkable worker = admin;
            worker.Work();




        }
    }

}