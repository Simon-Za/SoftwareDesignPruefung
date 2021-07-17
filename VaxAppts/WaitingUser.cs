using System;
using System.Collections.Generic;
using System.Text;

namespace VaxAppts
{
    public class WaitingUser
    {
        public string email;
        public string fname;
        public string lname;
        public string dOB;
        public string phoneNo;
        public string address;
        public WaitingUser(string mail, string frstname, string lstname, string dateOB, string phone, string addr)
        {
            this.email = mail;
            this.fname = frstname;
            this.lname = lstname;
            this.dOB = dateOB;
            this.phoneNo = phone;
            this.address = addr;
        }
        public WaitingUser()
        {

        }
    }
}