using System;
using System.Xml.Serialization;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace VaxAppts
{
    public class User
    {
        public static void adminLogin()
        {
            string _adminID = "VaxMaster69";
            string _adminPassword = "VacciGang";

            //bei Bedarf kann hier noch Regex und Datenabgleich (dokument auslesen etc) rein
            Console.WriteLine("__________________________");
            Console.WriteLine("\u2022 Please enter your Admin ID and Password or press Enter to return to the menu");
            Console.WriteLine("_________________________________________________________________________________");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Admin ID: ");
            string adminEntry = Console.ReadLine();
            if (adminEntry == "")
            {
                MainClass.startMenu();
            }
            Console.Write("Password: ");
            string passwordEntry = Console.ReadLine();

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
                if (newAppt.Dates[u].numberOfAppts <= 0)
                {
                    //do nothing (The date should not be shown)
                }
                else if (saveDate.Day != newAppt.Dates[u].day.Day || saveDate.Month != newAppt.Dates[u].day.Month)
                {
                    Console.WriteLine(newAppt.Dates[u].day.Day + "." + newAppt.Dates[u].day.Month + "." + newAppt.Dates[u].day.Year + ", " + newAppt.Dates[u].day.DayOfWeek);
                    saveDate = newAppt.Dates[u].day;
                }
            }
            reader.Dispose();


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
                        reader0.Dispose();
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
            Console.WriteLine("");
            Console.WriteLine("Please enter the date you're searching below");
            Console.WriteLine("Remember to use the correct format: DD/MM/YYYY");
            Console.WriteLine("____________________________________________");
            DateTime userDateTime;

            if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
            {
                var newAppt = new Appointments();
                var ser = new XmlSerializer(typeof(Appointments));

                TextReader reader1 = new StreamReader(newAppt.path);
                object obj = ser.Deserialize(reader1);
                newAppt = (Appointments)obj;

                bool foundDate = false;

                for (int n = 0; n < newAppt.Dates.Count(); n++)
                {
                    if (userDateTime.Day == newAppt.Dates.ElementAt(n).day.Day && userDateTime.Month == newAppt.Dates.ElementAt(n).day.Month && userDateTime.Year == newAppt.Dates.ElementAt(n).day.Year)
                    {
                        reader1.Dispose();
                        showTimes(userDateTime);
                        foundDate = true;
                        break;
                    }
                }
                if (!foundDate)
                {
                    dateNotFound(caseID);
                }
                reader1.Dispose();
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

            TextReader reader2 = new StreamReader(newAppt.path);
            object obj = ser.Deserialize(reader2);
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
            reader2.Dispose();

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

                TextReader reader3 = new StreamReader(newAppt1.path);
                object obj1 = ser.Deserialize(reader3);
                newAppt1 = (Appointments)obj1;

                bool foundDate = false;

                for (int n = 0; n < newAppt1.Dates.Count(); n++)
                {
                    if (specificDate.Day == newAppt1.Dates.ElementAt(n).day.Day && specificDate.Month == newAppt1.Dates.ElementAt(n).day.Month && specificDate.Year == newAppt1.Dates.ElementAt(n).day.Year)
                    {
                        if (userTime.Hour == newAppt1.Dates.ElementAt(n).day.Hour && userTime.Minute == newAppt1.Dates.ElementAt(n).day.Minute && userTime.Second == newAppt1.Dates.ElementAt(n).day.Second)
                        {
                            //hier schauen ob die Zeit appts frei hat
                            if (newAppt1.Dates.ElementAt(n).numberOfAppts <= 0)
                            {
                                caseID = 5;
                                timeNotFound(caseID, specificDate);

                            }

                            foundDate = true;
                            TimeSpan apptTime = new TimeSpan(userTime.Hour, userTime.Minute, userTime.Second);
                            DateTime apptDate = specificDate.Date.Add(apptTime);

                            reader3.Dispose();
                            register(apptDate);
                        }

                    }
                }
                if (!foundDate)
                {
                    timeNotFound(caseID, specificDate);
                }
                reader3.Dispose();
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


            string userSelect = Console.ReadLine();
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
            else if (caseID == 5)
            {
                Console.WriteLine("There are no appointments available at this time");
            }
            Console.WriteLine("Try to enter it again or leave");
            Console.WriteLine("_____________________________");
            Console.WriteLine("");
            Console.WriteLine("1. Try again");
            Console.WriteLine("2. Go back to menu");

            string userSelect = Console.ReadLine();
            if (userSelect == "1")
            {
                showTimes(specificDate);
            }
            else if (userSelect == "2")
            {
                MainClass.startMenu();
            }
        }
        public static void register(DateTime apptDate)
        {
            string email;
            string fname;
            string lname;
            string dOB;
            string phoneNo;
            string address;


            Console.WriteLine("Welcome to the registration!");
            Console.WriteLine("Please enter your credentials below:");
            Console.WriteLine("___________________________________");
            Console.WriteLine("");

            Console.Write("E-Mail: ");
            email = eMail();

            Console.Write("First Name: ");
            fname = Console.ReadLine();

            Console.Write("Last Name: ");
            lname = Console.ReadLine();

            Console.Write("Date of birth: ");
            dOB = Console.ReadLine();

            Console.Write("Phone number: ");
            phoneNo = Console.ReadLine();

            Console.Write("Address: ");
            address = Console.ReadLine();

            //hier entsprechenden Termin austragen und Daten in Dok eintragen
            var newAppt4 = new Appointments();
            var ser4 = new XmlSerializer(typeof(Appointments));

            TextReader reader4 = new StreamReader(newAppt4.path);
            object obj = ser4.Deserialize(reader4);
            newAppt4 = (Appointments)obj;

            for (int n = 0; n < newAppt4.Dates.Count(); n++)
            {
                if (newAppt4.Dates.ElementAt(n).day == apptDate)
                {
                    newAppt4.Dates.ElementAt(n).numberOfAppts -= 1;
                }
            }
            reader4.Dispose();

            using StringWriter TextWriter = new StringWriter();
            ser4.Serialize(TextWriter, newAppt4);
            File.WriteAllText(newAppt4.path, TextWriter.ToString());
            TextWriter.Dispose();



            var registrFile = new Registrations();
            var ser = new XmlSerializer(typeof(Registrations));

            if (!File.Exists(registrFile.path))
            {
                registrFile.Users = new List<UserRegistered>
                    {
                    new UserRegistered(apptDate, email, fname, lname, dOB, phoneNo, address)
                    };

                using StringWriter TextWriter1 = new StringWriter();
                ser.Serialize(TextWriter1, registrFile);
                File.WriteAllText(registrFile.path, TextWriter1.ToString());
                TextWriter1.Dispose();
            }
            else
            {
                //hier file auslesen und User einordnen
                TextReader reader5 = new StreamReader(registrFile.path);
                object obj1 = ser.Deserialize(reader5);
                registrFile = (Registrations)obj1;

                registrFile.Users.Insert(registrFile.Users.Count(), new UserRegistered(apptDate, email, fname, lname, dOB, phoneNo, address));

                reader5.Dispose();


                using StringWriter TextWriter2 = new StringWriter();
                ser.Serialize(TextWriter2, registrFile);
                File.WriteAllText(registrFile.path, TextWriter2.ToString());
                TextWriter2.Dispose();

            }

            Console.WriteLine("Registration complete!");
            Environment.Exit(0);
        }

        public static string eMail()
        {
            string email = Console.ReadLine();



            if (!validateEmail(email))
            {
                Console.WriteLine("The email is invalid");
                Console.WriteLine("Please try again");
                Console.WriteLine("_________________");
                eMail();
            }
            else
            {
                //Console.WriteLine("The email is valid");
            }

            var registrationFile = new Registrations();
            var ser0 = new XmlSerializer(typeof(Registrations));

            if (File.Exists(registrationFile.path))
            {
                TextReader reader6 = new StreamReader(registrationFile.path);
                object obj = ser0.Deserialize(reader6);
                registrationFile = (Registrations)obj;

                for (int k = 0; k < registrationFile.Users.Count(); k++)
                {
                    if (registrationFile.Users.ElementAt(k).email == email)
                    {
                        Console.WriteLine("This E-Mail is already registered");
                        Console.WriteLine("Please try another one");
                        Console.WriteLine("_____________________");
                        eMail();
                    }
                }
                reader6.Dispose();
            }
            return email;
        }
        public static bool validateEmail(string email)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline); //Source: https://www.tutorialspoint.com/how-to-validate-an-email-address-in-chash
            bool isValidEmail = regex.IsMatch(email);

            return isValidEmail;
        }
    }
}