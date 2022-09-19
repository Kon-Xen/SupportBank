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

        public void menuB(Dictionary<string, Account>.KeyCollection names)
        {
            bool done = false;
            int count = 0;

            while (!done)
            {
                try
                {
                    Console.WriteLine("choose one the accounts");

                    foreach (var name in names)
                    {
                        count++;
                        Console.WriteLine(count + " " + name + ", ");
                    }

                    name = int.Parse(Console.ReadLine());

                    done = (name <= names.Count) ? true : false;
                }

                catch (System.FormatException)
                {
                    Console.WriteLine("invalid input. please try again !");
                }
            }
        }
    }
}
