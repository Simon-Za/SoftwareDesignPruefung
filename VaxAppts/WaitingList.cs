using System;

namespace VaxAppts
{
    public class WaitingList
    {
        public static void WaitingListStartScreen()
        {
            Console.WriteLine("\u2022 Do you want to put your name on the list?");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. Exit");
            int waitingListSelect = Convert.ToInt32(Console.ReadLine());

            if(waitingListSelect == 1)
            {
                enterCredentials();
            }
            else
            {
                backToHomescreen();
            }
        }
        private static void enterCredentials()
        {
            Console.WriteLine("\u2022 Please enter your credentials below");

            //An der Stelle maybe ein Objekt erstellen mit: E-Mail, Vor-, Nachname, Geburtstag, Tel, Adresse ?

            Console.Write("E-Mail: ");
            String userMail = Console.ReadLine();
            Console.Write("First Name: ");
            String userFirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            String userLastName = Console.ReadLine();
            Console.Write("Date of Birth: ");
            String userBirthday = Console.ReadLine();
            Console.Write("Phone number: ");
            String userPhoneNumber = Console.ReadLine();
            Console.Write("Address: ");
            String userAddress = Console.ReadLine();
        }
        private static void backToHomescreen()
        {
            MainClass.startMenu();
        }
    }
}