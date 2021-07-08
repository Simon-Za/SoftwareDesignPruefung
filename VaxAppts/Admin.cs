using System;

namespace VaxAppts
{
    public class Admin
    {
        public static void adminScreen()
        {
            Console.WriteLine("\u2022 Welcome back Vaxmaster69");
            Console.WriteLine("___________________________");
            Console.WriteLine("");
            Console.WriteLine("1. Create new appointments");
            Console.WriteLine("2. View specific day");
            Console.WriteLine("3. View Statistics");
            int adminSelect = Convert.ToInt32(Console.ReadLine());

            switch (adminSelect)
            {
                case 1:
                    createNewAppt();
                    break;
                case 2:
                    dayOverview();
                    break;
                case 3:
                    viewStats();
                    break;
            }
        }
        public static void createNewAppt()
        {
            Console.WriteLine("\u2022 Please tell me for which day you want to create a new appointment");
            Console.WriteLine("___________________________________________________________________");
            Console.WriteLine("");
            //hier maybe einfach ne Eingabe, die mit schon erstellten Tagen abgleicht (wenn Tag schon vergeben: Meldung ggf. Option Tag zu löschen?? vllt lieber bei 2)
        }
        public static void dayOverview()
        {
            Console.WriteLine("\u2022 Please select the day you want to see");
            Console.WriteLine("_______________________________________");
            Console.WriteLine("");
            //hier Dok auslesen und Datumsobjekte darstellen
        }
        public static void viewStats()
        {
            Console.WriteLine("\u2022 Welcome to general statistics!");
            Console.WriteLine("________________________________");
            Console.WriteLine("");
            //yup, hier ebenfalls Dok auslesen (Braucht Stats n eigenes Dok oder alles zsm?)
        }
    }
}