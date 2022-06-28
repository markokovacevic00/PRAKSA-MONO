using System;
using System.Collections.Generic;

namespace Mono_praksa
{
    interface IBird
    {   
        string birdColor();
        bool cTalk();
    }
    class Parrot : IBird {
        public string parrotName;
        protected string parrotColor;

        public Parrot()
        {
            parrotName = "AAAA";
            parrotColor = "BBBB";
        }
        public Parrot(string pName, string pColor)
        {
            parrotName =  pName;
            parrotColor = pColor;

        }

        public string birdColor() {
            return parrotColor;
        }

        public bool cTalk() {return true;}
    }





    abstract class Clothes {

        private string name = "Clothes";
        public int clothesSize = 42;
        

        public abstract void PrintInfo();
        public void PrintSize()
        {
            Console.WriteLine(clothesSize);
        }

        public string CSize()
        {
            if (clothesSize < 30) { Console.WriteLine("S"); }
            else if (clothesSize > 30 && clothesSize < 40) { Console.WriteLine("M"); }
            else { Console.WriteLine("L"); }
            return "NaN";
        }

        public String clothesName
        {
            get{
                return name;
            }
            set{
                name = value;
            }
        }

    }

  
    class Pants : Clothes
    {

        private string pantsFit;
        private string pantsColor;

        public Pants(string pFit, string pColor)
        {
            pantsFit = pFit;
            pantsColor = pColor;
        }
        public Pants()
        {
            pantsFit = Console.ReadLine();
            pantsColor = Console.ReadLine();
        }

        
        override public void PrintInfo()
          {
            Console.WriteLine("Lower body");
            Console.WriteLine("Fit: " + pantsFit);
            Console.WriteLine("Color: " + pantsColor);

        }
    }

    class Jacket : Clothes
    {
        
        public string Season{ get; set; }
        override public void PrintInfo()
        {
            Console.WriteLine("Upper body");
        }
 

    }

    class Program
    {
        static void Main(string[] args)
        {
            Pants pants2 = new Pants();

            Jacket jacket1 = new Jacket();
            Jacket jacket2 = new Jacket();
            Jacket jacket3 = new Jacket();

            jacket1.Season = "Summer";
            jacket2.Season = "Autumn";
            jacket3.Season = "Spring";


            List<Jacket> listJacket = new List<Jacket>();
            listJacket.Add(jacket1);
            listJacket.Add(jacket2);
            listJacket.Add(jacket3);


            foreach (var jacket in listJacket)
            {
                Console.WriteLine(jacket.Season);
            }

            Pants pants1 = new Pants("regular", "yellow");
            pants1.PrintInfo();

            pants2.PrintInfo();
            Console.WriteLine("------------------");

            pants2.CSize();


            Console.WriteLine("------------------");
            
            jacket1.PrintSize();
            jacket1.clothesSize = 30;
            jacket1.PrintSize();



            Parrot parrot1 = new Parrot("CCCC","blue");
            Console.WriteLine("name = " + parrot1.parrotName);
            Console.WriteLine("color = " + parrot1.birdColor());



        }
    }
}
