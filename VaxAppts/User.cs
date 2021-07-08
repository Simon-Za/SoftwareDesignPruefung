using System;

namespace VaxAppts
{
    public class User
    {

        public static void adminLogin()
        {
            String _adminID = "VaxMaster69";
            String _adminPassword = "VacciGang";

            //bei Bedarf kann hier noch Regex und Datenabgleich (dokument auslesen etc) rein
            Console.WriteLine("__________________________");
            Console.WriteLine("\u2022 Please enter your Admin ID and Password or press Enter to return to the menu");
            Console.WriteLine("_________________________________________________________________________________");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Admin ID: ");
            String adminEntry = Console.ReadLine();
            if (adminEntry == "")
            {
                MainClass.startMenu();
            }
            Console.Write("Password: ");
            String passwordEntry = Console.ReadLine();

            if (adminEntry == _adminID && passwordEntry == _adminPassword)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("________________");
                Console.WriteLine("LogIn successful");
                Console.WriteLine("________________");
                Console.WriteLine("");
                Console.WriteLine("");

                Admin.adminScreen();
            }
            else
            {
                Console.WriteLine("Sorry, wrong input :/");
                adminLogin();
            }

        }

        public static void viewAvailableDates()
        {
            //hier müssen die vom Admin angelegten Daten ausgelesen werden 
        }
        public static void searchDate()
        {
            //siehe viewAbailableDates();
        }
    }
}