/*
Oliver Gallo 000504-2916
oligal-1@student.ltu.se
Kurs: L0002B
*/

using System;
using System.Collections.Generic;
using System.IO;

namespace Inlämning2
{
    class Program
    {
        public List<Seller> seller = new List<Seller>(); //seller list

        //Main method to start the commandoloop and resets file in the DEMO.txt 
        static void Main(string[] args)
        {
            Program pg = new Program();
            File.WriteAllText("C:/Users/Admin/Desktop/C#_Luleå/Inlämning2/Demo.txt", string.Empty);

            pg.CommandoLoop();            
        }

        //Insperation taken from https://csharpskolan.se/article/insertion-sort/ , done with some modefication
        //Insertion sort to sort the sellers based on the amount of artickles they have sold
        public void InsertionSort(List<Seller> artikel)
        {
          
           for(int i = 1; i < artikel.Count; i++)
            {
               for(int j = i; j > 0; j--)
                {
                    if(artikel[j].getArtikel() < artikel[j - 1].getArtikel())
                    {
                        Seller tmp = artikel[j - 1];
                        artikel[j - 1] = artikel[j];
                        artikel[j] = tmp;
                    }
                    else                    
                        break;                    
                }
            }            
        }

        //commando loop to read the inputs and handle them
        void CommandoLoop()
        {
            String command;

            do
            {
                command = ReadCommand();
                HandleCommand(command);

            } while (command != "exit");
        }     
        
        //read the commands
        string ReadCommand()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<Write '1' to add new seller, Write 2 to see all the sellers and write 'exit' to save the list to file and exit program \n");
            Console.ResetColor();
            string command = Console.ReadLine();
            return command;
        }

        //Handles commands such as adding new sellers, sortinga nd displaying them and exiting the program and saving it meanwhile
        void HandleCommand(string command)
        {
            switch (command)
            {
                case "1":
                    AddSeller();
                    break;
                case "2":
                    InsertionSort(seller);
                    PrintArray(seller);
                    break;
                case "exit":
                    InsertionSort(seller);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Följande tabell kommer att sparas till Demo.txt filen!\n");
                    Console.ResetColor();
                    PrintArray(seller);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Hejdå!");
                    Console.ResetColor();
                    break;
            } 
        }

        //Writes the result to a file in the same folder, but bc it didnt print out the way it was displayed this method is not used in the program
        /*
        void WriteSellerToFile()
        {
            InsertionSort(seller);
            Console.WriteLine("Everything have been saved");
            string writer = "C:/Users/Admin/Desktop/C#_Luleå/Inlämning2/Demo.txt";
            seller.ForEach(item => File.AppendAllText(writer, item + Environment.NewLine));
        }
        */

        //Adds seller to a list with a name, personalnumber, distrcit and amount of sold artickels, if format fails tries again
        void AddSeller()
        {
        First:
            try
            {               
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Personnummer: ");
                long persnr = Int64.Parse(Console.ReadLine());

                Console.WriteLine("Distrikt: ");
                string distrikt = Console.ReadLine();

                Console.WriteLine("artikel: ");
                int artikel = int.Parse(Console.ReadLine());

                Seller s = new Seller(name, persnr, distrikt, artikel);
                seller.Add(s);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe input must be the following format ==> Text , Number, Text, Number, Please try again");
                Console.ResetColor();
                goto First;
            }
        }

        //Displays the items in the array with the 4 cathegories that was the requirement of the assingment and writes them to the file as they are
        //this method gets called in the end of the program and bc of that it will always prints out the correct result to the DEMO.txt file in the same folder
        void PrintArray(List<Seller> artikel)
        {
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            string line = "";

            if (artikel.Count == 0)
                Console.WriteLine("There is no sellers in the list");

            foreach (var item in artikel)
            {
                if (item.getArtikel() < 50)
                {
                    a++;
                    Console.WriteLine(item);
                    line += item.ToString() + '\n';
                }
            }
            if (a > 0)
            {
                Console.WriteLine(a + " Har nått nivå 1: under 50 artiklar\n");
                line += a + " Har nått nivå 1: under 50 artiklar\n\n";
            }

            foreach (var item in artikel)
            {
                if (item.getArtikel() < 99 && item.getArtikel() > 50)
                {
                    b++;
                    Console.WriteLine(item);
                    line += item.ToString() + '\n';
                }
            }

            if (b > 0)
            {
                Console.WriteLine(b + " Har nått nivå 2: 50-99 artiklar\n");
                line += b + " Har nått nivå 1: under 50 artiklar\n\n";
            }

            foreach (var item in artikel) 
            {
                if (item.getArtikel() < 199 && item.getArtikel() > 100)
                {
                    c++;
                    Console.WriteLine(item);
                    line += item.ToString() + '\n';
                }
            }

            if (c > 0) {
                Console.WriteLine(c + " Har nått nivå 3: 100-199 artiklar\n");
                line += c + " Har nått nivå 1: under 50 artiklar\n\n";
            }

            foreach (var item in artikel)
            {
                if (item.getArtikel() > 199)
                {
                    d++;
                    Console.WriteLine(item);
                    line += item.ToString() + '\n';
                }
            }

            if (d > 0)
            {
                Console.WriteLine(d + " Har nått nivå 4: över 199 artiklar\n");
                line += d + " Har nått nivå 1: under 50 artiklar\n\n";
            }
            string writer = "C:/Users/Admin/Desktop/C#_Luleå/Inlämning2/Demo.txt";
            File.AppendAllText(writer, line + Environment.NewLine);
        }
    }

    //Seller class to be able to create a seller object
    public class Seller
    {
        string name {get;}
        long persnr {get;}
        string distrikt {get;}
        int artikel {get;}
        public Seller(string name, long persnr, string distrikt, int artikel)
        {
            this.name = name;
            this.persnr = persnr;
            this.distrikt = distrikt;
            this.artikel = artikel;
        }  
        
        //override of tostring method for a correct output
        public override string ToString()
        {
            return this.name + " " + this.persnr + " " + this.distrikt + " " + this.artikel;
        }

        //gets the artickel in order to sort correctly
        public int getArtikel()
        {
            return artikel;
        }
    }
}                        