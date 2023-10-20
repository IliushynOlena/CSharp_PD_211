namespace _13_Delegates
{
    //class MyDelegate: MulticastDelegate
    //{

    //}

    public delegate void SetStringDelegate(string str); 
    public delegate double GetDoubleDelegate();
    public delegate void VoidDelegate();

    public class SuperClass
    {
        public void Print(string str)
        {
            Console.WriteLine("String " + str);
        }
        public static double GetCoef()
        {
            double res = new Random().NextDouble();
            return res;
        }
        public double GetNumber()
        {
            return new Random().Next();
        }
        public void DoWork()
        {
            Console.WriteLine("Doing work......");
        }
        public void Test()
        {
            Console.WriteLine("Testing.....");
        }

    }
    public delegate double CalcDelegate(double x, double y);
    class Calculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public double Sub(double x, double y)
        {
            return x - y;
        }
        public double Multy(double x, double y)
        {
            return x * y;
        }
        public double Div(double x, double y)
        {
            if(y!= 0)
                return x / y;
            throw new DivideByZeroException();
        }
    }
    internal class Program
    {
        public static void DoOperation(double a, double b, CalcDelegate operation)
        {
            Console.WriteLine(operation.Invoke(a, b));
        }
        public delegate int ChangeDelegate(int i);
        public static void ChangeElement(int[] arr, ChangeDelegate change)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = change.Invoke(arr[i]);
            }
        }
        public static int Sqr(int v)
        {
            return v * v;
        }
        public static int Inrementer(int v)
        {
            return ++v;
        }

        static void Main(string[] args)
        {
            
            int[] arr = new int[] { 11, 4, 8, 9, 6, 25, 7 };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            //ChangeElement(arr, Sqr);
            //ChangeElement(arr, Inrementer);
            //ChangeElement(arr, delegate (int v) { return v * v; });

            //ChangeElement(arr, delegate (int i) { return i + 10; });
            ChangeElement(arr, (v) =>  v + 10);
            //ChangeElement(arr, (v) => v * v);
            //foreach (var item in arr) Console.Write(item + " "); Console.WriteLine();
            //ChangeElement(arr, (v) => v * 2);
            //foreach (var item in arr) Console.Write(item + " "); Console.WriteLine();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            //ChangeElement(arr, Inrementer);
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}
            //Console.WriteLine();



            /*
            Calculator calculator = new Calculator();
            CalcDelegate operation = calculator.Add;
            operation += calculator.Sub;
            operation += calculator.Multy;
            operation += calculator.Div;
            operation -= calculator.Div;

            Console.WriteLine("Last operation : " + operation(10, 5));
            foreach (CalcDelegate item in operation.GetInvocationList())
            {
                Console.WriteLine($" {item.Method.Name} - Result {item.Invoke(145, 3)}");
            }

            Console.WriteLine("------------------------");
            DoOperation(100, 12, operation);
            DoOperation(100, 12, calculator.Add);
            DoOperation(100, 12, calculator.Sub);
            DoOperation(100, 12, calculator.Multy);
            */
            /*
            Calculator calculator = new Calculator();
            double x, y;
            int key;
            do
            {
                CalcDelegate calcDelegate = null;
                Console.WriteLine("Enter first number ");
                x = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter second number ");
                y = double.Parse(Console.ReadLine());
                Console.WriteLine("Add  - 1 ");
                Console.WriteLine("Sub  - 2 ");
                Console.WriteLine("Mult  - 3 ");
                Console.WriteLine("Divide  - 4 ");
                Console.WriteLine("Exit  - 0 ");
                key = int.Parse(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        calcDelegate = new CalcDelegate(calculator.Add);
                        break;
                    case 2:
                        calcDelegate = new CalcDelegate(calculator.Sub);
                        break;
                    case 3:
                        calcDelegate = calculator.Multy;
                        break;
                    case 4:
                        calcDelegate = calculator.Div;
                        break;
                    case 0:
                        Console.WriteLine("Good  Buy");
                        break;
                    default:
                        Console.WriteLine("Error choice......");
                        break;
                }

                Console.WriteLine("Res = " + calcDelegate?.Invoke(x, y));
            } while (key != 0);
            */
            /*
            Console.WriteLine(SuperClass.GetCoef());
            //GetDoubleDelegate method = new GetDoubleDelegate(SuperClass.GetCoef);
            GetDoubleDelegate method =  SuperClass.GetCoef;
            //Console.WriteLine(method());
            Console.WriteLine(method?.Invoke());
            SuperClass super = new SuperClass();

            GetDoubleDelegate[] arr = new GetDoubleDelegate[]
            {
                SuperClass.GetCoef,
                new GetDoubleDelegate(super.GetNumber)
            };
            Console.WriteLine(arr[0].Invoke()); ;
            Console.WriteLine(arr[1].Invoke()); ;

            SetStringDelegate stringDelegate = new SetStringDelegate(super.Print);
            VoidDelegate voidDelegate = new VoidDelegate(super.DoWork);

            stringDelegate.Invoke("Hello friends!!!!");
            voidDelegate.Invoke();


            //Delegate.Combine(voidDelegate, new VoidDelegate(super.Test));
            //Delegate.Combine(voidDelegate, super.Test);
            Console.WriteLine("-------------------------------");
            voidDelegate += new VoidDelegate(super.Test);

            foreach (var item in voidDelegate.GetInvocationList())
            {
                (item as VoidDelegate).Invoke();
            }
            */
        }
    }
}