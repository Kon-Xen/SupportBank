using System.Collections.ObjectModel;
using System.IO;
namespace Bank
{
    public class Menu
    {
        public int choice { get; set; }
        public int name { get; set; }

        public void menuA()
        {
            bool done = false;

            while (!done)
            {
                try
                {
                    Console.WriteLine("** Acount Manager **");
                    Console.WriteLine(" options : ");
                    Console.WriteLine(" 1 : List All");
                    Console.WriteLine(" 2 : List / name");

                    choice = int.Parse(Console.ReadLine());

                    done = (choice == 1 || choice == 2) ? true : false;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("invalid input. please try again !");
                }
            }
        }

        public void menuB(int numberOfNames)
        {
            bool done = false;
            int count = 0;

            while (!done)
            {
                try
                {
                    Console.WriteLine("choose one the accounts");
                   
                    name = int.Parse(Console.ReadLine());

                    done = (name <= numberOfNames) ? true : false;
                }

                catch (System.FormatException)
                {
                    Console.WriteLine("invalid input. please try again !");
                }
            }
        }
    }
}
