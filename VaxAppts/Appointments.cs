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
            this.day = y;
        }
        public Date(DateTime y, int appts)
        {
            this.day = y;
            this.numberOfAppts = appts;
        }
         public Date(DateTime y, int appts, DateTime end)
        {
            this.day = y;
            this.numberOfAppts = appts;
            this.apptEnd = end;
        }
        public Date()
        {

        }
    }
}