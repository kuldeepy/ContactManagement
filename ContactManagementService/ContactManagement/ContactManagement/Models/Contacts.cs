using ContactManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagement.Models
{
    public class Contacts
    {
        //public Address Address { get; set; }

        //public Name Name { get; set; }
        public int AddressId { get; set; }

        public string Street { get; set; }

        public string Direction { get; set; }

        public string StreetName { get; set; }

        public string StreetType { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zip { get; set; }

        public int SubjectId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mi { get; set; }

        public string Suffix { get; set; }

    }
}