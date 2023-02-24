using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace producer
{
    internal class User
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string Email { get; set; }
        public bool completed { get; set; }
    }
    public class Address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geo geo { get; set; }
    }

    public class Company
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
    }

    public class Geo
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }
    public class RootObject
    { }
        public class Root
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        //public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        //public Company company { get; set; }
    }
}
