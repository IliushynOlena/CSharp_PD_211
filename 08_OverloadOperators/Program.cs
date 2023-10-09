using System.Diagnostics;

namespace _08_OverloadOperators
{
    class Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public Point3D() : this(0, 0, 0) { }
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;  
        }
        public override string ToString()
        {
            return $" X : {X} , Y {Y} , Z {Z}";
        }
    }
    class Point : Object
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point() : this(0, 0) { }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
            
        }
        //public override string ToString()
        //{
        //    return $" X : {X} , Y : {Y}";
        //}
        public override string ToString()
        {
            return $" X : {X} , Y {Y}";
        }
        public void Print()
        {
            Console.WriteLine($" X : {X} , Y {Y}");
        }

        public override bool Equals(object? obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
        //ref and out - not allowed
        //public static return_type operator[symvol](parameters)
        //{ }

        public static Point operator-(Point p)
        {
            Point p1 = new Point 
            { 
                X = p.X * -1, 
                Y = p.Y * -1
            };
            return p1;
        }
        public static Point operator ++(Point p)
        {
            p.X++;
            p.Y++;
            return p;
        }
        public static Point operator --(Point p)
        {
            p.X--;
            p.Y--;
            return p;
        }

        #region Bynary Operators
        public static Point operator+(Point p1, Point p2)
        {
            Point p3 = new Point
            {
                X = p1.X + p2.X,
                Y = p1.Y + p2.Y
            };
            return p3;
        }
        public static Point operator -(Point p1, Point p2)
        {
            Point p3 = new Point
            {
                X = p1.X - p2.X,
                Y = p1.Y - p2.Y
            };
            return p3;
        }
        public static Point operator *(Point p1, Point p2)
        {
            Point p3 = new Point
            {
                X = p1.X * p2.X,
                Y = p1.Y * p2.Y
            };
            return p3;
        }
        public static Point operator /(Point p1, Point p2)
        {
            Point p3 = new Point
            {
                X = p1.X / p2.X,
                Y = p1.Y / p2.Y
            };
            return p3;
        }
        #endregion

        #region Logic Operators
        public static bool operator ==(Point p1, Point p2)
        {
            
            return p1.Equals(p2);
            //return p1.X == p2.X && p1.Y == p2.Y;
        }
        //pair
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
            //return p1.X != p2.X && p1.Y != p2.Y;
        }
        public static bool operator >(Point p1, Point p2)
        {
            return p1.X + p1.Y > p2.X + p2.Y;           
        }
        //in pair
        public static bool operator <(Point p1, Point p2)
        {
            return !(p1>p2);
        }
        public static bool operator >=(Point p1, Point p2)
        {
            return p1.X + p1.Y >= p2.X + p2.Y;
        }
        //in pair
        public static bool operator <=(Point p1, Point p2)
        {
            return !(p1 >= p2);
        }
        #endregion

        #region true/false operators
        public static bool operator true(Point p)
        {
           return (p.X != 0) || (p.Y != 0); 
        }
        //in pair
        public static bool operator false(Point p)
        {
            return (p.X == 0) && (p.Y == 0);
        }
        #endregion

        #region Overload Types
        public static implicit operator int(Point p)
        {
            return p.X + p.Y;
        }
        public static implicit operator double(Point p)
        {
            return p.X + p.Y;
        }
        public static explicit operator Point3D(Point p)
        {
            return new Point3D(p.X, p.Y, 0);
        }
        #endregion
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 5;//int -> int
            double b = 6.7;//double -> double

            b = a;// int  -> double 5.0000000000000 - implicit

           // a = b;//double -> int 6 - implicit - error
            a = (int)b;//double -> int 6 - explicit
            Point newP = new Point(3,3);

            a = newP;//Point -> int - implicit
            Console.WriteLine(a);
            b = newP;//Point -> double  - implicit
            Console.WriteLine(b);
            Point3D p = (Point3D) newP;//Point -> Point3D
            Console.WriteLine(p);






            Point point1 = new Point() { X = 0, Y = 0};
            Point point2 = new Point() { X = 5, Y = 9};
            if(point1)
                Console.WriteLine("Point is true");
            else
                Console.WriteLine("Point is false");

            if (point1.Equals(point2))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("False");
            }
            //point.Print();
            //Console.WriteLine(point.ToString());
            //Console.WriteLine(point);

            Point res = -point1;
            Console.WriteLine($" operator-  :  {res}");
            Console.WriteLine($" Original  :  {point1}");

            Console.WriteLine($" Original  :  {point1++}");
            Console.WriteLine($" Original  :  {++point1}");
            Console.WriteLine($" Original  :  {point1--}");
            Console.WriteLine($" Original  :  {--point1}");

            res = point1 + point2;
            Console.WriteLine($" operator +  :  {res}");
            res = point1 - point2;
            Console.WriteLine($" operator -  :  {res}");
            res = point1 * point2;
            Console.WriteLine($" operator *  :  {res}");
            res = point1 / point2;
            Console.WriteLine($" operator /  :  {res}");


            object obj = new object();//00dd5d5d5d5
            string str = "Hello";//00dd5d5d5d5
            string str2 = "Hello";//
            Console.WriteLine(str);
            Console.WriteLine(str2);
            str2 += "!!!!";
            Console.WriteLine(str);
            Console.WriteLine(str2);

            if (str.Equals(str2))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("False");
            }

            if(point1==point2)
            {
                Console.WriteLine("Point is equals!!!");
            }
            else
            {
                Console.WriteLine("Point is not equals!!!");
            }
            if (point1 > point2)
            {
                Console.WriteLine("Point 1 > Point 2!!!");
            }
            else
            {
                Console.WriteLine("Point 2 > Point 1!!!");
            }














        }
    }
}