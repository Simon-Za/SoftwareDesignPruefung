using System;
using System.Collections.Generic;

namespace VaxAppts
{
    public class Registrations 
    {
        public string path = @"RegistrationsXml.xml";
        public List<UserRegistered> Users;

        public Registrations()
        {
            Users = new List<UserRegistered>();
        }
    }
}