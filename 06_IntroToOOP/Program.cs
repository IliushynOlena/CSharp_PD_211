using System.Security.Cryptography.X509Certificates;

namespace _06_IntroToOOP
{

    /*
     * Access Spetificators
    - private (default for fiels)
    - public 
    - protected
    - internal
    - protected internal
     
     */
    public class MyClass //: object
    {
        //class body
        private int number;
        private string name;
        private const float PI = 3.14f;
        private readonly int id = 10;
   
        public void Print()//private
        {
            Console.WriteLine($"Id : {id} . Name {name}");
        }
        public override string ToString()
        {
            return $"Id : {id} . Name {name}";
        }
    }
    //class MyClass1
    //{

    //}
    class DerivedClass : MyClass //public
    {

    }

    struct _2D_Point
    {
        public int x;
        public int y;
        public void Print()
        {
            Console.WriteLine($"x {x}. y {y}");
        }
    }
    partial class Point
    {
        //private string name;
        ////Properties
        //public string Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}       
        
        public string Name { get; set; }//private string name;
        //Auto property - prop + Tab
        public string Type { get; }//readonly property

        public string Color { get; private set; } = "Green";

        //full property
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }       
        static int count;
        static Point()
        {
            count = 0;
        }
        public Point(int value) : this(value, value)
        {
            //XCoord = value;
            //YCoord = value;
        }
        public Point(int x, int y)//: base()
        {
            XCoord = x;// SetX(x);
            YCoord = y;//SetY(y);               
        }     
      

    }
     class Program//internal
    {      
        static void Main(string[] args)
        {
            //Console.SetCursorPosition(10, 10);

            Point point = new Point(4,-7);
            point.Print();
            Console.WriteLine(point);

            point.SetX(4);
            point.Print();

            point.SetY(44); 
            point.Print();

            Console.WriteLine(point.getXCoord());;
            //properties
            point.XCoord = 100;//setter
            Console.WriteLine(point.XCoord);//getter

            point.Print();

            point.Name = "2_D_Point";//value - setter
            Console.WriteLine(point.Name);//getter
            Console.WriteLine(point);

            Point point2 = new Point(9);
            Console.WriteLine(point2);


            ////object obj = null;  
            //MyClass myClass = new MyClass();

            // //MyClass @class = new MyClass();
            // myClass.Print();
            // Console.WriteLine(myClass.ToString());




        }
    }
}