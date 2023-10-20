namespace _14_Events
{
    public delegate void FinishAction();
    public delegate void ExamDelegate(string task);  
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public void PassExam(string task)
        {
            Console.WriteLine($"Student {LastName } {FirstName} pass the exam { task}");
        }
    }
    class Teacher
    {
        //public ExamDelegate ExamDelegate;//MultiCast Delagete
        //public event ExamDelegate ExamDelegate;//MultiCast Delagete  -- auto prop
        //full event
        private ExamDelegate examDelegate;
        public event ExamDelegate ExamDelegate
        {
            add 
            { 
                examDelegate += value;
                Console.WriteLine(value.Method.Name +  " was added!!!");
            }
            remove 
            { 
                examDelegate -= value; 
                Console.WriteLine(value.Method.Name +  " was removed!!!");
            }
        }

        public event Action TestEvent;//MultiCast Delagete

        public void Create(string task)
        {
          
            //exam creating......
            ///some code

            //call event - call students
            examDelegate?.Invoke(task);
        }
        public void StartAction()
        {
            TestEvent?.Invoke();
        }

    }
    internal class Program
    {
        #region CallBack
        static void HardWord(FinishAction action)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Operation {i + 1} working.......");
                Thread.Sleep(random.Next(500));
                Console.WriteLine($"Operation {i + 1} finished.......");

            }
            action.Invoke();
        }
        static void Action1()
        {
            Console.WriteLine("Good bye!!!!!");
        }
        static void Action2()
        {
            Console.WriteLine("Good Job!!!!!");
        }
        static void Action3()
        {
            Console.WriteLine("Very bad!!!!!");
        }
        #endregion      

        static void Main(string[] args)
        {
            #region Event
            List<Student> students = new List<Student>
            {
                new Student
                {
                     FirstName = "Vova",
                     LastName = "Oliunuk",
                     Birthday = new DateTime(2000,5,15)
                },
                new Student
                {
                     FirstName = "Sasha",
                     LastName = "Petruk",
                     Birthday = new DateTime(2002,12,1)
                },
                new Student
                {
                     FirstName = "Bob",
                     LastName = "Tomson",
                     Birthday = new DateTime(2005,10,25)
                },
                new Student
                {
                     FirstName = "Candice",
                     LastName = "Leman",
                     Birthday = new DateTime(2003,5,15)
                },
                new Student
                {
                     FirstName = "Nicole",
                     LastName = "Cadman",
                     Birthday = new DateTime(2000,5,15)
                }
            };


            Teacher teacher = new Teacher();

            foreach (Student st in students)
            {
                teacher.ExamDelegate += new ExamDelegate(st.PassExam);
            }

            teacher.ExamDelegate -= students[4].PassExam;
            //teacher.ExamDelegate = null;

            teacher.Create("C# exam in Microsoft Team at 15:00 PM 20.10.2023");

            /*
            teacher.TestEvent += Console.Clear;
            teacher.TestEvent += delegate () { Console.ForegroundColor = ConsoleColor.Green; };
            teacher.TestEvent += () => Console.Beep(400, 1000);
            teacher.TestEvent += Teacher_TestEvent;
            teacher.TestEvent -= Teacher_TestEvent;
            //teacher.TestEvent -= delegate () { Console.ForegroundColor = ConsoleColor.Green; };

            teacher.StartAction();
            */
            #endregion
            #region CallBack
            /*
           Action1();
           HardWord(Action1);
           HardWord(Action2);
           HardWord(Action3);
           HardWord(delegate () { Console.WriteLine("You must work more!!!"); });
           */
            #endregion        }
        }

        private static void Teacher_TestEvent()
        {
            Console.WriteLine("Auto-created method by pressing TAB!!!");
        }
    }
}