using System;

namespace VaxAppts
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            startMenu();
        }
        public static void startMenu()
        {
            //appointmentsAvailable auf false wenn keine Termine mehr (jedes Mal file checken und schauen ob Array != 0 ?)
            bool appointmentsAvailable = true;
            if (appointmentsAvailable)
            {
                Console.WriteLine("__________________________");
                Console.WriteLine("\u2022 What do you want to do?");
                Console.WriteLine("__________________________");
                Console.WriteLine("1. View free appointments");
                Console.WriteLine("2. Search for date");
            }
            else
            {
                Console.WriteLine("________________________________________________________");
                Console.WriteLine("\u2022 Sorry, currently there are no appointments available");
                Console.WriteLine(" If you like you can put your name on the waiting list");
                Console.WriteLine("________________________________________________________");
                Console.WriteLine("1. Put your name on the waiting list");
                Console.WriteLine("2. Exit App");
            }

            Console.WriteLine("3. Admin Log-In");
            int startSelect = Convert.ToInt32(Console.ReadLine());

            if (appointmentsAvailable)
            {
                switch (startSelect)
                {
                    case 1:
                        User.viewAvailableDates();
                        break;
                    case 2:
                        User.searchDate();
                        break;
                    case 3:
                        User.adminLogin();
                        break;
                }
            }
            else
            {
                switch (startSelect)
                {
                    case 1:
                        WaitingList.WaitingListStartScreen();
                        break;
                    case 2:
                        break;
                    case 3:
                        User.adminLogin();
                        break;
                }
            }

        }
    }
}
