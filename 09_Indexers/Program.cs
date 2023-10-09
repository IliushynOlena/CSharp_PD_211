namespace _09_Indexers
{
    public class MultArray
    {
        private int[,] array;
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public MultArray(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            array = new int[rows, cols];
        }
        public int this[int r, int c]
        {
            get { return array[r, c]; }
            set { array[r, c] = value; }
        }
    }

    class Laptop
    {
        public string Model { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $" {Model}  {Price}";
        }
    }
    class Shop
    {
        Laptop[] laptops = null;//null
        public Shop(int size)
        {
            laptops = new Laptop[size];
        }
        public int Lenght
        {
            get { return laptops.Length; }
        }
        public void SetLaptop(int index, Laptop value)
        {
            laptops[index] = value;
        }
        public Laptop GetLaptop(int index)
        {
            if (index >= 0 && index < laptops.Length)
                return laptops[index];
            throw new IndexOutOfRangeException();
        }

        public Laptop this[int index]
        {
            get
            {
                if (index >= 0 && index < laptops.Length)
                    return laptops[index];
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index <= laptops.Length)
                    laptops[index] = value;
            }
        }

        public Laptop this[string name]
        {
            get
            {
                foreach (var item in laptops)
                {
                    if (item.Model == name)
                        return item;
                }
                return null;
            }
            private set
            {
                for (int i = 0; i < laptops.Length; i++)
                {
                    if (laptops[i].Model == name)
                    {
                        laptops[i] = value;
                        break;
                    }
                }
            }
        }
        public int FindByPrice(double price)
        {
            for (int i = 0; i < laptops.Length; i++)
            {
                if (laptops[i].Price == price)
                    return i;
            }
            return -1;
        }
        public Laptop this[double price]
        {
            get 
            {
                int index = FindByPrice(price); 
                if(index != -1) return laptops[index];
                throw new Exception("Incorrect price");
            
            }
            set 
            {
                int index = FindByPrice(price);
                if(index != -1)
                {
                    this[index] = value;
                }

            }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            MultArray multArray = new MultArray(2, 3);

            for (int i = 0; i < multArray.Rows; i++)
            {
                for (int j = 0; j < multArray.Cols; j++)
                {
                    multArray[i, j] = i + j;//indexator - set
                    Console.Write($"{multArray[i, j]} ");//indexator - get
                }
                Console.WriteLine();
            }
            */
            Shop shop = new Shop(3);

            //shop.SetLaptop(0, new Laptop() { Model = "HP", Price = 45520 });
            //var laptop = shop.GetLaptop(0);
            //Console.WriteLine(laptop);
            shop[0] = new Laptop() { Model = "HP", Price = 45520.10 };//set
            shop[1] = new Laptop() { Model = "Samsung", Price = 46000.99 };//set
            shop[2] = new Laptop() { Model = "Asus", Price = 30333.12 };//set
            var laptop = shop[0];//get
            Console.WriteLine(laptop);
            Console.WriteLine();



            Console.WriteLine($"Price 46000.99 : {shop[46000.99]}");
            Console.WriteLine($"Price 46000.99 : {shop[45520.10]}");

            shop[30333.12] = new Laptop() {  Model = "Mac", Price = 150000.33};

            try
            {
                for (int i = 0; i < shop.Lenght + 2; i++)
                {
                    Console.WriteLine(shop[i]);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(shop["Asus"]);//get
            //shop["Asus"] = new Laptop() { Model = "DELL", Price = 56325 };//set
            Console.WriteLine(shop["Asus"]);//get
            Console.WriteLine(shop["DELL"]);//get








        }
    }
}