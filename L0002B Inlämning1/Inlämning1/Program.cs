/*
Oliver Gallo 000504-2916
oligal-1@student.ltu.se
Kurs: L0002B
*/

using System;

namespace Inlämning1
{
    class Program
    {
        //Main method
        static void Main(string[] args)
        {
            Program pg = new Program(); //create new object of class

            //try of the input/output part of the program, if the input did not have a nummeric value write error and starts the try all over
            //same with if the payed value was less then the original pricing
        First:
            try
            {
                Console.WriteLine("Ange pris: ");
                int price = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Betalat: ");
                int payed = Convert.ToInt32(Console.ReadLine());

                int result = payed - price;

                if(result > 0)
                Console.WriteLine("Totala tillbaka summan blev: " + result + "\n");

                pg.CountPrice(result);

                if (result < 0)
                { 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du kan inte betala mindre än vad det kostar\n");
                    Console.ResetColor();
                    goto First;
                }
              
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The given input have to be nummeric! \n");
                Console.ResetColor();
                goto First;
            }
        }

        //Method to count out the change back of the price. It counts with 500, 100, 50, 20 and coins 10, 5, 1
        //It only prints out the ones that are acctually in use
        void CountPrice(int pris)
        {
           int femhundra = pris / 500;
            pris %= 500;
            if(femhundra > 0)
                Console.WriteLine("Antal femhundra lappar: " + femhundra);

          int hundra = pris / 100; 
            pris %= 100;
            if (hundra > 0)
                Console.WriteLine("Antal hundra lappar: " + hundra);


          int femtiolapp = pris / 50;
            pris %= 50;
            if (femtiolapp > 0)
                Console.WriteLine("Antal femtio lappar: " + femtiolapp);


            int tjugolapp = pris / 20;
            pris %= 20;
            if (tjugolapp > 0)
                Console.WriteLine("Antal tjugo lappar: " + tjugolapp);

            int tio = pris / 10;
            pris %= 10;
            if (tio > 0)
                Console.WriteLine("Antal tio kroner: " + tio);

            int fem = pris / 5;
            pris %= 5;
            if (fem > 0)
                Console.WriteLine("Antal fem kroner: " + fem);

            int ett = pris / 1;
            pris %= 1;
            if (ett > 0)
                Console.WriteLine("Antal ett kroner: " + ett);
        }
    }
}
