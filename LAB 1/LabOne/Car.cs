using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabOne
{
    // variant 1
    public  class Car
    {
        private bool VANID {  get; set; }
        public string Model { get; set; }

        public string PlateNumber { get; set; }

        public void Method()
        {
            Console.WriteLine("calling method");
        }

    }
}
