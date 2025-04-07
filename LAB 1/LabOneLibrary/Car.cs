using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabOneLibrary
{
    class CarAttribute : Attribute { }
    class CreateAttribute : Attribute { }
    class PrintObjectAttribute : Attribute { }
    [CarAttribute]
    public class Car
    {
        private bool VANID {  get; }
        public string Model { get; set; }
        public string PlateNumber { get; set; }

        public enum VehicleType
        {
            sedan,
            hatchback
        }


        public VehicleType vehicleType { get; set; }

        [CreateAttribute]
        public static Car Create(bool vanid, string model, string plateNumber, VehicleType vehicle_Type)
        {
            return new Car { Model = model, PlateNumber = plateNumber, vehicleType = vehicle_Type };
        }
        [PrintObjectAttribute]
        public void PrintObject()
        {
            Console.WriteLine($"VANID: {this.VANID}  Model: {this.Model}  PlateNumber: {this.PlateNumber}  VehicleType: {this.vehicleType}");
        }
    }
}
