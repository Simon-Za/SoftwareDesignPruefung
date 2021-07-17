using System;
using System.Xml.Serialization;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


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

            if (waitingListSelect == 1)
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
            //hier maybe einfach Appointments.cs benutzen??

            Console.Write("E-Mail: ");
            string userMail = User.eMail();
            Console.Write("First Name: ");
            string userFirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string userLastName = Console.ReadLine();
            Console.Write("Date of Birth: ");
            string userBirthday = Console.ReadLine();
            Console.Write("Phone number: ");
            string userPhoneNumber = Console.ReadLine();
            Console.Write("Address: ");
            string userAddress = Console.ReadLine();

            var newWaiter = new WaitingListObject();
            var serW = new XmlSerializer(typeof(WaitingListObject));

            if (!File.Exists(newWaiter.path))
            {
                newWaiter.Waiters = new List<WaitingUser>
                    {
                    new WaitingUser(userMail, userFirstName, userLastName, userBirthday, userPhoneNumber, userAddress)
                    };

                using StringWriter TextWriter1 = new StringWriter();
                serW.Serialize(TextWriter1, newWaiter);
                File.WriteAllText(newWaiter.path, TextWriter1.ToString());
                TextWriter1.Dispose();
            }
            else
            {
                TextReader readerW = new StreamReader(newWaiter.path);
                object obj = serW.Deserialize(readerW);
                newWaiter = (WaitingListObject)obj;

                newWaiter.Waiters.Insert(newWaiter.Waiters.Count(), new WaitingUser(userMail, userFirstName, userLastName, userBirthday, userPhoneNumber, userAddress));

                readerW.Dispose();

                using StringWriter TextWriter = new StringWriter();
                serW.Serialize(TextWriter, newWaiter);
                File.WriteAllText(newWaiter.path, TextWriter.ToString());
                TextWriter.Dispose();
            }
            Console.WriteLine("You're now on the Waiting List!");
            Environment.Exit(0);


        }
        private static void backToHomescreen()
        {
            MainClass.startMenu();
        }
    }
}