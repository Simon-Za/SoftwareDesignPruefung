using System;
using System.Xml.Serialization;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            int caseID = 0;
            var newAppt = new Appointments();
            var ser = new XmlSerializer(typeof(Appointments));

            TextReader reader = new StreamReader(newAppt.path);
            object obj = ser.Deserialize(reader);
            newAppt = (Appointments)obj;

            Console.WriteLine("Following dates are available:");
            Console.WriteLine("____________________________");
            Console.WriteLine("");

            DateTime saveDate = new DateTime();
            for (int u = 0; u < newAppt.Dates.Count(); u++)
            {
                //muss irgendnen Limiter, dass die Tage nicht doppelt kommen und Appts zusammengerechnet werden (Appts müssen nicht zwingend in der Datumsanzeige dargestellt werden)
                if (saveDate.Day != newAppt.Dates[u].day.Day || saveDate.Month != newAppt.Dates[u].day.Month)
                {
                    Console.WriteLine(newAppt.Dates[u].day.Day + "." + newAppt.Dates[u].day.Month + "." + newAppt.Dates[u].day.Year + ", " + newAppt.Dates[u].day.DayOfWeek);
                }

                saveDate = newAppt.Dates[u].day;

            }
            reader.Dispose();


            //hier iwie ne Auswahl? Einfach Datum eingeben?? Oder nummerieren? Gibt zu viele doe
            Console.WriteLine("");
            Console.WriteLine("Please enter the date you want to see available times to");
            Console.WriteLine("in the following format: DD/MM/YYYY");
            Console.WriteLine("_________________________________________________");

            DateTime userDateTime;

            if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
            {
                var newAppt0 = new Appointments();
                var ser0 = new XmlSerializer(typeof(Appointments));

                TextReader reader0 = new StreamReader(newAppt0.path);
                object obj0 = ser0.Deserialize(reader0);
                newAppt0 = (Appointments)obj0;


                bool foundDate = false;
                for (int n = 0; n < newAppt0.Dates.Count(); n++)
                {
                    if (userDateTime.Day == newAppt0.Dates.ElementAt(n).day.Day && userDateTime.Month == newAppt0.Dates.ElementAt(n).day.Month && userDateTime.Year == newAppt0.Dates.ElementAt(n).day.Year)
                    {
                        showTimes(userDateTime);
                        foundDate = true;
                        break;
                    }
                }
                if (!foundDate)
                {
                    dateNotFound(caseID);
                }
                reader0.Dispose();

            }
            else
            {
                caseID = 2;
                dateNotFound(caseID);
            }
        }

        public static void searchDate()
        {
            int caseID = 1;
            //case, falls Tag nicht existiert und else
            Console.WriteLine("");
            Console.WriteLine("Please enter the date you're searching below");
            Console.WriteLine("Remember to use the correct format: DD/MM/YYYY");
            Console.WriteLine("____________________________________________");
            DateTime userDateTime;

            if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
            {
                var newAppt = new Appointments();
                var ser = new XmlSerializer(typeof(Appointments));

                TextReader reader = new StreamReader(newAppt.path);
                object obj = ser.Deserialize(reader);
                newAppt = (Appointments)obj;

                bool foundDate = false;

                for (int n = 0; n < newAppt.Dates.Count(); n++)
                {
                    if (userDateTime.Day == newAppt.Dates.ElementAt(n).day.Day && userDateTime.Month == newAppt.Dates.ElementAt(n).day.Month && userDateTime.Year == newAppt.Dates.ElementAt(n).day.Year)
                    {
                        showTimes(userDateTime);
                        foundDate = true;
                        break;
                    }
                }
                if (!foundDate)
                {
                    dateNotFound(caseID);
                }
                reader.Dispose();
            }
            else
            {
                caseID = 2;
                dateNotFound(caseID);
            }
        }
        public static void showTimes(DateTime specificDate)
        {
            Console.WriteLine("_________");
            var newAppt = new Appointments();
            var ser = new XmlSerializer(typeof(Appointments));

            TextReader reader = new StreamReader(newAppt.path);
            object obj = ser.Deserialize(reader);
            newAppt = (Appointments)obj;

            for (int n = 0; n < newAppt.Dates.Count(); n++)
            {
                if (specificDate.Day == newAppt.Dates.ElementAt(n).day.Day && specificDate.Month == newAppt.Dates.ElementAt(n).day.Month && specificDate.Year == newAppt.Dates.ElementAt(n).day.Year)
                {
                    Console.WriteLine(newAppt.Dates[n].day.Hour + ":" + newAppt.Dates[n].day.Minute + "(" + newAppt.Dates[n].numberOfAppts + ")");

                }

                /*  for (int f = 0; f < specificDate; f++)
                 {
                     Console.WriteLine(newAppt.Dates[f].day + "(" + newAppt.Dates[f].numberOfAppts + ")");
                 } */
            }
            reader.Dispose();

            Console.WriteLine("");
            Console.WriteLine("Please pick a time you are comfortable with :)");
            Console.WriteLine("____________________________________________");

            DateTime userTime;
            if (DateTime.TryParse(Console.ReadLine(), out userTime))
            {
                //LESEN, OB ES DIESE ZEIT ÜBERHAUPT GIBT AN DEM DATUM
                int caseID = 3;

                var newAppt1 = new Appointments();
                var ser1 = new XmlSerializer(typeof(Appointments));

                TextReader reader1 = new StreamReader(newAppt1.path);
                object obj1 = ser.Deserialize(reader1);
                newAppt1 = (Appointments)obj1;

                bool foundDate = false;

                for (int n = 0; n < newAppt1.Dates.Count(); n++)
                {
                    if (specificDate.Day == newAppt1.Dates.ElementAt(n).day.Day && specificDate.Month == newAppt1.Dates.ElementAt(n).day.Month && specificDate.Year == newAppt1.Dates.ElementAt(n).day.Year)
                    {
                        if (userTime.Hour == newAppt1.Dates.ElementAt(n).day.Hour && userTime.Minute == newAppt1.Dates.ElementAt(n).day.Minute && userTime.Second == newAppt1.Dates.ElementAt(n).day.Second)
                        {
                            foundDate = true;
                            //registration(specificDate, userTime);
                            Console.WriteLine("HIER KÖNNTE IHRE REGISTRIERUNG STEHEN");
                            register(); 
                            //break;
                        }

                    }
                }
                if (!foundDate)
                {
                    timeNotFound(caseID, specificDate);
                }
                reader.Dispose();
            }
            else
            {
                int caseID = 4;
                timeNotFound(caseID, specificDate);
            }
        }
        public static void dateNotFound(int caseID)
        {
            if (caseID == 0 || caseID == 1)
            {
                Console.WriteLine("Unfortunately, this date does not exist :/");
            }
            else if (caseID == 2)
            {
                Console.WriteLine("That is not a valid date");
            }

            Console.WriteLine("________________________");
            Console.WriteLine("Do you want to try again?");
            Console.WriteLine("________________________");
            Console.WriteLine("");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. Go back to menu");


            String userSelect = Console.ReadLine();
            if (userSelect == "1")
            {
                if (caseID == 0)
                {
                    viewAvailableDates();
                }
                else if (caseID == 1 || caseID == 2)
                {
                    searchDate();
                }
            }
            else if (userSelect == "2")
            {
                MainClass.startMenu();
            }
        }
        public static void timeNotFound(int caseID, DateTime specificDate)
        {
            if (caseID == 3)
            {
                Console.WriteLine("This time does not exist");
            }
            else if (caseID == 4)
            {
                Console.WriteLine("That is not a valid time");
            }
            Console.WriteLine("Try to enter it again or leave");
            Console.WriteLine("_____________________________");
            Console.WriteLine("");
            Console.WriteLine("1. Try again");
            Console.WriteLine("2. Go back to menu");

            String userSelect = Console.ReadLine();
            if (userSelect == "1")
            {
                showTimes(specificDate);
            }
            else if (userSelect == "2")
            {
                MainClass.startMenu();
            }
        }
        public static void register()
        {

        }
    }
}