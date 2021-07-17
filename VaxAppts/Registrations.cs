using System;
using System.Collections.Generic;
using System.Text;

namespace VaxAppts
{
    public class Registrations : WaitingListObject //das hier soltle prolly einfach Warteliste extenden
    {
        public string pathReg = @"RegistrationsXml.xml";
        public List<UserRegistered> Users;

        public Registrations()
        {
            Users = new List<UserRegistered>();
        }
    }
    public class UserRegistered
    {
        public DateTime appt;

        public string email;
        public string fname;
        public string lname;
        public string dOB;
        public string phoneNo;
        public string address;

        public UserRegistered(DateTime appt, string mail, string frstname, string lstname, string dateOB, string phone, string addr)
        {
            this.appt = appt;
            this.email = mail;
            this.fname = frstname;
            this.lname = lstname;
            this.dOB = dateOB;
            this.phoneNo = phone;
            this.address = addr;
        }
        public UserRegistered()
        {

        }
    }
}