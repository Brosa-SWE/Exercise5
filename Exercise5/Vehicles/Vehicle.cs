using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Vehicle : Interfaces.IVehicle

    {
        public Dictionary<string, string> SpecialPropertyLabelDictionary = new Dictionary<string, string>();

        public string SpecialPropertyLabel
        {
            get
            {
                return SpecialPropertyLabelDictionary[VehicleType];
            }
        }
        public string SpecialPropertyValue { get; set; }

        public string RegNo { get; set; }
        public string Color { get; set; }
        public string NoOfWheels { get; set; }

        public Vehicle(string regNo, string color, string noOfWheels)
        {
            RegNo = regNo;
            Color = color;
            NoOfWheels = noOfWheels;

            SpecialPropertyLabelDictionary.Add("Airplane", "Number of engines");
            SpecialPropertyLabelDictionary.Add("Boat", "Length in meters");
            SpecialPropertyLabelDictionary.Add("Bus", "Number of seats");
            SpecialPropertyLabelDictionary.Add("Car", "Fueltype");
            SpecialPropertyLabelDictionary.Add("Motorcycle", "Engine CC");
        }

        public override string ToString()
        {
            return $"{RegNo} - {Color} {VehicleType} with {NoOfWheels} wheels and {SpecialPropertyValue} {SpecialPropertyLabel}";
        }

        public string VehicleType
        {
            get
            {
                return this.GetType().ToString().RightBack(".");
            }
        }
    }
}
