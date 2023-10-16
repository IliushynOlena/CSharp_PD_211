using System.Collections;

namespace _12_StandartInterface
{
    class StudentCard :ICloneable
    {
        public int Number { get; set; }//1111111 - 11111
        public string Series { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"Student Card : {Number}, { Series}";
        }
    }
    class Student : IComparable<Student>, ICloneable //IComparable
    {
        public string FirstName { get; set; }//00x25879  - 00x25879
        public string LastName { get; set; }//00d5dd5d5d  - 00d5dd5d5d
        public DateTime Birthday { get; set; }//2000.5.14  -   2000.5.14
        public StudentCard StudentCard { get; set; }//00x5555  -00x5555

        public object Clone()
        {
            Student clone = (Student) this.MemberwiseClone();
            //clone.StudentCard = new StudentCard
            //{
            //    Number = this.StudentCard.Number,
            //    Series = this.StudentCard.Series
            //};
            clone.StudentCard = (StudentCard) this.StudentCard.Clone();


            return clone;
        }

        public int CompareTo(Student? other)
        {
            return this.LastName.CompareTo(other.LastName);
        }
        //public int CompareTo(object? obj)
        //{ 
        //    if( obj is Student)
        //    {
        //        return this.LastName.CompareTo((obj as Student).LastName);
        //    }
        //    throw new NotImplementedException();
        //}
        public override string ToString()
        {
            return $"{FirstName} {LastName}, Birthday : {Birthday.ToShortDateString()}\n" +
                $"{StudentCard}\n";
        }
    }
    class Auditory : IEnumerable
    {
        //Array
        Student[] students =
        {
            new Student
            {
                 FirstName = "Vova",
                 LastName = "Oliunuk",
                 Birthday = new DateTime(2000,5,15),
                 StudentCard = new StudentCard{ Number = 123456, Series = "AA"}
            },
            new Student
            {
                 FirstName = "Sasha",
                 LastName = "Petruk",
                 Birthday = new DateTime(2002,12,1),
                 StudentCard = new StudentCard{ Number = 654321, Series = "BB"}
            },
            new Student
            {
                 FirstName = "Bob",
                 LastName = "Tomson",
                 Birthday = new DateTime(2005,10,25),
                 StudentCard = new StudentCard{ Number = 147852, Series = "AA"}
            },
            new Student
            {
                 FirstName = "Candice",
                 LastName = "Leman",
                 Birthday = new DateTime(2003,5,15),
                 StudentCard = new StudentCard{ Number = 369852, Series = "CC"}
            },
            new Student
            {
                 FirstName = "Nicole",
                 LastName = "Cadman",
                 Birthday = new DateTime(2000,5,15),
                 StudentCard = new StudentCard{ Number = 123456, Series = "AA"}
            }
        };
        public IEnumerator GetEnumerator()
        {
            return students.GetEnumerator();    
        }
        public void Sort()
        {
            Array.Sort(students);
        }
        public void Sort(IComparer<Student> compare)
        {
            Array.Sort(students, compare);
        }
    }

    class FirstNameComparer : IComparer<Student> //IComparer
    {
        //public int Compare(object? x, object? y)
        //{
        //    if (x is Student && y is Student)
        //    {
        //        return (x as Student).FirstName.CompareTo((y as Student).FirstName);

        //    }
        //    throw new NotImplementedException();
        //}
        public int Compare(Student? x, Student? y)
        {
            return x.FirstName.CompareTo(y.FirstName);
        }
    }
    class BirthdayComparer : IComparer<Student> //IComparer
    {
        public int Compare(Student? x, Student? y)
        {
            return x.Birthday.CompareTo(y.Birthday);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student
            {
                FirstName = "Nicole",
                LastName = "Cidman",
                Birthday = new DateTime(2000, 5, 15),
                StudentCard = new StudentCard { Number = 123456, Series = "AA" }
            };
            Console.WriteLine(student);
            Student copy = (Student) student.Clone();
            Console.WriteLine(copy);

            copy.StudentCard.Number = 111111;
            copy.FirstName = "Olivia";
            Console.WriteLine(student);
            Console.WriteLine(copy);

            /*
            Auditory auditory = new Auditory();
            Console.WriteLine("Sort by Last Name : ");
            auditory.Sort();

          
            foreach (Student student in auditory)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("Sort by First Name : ");
            auditory.Sort(new FirstNameComparer());
            foreach (Student student in auditory)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("Sort by Birtday : ");
            auditory.Sort(new BirthdayComparer());
            foreach (Student student in auditory)
            {
                Console.WriteLine(student);
            }
            */

        }
    }
}