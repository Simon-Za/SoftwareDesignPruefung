using System;
using System.Xml.Serialization;
using System.IO;
using System.Linq;

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

            bool appointmentsAvailable;

            appointmentsAvailable = checkIfApptsAv();

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

            User user = new User();

            if (appointmentsAvailable)
            {
                switch (startSelect)
                {
                    case 1:
                        user.viewAvailableDates();
                        break;
                    case 2:
                        user.searchDate();
                        break;
                    case 3:
                        user.adminLogin();
                        break;
                }
            }
            else
            {
                switch (startSelect)
                {
                    case 1:
                        WaitingList wait = new WaitingList();
                        wait.WaitingListStartScreen();
                        break;
                    case 2:
                        break;
                    case 3:
                        user.adminLogin();
                        break;
                }
            }

        }
        public static bool checkIfApptsAv()
        {
            bool isAvailable = false;

            var newAppt = new Appointments();
            var ser = new XmlSerializer(typeof(Appointments));

            if (File.Exists(newAppt.path))
            {
                TextReader reader = new StreamReader(newAppt.path);
                object obj = ser.Deserialize(reader);
                newAppt = (Appointments)obj;
                reader.Dispose();

                if (newAppt.Dates.Count() <= 0)
                {
                    isAvailable = false;
                }
                else
                {
                    int apptNo = 0;
                    for (int d = 0; d < newAppt.Dates.Count(); d++)
                    {
                        if (newAppt.Dates.ElementAt(d).numberOfAppts > 0)
                        {
                            apptNo += newAppt.Dates.ElementAt(d).numberOfAppts;
                        }
                    }
                    if (apptNo > 0)
                    {
                        isAvailable = true;

                    }
                }
            }
            else
            {
                isAvailable = false;
            }

            return isAvailable;
        }
    }
}
