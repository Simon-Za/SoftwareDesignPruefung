using System;

namespace VaxAppts
{
    public class Date
    {
        public DateTime day; //Datum mit Zeitangabe
        public DateTime apptEnd;
        public int numberOfAppts;
        public int numberOfTotalAppts;

        public Date(DateTime y, int appts, DateTime end)
        {
            this.day = y;
            this.numberOfAppts = appts;
            this.apptEnd = end;
            this.numberOfTotalAppts = appts;
        }
        public Date()
        {

        }
    }
}