using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;

namespace Lab1Library
{

    [XmlRoot(ElementName = "car")]
    public class Car
    {

        [XmlElement(ElementName = "VANID")]
        private bool VANID { get; set; }

        [XmlElement(ElementName = "Model")]
        public string Model { get; set; }

        [XmlElement(ElementName = "PlateNumber")]

        public string PlateNumber { get; set; }


        public enum VehicleType
        {
            Sedan,
            Hatchback
        }

        [XmlElement(ElementName = "VehicleType")]
        public VehicleType VehicleTypeProperty { get; set; }

        public Car()
        {
            this.VANID = true;
            this.Model = "BMW";
            this.PlateNumber = "1111";
            this.VehicleTypeProperty = VehicleType.Hatchback;
        }
        
        public Car(bool vanid, string model, string plateNumber, VehicleType vehicleTypeProperty)
        {
            this.VANID = vanid;
            this.Model = model;
            this.PlateNumber = plateNumber; 
            this.VehicleTypeProperty = vehicleTypeProperty;
        }

        public static Car Create(bool vanid, string model, string plateNumber, VehicleType vehicleTypeProperty)
        {
            return new Car(vanid, model, plateNumber, vehicleTypeProperty);
        }

        public void PrintObject()
        {
            Console.WriteLine($"vanid: {this.VANID}   model: {this.Model}   plate number: {this.PlateNumber}   vehicle type: {this.VehicleTypeProperty}");
        }
    }
}
