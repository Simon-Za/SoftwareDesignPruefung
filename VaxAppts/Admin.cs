using System;
using System.Xml.Serialization;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            //DateTime dt = new DateTime();       //Source: https://www.tutorialsteacher.com/csharp/csharp-datetime
            DateTime userDate;
            DateTime date = new DateTime(2021, 07, 11);
            DateTime dateEnd = new DateTime();

            Console.WriteLine("\u2022 Please tell me for which day you want to create a new appointment");
            Console.WriteLine("Remember to enter your date like this: YYYY, MM, DD");
            Console.WriteLine("___________________________________________________________________");
            Console.WriteLine("");
            //hier maybe einfach ne Eingabe, die mit schon erstellten Tagen abgleicht (wenn Tag schon vergeben: Meldung ggf. Option Tag zu löschen?? vllt lieber bei 2)

            //hier Datei erst lesen und schauen, ob Tag schon da, wenn ja: Message "gibt Tag schon, neue Uhrzeit dafür?"
            if (DateTime.TryParse(Console.ReadLine(), out userDate))        //Source: https://stackoverflow.com/questions/42075554/inputing-a-date-from-console-in-c-sharp
            {
                date = userDate;    //check here if date has already been created

                var apptsFile = new Appointments();
                var ser0 = new XmlSerializer(typeof(Appointments));

                TextReader reader0 = new StreamReader(apptsFile.path);
                object obj0 = ser0.Deserialize(reader0);
                apptsFile = (Appointments)obj0;
                reader0.Dispose();

                for (int h = 0; h < apptsFile.Dates.Count(); h++)
                {
                    if (date == apptsFile.Dates.ElementAt(h).day)
                    {
                        Console.WriteLine("There are already appointments for this day. Would you like to add some?");
                        Console.WriteLine("_____________________________________________________________________");
                        Console.WriteLine("");
                        Console.WriteLine("1. Add new appointments");
                        Console.WriteLine("2. Enter new day");
                        String adminSelect0 = Console.ReadLine();

                        if (adminSelect0 == "1")
                        {
                            break;
                        }
                        else if (adminSelect0 == "2")
                        {
                            createNewAppt();
                        }
                    }
                }

                Console.WriteLine(date.DayOfWeek + ", " + date.Day + "." + date.Month + "." + date.Year);

                Console.WriteLine("Now enter the desired time period");
                Console.WriteLine("_________________________________");
                Console.WriteLine("");

                DateTime dateSave = date;
                dateSave = enterTimeSpan(date);
                dateEnd = enterTimeSpan(date);
                date = dateSave;
                int appts = enterNoOfAppts();

                //calculateAppts();     //I should probably implement that and maybe just put the serializer in an extra method? idk
                TimeSpan ts = dateEnd.Subtract(date);
                Console.WriteLine(date);
                Console.WriteLine(dateEnd);
                Console.WriteLine(ts);

                int frequency = enterFrequencyOfAppts();

                writeAppts(date, dateEnd, appts, frequency, ts);








                Console.WriteLine("");
                Console.WriteLine("Would you like to create another appointment or go back to the menu?");
                Console.WriteLine("___________________________________________________________________");
                Console.WriteLine("");
                Console.WriteLine("1. Create another appointment");
                Console.WriteLine("2. Go back to menu");
                String adminSelect = Console.ReadLine();

                if (adminSelect == "1")
                {
                    createNewAppt();
                }
                else if (adminSelect == "2")
                {
                    adminScreen();
                }


            }
            else
            {
                Console.WriteLine("Not a valid date");
                createNewAppt();
            }

        }
        private static void dayOverview()
        {
            Console.WriteLine("\u2022 Please select the day you want to see");
            Console.WriteLine("_______________________________________");
            Console.WriteLine("");
            //hier Dok auslesen und Datumsobjekte darstellen
        }
        private static void viewStats()
        {
            Console.WriteLine("\u2022 Welcome to general statistics!");
            Console.WriteLine("________________________________");
            Console.WriteLine("");
            //yup, hier ebenfalls Dok auslesen (Braucht Stats n eigenes Dok oder alles zsm?)
        }

        public static DateTime enterTimeSpan(DateTime date)
        {
            TimeSpan userTime = new TimeSpan(0, 0, 0);

            if (TimeSpan.TryParse(Console.ReadLine(), out userTime))
            {
                date = date.Add(userTime);
            }
            else
            {
                Console.WriteLine("Not a valid time");
                enterTimeSpan(date);
            }
            return date;
        }
        public static int enterNoOfAppts()
        {
            int numberOfAppts;
            Console.WriteLine("How many appointments do you want for this time?");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("");
            numberOfAppts = Convert.ToInt32(Console.ReadLine());
            return numberOfAppts;
        }
        public static int enterFrequencyOfAppts()
        {
            int frequencyOfAppts;
            Console.WriteLine("Now enter how many minutes one appointment should take");
            Console.WriteLine("________________________________________________");
            Console.WriteLine("");
            frequencyOfAppts = Convert.ToInt32(Console.ReadLine());
            return frequencyOfAppts;
        }


        public static void writeAppts(DateTime date, DateTime dateEnd, int appts, int frequency, TimeSpan ts)
        {
            int tsMins = ts.Minutes + ts.Hours * 60;
            int apptCount = tsMins/frequency;
            Console.WriteLine("TimeSpan / Frequenz: " + apptCount);


            var newAppt = new Appointments();
            var ser = new XmlSerializer(typeof(Appointments));

            if (!File.Exists(newAppt.path))
            {
                newAppt.Dates = new List<Date>
                    {
                    new Date(date)
                    };

                using StringWriter TextWriter = new StringWriter();
                ser.Serialize(TextWriter, newAppt);
                File.WriteAllText(newAppt.path, TextWriter.ToString());
                TextWriter.Dispose();
            }

            TextReader reader = new StreamReader(newAppt.path);
            object obj = ser.Deserialize(reader);
            newAppt = (Appointments)obj;


            DateTime max = new DateTime();
            for (int j = 0; j < newAppt.Dates.Count(); j++)
            {
                if (newAppt.Dates.ElementAt(j).day > max)
                {
                    max = newAppt.Dates.ElementAt(j).day;
                }
            }


            for (int k = 0; k < newAppt.Dates.Count(); k++)
            {
                if (date <= newAppt.Dates.ElementAt(k).day)
                {
                    newAppt.Dates.Insert(k, new Date(date, appts));
                    break;
                }
                else if (date >= max)
                {
                    newAppt.Dates.Insert(newAppt.Dates.Count(), new Date(date, appts));

                    break;
                }
            }
            reader.Dispose();

            Console.WriteLine("___________");
            for (int l = 0; l < newAppt.Dates.Count(); l++)
            {
                Console.WriteLine(newAppt.Dates[l].day + "(" + newAppt.Dates[l].numberOfAppts + ")");
            }


            using StringWriter TextWriter2 = new StringWriter();
            ser.Serialize(TextWriter2, newAppt);
            File.WriteAllText(newAppt.path, TextWriter2.ToString());
            TextWriter2.Dispose();
        }
    }
}