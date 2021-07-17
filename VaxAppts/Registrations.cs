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
}