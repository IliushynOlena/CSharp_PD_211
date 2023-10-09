using System.Drawing;
using System.Security.Cryptography;

namespace _07_StructRefOut
{
    //using _2D_Object;

    partial struct MyStruct
    {
        public int MyProperty { get; set; }
    }
    partial struct MyStruct
    {
        public int MyProperty1 { get; set; }
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point()
        {
            X = 0;
            Y = 0;
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Print()
        {
            Console.WriteLine($" X {X} . Y {Y}");
        }
    }
    /*
    * Access Spetificators
   - private (default for fiels)
   - public 
   - protected
   - internal
   - protected internal

    */
    //struct Rectangle
    //{
    //    public int Height { get; set; }
    //    public int Width { get; set; }
    //    public void Print()
    //    {
    //        Console.WriteLine($"Rectangle : {Height} - {Width}");
    //    }
    //   // public Rectangle() = default;//not allow to implement

    //    public Rectangle(int h, int w)
    //    {
    //        Height = h; 
    //        Width = w;  
    //    }
    //}
    class Rectangle
    {
        private int height;
        public int Height
        {
            get { return height; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Invalid height");
                height = value;
            }
        }
        public int Width { get; set; }

        void Edit(int n)
        {
            Height = n;//135465465465456465456
        }
        public void Print()
        {
            Console.WriteLine($"Rectangle : {Height} - {Width}");
        }
        // public Rectangle() = default;//not allow to implement
        public Rectangle()
        {

        }
        public Rectangle(int h, int w)
        {
            Height = h;
            Width = w;
        }
    }
    internal class Program
    {
        //params - set many parameter
        static void MethodWithParams(string name,params int[]marks)
        {
            Console.WriteLine("-----------" + name + "---------------");
            foreach (var item in marks)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static void Modify(ref int num,ref  string str,ref Point point)
        {
            num += 1;
            str += "!";
            point.X++;
            point.Y++;
        }
        
        //static void GetCurrentTime(ref int hour,ref int minute, ref int sec)
        //{
        //     hour = DateTime.Now.Hour;
        //     minute = DateTime.Now.Minute;
        //     sec = DateTime.Now.Second;
        //    Console.WriteLine($"Time : {hour}:{minute}:{sec}");

        //}
        static void GetCurrentTime(out int hour, out int minute, out int sec)
        {
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            sec = DateTime.Now.Second;
            Console.WriteLine($"Time : {hour}:{minute}:{sec}");

        }

        static void Main(string[] args)
        {
            //Console.ReadKey()== ConsoleKey.Escape
            try
            {

                string name = Console.ReadLine();
                DateTime a = DateTime.Parse(name);
                Console.WriteLine(a);
                float price = float.Parse(Console.ReadLine());
              

                Console.WriteLine(name);
                Console.WriteLine(price);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
            try
            {
                Rectangle rectangle = new Rectangle() { Height = 0, Width = 100 };
                rectangle.Print();

                rectangle.Height--;
                rectangle.Print();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument exeption!!!!");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           
            Console.WriteLine("Continue................");



            /*

            Point point = new Point();//references type - new - get dynam memory

            Rectangle r = new Rectangle();//value type - new - default constructor

            int a;
            */
            //int h = 0, m = 0, s = 0 ;
            //Console.WriteLine($"Time : {h}:{m}:{s}");
            //GetCurrentTime(ref h,ref  m,ref s);
            //Console.WriteLine($"Time : {h}:{m}:{s}");
            /*
            int h, m, s;
            //Console.WriteLine($"Time : {h}:{m}:{s}");
            GetCurrentTime(out h, out m, out s);
            Console.WriteLine($"Time : {h}:{m}:{s}");

            
            int num = 10;
            string str = "Hello academy";
            Point point = new Point() { X = 5, Y = 5 };
            Console.WriteLine($"num  : {num}");
            Console.WriteLine($"str  : {str}");
            point.Print();
            Modify(ref num,ref str,ref point);
            Console.WriteLine();
            Console.WriteLine($"num  : {num}");
            Console.WriteLine($"str  : {str}");
            point.Print();
            */
            /*
            string name = "Ivanka";
            int[] marks = { 11, 12, 10, 9, 7, 10 };
            MethodWithParams(name, marks);
            MethodWithParams("Bob", new int[] {10,10,10,10,1,2,5,6,8,9,7});
            MethodWithParams("Tom", 10,10,10,10,1,2,5,6,8,9,7);//initializer_list
            */
            /*
            Point point = new Point();
            point.Print();
         
            _2D_Object.Point point1 = new _2D_Object.Point();
           //Point point1 = new Point();
            point1.Print();*/

        }
    }
}
namespace _2D_Object
{
    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public void Print()
        {
            Console.WriteLine($"Space : _2D_Object.  X {X} . Y {Y}");
        }
    }
}
namespace _3D_Object
{
    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public void Print()
        {
            Console.WriteLine($"Space : _3D_Object.  X {X} . Y {Y}. Z {Z}");
        }
    }
}