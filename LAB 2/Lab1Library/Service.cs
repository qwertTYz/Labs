using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lab1Library
{
    public class Service
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Address")]
        public string Address { get; set; }

        [XmlElement(ElementName = "IsServiceWorking")]
        private bool IsServiceWorking { get; set; }

        public Service()
        {
            this.Name = "servis";
            this.Address = "adres";
            this.IsServiceWorking = true;
        }

        public Service(string name, string address, bool isServiceWorking)
        {
            this.Name = name;
            this.Address = address;
            this.IsServiceWorking = isServiceWorking;
        }

        public static Service Create(string name, string address, bool isServiceWorking)
        {
            return new Service(name, address, isServiceWorking);
        }

        public void PrintObject()
        {
            Console.WriteLine($"name: {this.Name}   address: {this.Address}   is_working: {this.IsServiceWorking}");
        }
    }
}
