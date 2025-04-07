using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LabOneLibrary.Car;

namespace LabOneLibrary
{
    public class Service
    {
        public string Name { get; set; }
        public string Address { get; set; }

        private bool IsServiceWorking { get;  }

        public static Service Create(string name, string address, bool isServiceWorking)
        {
            return new Service { Name = name, Address = address};
        }

        public void PrintObject()
        {
            Console.WriteLine($"Name: {this.Name}  Address: {this.Address}  IsServiceWorking: {this.IsServiceWorking}");
        }
    }
}
