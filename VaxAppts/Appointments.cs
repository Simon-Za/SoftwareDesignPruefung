using System;
using System.Collections.Generic;

namespace VaxAppts
{
    public class Appointments
    {
        public string path = @"AppointmentsXml.xml";
        public List<Date> Dates;
        public Appointments()
        {
            Dates = new List<Date>();
        }
    }
}