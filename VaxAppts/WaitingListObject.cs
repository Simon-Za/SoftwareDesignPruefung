using System;
using System.Collections.Generic;

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