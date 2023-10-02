using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_IntroToOOP
{
    partial class Point
    {

        private int xCoord;
        //Properties
        public int XCoord
        {
            get
            {
                return xCoord;
            }
            set//value
            {
                if (value >= 0)
                    xCoord = value;
                else
                    xCoord = 0;
            }
        }
        private int yCoord;
        public int YCoord
        {
            get
            {
                return yCoord;
            }
            set//value
            {
                if (value >= 0)
                    yCoord = value;
                else
                    yCoord = 0;
            }
        }
    }

    partial class Point
    {
        public void SetX(int newX)
        {
            if (newX >= 0)
                xCoord = newX;
            else
                xCoord = 0;
        }
        public void SetY(int newY)
        {
            if (newY >= 0)
                yCoord = newY;
            else
                yCoord = 0;
        }

        public int getXCoord()
        {
            return xCoord;
        }
        public int getYCoord()
        {
            return yCoord;
        }

    }

    partial class Point
    {
        public void Print()
        {
            Console.WriteLine($"X : {xCoord}  Y : {yCoord}");
        }
        public override string ToString()
        {
            return $"Name : {Name} . X : {xCoord}  Y : {yCoord}";
        }

    }
}
