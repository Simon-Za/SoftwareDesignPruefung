using System;
using System.Collections.Generic;
using System.Text;

namespace VaxAppts
{
    public class Appointments
    {
        public String path = @"D:\SoftwareDesignPruefung\SoftwareDesignPruefung\VaxAppts\AppointmentsXml.xml";
        public List<Date> Dates;
        public Appointments()
        {
            Dates = new List<Date>();
        }
    }
    public class Date
    {
        public DateTime day; //Datum mit Zeitangabe
        public DateTime apptEnd;
        public int numberOfAppts;
        //public List<TimeofDay> Times;

        public Date(DateTime y)
        {
            day = y;
        }
        public Date(DateTime y, int appts)
        {
            day = y;
            numberOfAppts = appts;
        }
        public Date()
        {

        }
    }
    /* public class TimeofDay
    {
        public String time;
        public DateTime apptEnd;
        public int numberOfAppts;
        public TimeofDay(String z, int n)
        {
            time = z;
            numberOfAppts = n;
        }
        public TimeofDay()
        {

        }
    } */
}