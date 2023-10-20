using System;

namespace _16_Dictionary
{
    public delegate int ArrayDelegate();
    public delegate void VoidDelegate();

    class Array
    {
        int[] array = new int[] { 1, 12, 3, 13 ,-17, -10, -24, -35 };
        public int NegativeNumbers()
        {
            int a = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    ++a;
                   // Console.WriteLine(a + " " + array[i]);
                }

            }
            return a;
        }
        public void Print()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        public int SumNumber()
        {
            return array.Sum();
        }
        public int EasyNumbers()
        {
            int a = 0;
            for (int i = 2; i <= array.Length / 2; i++)
            {
                if (array[i] % i == 0)
                {
                    a++;
                }
            }
            return a;
        }
        public void ChangingNegativeNumbers()
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    array[i] = 0;
                }
            }
        }
        public void SortArray()
        {
            System.Array.Sort(array);
        }
        public void MovingElementsArray()//переміщення елементів у масиві
        {
            int left = 0;
            int right = array.Length - 1;
            while (left < right)
            {
                while (left < right && array[left] % 2 == 0)
                {
                    left++;
                }

                while (left < right && array[right] % 2 != 0)
                {
                    right--;
                }

                if (left < right)
                {
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    left++;
                    right--;
                }
            }
        }
    }
    static class MyClass
    {
        //public static string GoToPassword(this string s, int key)
        //{
        //    char[] a = s.ToCharArray();
        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        a[i] = a[i] + char.Parse(key);
        //    }
        //    string res = a.ToString();
        //    return res;
        //}
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Array array = new Array();
            array.Print();
            array.MovingElementsArray();
            array.Print();

            ArrayDelegate delegate1 = new ArrayDelegate(array.NegativeNumbers);
            delegate1 += array.SumNumber;
            delegate1 += array.EasyNumbers;

            Console.WriteLine("1- NegativeNumbers;2 - SumNumber ; 3 - EasyNumbers;");
            int key = int.Parse(Console.ReadLine());

            var  collection = delegate1.GetInvocationList();
            Console.WriteLine((collection[key-1] as ArrayDelegate).Invoke()); ;
            //foreach (var item in delegate1.GetInvocationList())
            //{
            //    Console.WriteLine((item as ArrayDelegate).Invoke());
            //}


        }
    }
}