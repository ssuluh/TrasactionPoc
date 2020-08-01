using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionPoc.Core.Model
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
