using System;
using System.Collections.Generic;
using System.Text;

namespace VaxAppts
{
    public class WaitingListObject
    {
        public string path = @"WaitingListXml.xml";
        public List<WaitingUser> Waiters;
        public WaitingListObject()
        {
            Waiters = new List<WaitingUser>();
        }
    }
}