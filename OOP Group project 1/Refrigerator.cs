using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_And_Inheritance
{
    public class Refrigerator : Appliance
    {
        public string numberOfDoors { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string NumberOfDoors
        {
            get
            {
                return numberOfDoors;
            }

            set
            {
                switch (value.ToLower())
                {
                    case "2":
                        numberOfDoors = "double doors";
                        break;
                    case "3":
                        numberOfDoors = "three doors";
                        break;
                    case "4":
                        numberOfDoors = "four doors";
                        break;
                    default:
                        throw new ArgumentException(
                        $"{value} is not a valid number of doors. Please only select 2 (double doors), or 3 (three doors), 4 (four doors)" + "Choose from: 2 (double doors), 3 (three dours), or 4 (four doors): ");
                }

            }
        }

        public static Refrigerator Parse(string s)
        {
            string[] args = s.Split(';');

            Refrigerator refrigerator = new Refrigerator();
            refrigerator.ItemNumber = long.Parse(args[0]);
            refrigerator.Brand = args[1];
            refrigerator.Quantity = int.Parse(args[2]);
            refrigerator.Wattage = double.Parse(args[3]);
            refrigerator.Color = args[4];
            refrigerator.Price = double.Parse(args[5]);
            refrigerator.NumberOfDoors = args[6];
            refrigerator.Height = int.Parse(args[7]);
            refrigerator.Width = int.Parse(args[8]);

            return refrigerator;
        }

        public override string ToString()
        {
            string s = base.ToString()
                 + $"NumberOfDoors: {NumberOfDoors}\n"
                 + $"Height: {Height}\n" 
                 +$"Width: {Width}\n";
            return s;

        }
        public override bool Matches(string option)
        {
            return option.ToLower().Equals(NumberOfDoors.ToLower());
        }
    }
}
