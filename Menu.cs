using System.IO;
namespace Bank
{
    public class Menu
    {

        public void show()
        {
            bool done = false;
            int choice;

            while (!done)
            {
                Console.WriteLine("** Acount Manager **");
                Console.WriteLine(" options : ");
                Console.WriteLine(" 1 : List All");
                Console.WriteLine(" 2 : List / name");

                choice = int.Parse(Console.ReadLine());

                done = (choice == 1 || choice == 2) ? true : false;

            }
        }

    }
}